import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SchoolLevel {

  private http: HttpClient;
  
  constructor(@Inject(HttpClient) http: HttpClient) {
    this.http = http;
} 

  getSchoolLevelByTeacherId(teacherId: string):Observable<string[]> { 
    let url_ = 'http://localhost:7292/api/QuestionParamaters/GetSchoolLevelsByTeacherId?teacherId=1@2.com';
    return this.http.get<string[]>(url_);
  }
  
}
