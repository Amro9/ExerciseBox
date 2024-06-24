import { Question } from "./Question";
import { Topic } from "./Topic";

export class Folder {

    id: string;
    name: string;
    topic: Topic;
    Questions : Question[] = [];

    constructor(id : string, name : string, topic : Topic) {
        this.id = id;
        this.name = name;
        this.topic = topic;
    }
}