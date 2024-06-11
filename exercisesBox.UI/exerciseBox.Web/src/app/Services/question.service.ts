import { Inject, Injectable, Optional } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, tap, throwError } from "rxjs";
import { API_BASE_URL } from "../Infrastucture/configurations";
import { Question } from "../Entities/Question";

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  private http: HttpClient;
  private baseUrl: string;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
    this.http = http;
    this.baseUrl = API_BASE_URL.toString(); }

    getQuestions(): Observable<Question[]>{
        let url_ = this.baseUrl + "publicQuestions";
        return this.http.get<Question[]>(url_).pipe(
            tap(data => console.log('Received questions:', data)),
            catchError(error => {
                console.error('Error fetching questions:', error);
                return throwError(error);
            }));
    }

}
