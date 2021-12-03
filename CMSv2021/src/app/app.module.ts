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
import { AppointmentComponent } from './appointment/appointment.component';
import { PatientService } from './shared/patient.service';
import { NgxPaginationModule } from 'ngx-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { StaffListComponent } from './staffs/staff-list/staff-list.component';
import { RouterModule } from '@angular/router';

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
    DoctorsComponent,
    DoctorComponent,
    DoctorListComponent,
    StaffListComponent
    
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
    NgxPaginationModule,
    Ng2SearchPipeModule,
  ],
  providers: [DoctorService,StaffService,AuthService,AuthGuard,{

    provide:HTTP_INTERCEPTORS,

    useClass:AuthInterceptor,

    multi:true

  }],
   
  bootstrap: [AppComponent]
})
export class AppModule { }
