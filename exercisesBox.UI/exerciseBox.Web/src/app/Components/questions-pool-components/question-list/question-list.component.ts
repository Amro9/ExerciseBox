import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Question } from  '../../../Entities/Question';

@Component({
  selector: 'app-question-list',
  templateUrl: './question-list.component.html',
  styleUrl: './question-list.component.css'
})
export class QuestionListComponent {
  @Input() isCreationFolder = false;
  @Input() questions: Question[] = [];
  @Output() showFolders = new EventEmitter<{ questionId: string, event: MouseEvent }>();
  @Output() hideQuestion = new EventEmitter<{ questionId: string, event: MouseEvent }>();

  onShowFoldersList(event: MouseEvent, questionId: string) {
    this.showFolders.emit({ questionId, event });
  }
  showHideQuestionPopUp(event: MouseEvent, questionId: string) {
    this.hideQuestion.emit({ questionId, event });
  }
}
