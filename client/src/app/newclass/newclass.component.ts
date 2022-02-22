import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-newclass',
  templateUrl: './newclass.component.html',
  styleUrls: ['./newclass.component.css']
})
export class NewclassComponent implements OnInit {
  model: any = { }
  baseurl = 'https://localhost:7038/api';
  constructor(public bsModalRef: BsModalRef, private http: HttpClient) { }

  ngOnInit(): void {
  }
  onSubmit(){
    this.http.post(this.baseurl+'/classes/new',this.model).subscribe();
    
  }

}
