import { Question } from "./Question";

export class ExerciseSheet {
    id: string;
    title: string;
    markPlaceHolder : boolean = false;
    namePlaceHolder : boolean = false;
    subjectPlaceHolder : boolean = false;
    datePlaceHolder : boolean = false;
    classNumberPlaceHolder : boolean = false;  
    classNumberText : string = "";
    questions: Question[] = [];
    blob : Blob;

    constructor(id: string, title: string, blob: Blob = new Blob()) {
        this.id = id;
        this.title = title;
        this.blob = blob;
    }
}