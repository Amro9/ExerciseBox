import { Component, OnInit } from '@angular/core';
import { Question } from '../../Entities/Question';
import { Folder } from '../../Entities/Folder';
import { FolderService } from '../../Services/api-services/Folder.Service';
import { Session } from '../../Entities/Session';
import { QuestionService } from '../../Services/api-services/question.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ExerciseSheetService } from '../../Services/api-services/exerciseSheet.service';
import { Subject } from '../../Entities/Subject';
import { ExerciseSheet } from '../../Entities/ExerciseSheet';
import { SubjectService } from '../../Services/api-services/Subject.service';
import { Topic } from '../../Entities/Topic';


@Component({
  selector: 'app-exercise-sheet-generation',
  templateUrl: './exercise-sheet-generation.component.html',
  styleUrl: './exercise-sheet-generation.component.css'
})
export class ExerciseSheetGenerationComponent implements OnInit{


  
  session! : Session;

  SelectedQuestions : Question[] = [];  
  Folders! : Folder[];
  DisplayedFolders! : Folder[];
  selectedFolder : Folder = new Folder("0", "Select a folder", new Topic ("0", "Select a topic", new Subject("", "", "")), false);
  selectedSubject : Subject = new Subject("", "", "");

  Subjects : Subject[] = [];

  WorkSheetHeaderOptions : Array<{Text: string, Value: number}> = 
  [ 
    { Text : "Nur Name", Value : 1}, 
    { Text : "Name und Datum", Value : 2},
    { Text : "Name und Note", Value : 3},
    { Text : "Name, Datum und Note", Value : 4},  
  ]
    
  selectedWorkSheetOption : number = 0;

  ExerciseSheet : ExerciseSheet = new ExerciseSheet("0", "");

  pdfSrc: any;
  pdfBlob!: Blob;

  sessionKey : string = "";

  constructor(private folderService: FolderService,
     private questionService: QuestionService,
      private modalService: NgbModal, 
      private exerciseSheetService: ExerciseSheetService,
      private subjectService: SubjectService
    ) 
  {
    this.selectedFolder.Questions = [];
    //this.session = Session.fromJson(localStorage.getItem("session"))
    
  }

  async ngOnInit(): Promise<void> {
    this.Folders = await this.folderService.getFoldersOfTeacher("2@3.com");
    this.Subjects = await this.subjectService.getSubjectById("2@3.com");
  }

  onSaveExerciseSheet() {

    throw new Error('Method not implemented.');

  }

  getQuestionDifficultyLevelCount(difficulty: number) : number {
    if(this.SelectedQuestions !== undefined && this.SelectedQuestions.length > 0){
      if(difficulty === 1)
      {
        return this.SelectedQuestions.filter(q => q.difficultyLevelDto.id === "4c4731a6-4456-4fdf-af73-80123016e7a1").length
      }
      else if(difficulty === 2)
      {
        return this.SelectedQuestions.filter(q => q.difficultyLevelDto.id === "aff14e35-bf94-47c5-89e5-1ca1e7ebcde4").length
      }
      else if(difficulty === 3)
      {
        return this.SelectedQuestions.filter(q => q.difficultyLevelDto.id === "bd04180b-ef00-427e-824b-288650098130").length
      }
    }
    return 0;
  }

  async onGenerateExerciseSheet(content: any) {
    try {
      this.pdfBlob = await this.exerciseSheetService.getNewExerciseSheet(this.SelectedQuestions.map(q => q.id), this.ExerciseSheet);
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

  onSubjectChange() {
   
    this.DisplayedFolders = this.Folders.filter(f => f.topic.subject.id === this.selectedSubject.id);

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

  onWorkSheetOptionChange() {
    if(this.selectedWorkSheetOption === 1)
    {
      this.ExerciseSheet.namePlaceHolder = true;
      this.ExerciseSheet.datePlaceHolder = false;
      this.ExerciseSheet.markPlaceHolder = false;
    }
    else if(this.selectedWorkSheetOption === 2)
    {
      this.ExerciseSheet.namePlaceHolder = true;
      this.ExerciseSheet.datePlaceHolder = true;
      this.ExerciseSheet.markPlaceHolder = false;
    }
    else if(this.selectedWorkSheetOption === 3)
    {
      this.ExerciseSheet.namePlaceHolder = true;
      this.ExerciseSheet.markPlaceHolder = true;
      this.ExerciseSheet.datePlaceHolder = false;
    }
    else if(this.selectedWorkSheetOption === 4)
    {
      this.ExerciseSheet.namePlaceHolder = true;
      this.ExerciseSheet.datePlaceHolder = true;
      this.ExerciseSheet.markPlaceHolder = true;
    }
  }
}
