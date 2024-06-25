import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, Optional } from '@angular/core';
import { Observable } from 'rxjs';
import { API_BASE_URL } from '../../Infrastucture/configurations';

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
  let url_ =  this.baseUrl+ 'QuestionParamaters/GetDifficultyLevels';

  return this.http.get<DifficultyLevel[]>(url_ , { withCredentials: true});
}
}

export class DifficultyLevel {
id: string;
description: string;

constructor(id: string, description: string){
  this.id = id;
  this.description = description;
}
}
