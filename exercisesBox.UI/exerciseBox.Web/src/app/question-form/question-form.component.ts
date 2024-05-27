import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-question-form',
  standalone: true,
  imports: [],
  templateUrl: './question-form.component.html',
  styleUrl: './question-form.component.css'
})
export class QuestionCreationFormComponent {
questionCreationForm =new FormGroup( {
questionTitle: new FormControl('', Validators.required),
questionOnlyForMe: new FormControl(false),
question: new FormControl('', Validators.required),
chooseClass: new FormControl('My Class'),
answer: new FormControl('', Validators.required),
chooseDifficulty: new FormControl('Easy')
});

onsubmit(){
  if(this.questionCreationForm.valid){
    console.log('Forma data:', this.questionCreationForm.value)
  }
  else{
    console.log('form not valid')
  }
}
}
