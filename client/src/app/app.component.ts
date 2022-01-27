import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit
{
  title = 'Attendance';

  constructor(private http: HttpClient){}

  users: any
  ngOnInit() {
      this.getUsers()
  }

  getUsers(){
    this.http.get('https://localhost:7038/api/users').subscribe(response =>
      {
        this.users = response
      }, error=>{
        console.log(error)
      })
  }
}
