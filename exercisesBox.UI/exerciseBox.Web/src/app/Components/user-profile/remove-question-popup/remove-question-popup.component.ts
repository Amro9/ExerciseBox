import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-remove-question-popup',
  templateUrl: './remove-question-popup.component.html',
  styleUrls: ['./remove-question-popup.component.css']
})
export class RemoveQuestionPopupComponent {
  @Input() popupTop: string = '';
  @Input() popupLeft: string = '';
  @Input() showRemoveConfirm: boolean = false;
  @Output() remove: EventEmitter<void> = new EventEmitter<void>();

  removeQuestion() {
    this.remove.emit();
  }
}
