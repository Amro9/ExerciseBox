import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { QuestionFromService } from '../../Services/question-from.service';
import { Subject} from '../../Entities/Subject';
import { SubjectService } from '../../Services/Subject.service';
import { TopicService, Topic } from '../../Services/Topic.service';
import { SchoolLevel } from '../../Services/SchoolLevel.service';
import { DifficultyLevel, DifficultyLevelsService } from '../../Services/difficulty-levels.service';
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

  constructor(
    private fb: FormBuilder,
    private subjectService: SubjectService,
    private topicService: TopicService,
    private schoolLevel : SchoolLevel,
    private difficultyLevelsService: DifficultyLevelsService,
    private questionFromService: QuestionFromService
  ) {
    this.questionCreationForm = this.fb.group({
      questionText: [''],
      answer: [''],
      SchoolLevel: [''],
      difficultyLevel: ['Einfach'],
      subject: ['', Validators.required],
      topic: [''],
      // class: [''],
      // questionNote: [''],
      // answerNote: [''],
      questionIsPrivate: [false],
      // questionIsSpecific: [false]
    });
  }

  ngOnInit(): void {
    this.subjectService.getAllSubjects().subscribe({
      next: (data) => this.subjects = data,
      error: (error) => console.error('Error fetching subjects:', error)
    });

    this.schoolLevel.getSchoolLevelByTeacherId("1@2.com").subscribe({
  next:(data) => this.schoolLevels = data,
  error: (error) => console.error('Error fetching Classes:', error)
    });

    this.difficultyLevelsService.getDifficultyLevels().subscribe({
      next:(data) => this.difficultyLevels = data,
      error: (error: string) => console.error('Error fetching Classes:', error)
        });
  }
  onLevelClick(level: string) {
    this.questionCreationForm.patchValue({ SchoolLevel: level });
  }
  onSubjectChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const selectedSubjectId = selectElement.value;

    this.topicService.getTopicsBySubject(selectedSubjectId).subscribe({
      next: (data) => this.subjectsTopics = data,
      error: (error: string) => console.error('Error fetching topics:', error)
    });
  }
  submitQuestionCreationForm() {
    const formData = this.questionCreationForm.value;
    formData.Author = "1@2.com"
    this.questionFromService.submitQuestionForm(formData);
  }
}
