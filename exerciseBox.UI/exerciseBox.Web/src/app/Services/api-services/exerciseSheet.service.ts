import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { API_BASE_URL } from "../../Infrastucture/configurations";
import { ExerciseSheet } from "../../Entities/ExerciseSheet";

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

    public async getNewExerciseSheet(questionIds: string[], exerciseSheet : ExerciseSheet, WithAnswers : boolean): Promise<Blob> {
        let url_ = this.baseUrl + "ExerciseSheet/GetNewExerciseSheet";
        try {
            const response: any = await this.http.post(url_, { questionIds: questionIds, exerciseSheet, WithAnswers}, { headers: this.headers, responseType: 'blob' as 'json', withCredentials: true }).toPromise();
            return response;
        } catch (error) {
            console.error('Error generating exercise sheet:', error);
            return new Blob();
        }
    }
  
}