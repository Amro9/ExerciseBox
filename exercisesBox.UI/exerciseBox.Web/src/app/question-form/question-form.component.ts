import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';


@Component({
  selector: 'app-question-form',
  templateUrl: './question-form.component.html',
  styleUrl: './question-form.component.css'
})
export class QuestionCreationFormComponent {
questionCreationForm =new FormGroup( {
  content: new FormControl('', Validators.required),
questionOnlyForMe: new FormControl(false),
//chooseClass: new FormControl('My Class'),
answer: new FormControl('', Validators.required),
//chooseDifficulty: new FormControl('Easy')
});
submitQuestionCreationForm(){
console.log("form geht")
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
