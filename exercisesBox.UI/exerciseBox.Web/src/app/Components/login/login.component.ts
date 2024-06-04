import { Component } from '@angular/core';
import { Teacher } from '../../Entities/Teacher';
import { TeacherAPIConnection } from '../../Services/TeacherAPIConnection';
import { Router } from '@angular/router';
import { HashGenerator } from '../../Services/HashGenerator';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  teacher! : Teacher;
  
  constructor(private teacherAPIConnection: TeacherAPIConnection, private router: Router) {
    this.teacher = new Teacher("","","","");
  }

  onSubmit(): void {
  

    this.teacherAPIConnection.getTeacherbyEmail(this.teacher.email).subscribe(
      (response: Teacher) => {
        let teacher = response
        
        if (teacher === null) {
          alert('Teacher not found');
          return;
        }

        if (teacher.password !== HashGenerator.generateHash(this.teacher.password)) {
          console.log(HashGenerator.generateHash(this.teacher.password));

          alert('Incorrect password');
          return;
        }

        sessionStorage.setItem('teacher', JSON.stringify(this.teacher));

        this.router.navigate(['/home']); 
      },
      (error: any) => {
        console.log(error);
      }
    );
  }
}
