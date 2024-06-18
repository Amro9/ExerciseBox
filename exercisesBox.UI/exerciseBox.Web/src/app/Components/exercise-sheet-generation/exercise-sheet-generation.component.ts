import { Component, OnInit } from '@angular/core';
import { Question } from '../../Entities/Question';
import { Folder } from '../../Entities/Folder';
import { FolderService } from '../../Services/Folder.Service';
import { Session } from '../../Entities/Session';
import { SessionProvider } from '../../Services/SessionProvider';

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

  constructor(private folderService: FolderService) 
  {
    //this.session = Session.fromJson(localStorage.getItem("session"))
    this.session = new Session("test", "2@3.com")
  }

  async ngOnInit(): Promise<void> {
    this.Folders = await this.folderService.getFoldersOfTeacher(this.session.SessionIdKey);
  }

  onSaveExerciseSheet() {

    throw new Error('Method not implemented.');

  }

  onGenerateExerciseSheet() {

    

  }

}
