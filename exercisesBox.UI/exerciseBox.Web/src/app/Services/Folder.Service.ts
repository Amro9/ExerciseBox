import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { SessionProvider } from "./SessionProvider";
import { API_BASE_URL } from "../Infrastucture/configurations";
import { Folder } from "../Entities/Folder";
import { BoundElementProperty } from "@angular/compiler";

@Injectable({
    providedIn : 'root'
})
export class FolderService{

    private headers = new HttpHeaders({
        'Content-Type': 'application/json',
    });

    private baseUrl : string;

    constructor(private http: HttpClient, @Inject(API_BASE_URL) baseUrl?: string) 
    {
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    public async getFoldersOfTeacher(id : string): Promise<Folder[]> {
        let url_ = this.baseUrl + "Folder/GetFolders";
        try {
            let body = new HttpParams().set('teacherId', id);
    
            const response: any = await this.http.get(url_, { headers: this.headers, params: body}).toPromise();
            return response.value as Folder[];
        } catch (error) {
            console.error('Error in getFolders:', error);
            return [] as Folder[];
        }
    }
}