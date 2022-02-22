import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NewclassComponent } from '../newclass/newclass.component';
import { ClassService } from '../services/class.service';

@Component({
  selector: 'app-class',
  templateUrl: './class.component.html',
  styleUrls: ['./class.component.css']
})
export class ClassComponent implements OnInit {
  bsModalRef: BsModalRef;
  classes: any;
  constructor(private http: HttpClient, private classService: ClassService, private modalService: BsModalService) { 
    this.getClassList();
   }

  ngOnInit(): void {
  }
  getClassList(){
    this.classService.getClassList().subscribe((response: any) =>
    {
      console.log(response)
      this.classes = response
    }, (error: any)=>{
      console.log(error)
    })
    
  }
  openNewClassModal(){
    const config = {
      class : 'modal-dialog-centered'
    }
    this.bsModalRef= this.modalService.show(NewclassComponent, config);
  }

}
