import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StaffComponent } from './staffs/staff/staff.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AdminComponent } from './admin/admin.component';
import { PatientsComponent } from './patients/patients.component';
import { PatientComponent } from './patients/patient/patient.component';
import { PatientListComponent } from './patients/patient-list/patient-list.component';
import { StaffsComponent } from './staffs/staffs.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DoctorsComponent } from './doctors/doctors.component';
import { DoctorComponent } from './doctors/doctor/doctor.component';
import { DoctorListComponent } from './doctors/doctor-list/doctor-list.component';
import { DoctorService } from './shared/doctor.service';
import{AuthInterceptor} from './shared/auth.interceptor';
import { StaffService } from './shared/staff.service';
import { AuthService } from './shared/auth.service';
import {AuthGuard} from './shared/auth.guard';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { AppointmentComponent } from './appointments/appointment/appointment.component';
import { PatientService } from './shared/patient.service';
import { NgxPaginationModule } from 'ngx-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { StaffListComponent } from './staffs/staff-list/staff-list.component';
import { BillComponent } from './bills/bill/bill.component';
import { PaymentbillService } from './shared/paymentbill.service';
import {AppointmentService} from './shared/appointment.service';
import { BillsComponent } from './bills/bills.component';
import { BillListComponent } from './bills/bill-list/bill-list.component';
import { AppointmentsComponent } from './appointments/appointments.component';
import { AppointmentListComponent } from './appointments/appointment-list/appointment-list.component';

import { CmedicineComponent } from './cmedicine/cmedicine.component';
import { MedicinesComponent } from './medicines/medicines.component';
import { MedicineComponent } from './medicines/medicine/medicine.component';
import { MedicinelistComponent } from './medicines/medicinelist/medicinelist.component';


import { RouterModule } from '@angular/router';

import { LabTechnitionComponent } from './lab-technition/lab-technition.component';
import { ReportComponent } from './lab-technition/report/report.component';
import { TestComponent } from './lab-technition/test/test.component';
import { ViewReportComponent } from './view-report/view-report.component';
import { DetailedReportComponent } from './view-report/detailed-report/detailed-report.component';
import { LabTechnitionService } from './shared/lab-technition.service';

@NgModule({
  declarations: [
    AppComponent,
    StaffComponent,
    AdminComponent,
    PatientsComponent,
    PatientComponent,
    PatientListComponent,
    StaffsComponent,
    LoginComponent,
    HomeComponent,
    StaffListComponent,
    BillComponent,
    BillsComponent,
    BillListComponent,
    AppointmentComponent,
    AppointmentsComponent,
    AppointmentListComponent,
    CmedicineComponent,
    MedicinesComponent,
    MedicineComponent,
    MedicinelistComponent,
    DoctorsComponent,
    DoctorComponent,
    DoctorListComponent,
    StaffListComponent,
    LabTechnitionComponent,
    ReportComponent,
    TestComponent,
    ViewReportComponent,
    DetailedReportComponent
    
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    RouterModule,
    ToastrModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    Ng2SearchPipeModule,
    NgxPaginationModule

  ],
  
    
 
  providers: [DoctorService,StaffService,AuthService,AuthGuard, PatientService,PaymentbillService,AppointmentService,LabTechnitionService,{

    provide:HTTP_INTERCEPTORS,

    useClass:AuthInterceptor,

    multi:true

  }],
   
  bootstrap: [AppComponent]
})
export class AppModule { }
