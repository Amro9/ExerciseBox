import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, Optional } from '@angular/core';
import { NotificationService } from '../general-services/notification.service';
import { Observable, tap } from 'rxjs';
import { API_BASE_URL } from '../../Infrastucture/configurations';
import { DifficultyLevel } from '../../Entities/DifficutlyLevel';
import { DifficultyLevelsService } from './difficulty-levels.service';
@Injectable({
  providedIn: 'root'
})
export class QuestionFromService {
  baseUrl: string;
  constructor(
    private difficultyLevelsService: DifficultyLevelsService,
    private http: HttpClient,
    private notificationService: NotificationService,
    @Optional() @Inject(API_BASE_URL) baseUrl: string
  ) { 
    this.baseUrl = baseUrl;
  }

  submitQuestionForm(formData: FormData): Observable<any> {
    let url = this.baseUrl + 'question/addQuestion';
  
    console.log('submitQuestionForm', formData);
    return this.http.post(url,formData ,{withCredentials: true}).pipe(
      tap(
        response => {
          this.notificationService.showSuccess('Frage wurde erfolgreich hinzugefügt');
        },
        error => {
          console.error('Error submitting form data:', error);
          this.notificationService.showError('Fehler beim Hinzufügen der Frage, bitte versuchen Sie es erneut.');
        }
      )
    );
}}
