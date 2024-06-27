import { Component, ElementRef, HostListener, ViewChild } from '@angular/core';
import { Question } from '../../../Entities/Question';
import { FormBuilder } from '@angular/forms';
import { Folder } from '../../../Entities/Folder';
import { FolderService } from '../../../Services/api-services/Folder.Service';
import { QuestionService } from '../../../Services/api-services/question.service';
import { CookieService } from 'ngx-cookie-service';
import { FoldersPopupComponent } from '../folders-popup/folders-popup.component';
import { NotificationService } from '../../../Services/general-services/notification.service';

@Component({
  selector: 'app-questions-pool',
  templateUrl: './questions-pool.component.html',
  styleUrls: ['./questions-pool.component.css']
})
export class QuestionsPoolComponent {
  publicQuestions: Question[] = [];
  Folders: Folder[] = [];
  showFolderList: boolean = false;
  showHideConfirm: boolean = false;
  popupTop!: string;
  popupLeft!: string;
  selectedQuestionId: string = '';

  userEmail!: string;

  @ViewChild(FoldersPopupComponent) foldersPopupComponent!: FoldersPopupComponent;

  constructor(
    private fb: FormBuilder,
    private questionService: QuestionService,
    private folderService: FolderService,
    private elementRef: ElementRef,
    private cookieService: CookieService ,
    private notificationService: NotificationService
  ) {}

  async ngOnInit(): Promise<void> {
    this.userEmail = this.cookieService.get("userEmail");
    console.log('User email:', this.userEmail);
    this.Folders = await this.folderService.getFoldersOfTeacher(this.userEmail);
  }

  submitSearch(searchParams: any) {
    searchParams.teacherEmail = this.userEmail;
    console.log('Search parameters:', searchParams);
    this.questionService.getQuestions(searchParams).subscribe({
      next: (data) => {
        this.publicQuestions = data;

        console.log('Questions fetched:', this.publicQuestions);
      },
      error: (error: string) => console.error('Error fetching questions:', error)
    });
  }

  @HostListener('window:scroll', ['$event'])
  onScroll(event: Event) {
    // Schließe das Popup-Fenster für die Ordnerliste, wenn gescrollt wird
    if (this.showFolderList) {
      this.showFolderList = false;
    }

    // Schließe das Popup-Fenster für das Ausblenden der Frage, wenn gescrollt wird
    if (this.showHideConfirm) {
      this.showHideConfirm = false;
    }
  }

  @HostListener('document:click', ['$event'])
  onClick(event: MouseEvent) {
    // Schließe das Popup-Fenster für die Ordnerliste, wenn außerhalb geklickt wird
    if (this.showFolderList && !this.elementRef.nativeElement.querySelector('.popup-folder-list').contains(event.target)) {
      this.showFolderList = false;
    }

    // Schließe das Popup-Fenster für das Ausblenden der Frage, wenn außerhalb geklickt wird
    if (this.showHideConfirm && !this.elementRef.nativeElement.querySelector('.popup-hide-question').contains(event.target)) {
      this.showHideConfirm = false;
    }
  }

  showFoldersList(event: { questionId: string, event: MouseEvent }) {
    event.event.stopPropagation();
    const popupWidth = 300; // Beispielbreite des Popups
  const popupHeight = 200; // Beispielhöhe des Popups
  const screenWidth = window.innerWidth;
  const screenHeight = window.innerHeight;

  let left = event.event.clientX;
  let top = event.event.clientY;
  if (left + popupWidth > screenWidth) {
    left = screenWidth - popupWidth;
  }

  // Überprüfen, ob das Popup außerhalb des sichtbaren Bereichs unten liegt
  if (top + popupHeight > screenHeight) {
    top = screenHeight - popupHeight;
  }
    this.showFolderList = true;
    this.popupTop = `${event.event.clientY}px`;
    this.popupLeft = `${event.event.clientX}px`;
    this.selectedQuestionId = event.questionId;
    this.foldersPopupComponent.checkQuestionsInFolders(); // Update the popup component whenever the folder list is shown
  }

  saveQuestion(folderId: string) {
    console.log(`Frage wird in ${folderId} gespeichert.`);
    this.showFolderList = false;

    this.questionService.saveQuestionToFolder(this.selectedQuestionId, folderId).subscribe({
      next: (data) => {
        console.log('Question saved:', data);
        this.foldersPopupComponent.checkQuestionsInFolders(); // Re-check questions in folders after saving
      },
      error: (error: string) => console.error('Error saving question:', error)
    });
  }

  showHideQuestionPopUp(event: { questionId: string, event: MouseEvent }) {
    event.event.stopPropagation();

  const popupWidth = 300; // Beispielbreite des Popups
  const popupHeight = 200; // Beispielhöhe des Popups
  const screenWidth = window.innerWidth;
  const screenHeight = window.innerHeight;

  let left = event.event.clientX;
  let top = event.event.clientY;

  // Überprüfen, ob das Popup außerhalb des sichtbaren Bereichs rechts liegt
  if (left + popupWidth > screenWidth) {
    left = screenWidth - popupWidth;
  }

  // Überprüfen, ob das Popup außerhalb des sichtbaren Bereichs unten liegt
  if (top + popupHeight > screenHeight) {
    top = screenHeight - popupHeight;
  }

    this.popupTop = `${event.event.clientY}px`;
    this.popupLeft = `${event.event.clientX}px`;
    this.showHideConfirm = true;
    this.selectedQuestionId = event.questionId;
  }

  hideQuestion() {
    console.log('Frage wird ausgeblendet.');

    this.questionService.hideQuestionByTeacher(this.selectedQuestionId, this.userEmail).subscribe({ 
      next: (data) => {
        console.log('Question hidden:', data);
        this.notificationService.showSuccess('Frage ausgeblendet');
        this.publicQuestions = this.publicQuestions.filter(q => q.id !== this.selectedQuestionId);
        this.showHideConfirm = false;
      }
    });
  }
}
