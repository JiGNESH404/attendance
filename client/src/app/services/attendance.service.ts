import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Attendee } from '../models/attendees.model';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService {
  baseurl = 'https://localhost:7038/api';
  constructor(private http: HttpClient) { }
  
  getAttendance(classId: Number, attendDate: string)

  {
    return this.http.get(this.baseurl+'/attendance/class/'+classId, {params:{"attendDate": attendDate}}) ;
  }
  newAttendance(classId: Number, list: any)
  {
    this.http.post(this.baseurl+'/attendance/class/'+classId,list).subscribe();
  }
}
