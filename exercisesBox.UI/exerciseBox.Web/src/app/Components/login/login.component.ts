import { Component } from '@angular/core';
import { Teacher } from '../../Entities/Teacher';
import { TeacherAPIConnection } from '../../Services/TeacherAPIConnection';
import { Router } from '@angular/router';
import { setAlternateWeakRefImpl } from '@angular/core/primitives/signals';
import { AuthentificationService } from '../../Services/AuthentificationService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  teacher! : Teacher;
  
  constructor(private authService: AuthentificationService, private router: Router) {
    this.teacher = new Teacher("","","","");
  }

  errorMessage: string | null = null;

  onSubmit(): void {
  

    this.authService.login(this.teacher.email, this.teacher.password)
  }
}
