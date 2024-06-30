import { Component } from '@angular/core';
import { AuthentificationService } from '../../Services/AuthentificationService';
import { CookieService } from 'ngx-cookie-service';
import { NotificationService } from '../../Services/general-services/notification.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrl: './change-password.component.css'
})
export class ChangePasswordComponent {
  oldPassword!: string;
  newPassword!: string;
  newPasswordRepeat!: string;

  userEmail! : string;

  constructor(private authService : AuthentificationService,
      private cookieService : CookieService,
      private notificationService : NotificationService,
      private router : Router
    ) 
  { 
    this.userEmail = this.cookieService.get("userEmail");
  }

  async onChangePassword() {
    try{
      if(await this.authService.changePassword(this.userEmail, this.oldPassword, this.newPassword)){
        this.notificationService.showSuccess("Passwort erfolgreich geändert");
        this.router.navigate(['/home']);
      }
      else{
        this.notificationService.showError("Passwort konnte nicht geändert werden");
      }
    }
    catch(error : any){
      this.notificationService.showError(error);
    }
  }
}
