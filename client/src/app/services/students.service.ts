import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  baseurl = 'https://localhost:7038/api';

  constructor(private http: HttpClient) { }

  addNewStudent(newStudent: any){
    
    this.http.post(this.baseurl+'/users/new', newStudent).subscribe();

  }
  getStudentsList(classId: Number)
  {
    return this.http.get(this.baseurl+'/users/class/'+classId);
  }

  
}
