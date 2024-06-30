import { Inject, Injectable, Optional } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, tap, throwError } from "rxjs";
import { API_BASE_URL } from "../../Infrastucture/configurations";
import { SchoolTypes } from "../../Entities/SchoolTypes";
import { SchoolBranch } from "../../Entities/SchoolBranch";
@Injectable({
  providedIn: 'root'
})
export class SchoolService {
  private http: HttpClient;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) private baseUrl: string) {
    this.http = http;
    }
    getSchoolTypes(): Observable<SchoolTypes[]>{ 
        let url_ = this.baseUrl + "school/types";
        return this.http.get<SchoolTypes[]>(url_, {withCredentials:true}).pipe(
            tap(data => console.log('Received school types:', data)),
            catchError(error => {
                console.error('Error fetching school types:', error);
                return throwError(error);
            }));
    }
    getSchoolBranches(): Observable<SchoolBranch[]>{
        let url_ = this.baseUrl + "school/branches";
        return this.http.get<SchoolBranch[]>(url_, {withCredentials: true}).pipe(
            tap(data => console.log('Received school branches:', data)),
            catchError(error => {
                console.error('Error fetching school branches:', error);
                return throwError(error);
            }));
    }

    async getBranchesOfSchool(schoolId: string): Promise<SchoolBranch[]>{
      let url_ = this.baseUrl + "school/branches/" + schoolId;

      try{
        const response : any = await this.http.get<SchoolBranch[]>(url_, {withCredentials: true}).toPromise();
        return response.value as SchoolBranch[];
      }
      catch (error : any){
        throw error;
      }
    }

  }
