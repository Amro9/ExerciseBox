 import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable, Optional } from "@angular/core";
import { API_BASE_URL } from "../../Infrastucture/configurations";
import { catchError, map, Observable, throwError } from "rxjs";
import { Teacher } from "../../Entities/Teacher";
import { Session } from "../../Entities/Session";

@Injectable({
    providedIn: 'root'
})
export class TeacherAPIConnection {

    private http: HttpClient;
    private baseUrl: string;

    //remove after working:
    private headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    } 

    getTeacherbyEmail(email : string) : Observable<Teacher> {
        let url_ = this.baseUrl + "Teacher/ByEmail";
    
        const body = { email: email };
    
        return this.http.post(url_, body, {headers : this.headers, withCredentials:true}).pipe(
          map((response: any) => {
            const jsonData = response.value;
            return Teacher.fromData(jsonData);
          }),
          catchError(error => {
            return throwError(error.message);
          })
        );
    }

    async getTeachersOfSchool(schoolEmail : string) : Promise<Teacher[]> 
    {
        let url_ = this.baseUrl + "School/Teachers/" + schoolEmail;
    
        try{
          const response : any =  await this.http.get(url_,{headers : this.headers, withCredentials:true}).toPromise();
          return response.teachers as Teacher[];
        }
        catch(error : any){
          throw error;
        }
    }

    async deactivateTeacher(teacherId : string) : Promise<void> {
        let url_ = this.baseUrl + "Teacher/Deactivate/" + teacherId;
    
        try{
          await this.http.post(url_,{},{headers : this.headers, withCredentials:true}).toPromise();
        }
        catch(error : any){
          throw error;
        }
    }
    
    async activateTeacher(teacherId : string) : Promise<void> {
      let url_ = this.baseUrl + "Teacher/Activate/" + teacherId;
  
      try{
        await this.http.post(url_,{},{headers : this.headers, withCredentials:true}).toPromise();
      }
      catch(error : any){
        throw error;
      }
    }
    
    async updateTeacher(teacher : Teacher) : Promise<void> {
      let url_ = this.baseUrl + "Teacher/Update";
  
      try{
        await this.http.post(url_,teacher,{headers : this.headers, withCredentials:true}).toPromise();
      }
      catch(error : any){
        throw error;
      }
    }

    async addTeacher(teacher : Teacher) : Promise<void> {
      let url_ = this.baseUrl + "Teacher/Add";
  
      try{
        await this.http.post(url_,teacher,{headers : this.headers, withCredentials:true}).toPromise();
      }
      catch(error : any){
        throw error;
      }
    }

    async resetPassword(teacherId : string) : Promise<void> {
      let url_ = this.baseUrl + "Teacher/ResetPassword/" + teacherId;
  
      try{
        await this.http.post(url_,{headers : this.headers, withCredentials:true}).toPromise();
      }
      catch(error : any){
        throw error;
      }
    }

    async addSubjectToTeacher(teacherId : string, subjectId : string) : Promise<void> {
      let url_ = this.baseUrl + "Teacher/AddSubject"
  
      try{
        await this.http.post(url_,{teacherId, subjectId},{headers : this.headers, withCredentials:true}).toPromise();
      }
      catch(error : any){
        throw error;
      }
    }
    
    async removeSubjectFromTeacher(teacherId : string, subjectId : string) : Promise<void> {
      let url_ = this.baseUrl + "Teacher/RemoveSubject"
  
      try{
        await this.http.post(url_,{teacherId, subjectId},{headers : this.headers, withCredentials:true}).toPromise();
      }
      catch(error : any){
        throw error;
      }
    }
}