import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ClassService } from '../services/class.service';
import { StudentService } from '../services/students.service';

@Component({
  selector: 'app-new-student',
  templateUrl: './new-student.component.html',
  styleUrls: ['./new-student.component.css']
})
export class NewStudentComponent implements OnInit {
classes : any;
model: any = { }
  constructor(public bsModalRef: BsModalRef, private classService: ClassService, private studentService: StudentService) { }
  
  ngOnInit(): void {

    this.getClasses();
  }
  getClasses()
  {
    this.classService.getClassList().subscribe((response: any) =>
    {
      this.classes = response
    }, (error: any)=>{
      console.log(error)
    })
  }

  onSubmit(){
    console.log(this.model);
    this.studentService.addNewStudent(this.model)
    this.bsModalRef.hide()
    

  }


}
