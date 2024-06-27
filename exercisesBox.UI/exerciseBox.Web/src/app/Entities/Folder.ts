import { Question } from "./Question";
import { Subject } from "./Subject";
import { Topic } from "./Topic";

export class Folder {

    id: string;
    name: string;
    Subject: Subject;
    Questions : Question[] = [];
    IsCreationFolder : boolean;;

    constructor(id : string, name : string, subject : Subject, isCreationFolder: boolean) {
        this.id = id;
        this.name = name;
        this.Subject = subject;
        this.IsCreationFolder = isCreationFolder;
    }
}