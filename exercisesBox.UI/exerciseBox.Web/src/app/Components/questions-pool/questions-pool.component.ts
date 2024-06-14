import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubjectService } from '../../Services/Subject.service';
import { Subject } from '../../Entities/Subject';
import { Topic, TopicService } from '../../Services/Topic.service';
import { SchoolLevel } from '../../Services/SchoolLevel.service';
import { DifficultyLevel, DifficultyLevelsService } from '../../Services/difficulty-levels.service';
import { SchoolService } from '../../Services/school.service';
import { QuestionService } from '../../Services/question.service';
import { Question } from '../../Entities/Question';
import { SchoolTypes } from '../../Entities/SchoolTypes';
import {SchoolBranch} from '../../Entities/SchoolBranch';
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
  constructor(
    private schoolService: SchoolService,
    private subjectService: SubjectService,
    private topicService: TopicService,
    private schoolLevel: SchoolLevel,
    private difficultyLevelsService: DifficultyLevelsService,
    private questionService: QuestionService,
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
      error: (error: string) => console.error('Error fetching Classes:', error)
    });
    this.questionService.getQuestions().subscribe({
      next: (data) => this.publicQuestions = data,
      error: (error: string) => console.error('Error fetching Classes:', error)
    });
    this.schoolService.getSchoolBranches().subscribe({
      next: (data) => this.schoolBranches = data,
      error: (error: string) => console.error('Error fetching Classes:', error)
    });

  }
  onSubjectChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const selectedSubjectId = selectElement.value;

    this.topicService.getTopicsBySubject(selectedSubjectId).subscribe({
      next: (data) => this.subjectsTopics = data,
      error: (error: string) => console.error('Error fetching topics:', error)
    });
  }
}