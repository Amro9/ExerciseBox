import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email: string;
  password: string;

  constructor() {
    this.email = '';
    this.password = '';
  }

  onSubmit(): void {
    // Add your login logic here
    console.log('Email:', this.email);
    console.log('Password:', this.password);
  }
}
