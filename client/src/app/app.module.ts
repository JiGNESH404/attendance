import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './header/header.component'
import { FormsModule } from '@angular/forms';
import { StudentsListComponent } from './students-list/students-list.component';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { HomeComponent } from './home/home.component';
import { ClassComponent } from './class/class.component';
import { AttendanceListComponent } from './attendance-list/attendance-list.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NewStudentComponent } from './new-student/new-student.component';
import { NewclassComponent } from './newclass/newclass.component';
import { MarkAttendanceComponent } from './mark-attendance/mark-attendance.component';
import { ListComponent } from './mark-attendance/list/list.component'


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    StudentsListComponent,
    HomeComponent,
    ClassComponent,
    AttendanceListComponent,
    NewStudentComponent,
    NewclassComponent,
    MarkAttendanceComponent,
    ListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    AppRoutingModule,
    ModalModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
