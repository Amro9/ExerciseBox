export class Subject
{
    id: string;
    name: string;
    shortcut: string;
    constructor(id: string, name: string, shortcut: string){
        this.id = id;
        this.name = name;
        this.shortcut = shortcut;
    }
static fromJSON(json: string): Subject {
    const obj = JSON.parse(json);
    return new Subject(obj.id, obj.name, obj.shortcut);
}
static fromData(data : any) : Subject {
    return new Subject(data.id, data.name, data.shortcut);
}
}