import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { SessionProvider } from "./SessionProvider";
import { API_BASE_URL } from "../Infrastucture/configurations";

@Injectable ({
    providedIn : 'root'
})
export class ExerciseSheetService {
    
    private headers = new HttpHeaders({
        'Content-Type': 'application/json',
    });

    private baseUrl : string;
    
    constructor(private http: HttpClient,  @Inject(SessionProvider) private sessionProvider: SessionProvider, @Inject(API_BASE_URL) baseUrl?: string) 
    {
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    public async getNewExerciseSheet(questionIds: string[]): Promise<any> {
        let url_ = this.baseUrl + "ExerciseSheet/GenerateExerciseSheet";
        try {
            const response: any = await this.http.post(url_, { questionIds: questionIds  }, { headers: this.headers }).toPromise();
            return response.value;
        } catch (error) {
            return null;
        }
    }
  
}