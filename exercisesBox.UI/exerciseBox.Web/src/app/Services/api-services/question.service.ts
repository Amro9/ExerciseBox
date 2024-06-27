import { Inject, Injectable, Optional } from "@angular/core";
import { HttpClient, HttpParams } from '@angular/common/http';
import { catchError, map, Observable, tap, throwError } from "rxjs";
import { API_BASE_URL } from "../../Infrastucture/configurations";
import { Question } from "../../Entities/Question";
import { NotificationService } from "../general-services/notification.service";

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  private http: HttpClient;

  constructor(
    @Inject(HttpClient) http: HttpClient
    , @Inject(API_BASE_URL) private baseUrl: string,
    private notificationService: NotificationService
  ) {
    this.http = http;
  }
hideQuestionByTeacher(questionId: string, teacherId : string): Observable<any> {
    let url_ =this.baseUrl + "question/hideQuestionByTeacher";
    const body = { questionId, teacherId };

    return this.http.put(url_, body, { withCredentials: true }).pipe(
      tap((response: any) => {
        this.notificationService.showSuccess(response.message)
      }),
      catchError(error => {
        console.error('Error hiding question:', error);
        return throwError(error);
      })
    );
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
saveQuestionToFolder(questionId: string, folderId: string): Observable<any> {
    let url_ = this.baseUrl + "question/saveQuestionToFolder";
    const body = {
      questionId: questionId,
      folderId: folderId,
      withValidation: true,
    };
    return this.http.post(url_,body,{withCredentials: true}).pipe(
      tap(data => console.log('Question added to folder:', data)),
      catchError(error => {
        console.error('Error adding question to folder:', error);
        return throwError(error);
      }));
  }

  getQuestionsByFolder(folderId: string): Observable<Question[]> {
    let url_ = this.baseUrl + "question/folderQuestions/" + folderId;

    return this.http.get(url_,{withCredentials: true}).pipe(
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
