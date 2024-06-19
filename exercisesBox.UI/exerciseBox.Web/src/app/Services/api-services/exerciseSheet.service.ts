import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { SessionProvider } from "../SessionProvider";
import { API_BASE_URL } from "../../Infrastucture/configurations";

@Injectable ({
    providedIn : 'root'
})
export class ExerciseSheetService {
    
    private headers = new HttpHeaders({
        'Content-Type': 'application/json',
    });
    
    constructor(private http: HttpClient, @Inject(API_BASE_URL) private baseUrl: string) 
    {
    }

    public async getNewExerciseSheet(questionIds: string[]): Promise<Blob> {
        let url_ = this.baseUrl + "ExerciseSheet/GetNewExerciseSheet";
        try {
            const response: any = await this.http.post(url_, { questionIds: questionIds }, { headers: this.headers, responseType: 'blob' as 'json' }).toPromise();
            return response;
        } catch (error) {
            console.error('Error generating exercise sheet:', error);
            return new Blob();
        }
    }
  
}