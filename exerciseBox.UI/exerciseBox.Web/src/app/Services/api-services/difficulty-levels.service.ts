import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, Optional } from '@angular/core';
import { Observable } from 'rxjs';
import { API_BASE_URL } from '../../Infrastucture/configurations';
import { DifficultyLevel } from '../../Entities/DifficutlyLevel';

@Injectable({
  providedIn: 'root'
})
export class DifficultyLevelsService {
  private http: HttpClient;
  baseUrl: string;
  
  constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
} 
getDifficultyLevels(): Observable<DifficultyLevel[]> {
  let url_ =  this.baseUrl+ 'QuestionParameters/GetDifficultyLevels';

  return this.http.get<DifficultyLevel[]>(url_,{withCredentials: true});
}
getDifficultyLevelById(id :string): Observable<DifficultyLevel> {
  let url_ =  this.baseUrl+ 'QuestionParameters/GetDifficultyLevelById?id='+id;

  return this.http.get<DifficultyLevel>(url_,{withCredentials: true});
}


}
