import { Inject, Injectable, Optional } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, tap, throwError } from "rxjs";
import { API_BASE_URL } from "../Infrastucture/configurations";

@Injectable({
  providedIn: 'root'
})
export class SchoolService {
  private http: HttpClient;
  private baseUrl: string;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
    this.http = http;
    this.baseUrl = API_BASE_URL.toString(); }

    getSchoolTypes(): Observable<string[]>{ 
        let url_ = this.baseUrl + "SchoolTypes";
        return this.http.get<string[]>(url_).pipe(
            tap(data => console.log('Received school types:', data)),
            catchError(error => {
                console.error('Error fetching school types:', error);
                return throwError(error);
            }));
    }

  }
