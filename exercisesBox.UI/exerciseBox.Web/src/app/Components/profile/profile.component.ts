import { Component, OnInit, ViewChild } from '@angular/core';
import { Folder } from '../../Entities/Folder';
import { QuestionService } from '../../Services/api-services/question.service';
import { FolderService } from '../../Services/api-services/Folder.Service';
import { CookieService } from 'ngx-cookie-service';
import { Subject } from '../../Entities/Subject';
import { Topic } from '../../Entities/Topic';
import { FoldersPopupComponent } from '../questions-pool-components/folders-popup/folders-popup.component';
import { SubjectService } from '../../Services/api-services/Subject.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent implements OnInit{



  errorMessage: string | null = null;


  userMail : string = "";

  showFolderList: boolean = false;
  showHideConfirm: boolean = false;
  popupTop!: string;
  popupLeft!: string;
  selectedQuestionId: string = '';

  @ViewChild(FoldersPopupComponent) foldersPopupComponent!: FoldersPopupComponent;


  selectedFolder : Folder = new Folder("0", "Select a folder", new Subject("", "", ""), false);
  Folders : Folder[] = [];
  selectedSubject : Subject = new Subject("", "", "");
  Subjects : Subject[] = [];
  DisplayedFolders : Folder[] = [];

  selectedSubjectforNewFolder: Subject = new Subject("", "", "");
  folderName: any;

  constructor(private folderService: FolderService,
    private questionService: QuestionService,
    private cookieService: CookieService,
    private subjectService: SubjectService,
    private modalService: NgbModal
  )
  {
  
  }

  async ngOnInit(): Promise<void> {
    this.userMail = this.cookieService.get("userEmail");
    await this.folderService.getFoldersOfTeacher(this.userMail).then(folders => {
      this.Folders = folders;
    });
    this.Subjects = await this.subjectService.getSubjectById(this.userMail);
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

  openNewFolderModal(content: any) {
    this.errorMessage = null;
  
    this.modalService.open(content, { centered: true, size: 'md'});
  }

  onSubjectChange() {
    this.DisplayedFolders = this.Folders.filter(f => f.subject.id === this.selectedSubject.id);
  }

  onFolderChange() {
    if(this.selectedFolder.Questions !== undefined){
      if(this.selectedFolder.Questions.length > 0){
        return;
      }
    }
    this.questionService.getQuestionsByFolder(this.selectedFolder.id).subscribe(questions => this.selectedFolder.Questions = questions)
    if(this.selectedFolder.Questions === undefined)
    {
      this.selectedFolder.Questions = [];
    }
  }

  showFoldersList(event: { questionId: string, event: MouseEvent }) {
    event.event.stopPropagation();
    this.showFolderList = true;
    this.popupTop = `${event.event.clientY}px`;
    this.popupLeft = `${event.event.clientX}px`;
    this.selectedQuestionId = event.questionId;
    this.foldersPopupComponent.checkQuestionsInFolders(); // Update the popup component whenever the folder list is shown
  }

  hideQuestion() {
    console.log('Frage wird ausgeblendet.');
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
