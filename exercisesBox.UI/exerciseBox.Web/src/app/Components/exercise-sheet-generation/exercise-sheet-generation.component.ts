import { Component, OnInit } from '@angular/core';
import { Question } from '../../Entities/Question';
import { Folder } from '../../Entities/Folder';
import { FolderService } from '../../Services/Folder.Service';
import { Session } from '../../Entities/Session';
import { SessionProvider } from '../../Services/SessionProvider';
import { QuestionService } from '../../Services/question.service';

@Component({
  selector: 'app-exercise-sheet-generation',
  templateUrl: './exercise-sheet-generation.component.html',
  styleUrl: './exercise-sheet-generation.component.css'
})
export class ExerciseSheetGenerationComponent implements OnInit{



  session! : Session;

  Questions : Question[] = [];  
  Folders! : Folder[];
  selectedFolder! : Folder;

  constructor(private folderService: FolderService, private questionService: QuestionService) 
  {
    //this.session = Session.fromJson(localStorage.getItem("session"))
    this.session = new Session("test", "2@3.com")
  }

  async ngOnInit(): Promise<void> {
    this.Folders = await this.folderService.getFoldersOfTeacher("2@3.com");
  }

  onSaveExerciseSheet() {

    throw new Error('Method not implemented.');

  }

  onGenerateExerciseSheet() {

    

  }

  onFolderChange() {
    this.questionService.getQuestionsByFolder(this.selectedFolder.id).subscribe(questions => this.Questions = questions);
  }

}
