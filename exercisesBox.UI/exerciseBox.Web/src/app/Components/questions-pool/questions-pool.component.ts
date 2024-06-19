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
@Component({
  selector: 'app-questions-pool',
  templateUrl: './questions-pool.component.html',
  styleUrl: './questions-pool.component.css'
})
export class QuestionsPoolComponent {
  subjects: Subject[] = [];
  subjectsTopics: Topic[] = [];
  schoolLevels: string[] = [];
  difficultyLevels: DifficultyLevel[] = [];
  publicQuestions: Question[] = [];
  schoolTypes: SchoolTypes[] = [];
  schoolBranches: SchoolBranch[] = [];
  isSchoolBranchSelectEnabled: boolean = false;

  selectedSchoolType: number = 0;
  selectedSchoolBranch: string = '';
  selectedSchoolLevel: number = 0;
  selectedSubject: string = '';
  selectedTopic: string = '';
  selectedDifficultyLevel: string = '';

  constructor(
    private schoolService: SchoolService,
    private subjectService: SubjectService,
    private topicService: TopicService,
    private schoolLevel: SchoolLevelService,
    private difficultyLevelsService: DifficultyLevelsService,
    private questionService: QuestionService
  ) { }

  excludeQuestion(_t50: any) {
    throw new Error('Method not implemented.');
  }
  saveQuestion(_t50: any) {
    throw new Error('Method not implemented.');
  }
  ngOnInit(): void {
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

  }
  // nur vorrübergehend, da wir uns zuerst auf die Berufsschule kontzentrieren
  isSchoolTypeDisabled(schoolTypeId: number): boolean {
    return schoolTypeId !== 16;
  }
  // abfangen der Events von den Select-Elementen
  onSchoolTypeChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const selectedSchoolTypeId = selectElement.value;
    this.selectedSchoolType = parseInt(selectedSchoolTypeId, 10);

    // Aktivieren der Berufswahl nur wenn die Schule Berufsschule ist
    this.isSchoolBranchSelectEnabled = selectedSchoolTypeId === '16'

    // Hole die Schulstufen anhand des gewählten Schultypes
    this.schoolLevel.getSchoolLevelsBySchoolTypeId(selectedSchoolTypeId).subscribe({
      next: (data) => this.schoolLevels = data,
      error: (error: string) => console.error('Error fetching branches:', error)
    });
  }

  onBranchChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedSchoolBranch =  selectElement.value;
  }
  onSchoolLevelChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedSchoolLevel = parseInt(selectElement.value, 10);
  }
  onTopicChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedTopic = selectElement.value;
  }
  onDifficultyLevelChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedDifficultyLevel = selectElement.value;
  }
  onSubjectChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedSubject = selectElement.value;

    this.topicService.getTopicsBySubject(this.selectedSubject).subscribe({
      next: (data) => this.subjectsTopics = data,
      error: (error: string) => console.error('Error fetching topics:', error)
    });
  }

  submitSearch() {
    const searchParams = {
      schoolTypeId: this.selectedSchoolType,
      schoolBranch: this.selectedSchoolBranch,
      schoolLevel: this.selectedSchoolLevel,
      subjectId: this.selectedSubject,
      topicId: this.selectedTopic,
      difficultyLevel: this.selectedDifficultyLevel
    };

    // this.questionService.searchQuestions(searchParams).subscribe({
    //   next: (data) => this.publicQuestions = data,
    //   error: (error: string) => console.error('Error fetching questions:', error)
    // });
  }
}