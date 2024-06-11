import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubjectService } from '../../Services/Subject.service';
import { Subject} from '../../Entities/Subject';
import { Topic, TopicService } from '../../Services/Topic.service';
import { ClassService } from '../../Services/class.service';
import { DifficultyLevelsService } from '../../Services/difficulty-levels.service';
import { QuestionFromService } from '../../Services/question-from.service';
import { SchoolService } from '../../Services/school.service';

@Component({
  selector: 'app-questions-pool',
  templateUrl: './questions-pool.component.html',
  styleUrl: './questions-pool.component.css'
})
export class QuestionsPoolComponent {
  subjects: Subject[] = [];
  subjectsTopics: Topic[] = [];
  schoolLevels: string[] = [];
  constructor(
    private schoolService: SchoolService,
    private subjectService: SubjectService,
    private topicService: TopicService,
    private classService : ClassService,
    private difficultyLevelsService: DifficultyLevelsService,
    private questionFromService: QuestionFromService
  ) { }

  ngOnInit(): void {
this.subjectService.getAllSubjects().subscribe({
  next: (data) => this.subjects = data,
  error: (error) => console.error('Error fetching subjects:', error)
  });
  this.schoolService.getSchoolTypes().subscribe({
    next:(data) => this.schoolLevels = data,
    error: (error) => console.error('Error fetching Classes:', error)
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