import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable, Optional } from "@angular/core";
import { API_BASE_URL } from "../Infrastucture/configurations";
import { catchError, map, Observable, throwError } from "rxjs";
import { Teacher } from "../Entities/Teacher";

@Injectable({
    providedIn: 'root'
})
export class TeacherAPIConnection {

    private http: HttpClient;
    private baseUrl: string;

    //remove after working:
    private headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    } 

    getTeacherbyEmail(email : string) : Observable<Teacher> {
        let url_ = this.baseUrl + "Teacher/ByEmail";
    
        const body = { email: email };
    
        return this.http.post(url_, body, {headers : this.headers}).pipe(
          map((response: any) => {
            const jsonData = response.value;
            return Teacher.fromData(jsonData);
          }),
          catchError(error => {
            return throwError(error.message);
          })
        );
    }

    // getTeacherWithPasswordValidation(email : string, password : string) : Observable<Teacher> {
    //     let url_ = this.baseUrl + "Teacher/ByEmailAndPassword";
    
    //     const body = { email: email, password: password };
    
    //     return this.http.post(url_, body, {headers : this.headers}).pipe(
    //       map((response: any) => {
    //         const jsonData = response.value;
    //         return Teacher.fromData(jsonData);
    //       }),
    //       catchError(error => {
    //         return throwError(error.error);
    //       })
    //     );
    // }

}