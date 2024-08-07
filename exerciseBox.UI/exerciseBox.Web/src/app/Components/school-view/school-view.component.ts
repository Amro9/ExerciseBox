import { Component } from '@angular/core';
import { TeacherService } from '../../Services/api-services/Teacher';
import { Teacher } from '../../Entities/Teacher';

@Component({
  selector: 'app-school-view',
  templateUrl: './school-view.component.html',
  styleUrl: './school-view.component.css'
})
export class SchoolViewComponent {

  teachers : Teacher[] = [];


  

}
