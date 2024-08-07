import { Inject, Injectable } from "@angular/core";
import { Session } from "../Entities/Session";

@Injectable({
    providedIn : 'root'
})
export class SessionStorageProvider {

    public async GetUserId() : Promise<string> {
    
        const id : string = (await sessionStorage.getItem("id")) ?? "";
        return id;
    }

    public async SetUserId(id : string) {
        await sessionStorage.setItem("id", id);
    }   
}