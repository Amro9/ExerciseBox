import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Subject} from '../../Entities/Subject';
import { SubjectService } from '../../Services/Subject.service';
import { TopicService, Topic } from '../../Services/Topic.service';
@Component({
  selector: 'app-question-form',
  templateUrl: './question-form.component.html',
  styleUrl: './question-form.component.css'
})

export class QuestionCreationFormComponent implements OnInit {
  subjects: Subject[] = [];
  questionCreationForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private subjectService: SubjectService,
    private topicService: TopicService
  ) {
    this.questionCreationForm = this.fb.group({
      subject: ['', Validators.required],
      topic: [''],
      class: [''],
      questionText: [''],
      questionNote: [''],
      answer: [''],
      answerNote: [''],
      difficultyLevel: ['Einfach'],
      questionOnlyForMe: [false],
      questionIsSpecific: [false]
    });
  }

  ngOnInit(): void {
    this.subjectService.getAllSubjects().subscribe({
      next: (data) => this.subjects = data,
      error: (error) => console.error('Error fetching subjects:', error)
    });
  }
  onSubjectChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const selectedSubjectId = selectElement.value;
    this.topicService.getTopicsBySubject(selectedSubjectId).subscribe(topics => {
      console.log(topics); // Do something with the fetched topics
    });
  }
  submitQuestionCreationForm() {
    const formData = this.questionCreationForm.value;
    // Implement the submission logic, e.g., using HttpClient to send the form data to the backend.
    console.log('Form data:', formData);
  }
}

// submitQuestionCreationForm() {
//   const formData = this.questionCreationForm.value;
//   this.http.post('http://localhost:5000/api/question/add', formData)
//     .subscribe(response => {
//       console.log('Frage erfolgreich an den Server gesendet:', response);
//     }, error => {
//       console.error('Fehler beim Senden der Frage an den Server:', error);
//     });
// }
