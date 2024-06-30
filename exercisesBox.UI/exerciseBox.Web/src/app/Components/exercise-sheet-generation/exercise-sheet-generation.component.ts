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
import { FolderPickModel } from '../../Entities/FolderPickModel';
import { QuestionPickModel } from '../../Entities/QuestionPickModel';
import { NotificationService } from '../../Services/general-services/notification.service';
import { CookieService } from 'ngx-cookie-service';


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
  selectedFolder : FolderPickModel = new FolderPickModel(new Folder("", "", new Subject("", "", ""), false),false, []);
  selectedSubject : Subject = new Subject("", "", "");

  Subjects : Subject[] = [];

  MaxQuestionCount: number = 0;
  EasyQuestionCount: number = 0;
  MediumQuestionCount: number = 0;
  HardQuestionCount: number = 0;

  IsRandomPick: boolean = false;
  WithAnswers : boolean = false;

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

  userEmail : string = "";

  constructor(private folderService: FolderService,
     private questionService: QuestionService,
      private modalService: NgbModal, 
      private exerciseSheetService: ExerciseSheetService,
      private subjectService: SubjectService,
      private notificationService: NotificationService,
      private cookieService: CookieService
    ) 
  {
    this.selectedFolder.QuestionPickModels = [];
    //this.session = Session.fromJson(localStorage.getItem("session"))
    
  }

  async ngOnInit(): Promise<void> {
    this.userEmail = this.cookieService.get("userEmail");
    this.Folders = await this.folderService.getFoldersOfTeacher(this.userEmail);
    this.Subjects = await this.subjectService.getSubjectByTeacherId(this.userEmail);
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
  getQuestionDifficultyTotal(difficulty: number) : number {
    if(this.selectedFolder.QuestionPickModels !== undefined && this.selectedFolder.QuestionPickModels.length > 0){
      if(difficulty === 1)
      {
        return this.selectedFolder.QuestionPickModels.filter(q => q.Question.difficultyLevelDto.id === "4c4731a6-4456-4fdf-af73-80123016e7a1").length
      }
      else if(difficulty === 2)
      {
        return this.selectedFolder.QuestionPickModels.filter(q => q.Question.difficultyLevelDto.id=== "aff14e35-bf94-47c5-89e5-1ca1e7ebcde4").length
      }
      else if(difficulty === 3)
      {
        return this.selectedFolder.QuestionPickModels.filter(q => q.Question.difficultyLevelDto.id === "bd04180b-ef00-427e-824b-288650098130").length
      }
    }
    return 0;
  }

  async onGenerateExerciseSheet(content: any) {
    try {
      this.pdfBlob = await this.exerciseSheetService.getNewExerciseSheet(this.SelectedQuestions.map(q => q.id), this.ExerciseSheet, this.WithAnswers);
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

  async getQuestion(){
    
  }

  async onFolderChange() {
    this.selectedFolder.QuestionPickModels = [];
    if(this.selectedFolder.folder.Questions !== undefined){
      if(this.selectedFolder.folder.Questions.length > 0){
        this.selectedFolder.QuestionPickModels = this.selectedFolder.folder.Questions.map(q => new QuestionPickModel(q, false));
        return;
      }
    }
    this.selectedFolder.folder.Questions = await this.questionService.getQuestionsByFolderPromise(this.selectedFolder.folder.id);
    if(this.selectedFolder.folder.Questions !== undefined && this.selectedFolder.folder.Questions.length > 0){
      this.selectedFolder.QuestionPickModels = this.selectedFolder.folder.Questions.map(q => new QuestionPickModel(q, false));
    }
    if(this.selectedFolder.QuestionPickModels === undefined)
    {
      this.selectedFolder.QuestionPickModels = [];
    }
  }

  onSubjectChange() {
   
    this.DisplayedFolders = this.Folders.filter(f => f.subject.id === this.selectedSubject.id);

  }

  onRandomPick(content : any) {
    this.modalService.open(content, { size: 'lg', centered: true });
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

  onMaxQuestionCountChange() {
    if(this.MaxQuestionCount > this.selectedFolder.QuestionPickModels.length)
    {
      this.notificationService.showError("Die maximale Anzahl der Fragen kann nicht größer sein als die Anzahl der ausgewählten Fragen");
      this.MaxQuestionCount = this.selectedFolder.QuestionPickModels.length;
    }
  }

  onEasyQuestionCountChange() {
    if(this.EasyQuestionCount + this.MediumQuestionCount + this.HardQuestionCount > this.selectedFolder.QuestionPickModels.length){
      this.notificationService.showError("Die Anzahl der Fragen kann nicht größer sein als die maximale Anzahl der Fragen");
      this.EasyQuestionCount = this.getQuestionDifficultyTotal(1);
    }
    else{
      if(this.EasyQuestionCount > this.getQuestionDifficultyTotal(1))
        {
          this.notificationService.showError("Die Anzahl der einfachen Fragen kann nicht größer sein als die Anzahl der einfachen Fragen im Ordner");
          this.EasyQuestionCount = this.getQuestionDifficultyTotal(1);
        }
    }
  }

  onMediumQuestionCountChange() {
    if(this.MediumQuestionCount + this.EasyQuestionCount + this.HardQuestionCount > this.selectedFolder.QuestionPickModels.length){
      this.notificationService.showError("Die Anzahl der Fragen kann nicht größer sein als die maximale Anzahl der Fragen");
      this.MediumQuestionCount = this.getQuestionDifficultyTotal(2);
    }
    else{
      if(this.MediumQuestionCount > this.getQuestionDifficultyTotal(2))
      {
        this.notificationService.showError("Die Anzahl der mittelschweren Fragen kann nicht größer sein als die Anzahl der mittelschweren Fragen im Ordner");
        this.MediumQuestionCount = this.getQuestionDifficultyTotal(2);
      }
    }
  }

  onHardQuestionCountChange() {
    if(this.HardQuestionCount + this.EasyQuestionCount + this.MediumQuestionCount > this.selectedFolder.QuestionPickModels.length){
      this.notificationService.showError("Die Anzahl der Fragen kann nicht größer sein als die maximale Anzahl der Fragen");
      this.HardQuestionCount = this.getQuestionDifficultyTotal(3);
    }
    else{
      if(this.HardQuestionCount > this.getQuestionDifficultyTotal(3))
      {
        this.notificationService.showError("Die Anzahl der schweren Fragen kann nicht größer sein als die Anzahl der schweren Fragen im Ordner");
        this.HardQuestionCount = this.getQuestionDifficultyTotal(3);
      }
    }
  }

  onRandomPickSubmit() {

    this.selectedFolder.QuestionPickModels.forEach(q => q.IsSelected = false);

    this.SelectedQuestions = [];
    if(this.IsRandomPick)
    {
      let easyQuestions = this.selectedFolder.QuestionPickModels.filter(q => q.Question.difficultyLevelDto.id === "4c4731a6-4456-4fdf-af73-80123016e7a1");
      let mediumQuestions = this.selectedFolder.QuestionPickModels.filter(q => q.Question.difficultyLevelDto.id === "aff14e35-bf94-47c5-89e5-1ca1e7ebcde4");
      let hardQuestions = this.selectedFolder.QuestionPickModels.filter(q => q.Question.difficultyLevelDto.id === "bd04180b-ef00-427e-824b-288650098130");
      let randomEasyQuestions = this.shuffle(easyQuestions).slice(0, this.EasyQuestionCount);
      let randomMediumQuestions = this.shuffle(mediumQuestions).slice(0, this.MediumQuestionCount);
      let randomHardQuestions = this.shuffle(hardQuestions).slice(0, this.HardQuestionCount);
      this.SelectedQuestions = this.SelectedQuestions.concat(randomEasyQuestions.map(q => q.Question));
      this.SelectedQuestions = this.SelectedQuestions.concat(randomMediumQuestions.map(q => q.Question));
      this.SelectedQuestions = this.SelectedQuestions.concat(randomHardQuestions.map(q => q.Question));

      this.SelectedQuestions.forEach(q => {
        let questionPickModel = this.selectedFolder.QuestionPickModels.find(qpm => qpm.Question.id === q.id);
        if(questionPickModel !== undefined)
        {
          questionPickModel.IsSelected = true;
        }
      }, this);
    }
    else
    {
      this.SelectedQuestions = this.selectedFolder.QuestionPickModels.filter(q => q.IsSelected).map(q => q.Question);
    }
  }

  shuffle(array: any[]) {
    let currentIndex = array.length, randomIndex;
    while (currentIndex !== 0) {
      randomIndex = Math.floor(Math.random() * currentIndex);
      currentIndex--;
      [array[currentIndex], array[randomIndex]] = [array[randomIndex], array[currentIndex]];
    }
    return array;
  }

}
