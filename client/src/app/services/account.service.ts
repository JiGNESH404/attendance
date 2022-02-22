import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, ReplaySubject } from 'rxjs';
import { User } from '../models/user.model';
import {Router} from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AccountService {
baseurl = 'https://localhost:7038/api';
private currentUserSrc = new ReplaySubject<User>(1)
currentUser$ = this.currentUserSrc.asObservable();

  constructor(private http: HttpClient, private router: Router) { }
  login(model: any){
    return this.http.post<User>(this.baseurl+'/account/login', model).pipe(
      map((response: User)=>{
        const user = response;
        if(user)
        {
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUserSrc.next(user);
        }
      })
    )
  }
  setCurrentUser(user: User){
    this.currentUserSrc.next(user);
  }
  logout()
  {
    localStorage.removeItem('user')
    this.currentUserSrc.next(null);
    this.router.navigate([''])
    
  }
}
