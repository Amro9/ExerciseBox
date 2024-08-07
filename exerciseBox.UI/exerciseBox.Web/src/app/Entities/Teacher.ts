export class Teacher 
{   
    surname: string;
    givenname: string;
    email: string;
    password: string;
    isActive: boolean; 
    branch : string;
    schoolId?: string;

    constructor(surname: string, givenname: string, email: string, password: string, branch : string, isActive: boolean = true)
    {
        this.surname = surname;
        this.givenname = givenname;
        this.email = email;
        this.password = password;
        this.isActive = isActive;
        this.branch = branch;
    }

    static fromJSON(json: string): Teacher {
        const obj = JSON.parse(json);
        return new Teacher(obj.surname, obj.givenname, obj.email, obj.password, obj.isActive);
    }

    static fromData(data : any) : Teacher {
        return new Teacher(data.surname, data.givenname, data.email, data.password, data.isActive);
    }
}