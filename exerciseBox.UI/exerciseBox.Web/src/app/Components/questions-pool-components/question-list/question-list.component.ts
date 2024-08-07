import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Question } from '../../../Entities/Question';

@Component({
  selector: 'app-question-list',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css']
})
export class QuestionListComponent {
  @Input() isCreationFolder = false;
  @Input() questions: Question[] = [];
  @Output() showFolders = new EventEmitter<{ questionId: string, event: MouseEvent }>();
  @Output() hideQuestionEvent = new EventEmitter<{ questionId: string, event: MouseEvent }>();

  onShowFoldersList(event: MouseEvent, questionId: string) {
    this.showFolders.emit({ questionId, event });
  }

  showHideQuestionPopUp(event: MouseEvent, questionId: string) {
    console.log('Show/hide question popup:', questionId);
    this.hideQuestionEvent.emit({ questionId, event });
  }
}
