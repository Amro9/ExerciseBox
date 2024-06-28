import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable, Optional } from "@angular/core";
import { API_BASE_URL } from "../Infrastucture/configurations";
import { SessionStorageProvider } from "./SessionProvider";
import { CookieService } from "ngx-cookie-service";
import { throwError } from "rxjs";
import { Roles } from "../Infrastucture/enums";
import { Router } from "@angular/router";


@Injectable({
    providedIn : 'root'
})
export class AuthentificationService {

    private headers = new HttpHeaders({
        'Content-Type': 'application/json',
    });

    private baseUrl : string;

    private userRole: Roles | null = null; 

    constructor(private http: HttpClient,
         private SessionStorageProvider : SessionStorageProvider, 
         private cookieService: CookieService,
         private router: Router,
        @Inject(API_BASE_URL) baseUrl?: string) 
    {
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    public async login(email: string, password: string): Promise<boolean> {
        let url_ = this.baseUrl + "Authentification/Login";

        try {
            const response: any = await this.http.post(url_, { email, password }, { headers: this.headers, withCredentials: true }).toPromise();
            const jsonData = response;
            this.cookieService.set('userEmail', jsonData.id, 1, '/', '', true, 'Strict');
            this.cookieService.set('userRole', jsonData.role, 1, '/', '', true, 'Strict');
            this.userRole = jsonData.role as Roles; 
            this.startTokenRefresh();
            return true;
        } catch (error) {
            throw error;
      }
    }

    public async refreshToken(): Promise<boolean> {
        let url_ = this.baseUrl + "Authentification/RefreshToken";
    
        try {
          await this.http.post(url_, {}, { headers: this.headers, withCredentials: true }).toPromise();
          return true;
        } catch (error) {
          console.error('Token refresh error:', error);
          return false;
        }
    }

    public startTokenRefresh(interval: number = 300000) {
        setInterval(() => {
          this.refreshToken();
        }, interval); // Refresh every 5 minutes (300,000 ms)
    }

    public async startTokenCheck(interval: number = 300000) {
        const checkInterval = setInterval(() => {
            if (!this.isLoggedIn()) {
                this.cookieService.delete('AuthCookie', '/', '', true, 'Strict');
                this.cookieService.delete('userRole', '/', '', true, 'Strict');
                this.cookieService.delete('userEmail', '/', '', true, 'Strict');
                this.router.navigate(['/login']);
                alert('Sie wurden ausgeloggt, da Sie zu lange inaktiv waren. Bitte loggen Sie sich erneut ein.');
                clearInterval(checkInterval); // Stop the interval after logging out
            }
        }, interval); // Refresh every 5 minutes (300,000 ms)
    }
    
      public isLoggedIn(): boolean {
        return this.cookieService.check('AuthCookie');
      }

      public async getRole(): Promise<Roles> {
          let url_ = this.baseUrl + "Authentification/Role";
        
          try {
              const response: any = await this.http.get(url_, { headers: this.headers, withCredentials: true }).toPromise();
              const roleAsString: string = response.value;
              return Roles[roleAsString as keyof typeof Roles]; // Convert string to Role enum
          } catch (error) {
              throw error; 
          }
      }
      
      public hasRole(role: Roles): boolean {
        try {
            this.userRole = this.cookieService.get('userRole') as Roles;  

            if (this.userRole === role) {
                return true;
            } else {
                return false;
            }

        } catch (error) {
            throw error;
      }
      }

      public logout(): void {
        this.http.post(this.baseUrl + "Authentification/Logout", {}, { headers: this.headers, withCredentials: true }).toPromise();
        this.cookieService.delete('userRole', '/', '', true, 'Strict');
        this.cookieService.delete('userEmail', '/', '', true, 'Strict');
        this.userRole = null; 
      }
}
