import { Inject, Injectable, Optional } from "@angular/core";
import { HttpClient, HttpParams } from '@angular/common/http';
import { catchError, map, Observable, tap, throwError } from "rxjs";
import { API_BASE_URL } from "../../Infrastucture/configurations";
import { Question } from "../../Entities/Question";

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  private http: HttpClient;

    constructor(
      @Inject(HttpClient) http: HttpClient
    ,@Inject(API_BASE_URL) private baseUrl: string
  ) {
    this.http = http; 
  }

    getQuestions(): Observable<Question[]>{
        let url_ = this.baseUrl + "question/publicQuestions";
        return this.http.get<Question[]>(url_).pipe(
            tap(data => console.log('Received questions:', data)),
            catchError(error => {
                console.error('Error fetching questions:', error);
                return throwError(error);
            }));
    }

    getQuestionsByFolder(folderId: string): Observable<Question[]>{
  
      let url_ = this.baseUrl + "question/folderQuestions/" + folderId;
        
      return this.http.get(url_).pipe(
        map((response : any) => {
          const data = response.value // replace 'data' with the actual key in the response object
          return data.map((question: any) => Question.fromJSON(question));
        }),
        catchError(error => {
            console.error('Error fetching questions:', error);
            return throwError(error);
        }));
    }
}