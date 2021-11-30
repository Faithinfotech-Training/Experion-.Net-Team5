import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { StaffComponent } from './staffs/staff/staff.component';
import { StaffListComponent } from './staffs/staff-list/staff-list.component';
import { PatientComponent } from './patients/patient/patient.component';
import { HomeComponent } from './home/home.component';
import { AppointmentComponent } from './appointment/appointment.component';
import { PatientListComponent } from './patients/patient-list/patient-list.component';

const routes: Routes = [
  {path:'',redirectTo:"/login",pathMatch:'full'},
  {path:'login',component:LoginComponent},
  { path: 'staff', component: StaffComponent },
  { path: 'stafflist', component: StaffListComponent },
  { path: 'staff/:staffId', component: StaffComponent },
  { path: 'patient', component: PatientComponent },
  { path: 'home', component: HomeComponent },
  { path: 'appointment', component: AppointmentComponent },
  { path: 'patientlist', component: PatientListComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
