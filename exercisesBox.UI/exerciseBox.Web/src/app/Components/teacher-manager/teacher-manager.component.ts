import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { TeacherService } from '../../Services/api-services/Teacher';
import { Teacher } from '../../Entities/Teacher';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Subject } from '../../Entities/Subject';
import { SubjectService } from '../../Services/api-services/Subject.service';
import { SchoolBranch } from '../../Entities/SchoolBranch';
import { SchoolService } from '../../Services/api-services/school.service';
import { AuthentificationService } from '../../Services/AuthentificationService';
import { NotificationService } from '../../Services/general-services/notification.service';

@Component({
  selector: 'app-teacher-manager',
  templateUrl: './teacher-manager.component.html',
  styleUrl: './teacher-manager.component.css'
})
export class TeacherManagerComponent implements OnInit{




  schoolBranches : SchoolBranch[] = [];
  selectedBranche : SchoolBranch = new SchoolBranch("","");

  userMail : string = ""; 
  Teachers! : Teacher[];
  selectedTeacher : Teacher = new Teacher("","","","","");

  subjectsOfTeacher : Subject[] = [];

  subjectOfBranche : Subject[] = [];
  selectedSubject : Subject = new Subject("","Schulfach auswählen","");
  displayedSchoolSubjects : Subject[] = [];

  newTeacher : Teacher = new Teacher("","","","","");

  newTeacherFildNotFilled : boolean = false;

  newPassword!: string;
  newPasswordRepeat!: string;
  PasswordChangeBool: boolean = false;

  constructor (
    private cookieService : CookieService,
    private teacherService : TeacherService,
    private modal : NgbModal,
    private subjectService : SubjectService,
    private schoolService : SchoolService,
    private authService : AuthentificationService,
    private notificationService : NotificationService,
  )
  {
    
    this.userMail = this.cookieService.get("userEmail");
  }
  
  async ngOnInit(): Promise<void> {
    this.schoolBranches = await this.schoolService.getBranchesOfSchool(this.userMail);
    this.schoolBranches.push(new SchoolBranch("", "Schulzweig auswählen"));
    this.selectedBranche = this.schoolBranches[this.schoolBranches.length - 1];
    this.Teachers = await this.teacherService.getTeachersOfSchool(this.userMail);
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
    this.teacherService.resetPassword(this.selectedTeacher.email);
  }

  onPasswordChangePress() {
    if(!this.PasswordChangeBool) {
      this.PasswordChangeBool = true;
    }
    else {
      this.PasswordChangeBool = false;
    }
  }

  async onChangePassword() {
    if(this.newPassword !== this.newPasswordRepeat) {
      this.notificationService.showError("Passwörter stimmen nicht überein");
      return;
    }
    this.PasswordChangeBool = false;
    if(await this.authService.changePassword(this.selectedTeacher.email, this.selectedTeacher.password, this.newPassword, true)) {
      this.notificationService.showSuccess("Passwort erfolgreich geändert");
      this.newPassword = "";
      this.newPasswordRepeat = "";
    } else {
      this.notificationService.showError("Passwort konnte nicht geändert werden");
    }
  }

  async refresh() {
    this.Teachers =  await this.teacherService.getTeachersOfSchool(this.userMail);
  }

  async refreshSubjects() {
    this.subjectsOfTeacher = await this.subjectService.getSubjectByTeacherId(this.selectedTeacher.email);
  }

  async refreshSchoolSubjects() {
    this.subjectOfBranche = await this.subjectService.getSubjectByBranch(this.selectedTeacher.branch);
    this.displayedSchoolSubjects = this.subjectOfBranche.filter(schoolSubject => 
      !this.subjectsOfTeacher.some(teacherSubject => teacherSubject.id === schoolSubject.id));
    this.displayedSchoolSubjects.push(new Subject("0", "Schulfach auswählen", "This is a dummy subject."));
    this.selectedSubject = this.displayedSchoolSubjects[this.displayedSchoolSubjects.length - 1];
  }

  async onSubjectsEdit(_t17: Teacher, content: any) {
    this.selectedTeacher = _t17;
    this.subjectOfBranche = await this.subjectService.getSubjectByBranch(this.selectedTeacher.branch);
    this.subjectsOfTeacher = await this.subjectService.getSubjectByTeacherId(_t17.email);
    this.displayedSchoolSubjects = this.subjectOfBranche.filter(schoolSubject => 
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
    this.newTeacherFildNotFilled = false;
    if(this.newTeacher.email !== "" || this.newTeacher.surname !== "" || this.newTeacher.givenname !== "" || this.selectedBranche.id !== "") {
      this.newTeacher.schoolId = this.userMail;
      await this.teacherService.addTeacher(this.newTeacher);
      this.modal.dismissAll();
      this.refresh();
    }
    else{
      this.newTeacherFildNotFilled = true;
    }
  }
}
