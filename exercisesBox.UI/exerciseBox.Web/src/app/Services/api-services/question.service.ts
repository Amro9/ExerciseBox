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
    , @Inject(API_BASE_URL) private baseUrl: string
  ) {
    this.http = http;
  }

  getQuestions(obj: any): Observable<Question[]> {
    let url_ = this.baseUrl + "question/searchquestions";
    let params = new HttpParams();
    console.log('obj:', obj)
    for (let key in obj) {
      if (obj.hasOwnProperty(key) && obj[key] !== null && obj[key] !== undefined && obj[key] !== '' && obj[key] !== 0) {
        params = params.append(key, obj[key]);
      }
    }
    console.log('params:', params)
    return this.http.get<Question[]>(url_, { params: params, withCredentials : true }).pipe(
      tap(data => console.log('Received questions:', data)),
      catchError(error => {
        console.error('Error fetching questions:', error);
        return throwError(error);
      }));
  }
saveQuestionInFolder(questionId: string, folderId: string): Observable<any> {
    let url_ = this.baseUrl + "question/addQuestionToFolder";
    return this.http.post(url_, { questionId, folderId }).pipe(
      tap(data => console.log('Question added to folder:', data)),
      catchError(error => {
        console.error('Error adding question to folder:', error);
        return throwError(error);
      }));
  }

  getQuestionsByFolder(folderId: string): Observable<Question[]> {
    let url_ = this.baseUrl + "question/folderQuestions/" + folderId;
    return this.http.get(url_).pipe(
      map((response: any) => {
        const data = response.value // replace 'data' with the actual key in the response object
        return data.map((question: any) => Question.fromJSON(question));
      }),
      catchError(error => {
        console.error('Error fetching questions:', error);
        return throwError(error);
      }));
  }
}
