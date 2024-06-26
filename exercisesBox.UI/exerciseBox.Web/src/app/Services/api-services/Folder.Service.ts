import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { API_BASE_URL } from "../../Infrastucture/configurations";
import { Folder } from "../../Entities/Folder";
import { BoundElementProperty } from "@angular/compiler";

@Injectable({
    providedIn : 'root'
})
export class FolderService{

    private headers = new HttpHeaders({
        'Content-Type': 'application/json',
    });


    constructor(private http: HttpClient, @Inject(API_BASE_URL) private baseUrl: string) 
    {
    }

    public async getFoldersOfTeacher(id : string): Promise<Folder[]> {
        let url_ = this.baseUrl + "Teacher/Folders/" + id;
        try {
            let body = new HttpParams().set('id', id);
    
            const response: any = await this.http.get(url_, { headers: this.headers, params: body, withCredentials: true}).toPromise();
            return response.value as Folder[];
        } catch (error) {
            console.error('Error in getFolders:', error);
            return [] as Folder[];
        }
    }

    public async createNewFolder(folder : Folder): Promise<boolean> {
        let url_ = this.baseUrl + "Teacher/NewFolder";
        try {
            const response: any = await this.http.post(url_, folder, { headers: this.headers, withCredentials: true }).toPromise();
            return true;
        } catch (error) {
            console.error('Error creating folder:', error);
            return false;
        }
    }
}