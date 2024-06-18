import { Inject, Injectable, Optional } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, tap, throwError } from "rxjs";
import { API_BASE_URL } from "../Infrastucture/configurations";
import { Subject} from '../Entities/Subject';
@Injectable({
  providedIn: 'root'
})
export class SubjectService {
  private http: HttpClient;
  baseUrl: string;
  // private headers = new HttpHeaders({
  //   'Content-Type': 'application/json',
  // });

  constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
} 

getAllSubjects(): Observable<Subject[]>{
  let url_ = this.baseUrl + "QuestionParamaters/Subjects";
  console.log('getAllSubjects called');
  return this.http.get<Subject[]>(url_).pipe(
    tap(data => console.log('Received subjects:', data)),
    catchError(error => {
      console.error('Error fetching subjects:', error);
      return throwError(error);
    }));
}
}
