import { Component, ElementRef, HostListener } from '@angular/core';
import { Question } from '../../../Entities/Question';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Folder } from '../../../Entities/Folder';
import { FolderService } from '../../../Services/api-services/Folder.Service';
import { QuestionService } from '../../../Services/api-services/question.service';
@Component({
  selector: 'app-questions-pool',
  templateUrl: './questions-pool.component.html',
  styleUrl: './questions-pool.component.css'
})
export class QuestionsPoolComponent {
  publicQuestions: Question[] = [];
  Folders: Folder[] = [];
  showFolderList: boolean = false;
  popupTop!: string;
  popupLeft!: string;

  constructor(
    private fb: FormBuilder,
    private questionService: QuestionService,
    private folderService: FolderService,
    private elementRef: ElementRef
  ) {}

  async ngOnInit(): Promise<void> {
    this.Folders = await this.folderService.getFoldersOfTeacher("1@2.com");
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

  showFoldersList(event: MouseEvent) {
    event.stopPropagation();
    this.showFolderList = true;
    this.popupTop = `${event.clientY}px`;
    this.popupLeft = `${event.clientX}px`;
  }

  saveQuestion(folder: string) {
    console.log(`Frage wird in ${folder} gespeichert.`);
    this.showFolderList = false;
  }

  hideQuestion() {
    console.log('Frage wird ausgeblendet.');
  }

}