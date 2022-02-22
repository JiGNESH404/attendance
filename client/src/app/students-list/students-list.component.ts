import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { User } from '../models/user.model';
import { NewStudentComponent } from '../new-student/new-student.component';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.css']
})
export class StudentsListComponent implements OnInit {

  bsModalRef: BsModalRef;

  constructor(private http: HttpClient, private accountService: AccountService,
    private router: Router, private modalService: BsModalService) { }

  users: any
  ngOnInit() {
    var token = JSON.parse( localStorage.getItem('user'));
    this.getUsers(token.token)
    this.setCurrentUsers()
  }
  addNewStudent() {
    this.router.navigate(['newStudent'])
  }
  getUsers(token: string) {
    
       this.http.get('https://localhost:7038/api/users',{
      headers:
      {
        "Authorization" : "Bearer " + token
      }
    }).subscribe((response: any) => {
      this.users = response
    }, (error: any) => {
      console.log(error)
    })
  }
  setCurrentUsers()
  {
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user)
  }

  openNewStudentModal(){
    const config = {
      class : 'modal-dialog-centered'
    }
    this.bsModalRef= this.modalService.show(NewStudentComponent, config);
  }



}
