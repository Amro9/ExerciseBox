import { Component, OnInit } from '@angular/core';
import { Folder } from '../../Entities/Folder';
import { QuestionService } from '../../Services/api-services/question.service';
import { FolderService } from '../../Services/api-services/Folder.Service';
import { CookieService } from 'ngx-cookie-service';
import { Subject } from '../../Entities/Subject';
import { Topic } from '../../Entities/Topic';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent implements OnInit{

  userMail : string = "";

  selectedFolder : Folder = new Folder("0", "Select a folder", new Topic ("0", "Select a topic", new Subject("", "", "")));

  Folders : Folder[] = [];

  constructor(private folderService: FolderService,
    private questionService: QuestionService,
    private cookieService: CookieService  
  )
  {
  
  }

  async ngOnInit(): Promise<void> {
    this.userMail = this.cookieService.get("userEmail");

    this.Folders = await this.folderService.getFoldersOfTeacher(this.userMail);
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

}
