import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-question-form',
  templateUrl: './question-form.component.html',
  styleUrl: './question-form.component.css'
})
export class QuestionCreationFormComponent {

  questionCreationForm =new FormGroup( {
    subject: new FormControl(''),
    topic: new FormControl(''),
class: new FormControl(''),
questionText: new FormControl(''),
questionNote: new FormControl(''),
answer: new FormControl(''),
answerNote: new FormControl(''),
difficultyLevel: new FormControl('Einfach'),
questionOnlyForMe: new FormControl(false),
questionIsSpecific: new FormControl(false)
});
constructor(private http: HttpClient){}

submitQuestionCreationForm() {
  const formData = this.questionCreationForm.value;
  this.http.post('http://localhost:5000/api/question/add', formData)
    .subscribe(response => {
      console.log('Frage erfolgreich an den Server gesendet:', response);
    }, error => {
      console.error('Fehler beim Senden der Frage an den Server:', error);
    });
}
}