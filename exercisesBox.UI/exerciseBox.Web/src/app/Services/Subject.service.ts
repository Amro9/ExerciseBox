import { Inject, Injectable, Optional } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, Observable, throwError } from "rxjs";
import { API_BASE_URL } from "../Infrastucture/configurations";
@Injectable({
  providedIn: 'root'
})
export class SubjectService {
  private http: HttpClient;
  private baseUrl: string;
  private headers = new HttpHeaders({
    'Content-Type': 'application/json',
  });

  constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
    this.http = http;
    this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
} 

getAllSubjects(){
  let url_ = this.baseUrl + "Subjects";
  return this.http.post(url_, {headers : this.headers}).pipe(
    map((response: any) => {
      const jsonData = response.value;
      return jsonData
    }),
    catchError(error => {
      return throwError(error.message);
    })
  );
}
}
