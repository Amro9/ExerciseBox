import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { TeacherAPIConnection } from '../../Services/api-services/TeacherAPIConnection';
import { Teacher } from '../../Entities/Teacher';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-teacher-manager',
  templateUrl: './teacher-manager.component.html',
  styleUrl: './teacher-manager.component.css'
})
export class TeacherManagerComponent implements OnInit{




onPasswordReset() {
throw new Error('Method not implemented.');
}
onChangePassword() {
throw new Error('Method not implemented.');
}
onAddTeacher() {
throw new Error('Method not implemented.');
}


  userMail : string = ""; 
  Teachers! : Teacher[];
  selectedTeacher : Teacher = new Teacher("","","","");

  constructor (
    private cookieService : CookieService,
    private teacherService : TeacherAPIConnection,
    private modal : NgbModal
  )
  {
    
    this.userMail = this.cookieService.get("userEmail");
  }
  
  async ngOnInit(): Promise<void> {
    this.Teachers = await this.teacherService.getTeachersOfSchool(this.userMail);
  }

  onEditTeacher(teacher : Teacher, content: any) {
    this.selectedTeacher = teacher;
    this.modal.open(content , {ariaLabelledBy: 'modal-basic-title', centered: true});
  }

  onSaveTeacher() {
    throw new Error('Method not implemented.');
  }

  onDeactivateTeacher() {
    this.teacherService.deactivateTeacher(this.selectedTeacher.email).then(() => {
      const teacher = this.Teachers.find(t => t.email !== this.selectedTeacher.email);
      if (teacher) {
        teacher.isActive = false;
      }
    });
  }

  onActivateTeacher() {
    this.teacherService.activateTeacher(this.selectedTeacher.email).then(() => {
      const teacher = this.Teachers.find(t => t.email !== this.selectedTeacher.email);
      if (teacher) {
        teacher.isActive = true;
      }
    });
  }

  getState(teacher: Teacher) : string {
    return teacher.isActive ? "Active" : "Inactive";
  }
}
