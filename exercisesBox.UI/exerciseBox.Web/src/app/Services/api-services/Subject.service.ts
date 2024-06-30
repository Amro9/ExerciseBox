import { Inject, Injectable, Optional } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, tap, throwError } from "rxjs";
import { API_BASE_URL } from "../../Infrastucture/configurations";
import { Subject} from '../../Entities/Subject';
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
  let url_ = this.baseUrl + "QuestionParameters/Subjects";
  console.log('getAllSubjects called');
  return this.http.get<Subject[]>(url_, {withCredentials: true}).pipe(
    tap(data => console.log('Received subjects:', data)),
    catchError(error => {
      console.error('Error fetching subjects:', error);
      return throwError(error);
    }));
}

  public async getSubjectByTeacherId(id: string): Promise<Subject[]>{
    let url_ = this.baseUrl + "Teacher/Subjects/" + id;
  
    try {
      const response: any = await this.http.get(url_, { withCredentials: true }).toPromise();
      return response.value as Subject[];
    } catch (error: any) {
      return Promise.reject(error.message);
    }
  }
getSubjectNameById(id: string): Observable<string> {
  let url_ = this.baseUrl + "QuestionParameters/getSubjectNameById/"+id;

  return this.http.get<any>(url_, {withCredentials: true});
}
getSubjectNameByTopic(topicId: string): Observable<string> {
  let url_ = this.baseUrl + "QuestionParameters/getSubjectNameByTopic/"+topicId;

  return this.http.get<any>(url_, {withCredentials: true});
}
getSubjectByTopic(topicId: string): Observable<Subject> {
  let url_ = this.baseUrl + "QuestionParameters/getSubjectByTopic/"+topicId;

  return this.http.get<Subject>(url_, {withCredentials: true});
}
  public async getSubjectBySchool(schoolId : string): Promise<Subject[]> {
    let url_ = this.baseUrl + "School/Subjects/" + schoolId;
  
    try {
      const response : any = await this.http.get(url_, { withCredentials: true}).toPromise();
      return response.value as Subject[];
    } catch (error : any) {
      throw error;
    }
  }

  public async getSubjectByBranch(brancheId : string): Promise<Subject[]> {
    let url_ = this.baseUrl + "SchoolBranch/Subjects/" + brancheId;
  
    try {
      const response : any = await this.http.get(url_, { withCredentials: true}).toPromise();
      return response.value as Subject[];
    } catch (error : any) {
      throw error;
    }
  }
}
