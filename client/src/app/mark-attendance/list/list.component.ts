import { Component, Input, NgModule, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AttendanceService } from 'src/app/services/attendance.service';
import { StudentService } from 'src/app/services/students.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  @Input() classId: Number;

  constructor(private studentservice: StudentService, private attendacneService: AttendanceService) {
    
   }
   
   
studentslist: any;
attendance : any = [];
  ngOnInit(): void {
    this.studentservice.getStudentsList(this.classId).subscribe((data) => {
      console.log(data);
      this.studentslist = data;
    } )
    
    
  
  }
  formSubmit(form: NgForm){
    this.attendacneService.newAttendance(this.classId,this.attendance);
  }

  onClickA(studentId: Number, studentName: string){

      this.attendance.push({
        "studentId" : studentId,
        "studentName" : studentName,
        "status": true,
        "attendDate":  (Math.round(new Date().getTime()  / 1000) ).toString(),
        "SudentClassId" : this.classId
      })
    console.log(this.attendance);
  }


}
