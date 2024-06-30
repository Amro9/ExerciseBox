import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { API_BASE_URL } from "../../Infrastucture/configurations";
import { Folder } from "../../Entities/Folder";
import { BoundElementProperty } from "@angular/compiler";
import { Observable } from "rxjs";

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
public async getFoldersOfSubject(subjectId : string, teacherId:string): Promise<Folder[]> {
    let url_ = this.baseUrl + "Subject/Folders/" + subjectId + "/" + teacherId;
    try {
        let body = new HttpParams().set('id', subjectId).set('teacherId', teacherId);

        const response: any = await this.http.get(url_, { headers: this.headers, params: body, withCredentials: true}).toPromise();
        return response.value as Folder[];
    } catch (error) {
        console.error('Error in getFolders:', error);
        return [] as Folder[];
    }
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

    public async createNewFolder(folderName : string, subjectId : string, teacherId : string): Promise<Folder> {
        let url_ = this.baseUrl + "Teacher/NewFolder";
        try {
            const response : any = await this.http.post(url_, { folderName, subjectId, teacherId }, { headers: this.headers, withCredentials: true }).toPromise();
            return response as Folder;
            
        } catch (error) {
            console.error('Error creating folder:', error);
            throw error;
        }
    }

    public async getCreationFolder(subjectId: string, userId: string): Promise<Folder> {
        let url_ = this.baseUrl + "Teacher/CreationFolder/" + subjectId;
        try {
            const response: any = await this.http.post(url_,{subjectId, userId} ,{ headers: this.headers, withCredentials: true }).toPromise();
            return response.value as Folder;
        } catch (error) {
            console.error('Error fetching creation folder:', error);
            throw error;
        }
    }
}