import { Component } from '@angular/core';
import { AuthentificationService } from '../../Services/AuthentificationService';
import { Roles } from '../../Infrastucture/enums';

@Component({
  selector: 'app-navbar',
  // standalone: true,
  // imports: [],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  constructor(public authService: AuthentificationService) { }

  userIsLoggedIn() {
    return this.authService.isLoggedIn();
  }

  userIsTeacher() {
    return this.authService.hasRole(Roles.Teacher);
  }
  
  userIsSchool() {
      return this.authService.hasRole(Roles.School);
  }


}
