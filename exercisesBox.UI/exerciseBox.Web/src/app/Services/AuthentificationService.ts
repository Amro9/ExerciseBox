import { HttpClient } from "@angular/common/http";
import { Inject, Injectable, Optional } from "@angular/core";
import { API_BASE_URL } from "../Infrastucture/configurations";

@Injectable({
    providedIn : 'root'
})
export class AuthentificationService {

    private headers = new HttpHeaders({
        'Content-Type': 'application/json',
    });

    private baseUrl : string;

    constructor(private http: HttpClient, @Inject(API_BASE_URL) baseUrl?: string) 
    {
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    public login(email : string, password : string) : string { 

        

    }
}