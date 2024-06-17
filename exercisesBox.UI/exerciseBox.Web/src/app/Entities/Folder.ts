import { Question } from "./Question";

export class Folder {

    id: string;
    name: string;
    topic: string;
    Questions : Question[] = [];

    constructor(id : string, name : string, topic : string) {
        this.id = id;
        this.name = name;
        this.topic = topic;
    }
}