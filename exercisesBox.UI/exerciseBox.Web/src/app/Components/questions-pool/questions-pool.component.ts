import { Component, Inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubjectService } from '../../Services/api-services/Subject.service';
import { Subject } from '../../Entities/Subject';
import { Topic, TopicService } from '../../Services/api-services/Topic.service';
import { SchoolLevelService } from '../../Services/api-services/SchoolLevel.service';
import { DifficultyLevel, DifficultyLevelsService } from '../../Services/api-services/difficulty-levels.service';
import { SchoolService } from '../../Services/api-services/school.service';
import { QuestionService } from '../../Services/api-services/question.service';
import { Question } from '../../Entities/Question';
import { SchoolTypes } from '../../Entities/SchoolTypes';
import { SchoolBranch } from '../../Entities/SchoolBranch';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Folder } from '../../Entities/Folder';
import { FolderService } from '../../Services/api-services/Folder.Service';
@Component({
  selector: 'app-questions-pool',
  templateUrl: './questions-pool.component.html',
  styleUrl: './questions-pool.component.css'
})
export class QuestionsPoolComponent {
  hideQuestion() {
    throw new Error('Method not implemented.');
  }
  publicQuestions: Question[] = [];
  subjects: Subject[] = [];
  subjectsTopics: Topic[] = [];
  schoolLevels: string[] = [];
  difficultyLevels: DifficultyLevel[] = [];
  schoolTypes: SchoolTypes[] = [];
  schoolBranches: SchoolBranch[] = [];
  // isSchoolBranchSelectEnabled: boolean ;
  
  Folders!: Folder[];
  showFolderList: boolean = false;
  questionSearchParams: FormGroup;

  // selectedSchoolType: number = 0;
  // selectedSchoolBranch: string = '';
  // selectedSchoolLevel: number = 0;
  // selectedSubject: string = '';
  // selectedTopic: string = '';
  // selectedDifficultyLevel: string = '';

  constructor(
    private fb: FormBuilder,
    private schoolService: SchoolService,
    private subjectService: SubjectService,
    private topicService: TopicService,
    private schoolLevel: SchoolLevelService,
    private difficultyLevelsService: DifficultyLevelsService,
    private questionService: QuestionService,
    private folderService: FolderService
  ) {
    // this.isSchoolBranchSelectEnabled = false;
    this.questionSearchParams = this.fb.group({
      schoolType: ['0'],
      schoolBranch: [{ value: 'null', disabled: true }],
      schoolLevel: ['0'],
      subject: ['null'],
      topic: ['null'],
      difficultyLevel: ['null']
    });

  }

  async ngOnInit(): Promise<void> {
    this.subjectService.getAllSubjects().subscribe({
      next: (data) => this.subjects = data,
      error: (error) => console.error('Error fetching subjects:', error)
    });
    this.schoolService.getSchoolTypes().subscribe({
      next: (data) => this.schoolTypes = data,
      error: (error) => console.error('Error fetching Classes:', error)
    });
    this.difficultyLevelsService.getDifficultyLevels().subscribe({
      next: (data) => this.difficultyLevels = data,
      error: (error: string) => console.error('Error fetching difficultyLevels:', error)
    });
    // this.questionService.getQuestions().subscribe({
    //   next: (data) => this.publicQuestions = data,
    //   error: (error: string) => console.error('Error fetching questions:', error)
    // });
    this.schoolService.getSchoolBranches().subscribe({
      next: (data) => this.schoolBranches = data,
      error: (error: string) => console.error('Error fetching branches:', error)
    });
    this.Folders = this.Folders = await this.folderService.getFoldersOfTeacher("2@3.com");
  }

  deactivateButVocationalSchool(schoolTypeId: number): boolean {
    return schoolTypeId !== 16;
  }
  // abfangen des SchoolType Events vom Select-Element
  onSchoolTypeChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const selectedSchoolTypeId = selectElement.value;
    // this.selectedSchoolType = parseInt(selectedSchoolTypeId, 10);

    // Aktivieren der Berufswahl nur wenn die Schule Berufsschule ist
    // this.isSchoolBranchSelectEnabled = selectedSchoolTypeId === '16'
    if (selectedSchoolTypeId === '16') {
      this.questionSearchParams.get('schoolBranch')?.enable();
    }
    else {
      this.questionSearchParams.get('schoolBranch')?.disable();
      this.questionSearchParams.get('schoolBranch')?.setValue('null');
    }

    if (selectedSchoolTypeId === '0') {
      this.questionSearchParams.get('schoolLevel')?.setValue('0');
    }
    else {
      // Hole die Schulstufen anhand des gewählten Schultypes
      this.schoolLevel.getSchoolLevelsBySchoolTypeId(selectedSchoolTypeId).subscribe({
        next: (data) => this.schoolLevels = data,
        error: (error: string) => console.error('Error fetching branches:', error)
      });

    }
  }

  // onBranchChange(event: Event) {
  //   const selectElement = event.target as HTMLSelectElement;
  //   this.selectedSchoolBranch =  selectElement.value;
  // }
  // onSchoolLevelChange(event: Event) {
  //   const selectElement = event.target as HTMLSelectElement;
  //   this.selectedSchoolLevel = parseInt(selectElement.value, 10);
  // }
  // onTopicChange(event: Event) {
  //   const selectElement = event.target as HTMLSelectElement;
  //   this.selectedTopic = selectElement.value;
  // }
  // onDifficultyLevelChange(event: Event) {
  //   const selectElement = event.target as HTMLSelectElement;
  //   this.selectedDifficultyLevel = selectElement.value;
  // }
  onSubjectChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    // this.selectedSubject = selectElement.value;

    this.topicService.getTopicsBySubject(selectElement.value).subscribe({
      next: (data) => this.subjectsTopics = data,
      error: (error: string) => console.error('Error fetching topics:', error)
    });
  }

  submitSearch() {

    const searchParams = this.questionSearchParams.value;

    Object.entries(searchParams).forEach(([key, value]) => {
      if (value === 'null') {
        delete searchParams[key];
      }
    });

    console.log('searchParams', searchParams);
    this.questionService.getQuestions(searchParams).subscribe({
      next: (data) => this.publicQuestions = data,
      error: (error: string) => console.error('Error fetching questions:', error)
    });
  }

  showFoldersList() {
    this.showFolderList = !this.showFolderList;
  }
  saveQuestion(folder: string) {
    console.log(`Frage wird in ${folder} gespeichert.`);
    // this.showFolderList = false; // Schließe das Div nach Auswahl eines Ordners
  }
}