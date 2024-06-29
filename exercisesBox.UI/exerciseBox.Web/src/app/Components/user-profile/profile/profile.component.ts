import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { Folder } from '../../../Entities/Folder';
import { QuestionService } from '../../../Services/api-services/question.service';
import { FolderService } from '../../../Services/api-services/Folder.Service';
import { CookieService } from 'ngx-cookie-service';
import { Subject } from '../../../Entities/Subject';
import { Topic } from '../../../Entities/Topic';
import { FoldersPopupComponent } from '../../questions-pool-components/folders-popup/folders-popup.component';
import { SubjectService } from '../../../Services/api-services/Subject.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent implements OnInit{
  @ViewChild(FoldersPopupComponent) foldersPopupComponent!: FoldersPopupComponent;
  errorMessage: string | null = null;
  userMail : string = "";

  showFolderList: boolean = false;
  showRemoveConfirm: boolean = false;
  popupTop!: string;
  popupLeft!: string;
  selectedQuestionId: string = '';

  selectedFolder?: Folder;
  Folders : Folder[] = [];
  selectedSubject : Subject = new Subject("", "", "");
  Subjects : Subject[] = [];
  DisplayedFolders : Folder[] = [];

  selectedSubjectforNewFolder: Subject = new Subject("", "", "");
  folderName: any;

  constructor(private folderService: FolderService,
    private questionService: QuestionService,
    private cookieService: CookieService,
    private elementRef: ElementRef,
    private subjectService: SubjectService,
    private modalService: NgbModal
  )
  {}

  async ngOnInit(): Promise<void> {
    this.userMail = this.cookieService.get("userEmail");
  await this.folderService.getFoldersOfTeacher(this.userMail).then(folders => {
      this.Folders = folders;
    });
    this.Subjects = await this.subjectService.getSubjectByTeacherId(this.userMail);
 }

  onFolderSubmit() {
    try{
      this.folderService.createNewFolder(this.folderName, this.selectedSubjectforNewFolder.id, this.userMail).then(
        value => {
          console.log('Folder created:', value);
          this.Folders.push(value);
          this.DisplayedFolders.push(value);
          this.modalService.dismissAll();
        },);
    }
    catch (error : any){
      this.errorMessage = error.toString();
    }

  }
  @HostListener('window:scroll', ['$event'])
  onScroll(event: Event) {
    // Schließe das Popup-Fenster für die Ordnerliste, wenn gescrollt wird
    if (this.showFolderList) {
      this.showFolderList = false;
    }

    // Schließe das Popup-Fenster für das Ausblenden der Frage, wenn gescrollt wird
    if (this.showRemoveConfirm) {
      this.showRemoveConfirm = false;
    }
  }

  @HostListener('document:click', ['$event'])
  onClick(event: MouseEvent) {
    // Schließe das Popup-Fenster für die Ordnerliste, wenn außerhalb geklickt wird
    if (this.showFolderList && !this.elementRef.nativeElement.querySelector('.popup-folder-list').contains(event.target)) {
      this.showFolderList = false;
    }

    // Schließe das Popup-Fenster für das Ausblenden der Frage, wenn außerhalb geklickt wird
    if (this.showRemoveConfirm && !this.elementRef.nativeElement.querySelector('.popup-remove-question').contains(event.target)) {
      this.showRemoveConfirm = false;
    }
  }
  openNewFolderModal(content: any) {
    this.errorMessage = null;
  
    this.modalService.open(content, { centered: true, size: 'md'});
  }

  onSubjectChange() {
    this.DisplayedFolders = this.Folders.filter(f => f.subject.id === this.selectedSubject.id);
  }

  async onFolderChange() {
    
    if (!this.selectedFolder) {
      return;
    }

    this.questionService.getQuestionsByFolder(this.selectedFolder.id).subscribe(questions => {
      console.log(this.selectedFolder);
  
      this.selectedFolder!.Questions = questions;

    });
  }

  showFoldersList(event: { questionId: string, event: MouseEvent }) {
    event.event.stopPropagation();
    this.showFolderList = true;
    this.popupTop = `${event.event.clientY}px`;
    this.popupLeft = `${event.event.clientX}px`;
    this.selectedQuestionId = event.questionId;
    this.foldersPopupComponent.checkQuestionsInFolders(); // Update the popup component whenever the folder list is shown
  }
  showRemoveQuestionConfirm(event: { questionId: string, event: MouseEvent }) {
    event.event.stopPropagation();
    this.showRemoveConfirm = true;
    this.popupTop = `${event.event.clientY}px`;
    this.popupLeft = `${event.event.clientX}px`;
    this.selectedQuestionId = event.questionId;
  }

  removeSavedQuestionFromFolder() {
    console.log('Frage wird gelöscht.');
    this.showRemoveConfirm = false;

    this.questionService.removeQuestionFromFolder(this.selectedQuestionId, this.selectedFolder!.id).subscribe({
      next: (data) => {
        this.foldersPopupComponent.checkQuestionsInFolders(); // Re-check questions in folders after removing
        this.selectedFolder!.Questions = this.selectedFolder!.Questions.filter(q => q.id !== this.selectedQuestionId);
      },
      error: (error: string) => console.error('Error removing question:', error)
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

}
