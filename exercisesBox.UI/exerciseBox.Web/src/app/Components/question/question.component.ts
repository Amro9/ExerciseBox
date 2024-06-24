import { Component, Input } from '@angular/core';
import { Question } from '../../Entities/Question';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrl: './question.component.css'
})
export class QuestionComponent {

  ShowQuestionAnswer() {
    throw new Error('Method not implemented.');
  }

  @Input() Question! : Question;
  @Input() ShwoSubject : boolean = false;  

  constructor() 
  {
    //this.Question = this.generateMockQuestion();
  }

//   generateMockQuestion() {
//     // Create a new instance of the Question class
//     const mockQuestion = new Question(
//         '1', // id
//         'Test Author', // author
//         'What is the capital of France?', // questionText
//         'Paris', // answer
//         'High School', // schoolLevel
//         'Easy', // difficultyLevel
//         'Geography', // subject
//         'Capitals' // topic
//     );

//     // Return the mock question
//     return mockQuestion;
// }
}
