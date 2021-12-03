import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StaffComponent } from './staffs/staff/staff.component';
import { HttpClientModule } from '@angular/common/http';
import { AdminComponent } from './admin/admin.component';
import { PatientsComponent } from './patients/patients.component';
import { PatientComponent } from './patients/patient/patient.component';
import { PatientListComponent } from './patients/patient-list/patient-list.component';
import { StaffsComponent } from './staffs/staffs.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StaffService } from './shared/staff.service';
import { AuthService } from './shared/auth.service';
import {AuthGuard} from './shared/auth.guard';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { AppointmentComponent } from './appointments/appointment/appointment.component';
import { PatientService } from './shared/patient.service';
import { StaffListComponent } from './staffs/staff-list/staff-list.component';
import { BillComponent } from './bills/bill/bill.component';
import { PaymentbillService } from './shared/paymentbill.service';
import {AppointmentService} from './shared/appointment.service';
import { BillsComponent } from './bills/bills.component';
import { BillListComponent } from './bills/bill-list/bill-list.component';
import { AppointmentsComponent } from './appointments/appointments.component';
import { AppointmentListComponent } from './appointments/appointment-list/appointment-list.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { CmedicineComponent } from './cmedicine/cmedicine.component';
import { MedicinesComponent } from './medicines/medicines.component';
import { MedicineComponent } from './medicines/medicine/medicine.component';
import { MedicinelistComponent } from './medicines/medicinelist/medicinelist.component';



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
    MedicinelistComponent
    
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule,
    Ng2SearchPipeModule
    

  ],
  providers: [
    StaffService,AuthService,AuthGuard,PatientService,PaymentbillService,AppointmentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
