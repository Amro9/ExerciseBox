import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthentificationService } from './AuthentificationService';
import { Roles } from '../Infrastucture/enums';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthentificationService, private router: Router) { }
  
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const expectedRole = route.data['expectedRole'] as Roles; 

    if (this.authService.isLoggedIn() && this.authService.hasRole(expectedRole)) {
      return true;
    } else {
      this.router.navigate(['/login']);
      return false;
    }
  }
}
