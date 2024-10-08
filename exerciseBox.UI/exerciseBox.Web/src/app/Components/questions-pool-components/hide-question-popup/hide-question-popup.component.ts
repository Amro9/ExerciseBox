import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-hide-question-popup',
  templateUrl: './hide-question-popup.component.html',
  styleUrls: ['./hide-question-popup.component.css'] // Correct styleUrls spelling
})
export class HideQuestionPopupComponent {
  @Input() popupTop: string = '';
  @Input() popupLeft: string = '';
  @Input() showHideConfirm: boolean = false;
  @Output() hide: EventEmitter<void> = new EventEmitter<void>();

  hideQuestion() {
    this.hide.emit();
  }
}
