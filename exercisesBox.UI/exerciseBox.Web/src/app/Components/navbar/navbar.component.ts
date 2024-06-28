import { Component } from '@angular/core';
import { AuthentificationService } from '../../Services/AuthentificationService';
import { Roles } from '../../Infrastucture/enums';
import { RoundOffsets } from '@popperjs/core/lib/modifiers/computeStyles';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  // standalone: true,
  // imports: [],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
onProfileBtnClick() {
throw new Error('Method not implemented.');
}
  onLogout() {
    this.authService.logout();
    this.router.navigate(['/home']);
  }

  constructor(public authService: AuthentificationService, private router: Router) { }

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
