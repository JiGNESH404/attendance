import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './models/user.model';
import { AccountService } from './services/account.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit
{
  showContent : boolean | undefined
  title = 'Attendance';

  constructor(private http: HttpClient, private accountService: AccountService){}

  users: any
  ngOnInit() {
      /* this.getUsers() */
      this.setCurrentUsers()
  }

  getUsers(){
    this.http.get('https://localhost:7038/api/users').subscribe(response =>
      {
        this.users = response
      }, error=>{
        console.log(error)
      })
  }
  setCurrentUsers()
  {
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user)
  }
}
