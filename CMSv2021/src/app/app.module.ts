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
import { AppointmentComponent } from './appointment/appointment.component';
import { PatientService } from './shared/patient.service';
import { StaffListComponent } from './staffs/staff-list/staff-list.component';

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
    StaffListComponent
    
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule

  ],
  providers: [
    StaffService,AuthService,AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
