import { Inject, Injectable, Optional } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, Observable, tap, throwError } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class TopicService {
  private http: HttpClient;
  
  constructor(@Inject(HttpClient) http: HttpClient) {
    this.http = http;
} 
getTopicsBySubject(subjectId: string): Observable<any> {
  let url_ = 'http://localhost:7292/api/QuestionParamaters/GetTopicBySubject/'+subjectId;

  return this.http.get<any>(url_);
}
// getAllSubjects(): Observable<Topic[]>{
//   // let url_ = this.baseUrl + "QuestionParamaters/Subjects";
//   let url_ = "http://localhost:7292/api/QuestionParamaters/Topics";
//   return this.http.get<Topic[]>(url_).pipe(
//     tap(data => console.log('Received Topics:', data)),
//     catchError(error => {
//       console.error('Error fetching Topics:', error);
//       return throwError(error);
//     }));
// }
}

export class Topic {
id: string;
description: string;

constructor(id: string, description: string){
  this.id = id;
  this.description = description;
}
}