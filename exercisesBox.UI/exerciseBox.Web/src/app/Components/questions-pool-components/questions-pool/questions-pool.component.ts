import { Component, ElementRef, HostListener } from '@angular/core';
import { Question } from '../../../Entities/Question';
import { FormBuilder } from '@angular/forms';
import { Folder } from '../../../Entities/Folder';
import { FolderService } from '../../../Services/api-services/Folder.Service';
import { QuestionService } from '../../../Services/api-services/question.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-questions-pool',
  templateUrl: './questions-pool.component.html',
  styleUrls: ['./questions-pool.component.css']
})
export class QuestionsPoolComponent {
  publicQuestions: Question[] = [];
  Folders: Folder[] = [];
  showFolderList: boolean = false;
  popupTop!: string;
  popupLeft!: string;
  selectedQuestionId: string = '';

  userEmail! : string;

  constructor(
    private fb: FormBuilder,
    private questionService: QuestionService,
    private folderService: FolderService,
    private elementRef: ElementRef,
    private cookieService: CookieService 
  ) {}

  async ngOnInit(): Promise<void> {
    this.userEmail = this.cookieService.get("userEmail");
    this.Folders = await this.folderService.getFoldersOfTeacher(this.userEmail);
  }

  submitSearch(searchParams: any) {
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
    if (this.showFolderList) {
      this.showFolderList = false;
    }
  }

  @HostListener('document:click', ['$event'])
  onClick(event: MouseEvent) {
    if (this.showFolderList && !this.elementRef.nativeElement.querySelector('.popup-folder-list').contains(event.target)) {
      this.showFolderList = false;
    }
  }

  showFoldersList(event: { questionId: string, event: MouseEvent }) {
    event.event.stopPropagation();
    this.showFolderList = true;
    this.popupTop = `${event.event.clientY}px`;
    this.popupLeft = `${event.event.clientX}px`;
    this.selectedQuestionId = event.questionId;
  }

  saveQuestion(folderId: string) {
    console.log(`Frage wird in ${folderId} gespeichert.`);
    this.showFolderList = false;

    this.questionService.saveQuestionToFolder(this.selectedQuestionId, folderId).subscribe({
      next: (data) => {
        console.log('Question saved:', data);
        this.updateFoldersPopup();
      },
      error: (error: string) => console.error('Error saving question:', error)
    });
  }
  updateFoldersPopup() {
    const foldersPopupComponent = this.elementRef.nativeElement.querySelector('app-folders-popup');
    if (foldersPopupComponent) {
      foldersPopupComponent.checkQuestionsInFolders();
    }
  }
  hideQuestion() {
    console.log('Frage wird ausgeblendet.');
  }
}
