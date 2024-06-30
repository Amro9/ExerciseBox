import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthentificationService } from './AuthentificationService';
import { Roles } from '../Infrastucture/enums';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class PasswordGuard implements CanActivate {

  constructor(private authService: AuthentificationService, private router: Router, private cookieService : CookieService) { }
  
  async canActivate(route: ActivatedRouteSnapshot): Promise<boolean> {

    if (this.authService.isLoggedIn()) {
        let userEmail = this.cookieService.get('userEmail');
        let isPasswordDefault = await this.authService.isPasswordDefault(userEmail);
        if(isPasswordDefault){
          this.router.navigate(['/changePassword']);
          return false;
        }
        return true;
    }
    return true;
  }
}
