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
import { AppointmentComponent } from './appointments/appointment/appointment.component';
import { PatientListComponent } from './patients/patient-list/patient-list.component';
import { BillComponent } from './bills/bill/bill.component';
import { BillListComponent } from './bills/bill-list/bill-list.component';
import { AppointmentListComponent } from './appointments/appointment-list/appointment-list.component';
import { MedicineComponent } from './medicines/medicine/medicine.component';
import { MedicinelistComponent } from './medicines/medicinelist/medicinelist.component';
import { TestComponent } from './lab-technition/test/test.component';
import { ViewReportComponent } from './view-report/view-report.component';
import { DetailedReportComponent } from './view-report/detailed-report/detailed-report.component';
import { ReportComponent } from './lab-technition/report/report.component';
import { MainhomeComponent } from './mainhome/mainhome.component';
import { TestListComponent } from './lab-technition/test-list/test-list.component';
import { LabhomeComponent } from './lab-technition/labhome/labhome.component';
import { DappoinmentComponent } from './dappoinment/dappoinment.component';
import { DtestComponent } from './dtest/dtest.component';
import { PrescriptionhistoryComponent } from './prescriptionhistory/prescriptionhistory.component';
import { DtestListComponent } from './dtest-list/dtest-list.component';
import { PrescriptionComponent } from './prescription/prescription.component';
import { LabappointmentComponent } from './labappointment/labappointment.component';
import { LabtestlistsComponent } from './labtestlists/labtestlists.component';
import { AddreportComponent } from './lab-technition/addreport/addreport.component';

const routes: Routes = [
  { path: '', redirectTo: "/mainhome", pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'doctor', component: DoctorComponent },
  { path: 'doctorlist', component: DoctorListComponent },
  { path: 'doctor/:docId', component: DoctorComponent },
  { path: 'admin', component: AdminComponent },
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
  { path: 'medicine/:MedicineId', component: MedicineComponent },
  { path: 'test', component: TestComponent },
  //{ path: 'viewreport', component: ViewReportComponent },
  //{ path: 'detailedreport/:rtId', component: DetailedReportComponent },
  { path: 'report/:patientId', component: ReportComponent },
  { path: 'mainhome', component: MainhomeComponent },
  { path: 'testlist', component: TestListComponent },
  { path: 'labtechnician', component: LabhomeComponent },
  { path: 'dappointment', component: DappoinmentComponent },
  { path: 'dappointment/:bId/:bdate', component: DappoinmentComponent },
  { path: 'dtest/:docId/:patientId', component: DtestComponent },
  { path: 'viewtest/:PatientId', component: PrescriptionhistoryComponent },
  { path: 'prescriptionhistory', component: PrescriptionhistoryComponent },
  {path:'viewtest/:docId/:patientId',component:DtestListComponent},
  { path: 'prescription', component: PrescriptionComponent },
  { path: 'dappointment/:PatientId', component: PrescriptionComponent },
  { path: 'addpres/:PatientId/:AppointmentDate', component: PrescriptionComponent },
  { path: 'lhapp', component: LabappointmentComponent},
  {path:'labtest/:docId/:patientId',component:LabtestlistsComponent},
  {path:'labresult/:TestId',component:AddreportComponent},
  { path: 'addmed/:PatientId', component: MedicineComponent },
  { path: 'dappointment/:PatientId', component: MedicineComponent },
  { path: 'dappointment/:PatientId/:DoctorId', component: DappoinmentComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
