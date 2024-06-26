import { Question } from "./Question";
import { Topic } from "./Topic";

export class Folder {

    id: string;
    name: string;
    topic: Topic;
    Questions : Question[] = [];
    IsCreationFolder : boolean;;

    constructor(id : string, name : string, topic : Topic, isCreationFolder: boolean) {
        this.id = id;
        this.name = name;
        this.topic = topic;
        this.IsCreationFolder = isCreationFolder;
    }
}