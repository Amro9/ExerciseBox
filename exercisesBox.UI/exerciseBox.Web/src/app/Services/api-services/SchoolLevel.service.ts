import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Inject, Injectable, Optional } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { API_BASE_URL } from '../../Infrastucture/configurations';
import { NotificationService } from '../general-services/notification.service';

@Injectable({
  providedIn: 'root'
})
export class SchoolLevelService {

  private http: HttpClient;
  baseUrl: string;

  constructor(@Inject(HttpClient) http: HttpClient,
  @Optional() @Inject(API_BASE_URL) baseUrl: string,
  private notificationService: NotificationService) {
    this.http = http;
    this.baseUrl = baseUrl;
} 

  getSchoolLevelByTeacherId(teacherId: string):Observable<string[]> { 
    let url_ = this.baseUrl+'QuestionParamaters/GetSchoolLevelsByTeacherId?teacherId=1@2.com';
    return this.http.get<string[]>(url_).pipe(
      catchError((error: HttpErrorResponse) => {
        this.notificationService.showPersistentError('Fehler beim Laden der Daten');
        return throwError(error);
      })
    );
  }
  getSchoolLevelsBySchoolTypeId(schoolTypeId: string):Observable<string[]> {
    let url_ = this.baseUrl+'QuestionParamaters/GetSchoolLevelsBySchoolTypeId?schoolTypeId='+ schoolTypeId.toString();
    return this.http.get<string[]>(url_, {withCredentials: true}).pipe(
      catchError((error: HttpErrorResponse) => {
        this.notificationService.showPersistentError('Fehler beim Laden der Daten');
        return throwError(error);
      })
    );
  }
}
