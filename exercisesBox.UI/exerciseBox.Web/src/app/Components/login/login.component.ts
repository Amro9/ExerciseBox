import { Component } from '@angular/core';
import { Teacher } from '../../Entities/Teacher';
import { TeacherAPIConnection } from '../../Services/TeacherAPIConnection';
import { Router } from '@angular/router';
import { setAlternateWeakRefImpl } from '@angular/core/primitives/signals';

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

  errorMessage: string | null = null;

  onSubmit(): void {
  

    this.teacherAPIConnection.getTeacherWithPasswordValidation(this.teacher.email, this.teacher.password).subscribe(
      (response: Teacher) => {
        let teacher = response
        
        sessionStorage.setItem('teacher', JSON.stringify(teacher));

        this.router.navigate(['/home']); 
      },
      (error: any) => {
        this.errorMessage = error;
      }
    );
  }
}
