import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { map, Observable } from 'rxjs';
import { AccountService } from './services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {


constructor(private accountService : AccountService) {

  
}
  canActivate():Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map(user => {
        if(user) {
         return true;}
         else
         {
           window.confirm("Bad Request")
           return false;
         }
       
      })
    )
  }
  
}
