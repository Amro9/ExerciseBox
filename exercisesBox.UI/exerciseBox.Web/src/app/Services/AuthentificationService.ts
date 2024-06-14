import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable, Optional } from "@angular/core";
import { API_BASE_URL } from "../Infrastucture/configurations";
import { SessionProvider } from "./SessionProvider";

@Injectable({
    providedIn : 'root'
})
export class AuthentificationService {

    private headers = new HttpHeaders({
        'Content-Type': 'application/json',
    });

    private baseUrl : string;

    constructor(private http: HttpClient,  @Inject(SessionProvider) private sessionProvider: SessionProvider, @Inject(API_BASE_URL) baseUrl?: string) 
    {
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    public async login(email: string, password: string): Promise<boolean> {

        let url_ = this.baseUrl + "Authentification/Login";

        try {
            const response: any = await this.http.post(url_, { email: email, password: password }, { headers: this.headers }).toPromise();
            const jsonData = response.value;
            this.sessionProvider.setSession(jsonData);
            return true;
        } catch (error) {
            return false;
        }
    }
}