import { Question } from "./Question";

export class QuestionPickModel {

    Question : Question
    IsSelected : boolean;   

    constructor(question : Question, isSelected : boolean)
    {
        this.Question = question;
        this.IsSelected = isSelected;
    }
}