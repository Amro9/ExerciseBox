import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { Question } from '../../../Entities/Question';
import { Folder } from '../../../Entities/Folder';

@Component({
  selector: 'app-profile-question-list',
  templateUrl: './profile-question-list.component.html',
  styleUrl: './profile-question-list.component.css'
})
export class ProfileQuestionListComponent   implements OnChanges {
  @Input() selectedFolderName!: string;
  @Input() questions: Question[] = [];
  @Output() showFolders = new EventEmitter<{ questionId: string, event: MouseEvent }>();
  @Output() showRemoveQuestionConfirm = new EventEmitter<{ questionId: string, event: MouseEvent }>();

  ngOnChanges(changes: SimpleChanges) {

console.log('selectedFolder', this.selectedFolderName); 
  }
  onShowFoldersList(event: MouseEvent, questionId: string) {
    this.showFolders.emit({ questionId, event });
  }

  onRemoveSavedQuestionFromFolder(event: MouseEvent, questionId: string) {
    this.showRemoveQuestionConfirm.emit({ questionId, event });
  }
}
