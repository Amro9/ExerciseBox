import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthentificationService } from './Services/AuthentificationService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'exerciseBox.Web';

  constructor(private authService : AuthentificationService) {}

  async ngOnInit() {
    await this.authService.startTokenCheck();
  }
}
