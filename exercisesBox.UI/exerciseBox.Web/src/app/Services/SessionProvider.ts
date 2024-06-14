import { Session } from "../Entities/Session";

export class SessionProvider {

    private static instance : SessionProvider;
    private session : Session;

    private constructor(){
        this.session = Session.fromJson(localStorage.getItem("session"));
    }

    static getInstance() : SessionProvider {
        if(!SessionProvider.instance){
            SessionProvider.instance = new SessionProvider();
        }
        return SessionProvider.instance;
    }

    getSession() : Session {
        return this.session;
    }

    setSession(session : Session) : void {
        this.session = session;
        localStorage.setItem("session", JSON.stringify(session));
    }

    clearSession() : void {
        this.session = (null as unknown as Session);
        localStorage.removeItem("session");
    }

}