import { Component } from '@angular/core';
import { TeacherAPIConnection } from '../../Services/TeacherAPIConnection';
import { Teacher } from '../../Entities/Teacher';

@Component({
  selector: 'app-school-view',
  templateUrl: './school-view.component.html',
  styleUrl: './school-view.component.css'
})
export class SchoolViewComponent {

  teachers : Teacher[] = [];

  constructor(private teacherService: TeacherAPIConnection) 
  {

    //sessionStorage.

    // this.teacherService.getTeachersOfSchool().subscribe(
    //   (response: any) => {
    //     console.log(response);
    //   },
    //   (error: any) => {
    //     console.log(error);
    //   }
    // );
  } 

  

}
