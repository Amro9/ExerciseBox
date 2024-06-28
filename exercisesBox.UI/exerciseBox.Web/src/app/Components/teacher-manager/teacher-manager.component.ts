import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { TeacherAPIConnection } from '../../Services/api-services/TeacherAPIConnection';
import { Teacher } from '../../Entities/Teacher';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Subject } from '../../Entities/Subject';
import { SubjectService } from '../../Services/api-services/Subject.service';

@Component({
  selector: 'app-teacher-manager',
  templateUrl: './teacher-manager.component.html',
  styleUrl: './teacher-manager.component.css'
})
export class TeacherManagerComponent implements OnInit{









onChangePassword() {
throw new Error('Method not implemented.');
}



  userMail : string = ""; 
  Teachers! : Teacher[];
  selectedTeacher : Teacher = new Teacher("","","","");

  subjectsOfTeacher : Subject[] = [];

  subjectOfSchool : Subject[] = [];
  selectedSubject : Subject = new Subject("","Schulfach auswählen","");
  displayedSchoolSubjects : Subject[] = [];

  newTeacher : Teacher = new Teacher("","","","");

  constructor (
    private cookieService : CookieService,
    private teacherService : TeacherAPIConnection,
    private modal : NgbModal,
    private subjectService : SubjectService
  )
  {
    
    this.userMail = this.cookieService.get("userEmail");
  }
  
  async ngOnInit(): Promise<void> {
    this.Teachers = await this.teacherService.getTeachersOfSchool(this.userMail);
    this.subjectOfSchool = await this.subjectService.getSubjectBySchool(this.userMail);
  }

  onEditTeacher(teacher : Teacher, content: any) {
    this.selectedTeacher = teacher;
    this.modal.open(content , {ariaLabelledBy: 'modal-basic-title', centered: true});
  }

  async onSaveTeacher() {
    this.selectedTeacher.schoolId = this.userMail;
    this.selectedTeacher.password = "";
    await this.teacherService.updateTeacher(this.selectedTeacher);
    this.modal.dismissAll();
    this.refresh();
  }

  async onDeactivateTeacher() {
    await this.teacherService.deactivateTeacher(this.selectedTeacher.email);
    this.modal.dismissAll();
    this.refresh();
  }

  async onActivateTeacher() {
    await this.teacherService.activateTeacher(this.selectedTeacher.email);
    this.modal.dismissAll();
    this.refresh();
  }

  getState(teacher: Teacher) : string {
    return teacher.isActive ? "Active" : "Inactive";
  }

  onPasswordReset() {
    
  }

  async refresh() {
    this.Teachers =  await this.teacherService.getTeachersOfSchool(this.userMail);
  }

  async refreshSubjects() {
    this.subjectsOfTeacher = await this.subjectService.getSubjectById(this.selectedTeacher.email);
  }

  async refreshSchoolSubjects() {
    this.subjectOfSchool = await this.subjectService.getSubjectBySchool(this.userMail);
    this.displayedSchoolSubjects = this.subjectOfSchool.filter(schoolSubject => 
      !this.subjectsOfTeacher.some(teacherSubject => teacherSubject.id === schoolSubject.id));
    this.displayedSchoolSubjects.push(new Subject("0", "Schulfach auswählen", "This is a dummy subject."));
    this.selectedSubject = this.displayedSchoolSubjects[this.displayedSchoolSubjects.length - 1];
  }

  async onSubjectsEdit(_t17: Teacher, content: any) {
    this.subjectsOfTeacher = await this.subjectService.getSubjectById(_t17.email);
    this.selectedTeacher = _t17;
    this.displayedSchoolSubjects = this.subjectOfSchool.filter(schoolSubject => 
      !this.subjectsOfTeacher.some(teacherSubject => teacherSubject.id === schoolSubject.id));
    this.displayedSchoolSubjects.push(new Subject("0", "Schulfach auswählen", "This is a dummy subject."));
    this.selectedSubject = this.displayedSchoolSubjects[this.displayedSchoolSubjects.length - 1];
    this.modal.open(content, {centered: true, size: 'lg'});
  }

  async onRemoveSubject(_t80: Subject) {
    await this.teacherService.removeSubjectFromTeacher(this.selectedTeacher.email, _t80.id);
    await this.refreshSubjects();
    this.refreshSchoolSubjects();
  }

  async onAddSubject() {
    if (this.selectedSubject && this.selectedSubject.id && this.selectedSubject.id !== "0") {
        await this.teacherService.addSubjectToTeacher(this.selectedTeacher.email, this.selectedSubject.id);
        this.refreshSubjects();
        this.refreshSchoolSubjects();
    } else {
        
    }
}

  onAddTeacher(content: any) {
    this.modal.open(content, {centered: true, size: 'lg'});
  }

  async onSubmitNewTeacher() {
    this.newTeacher.schoolId = this.userMail;
    await this.teacherService.addTeacher(this.newTeacher);
    this.modal.dismissAll();
    this.refresh();
  }
}
