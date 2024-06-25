import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, ReactiveFormsModule, AbstractControl } from '@angular/forms';
import { QuestionFromService } from '../../Services/api-services/question-form.service';
import { Subject} from '../../Entities/Subject';
import { SubjectService } from '../../Services/api-services/Subject.service';
import { TopicService, Topic } from '../../Services/api-services/Topic.service';
import { SchoolLevelService } from '../../Services/api-services/SchoolLevel.service';
import { DifficultyLevel, DifficultyLevelsService } from '../../Services/api-services/difficulty-levels.service';

@Component({
  selector: 'app-question-form',
  templateUrl: './question-form.component.html',
  styleUrl: './question-form.component.css'
})

export class QuestionCreationFormComponent implements OnInit {
  subjects: Subject[] = [];
  schoolLevels: string[] = [];
  questionCreationForm: FormGroup;
  subjectsTopics: Topic[] = [];
  difficultyLevels: DifficultyLevel[] = [];


  onChange(newHtml: string) {
  }

  constructor(
    private fb: FormBuilder,
    private subjectService: SubjectService,
    private topicService: TopicService,
    private schoolLevel : SchoolLevelService,
    private difficultyLevelsService: DifficultyLevelsService,
    private questionFromService: QuestionFromService
  ) {

    this.questionCreationForm = this.fb.group({
      schoolLevel: ['0', [Validators.required, this.validateDropdown]],
      topic: ['0',[Validators.required, this.validateDropdown]],
      questionText: ['', [Validators.required]],
      answer: ['', [Validators.required]],
      difficultyLevel: ['0',[Validators.required, this.validateDropdown]],
      questionIsPrivate: [false]
    });
  }
  validateDropdown(control: AbstractControl): { [key: string]: boolean } | null {
    if (control.value === '0') {
      return { 'invalidDropdown': true };
    }
    return null;
  }
  ngOnInit(): void {
    this.fetchSubjects();
    this.fetchSchoolLevels();
    this.fetchDifficultyLevels()
  //   this.subjectService.getAllSubjects().subscribe({
  //     next: (data) => this.subjects = data,
  //     error: (error) => console.error('Error fetching subjects:', error)
  //   });

  //   this.schoolLevel.getSchoolLevelByTeacherId("1@2.com").subscribe({
  // next:(data) => this.schoolLevels = data,
  // error: (error) => console.error('Error fetching Classes:', error)
  //   });

  //   this.difficultyLevelsService.getDifficultyLevels().subscribe({
  //     next:(data) => this.difficultyLevels = data,
  //     error: (error: string) => console.error('Error fetching Classes:', error)
  //       });
  }
  // onLevelClick(level: string) {
  //   this.questionCreationForm.patchValue({ SchoolLevel: level });
  // }
  onSubjectChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const selectedSubjectId = selectElement.value;

    this.topicService.getTopicsBySubject(selectedSubjectId).subscribe({
      next: (data) => this.subjectsTopics = data,
      error: (error: string) => console.error('Error fetching topics:', error)
    });
  }
  submitQuestionCreationForm() :void{
    if (!this.questionCreationForm.valid) {
      this.questionCreationForm.markAllAsTouched();
    }
    else{

      const formData = this.questionCreationForm.value;
      formData.Author = "1@2.com"
      formData.SchoolType= "16"
      formData.SchoolBranch = "f475008d-222d-4e34-8e8f-b9700cb828e5" 
      
      this.questionFromService.submitQuestionForm(formData).subscribe({
        next: () => {
          this.questionCreationForm.patchValue({
            questionText: '',
            answer: '',
          });
          
          this.questionCreationForm.markAsUntouched();
          
        },
      });
    }
}
fetchSubjects(): void {
  this.subjectService.getAllSubjects().subscribe({
    next: (data) => this.subjects = data,
    error: (error) => console.error('Error fetching subjects:', error)
  });
}

fetchSchoolLevels(): void {
  this.schoolLevel.getSchoolLevelByTeacherId("1@2.com").subscribe({
    next:(data) => this.schoolLevels = data,
    error: (error) => console.error('Error fetching Classes:', error)
  });
}

fetchDifficultyLevels(): void {
  this.difficultyLevelsService.getDifficultyLevels().subscribe({
    next:(data) => this.difficultyLevels = data,
    error: (error: string) => console.error('Error fetching Classes:', error)
  });
}

}