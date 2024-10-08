import { Component, ElementRef, HostListener, ViewChild } from '@angular/core';
import { Question } from '../../../Entities/Question';
import { FormBuilder } from '@angular/forms';
import { Folder } from '../../../Entities/Folder';
import { FolderService } from '../../../Services/api-services/Folder.Service';
import { QuestionService } from '../../../Services/api-services/question.service';
import { CookieService } from 'ngx-cookie-service';
import { FoldersPopupComponent } from '../folders-popup/folders-popup.component';
import { NotificationService } from '../../../Services/general-services/notification.service';
import { SubjectService } from '../../../Services/api-services/Subject.service';

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

  userMail!: string;

  @ViewChild(FoldersPopupComponent) foldersPopupComponent!: FoldersPopupComponent;

  constructor(
    private fb: FormBuilder,
    private questionService: QuestionService,
    private folderService: FolderService,
    private elementRef: ElementRef,
    private cookieService: CookieService,
    private notificationService: NotificationService,
    private subjectService: SubjectService
  ) { }

  async ngOnInit(): Promise<void> {
    this.userMail = this.cookieService.get("userEmail");
    console.log('User email:', this.userMail);
    // this.Folders = await this.folderService.getFoldersOfTeacher(this.userEmail);

  }

  submitSearch(searchParams: any) {
    searchParams.teacherEmail = this.userMail;
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
// achtung!! diese methode wurde 1 zu 1 kopiert aus dem question pool component. es gehört zusammengefügt
  async showFoldersList(event: { questionId: string, event: MouseEvent }) {
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
    const subjectId = await this.getSubjectIdByQuestionId(event.questionId);
console.log('Subject ID:', subjectId);
    this.Folders = await this.folderService.getFoldersOfSubject(subjectId, this.userMail);
    console.log('Folders:', this.Folders);
    this.showFolderList = true;
    this.popupTop = `${event.event.clientY}px`;
    this.popupLeft = `${event.event.clientX}px`;
    this.selectedQuestionId = event.questionId;
    this.foldersPopupComponent.checkQuestionsInFolders(); // Update the popup component whenever the folder list is shown
  }
  public getSubjectIdByQuestionId(questionId: string): Promise<string> {
    return new Promise((resolve, reject) => {
        // Find the question with the given ID in the list of public questions.
        const question = this.publicQuestions.find(q => q.id === questionId);
        if (!question) {
            reject('Question not found');
            return;
        }
        // Fetch the subject using the subject service and resolve or reject the promise based on the result.
        this.subjectService.getSubjectByTopic(question.topic).subscribe({
            next: (data) => {
                console.log('Subject fetched:', data);
                resolve(data.id);
            },
            error: (error: string) => {
                console.error('Error fetching subject:', error);
                reject(error);
            }
        });
    });
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
    console.log('Show/hide question popup:', event.questionId); // Debugging
  
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
  
    this.popupTop = `${top}px`;
    this.popupLeft = `${left}px`;
    this.showHideConfirm = true;
    this.selectedQuestionId = event.questionId;
  
    console.log('Popup position:', this.popupTop, this.popupLeft); // Debugging
    console.log('showHideConfirm:', this.showHideConfirm); // Debugging
  }

  hideQuestion() {
    console.log('Frage wird ausgeblendet.');

    this.questionService.hideQuestionByTeacher(this.selectedQuestionId, this.userMail).subscribe({
      next: (data) => {
        console.log('Question hidden:', data);
        this.notificationService.showSuccess('Frage ausgeblendet');
        this.publicQuestions = this.publicQuestions.filter(q => q.id !== this.selectedQuestionId);
        this.showHideConfirm = false;
      }
    });
  }
}
