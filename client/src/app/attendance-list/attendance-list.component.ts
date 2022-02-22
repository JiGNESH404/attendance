import { HttpClient } from '@angular/common/http';
import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute} from '@angular/router';
import { AttendanceService } from '../services/attendance.service';

@Component({
  selector: 'app-attendance-list',
  templateUrl: './attendance-list.component.html',
  styleUrls: ['./attendance-list.component.css']
})
export class AttendanceListComponent implements OnInit {

 date: Date ; 
  studentsList: any;
  baseurl = 'https://localhost:7038/api';
  
  constructor(private attendService: AttendanceService, private activatedRoute: ActivatedRoute) {
    
   }
  
  classId = this.activatedRoute.snapshot.params['id'];
   attendDate: string =""  
  ngOnInit(): void {
   this.attendDate = this.activatedRoute.snapshot.queryParams['attendDate']
   

    console.log(this.classId);
    this.getAttendees(this.attendDate, this.classId);
    
  }
 
  getAttendees(attendDate: string, classId: Number){
    
    this.attendService.getAttendance(classId, attendDate).subscribe((response) => {
      this.studentsList = response;
    })
  }
  onDateSubmit(form: NgForm){
    const date = new Date( form.value.date);
    this.attendDate = (date.getTime() / 1000).toString();
    this.getAttendees(this.attendDate, this.classId );
    console.log(this.attendDate);
    

  }
}
