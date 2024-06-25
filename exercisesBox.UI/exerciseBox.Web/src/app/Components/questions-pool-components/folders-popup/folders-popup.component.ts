import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Folder } from '../../../Entities/Folder';
@Component({
  selector: 'app-folders-popup',
  templateUrl: './folders-popup.component.html',
  styleUrl: './folders-popup.component.css'
})
export class FoldersPopupComponent {
  @Input() folders: Folder[] = [];
  @Input() popupTop: string = '';
  @Input() popupLeft: string = '';
  @Input() showFolderList: boolean = false;
  @Output() save: EventEmitter<string> = new EventEmitter<string>();
  @Output() close: EventEmitter<void> = new EventEmitter<void>();

  saveQuestion(folder: string) {
    this.save.emit(folder);
  }

  closePopup() {
    this.close.emit();
  }
}
