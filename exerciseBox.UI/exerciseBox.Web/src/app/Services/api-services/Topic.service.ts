import { Inject, Injectable, Optional } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, Observable, tap, throwError } from "rxjs";
import { API_BASE_URL } from '../../Infrastucture/configurations';

@Injectable({
  providedIn: 'root'
})
export class TopicService {
  private http: HttpClient;
  baseUrl: string;
  
  constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;

} 
getTopicsBySubject(subjectId: string): Observable<any> {
  let url_ = this.baseUrl +"QuestionParameters/GetTopicBySubject/"+subjectId;

  return this.http.get<any>(url_, {withCredentials: true});
}
getTopicById(id: string): Observable<string> {
  let url_ = this.baseUrl + "QuestionParameters/getTopicNameById/"+id;

  return this.http.get<any>(url_, {withCredentials: true});
}
}
export class Topic {
id: string;
description: string;

constructor(id: string, description: string){
  this.id = id;
  this.description = description;
}
}