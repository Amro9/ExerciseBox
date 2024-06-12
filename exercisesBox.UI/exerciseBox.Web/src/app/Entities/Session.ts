export class Session {

    SessionId : string;
    SessionIdKey : string;

    constructor(sessionId : string, sessionIdKey : string){
        this.SessionId = sessionId;
        this.SessionIdKey = sessionIdKey;
    }

    static fromJson(jsonData : any) : Session{
        return new Session(jsonData.SessionId, jsonData.SessionIdKey);
    }
}