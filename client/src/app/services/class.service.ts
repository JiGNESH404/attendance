import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ClassService {
  baseurl = 'https://localhost:7038/api';

  constructor(private http: HttpClient) { }

  getClassList(){
    return this.http.get(this.baseurl+ '/classes');
  }
}
