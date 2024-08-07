import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthentificationService } from './AuthentificationService';
import { Roles } from '../Infrastucture/enums';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthentificationService, private router: Router, private cookieService : CookieService) { }
  
  async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> {
    const expectedRole = route.data['expectedRole'] as Roles; 
    

    if(!this.authService.isLoggedIn()){
      this.router.navigate(['/login']);
      return false;
    }
    
    let isPasswordDefault : boolean = false;

    if(this.authService.hasRole(Roles.School)){
      isPasswordDefault = false;
    }
    else{
      let userEmail = this.cookieService.get('userEmail');
      isPasswordDefault = await this.authService.isPasswordDefault(userEmail);
    }

    if (this.authService.isLoggedIn() && this.authService.hasRole(expectedRole) && !isPasswordDefault) {
      return true;
    } else {
      if(isPasswordDefault){
        this.router.navigate(['/changePassword']);
        return false;
      }
      if(this.authService.isLoggedIn()){
        this.router.navigate(['/home']);
        return false;
      }
      else{
        this.router.navigate(['/login']);
        return false;
      }
    }
  }
}
