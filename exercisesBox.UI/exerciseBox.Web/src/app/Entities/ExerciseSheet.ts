import { Question } from "./Question";

export class ExerciseSheet {
    id: string;
    name: string;
    questions: Question[] = [];
    blob : Blob;

    constructor(id: string, name: string, blob: Blob = new Blob()) {
        this.id = id;
        this.name = name;
        this.blob = blob;
    }
}