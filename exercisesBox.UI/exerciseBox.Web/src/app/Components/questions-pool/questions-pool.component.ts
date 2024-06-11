import { Component } from '@angular/core';
import { SubjectService } from '../../Services/Subject.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-questions-pool',
  standalone: true,
  imports: [],
  templateUrl: './questions-pool.component.html',
  styleUrl: './questions-pool.component.css'
})
export class QuestionsPoolComponent {
  subjects: Subject[] = [];
  constructor(
    private subjectService: SubjectService,
  ) { }

  ngOnInit(): void {
this.subjectService.getAllSubjects().subscribe({
  
  }
}
