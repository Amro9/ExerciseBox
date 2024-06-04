export class Teacher 
{   
    surname: string;
    givenname: string;
    email: string;
    password: string;

    constructor(surname: string, givenname: string, email: string, password: string)
    {
        this.surname = surname;
        this.givenname = givenname;
        this.email = email;
        this.password = password;
    }

    static fromJSON(json: string): Teacher {
        const obj = JSON.parse(json);
        return new Teacher(obj.surname, obj.givenname, obj.email, obj.password);
    }

    static fromData(data : any) : Teacher {
        return new Teacher(data.surname, data.givenname, data.email, data.password);
    }
}