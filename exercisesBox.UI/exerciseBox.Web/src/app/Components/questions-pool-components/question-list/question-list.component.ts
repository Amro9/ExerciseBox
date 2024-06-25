import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Question } from  '../../../Entities/Question';

@Component({
  selector: 'app-question-list',
  templateUrl: './question-list.component.html',
  styleUrl: './question-list.component.css'
})
export class QuestionListComponent {
  @Input() questions: Question[] = [];
  @Output() showFolders = new EventEmitter<MouseEvent>();
  @Output() hideQuestion = new EventEmitter<void>();

  onShowFoldersList(event: MouseEvent) {
    this.showFolders.emit(event);
  }

  onHideQuestion() {
    this.hideQuestion.emit();
  }
}
