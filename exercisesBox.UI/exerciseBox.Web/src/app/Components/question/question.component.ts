import { Component, Input } from '@angular/core';
import { Question } from '../../Entities/Question';
import { SubjectService } from '../../Services/api-services/Subject.service';
import { TopicService } from '../../Services/api-services/Topic.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrl: './question.component.css'
})
export class QuestionComponent {


  @Input() Question! : Question;
  @Input() ShwoSubject : boolean = false;  
  questionSubject!: string ;
  questionTopic!: string ;

  constructor(
    private subjectService: SubjectService,
    private topicService: TopicService
  ) 
  {
  }
  ngOnInit() {
    console.log('question:', this.Question);
   this.loadTopic() ;
   this.loadSubject();
  
  }
  loadTopic() {
    this.topicService.getTopicById(this.Question.topic).subscribe(
      (topic) => {
        this.questionTopic = topic;
      },
      (error) => {
        console.error('Error loading topic:', error);
      }
    );
  }
  async loadSubject() {

    this.subjectService.getSubjectNameByTopic(this.Question.topic).subscribe(
      (subject) => {
        this.questionSubject = subject;
      },
      (error) => {
        console.error('Error loading topic:', error);
      }
    );
  }

}
