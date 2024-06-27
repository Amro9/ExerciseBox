import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SchoolBranch } from '../../../Entities/SchoolBranch';
import { SchoolTypes } from '../../../Entities/SchoolTypes';
import {  DifficultyLevelsService } from '../../../Services/api-services/difficulty-levels.service';
import { Topic, TopicService } from '../../../Services/api-services/Topic.service';
import { Subject } from '../../../Entities/Subject';
import { FormGroup, FormBuilder } from '@angular/forms';
import { SchoolLevelService } from '../../../Services/api-services/SchoolLevel.service';
import { SubjectService } from '../../../Services/api-services/Subject.service';
import { SchoolService } from '../../../Services/api-services/school.service';
import { DifficultyLevel } from '../../../Entities/DifficutlyLevel';

@Component({
  selector: 'app-filter-formular',
  templateUrl: './filter-formular.component.html',
  styleUrl: './filter-formular.component.css'
})
export class FilterFormularComponent {
  @Output() search: EventEmitter<any> = new EventEmitter<any>();
  subjects: Subject[] = [];
  subjectsTopics: Topic[] = [];
  schoolLevels: string[] = [];
  difficultyLevels: DifficultyLevel[] = [];
  schoolTypes: SchoolTypes[] = [];
  schoolBranches: SchoolBranch[] = [];
  
  questionSearchParams: FormGroup;
  constructor(
    private fb: FormBuilder,
    private schoolService: SchoolService,
    private subjectService: SubjectService,
    private topicService: TopicService,
    private schoolLevel: SchoolLevelService,
    private difficultyLevelsService: DifficultyLevelsService,
  ) {
    this.questionSearchParams = this.fb.group({
      schoolType: ['0'],
      schoolBranch: [{ value: 'null', disabled: true }],
      schoolLevel: ['0'],
      subject: ['null'],
      topic: ['null'],
      difficultyLevel: ['null']
    });
  }
  ngOnInit() {
    this.getSubjects();
    this.getSchoolTypes();
    this.getDifficultyLevels();
    this.getSchoolBranches();
  }
  getSubjects() {
    this.subjectService.getAllSubjects().subscribe({
      next: (data) => this.subjects = data,
      error: (error) => console.error('Error fetching subjects:', error)
    });
  }
  
  getSchoolTypes() {
    this.schoolService.getSchoolTypes().subscribe({
      next: (data) => this.schoolTypes = data,
      error: (error) => console.error('Error fetching Classes:', error)
    });
  }
  getDifficultyLevels() {
    this.difficultyLevelsService.getDifficultyLevels().subscribe({
      next: (data) => this.difficultyLevels = data,
      error: (error: string) => console.error('Error fetching difficultyLevels:', error)
    });
  }
getSchoolBranches() {
  this.schoolService.getSchoolBranches().subscribe({
    next: (data) => this.schoolBranches = data,
    error: (error: string) => console.error('Error fetching branches:', error)
  });
}

deactivateButVocationalSchool(schoolTypeId: number): boolean {
  return schoolTypeId !== 16;
}
onSchoolTypeChange(event: Event) {
  const selectElement = event.target as HTMLSelectElement;
  const selectedSchoolTypeId = selectElement.value;
  if (selectedSchoolTypeId === '16') {
    this.questionSearchParams.get('schoolBranch')?.enable();
  } else {
    this.questionSearchParams.get('schoolBranch')?.disable();
    this.questionSearchParams.get('schoolBranch')?.setValue('null');
  }

  if (selectedSchoolTypeId === '0') {
    this.questionSearchParams.get('schoolLevel')?.setValue('0');
  } else {
    this.schoolLevel.getSchoolLevelsBySchoolTypeId(selectedSchoolTypeId).subscribe({
      next: (data) => this.schoolLevels = data,
      error: (error: string) => console.error('Error fetching branches:', error)
    });
  }
}
onSubjectChange(event: Event) {
  const selectElement = event.target as HTMLSelectElement;
  this.topicService.getTopicsBySubject(selectElement.value).subscribe({
    next: (data) => this.subjectsTopics = data,
    error: (error: string) => console.error('Error fetching topics:', error)
  });
}
// submitSearch() {

//   const searchParams = this.questionSearchParams.value;

//   Object.entries(searchParams).forEach(([key, value]) => {
//     if (value === 'null') {
//       delete searchParams[key];
//     }
//   });

//   console.log('searchParams', searchParams);
//   this.questionService.getQuestions(searchParams).subscribe({
//     next: (data) => this.publicQuestions = data,
//     error: (error: string) => console.error('Error fetching questions:', error)
//   });
// }
submitSearch() {
  const searchParams = this.questionSearchParams.value;
  Object.entries(searchParams).forEach(([key, value]) => {
    if (value === 'null') {
      delete searchParams[key];
    }
  });
  this.search.emit(searchParams);
}
}