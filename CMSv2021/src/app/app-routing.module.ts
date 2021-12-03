import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { DoctorListComponent } from './doctors/doctor-list/doctor-list.component';
import { DoctorComponent } from './doctors/doctor/doctor.component';
import { LoginComponent } from './login/login.component';
import { StaffComponent } from './staffs/staff/staff.component';
import { StaffListComponent } from './staffs/staff-list/staff-list.component';
import { PatientComponent } from './patients/patient/patient.component';
import { HomeComponent } from './home/home.component';
import { AppointmentComponent } from './appointment/appointment.component';
import { PatientListComponent } from './patients/patient-list/patient-list.component';
import { TestComponent } from './lab-technition/test/test.component';
import { ViewReportComponent } from './view-report/view-report.component';
import { DetailedReportComponent } from './view-report/detailed-report/detailed-report.component';


const routes: Routes = [
  {path:'',redirectTo:"/login",pathMatch:'full'},
  {path:'login',component:LoginComponent},
  {path:'doctor',component:DoctorComponent},
  {path:'doctorlist',component:DoctorListComponent},
  {path:'doctor/:docId',component:DoctorComponent},
  {path:'admin',component:AdminComponent},
  { path: 'staff', component: StaffComponent },
  { path: 'stafflist', component: StaffListComponent },
  { path: 'staff/:staffId', component: StaffComponent },
  { path: 'patient', component: PatientComponent },
  { path: 'home', component: HomeComponent },
  { path: 'appointment', component: AppointmentComponent },
  { path: 'patientlist', component: PatientListComponent },
  { path: 'test', component: TestComponent },
  { path: 'viewreport', component: ViewReportComponent },
  { path: 'detailedreport/:rtId', component: DetailedReportComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
