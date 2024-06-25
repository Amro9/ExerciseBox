import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { Folder } from '../../../Entities/Folder';
import { QuestionService } from '../../../Services/api-services/question.service';

@Component({
  selector: 'app-folders-popup',
  templateUrl: './folders-popup.component.html',
  styleUrls: ['./folders-popup.component.css'] // Korrigiert zu styleUrls
})
export class FoldersPopupComponent implements OnInit {
  @Input() folders: Folder[] = [];
  @Input() popupTop: string = '';
  @Input() popupLeft: string = '';
  @Input() showFolderList: boolean = false;
  @Input() questionId: string = '';
  @Output() save: EventEmitter<string> = new EventEmitter<string>();
  @Output() close: EventEmitter<void> = new EventEmitter<void>();
  
  folderQuestionMap: { [key: string]: boolean } = {};

  constructor(private questionService: QuestionService) {}

  ngOnInit() {
    this.checkQuestionsInFolders();
  }

  checkQuestionsInFolders() {
    this.folders.forEach(folder => {
      this.questionService.getQuestionsByFolder(folder.id).subscribe(questions => {
        this.folderQuestionMap[folder.id] = questions.some(question => question.id === this.questionId);
      });
    });
  }

  saveQuestion(folderId: string) {
    if (!this.folderQuestionMap[folderId]) {
      this.save.emit(folderId);
    }
  }

  closePopup() {
    this.close.emit();
  }
}
