import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { StaffComponent } from './staffs/staff/staff.component';
import { StaffListComponent } from './staffs/staff-list/staff-list.component';
import { PatientComponent } from './patients/patient/patient.component';
import { HomeComponent } from './home/home.component';
import { AppointmentComponent } from './appointments/appointment/appointment.component';
import { PatientListComponent } from './patients/patient-list/patient-list.component';
import { BillComponent } from './bills/bill/bill.component';
import { BillListComponent } from './bills/bill-list/bill-list.component';
import { AppointmentListComponent } from './appointments/appointment-list/appointment-list.component';
import { MedicineComponent } from './medicines/medicine/medicine.component';
import { MedicinelistComponent } from './medicines/medicinelist/medicinelist.component';


const routes: Routes = [
  {path:'',redirectTo:"/login",pathMatch:'full'},
  {path:'login',component:LoginComponent},
  { path: 'staff', component: StaffComponent },
  { path: 'stafflist', component: StaffListComponent },
  { path: 'staff/:staffId', component: StaffComponent },
  { path: 'patient', component: PatientComponent },
  { path: 'home', component: HomeComponent },
  { path: 'appointment', component: AppointmentComponent },
  { path: 'patientlist', component: PatientListComponent },
  { path: 'bill', component: BillComponent },
  { path: 'billlist', component: BillListComponent },
  { path: 'appointment', component: AppointmentComponent },
  { path: 'appointmentlist', component: AppointmentListComponent },
  { path: 'appointment/:AppointmentId', component: AppointmentComponent },
  { path: 'bill/:BillId', component: BillComponent },
  { path: 'patient/:PatientId', component: PatientComponent },
  { path: 'medicine', component: MedicineComponent },
  { path: 'medicinelist', component: MedicinelistComponent },
  { path: 'medicine/:MedicineId', component: MedicineComponent }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
