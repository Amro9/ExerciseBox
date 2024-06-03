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

    
}