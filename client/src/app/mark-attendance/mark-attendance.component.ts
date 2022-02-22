import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ClassService } from '../services/class.service';

@Component({
  selector: 'app-mark-attendance',
  templateUrl: './mark-attendance.component.html',
  styleUrls: ['./mark-attendance.component.css']
})
export class MarkAttendanceComponent implements OnInit {
  classSelected: boolean = false;

  constructor(private classService: ClassService) { }
  SelectedClassID: Number;
classes: any;
  ngOnInit(): void {
    this.classService.getClassList().subscribe((response: any)=>{
      console.log(response)
      this.classes = response
      
    })
    
  }
  onClassSubmit(form: NgForm){
    this.SelectedClassID =  form.value.studentClass;
    this.classSelected = true;
  }

 

}
