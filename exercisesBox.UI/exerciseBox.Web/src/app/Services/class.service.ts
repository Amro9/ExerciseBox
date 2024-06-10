import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClassService {

  private http: HttpClient;
  
  constructor(@Inject(HttpClient) http: HttpClient) {
    this.http = http;
} 

  getClassesByTeacherId(teacherId: string):Observable<string[]> { 
    let url_ = 'http://localhost:7292/api/QuestionParamaters/GetClassByTeacherId?teacherId=1@2.com';
    return this.http.get<string[]>(url_);
  }
}
