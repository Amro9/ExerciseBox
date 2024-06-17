import { Component } from '@angular/core';
import { Question } from '../../Entities/Question';

@Component({
  selector: 'app-question',
  standalone: true,
  imports: [],
  templateUrl: './question.component.html',
  styleUrl: './question.component.css'
})
export class QuestionComponent {

  Question! : Question;

  constructor() 
  {
    this.Question = this.generateMockQuestion();
  }

  onGenerateExerciseSheet() {

    
  }
  generateMockQuestion() {
    // Create a new instance of the Question class
    const mockQuestion = new Question(
        '1', // id
        'Test Author', // author
        'What is the capital of France?', // questionText
        'Paris', // answer
        'High School', // schoolLevel
        'Easy', // difficultyLevel
        'Geography', // subject
        'Capitals' // topic
    );

    // Return the mock question
    return mockQuestion;
}
}
