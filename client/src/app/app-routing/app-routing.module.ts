import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../auth.guard';
import { StudentsListComponent } from '../students-list/students-list.component';
import { HomeComponent } from '../home/home.component';
import { ClassComponent } from '../class/class.component';
import { AttendanceListComponent } from '../attendance-list/attendance-list.component';
import { MarkAttendanceComponent } from '../mark-attendance/mark-attendance.component';



const routes: Routes = [
  { 'path': '', component: HomeComponent},
  {'path': 'students', component: StudentsListComponent, canActivate: [AuthGuard] },
  { 'path': 'classes', component: ClassComponent},
  {'path': 'markattendance', component: MarkAttendanceComponent},
  {'path': 'markattendance/class/:id', component: AttendanceListComponent}
  

]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
