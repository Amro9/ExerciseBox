import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';


@Component({
  selector: 'app-question-form',
  templateUrl: './question-form.component.html',
  styleUrl: './question-form.component.css'
})
export class QuestionCreationFormComponent {
  questionCreationForm =new FormGroup( {
    chooseSubject: new FormControl('Fach'),
    chooseTopic: new FormControl('Thema'),
chooseClass: new FormControl('Klasse'),
questionText: new FormControl(''),
questionNote: new FormControl(''),
answer: new FormControl(''),
answerNote: new FormControl(''),
chooseDifficulty: new FormControl('Easy'),
questionOnlyForMe: new FormControl(false),
questionIsSpecific: new FormControl(false)
});
submitQuestionCreationForm(){
console.log("form geht")
console.log("Subject:", this.questionCreationForm.get('chooseSubject')!.value);
}
// onsubmit(){
//   if(this.questionCreationForm.valid){
//     console.log('Forma data:', this.questionCreationForm.value)
//   }
//   else{
//     console.log('form not valid')
//   }
// }
}
