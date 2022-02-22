import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  model: any = {};
  currentUser: Observable<User>;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.currentUser = this.accountService.currentUser$;
  }
  signin() {
    console.log(this.model)
    this.accountService.login(this.model).subscribe(response => {
    }, error => {
      console.log(error);
    })
    
    

  }
  logout() {

    this.accountService.logout()
    
  }

}
