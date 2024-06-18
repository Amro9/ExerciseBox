export class Question {
    id: string;
    author: string;
    questionText: string;
    answer: string;
    schoolLevel: string;
    difficultyLevel: string;
    subject: string;
    topic: string;

    constructor(id: string, author: string, questionText: string, answer: string, schoolLevel: string, difficultyLevel: string, subject: string, topic: string){
        this.id = id;
        this.author = author;
        this.questionText = questionText;
        this.answer = answer;
        this.schoolLevel = schoolLevel;
        this.difficultyLevel = difficultyLevel;
        this.subject = subject;
        this.topic = topic;
    }

    static fromJSON(json: any): Question {
        return new Question(
            json.id,
            json.author,
            json.questionText,
            json.answer,
            json.schoolLevel,
            json.difficultyLevel,
            json.subject,
            json.topic
        );
    }
}