import { Component } from '@angular/core';
import { TeacherAPIConnection } from '../../Services/api-services/TeacherAPIConnection';
import { Teacher } from '../../Entities/Teacher';

@Component({
  selector: 'app-school-view',
  templateUrl: './school-view.component.html',
  styleUrl: './school-view.component.css'
})
export class SchoolViewComponent {

  teachers : Teacher[] = [];


  

}
