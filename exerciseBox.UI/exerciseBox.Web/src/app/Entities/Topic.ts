import { Subject } from "./Subject";

export class Topic {

    id: string;
    name: string;
    subject: Subject;

    constructor(id : string, name : string, subject : Subject) {
        this.id = id;
        this.name = name;
        this.subject = subject;
    }
}