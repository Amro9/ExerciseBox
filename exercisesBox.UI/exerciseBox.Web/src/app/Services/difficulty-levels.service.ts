import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DifficultyLevelsService {
  private http: HttpClient;
  
  constructor(@Inject(HttpClient) http: HttpClient) {
    this.http = http;
} 
getDifficultyLevels(): Observable<DifficultyLevel[]> {
  let url_ = 'http://localhost:7292/api/QuestionParamaters/GetDifficultyLevels';

  return this.http.get<DifficultyLevel[]>(url_);
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
