import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable, Optional } from "@angular/core";
import { API_BASE_URL } from "../Infrastucture/configurations";
import { SessionStorageProvider } from "./SessionProvider";
import { CookieService } from "ngx-cookie-service";


@Injectable({
    providedIn : 'root'
})
export class AuthentificationService {

    private headers = new HttpHeaders({
        'Content-Type': 'application/json',
    });

    private baseUrl : string;

    constructor(private http: HttpClient, private SessionStorageProvider : SessionStorageProvider, private cookieService: CookieService, @Inject(API_BASE_URL) baseUrl?: string) 
    {
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    public async login(email: string, password: string): Promise<boolean> {

        let url_ = this.baseUrl + "Authentification/Login";

        try {
            const response: any = await this.http.post(url_, { email: email, password: password }, { headers: this.headers, withCredentials: true }).toPromise();
            const jsonData = response.value;
            this.SessionStorageProvider.SetUserId(jsonData.id);
            return true;
        } catch (error) {
            return false;
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
    
      public isLoggedIn(): boolean {
        return this.cookieService.check('AuthCookie');
      }
    
      public logout(): void {
        this.cookieService.delete('AuthCookie', '/', '', true, 'Strict');
      }
}
