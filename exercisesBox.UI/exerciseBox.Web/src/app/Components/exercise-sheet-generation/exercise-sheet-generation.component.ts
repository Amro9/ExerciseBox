import { Component, OnInit } from '@angular/core';
import { Question } from '../../Entities/Question';
import { Folder } from '../../Entities/Folder';
import { FolderService } from '../../Services/api-services/Folder.Service';
import { Session } from '../../Entities/Session';
import { SessionProvider } from '../../Services/SessionProvider';
import { QuestionService } from '../../Services/api-services/question.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ExerciseSheetService } from '../../Services/api-services/exerciseSheet.service';

@Component({
  selector: 'app-exercise-sheet-generation',
  templateUrl: './exercise-sheet-generation.component.html',
  styleUrl: './exercise-sheet-generation.component.css'
})
export class ExerciseSheetGenerationComponent implements OnInit{
  
  session! : Session;

  SelectedQuestions : Question[] = [];  
  Folders! : Folder[];
  selectedFolder : Folder = new Folder("0", "Select a folder", "0");

  pdfSrc: any;
  pdfBlob!: Blob;

  constructor(private folderService: FolderService, private questionService: QuestionService, private modalService: NgbModal, private exerciseSheetService: ExerciseSheetService) 
  {
    this.selectedFolder.Questions = [];
    //this.session = Session.fromJson(localStorage.getItem("session"))
    this.session = new Session("test", "2@3.com")
  }

  async ngOnInit(): Promise<void> {
    this.Folders = await this.folderService.getFoldersOfTeacher("2@3.com");
  }

  onSaveExerciseSheet() {

    throw new Error('Method not implemented.');

  }

  async onGenerateExerciseSheet(content: any) {
    try {
      this.pdfBlob = await this.exerciseSheetService.getNewExerciseSheet(this.SelectedQuestions.map(q => q.id));
      this.pdfSrc = URL.createObjectURL(this.pdfBlob);
      this.modalService.open(content, { size: 'lg' });
    } catch (error) {
      console.error('Error generating exercise sheet:', error);
    }
  }

  downloadPdf() {
    const link = document.createElement('a');
    link.href = this.pdfSrc;
    link.download = 'exercise-sheet.pdf';
    link.click();
  }

  onFolderChange() {
    this.questionService.getQuestionsByFolder(this.selectedFolder.id).subscribe(questions => this.selectedFolder.Questions = questions)
    if(this.selectedFolder.Questions === undefined)
    {
      this.selectedFolder.Questions = [];
    }
  }

  onQesionSwitchChange(event : any , question: Question) {
    if(event.checked)
    {
      this.SelectedQuestions.push(question);
    }
    else
    {
      this.SelectedQuestions = this.SelectedQuestions.filter(q => q.id !== question.id);
    }
  }
}
