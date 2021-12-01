import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { DoctorListComponent } from './doctors/doctor-list/doctor-list.component';
import { DoctorComponent } from './doctors/doctor/doctor.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {path:'',redirectTo:"/login",pathMatch:'full'},
  {path:'login',component:LoginComponent},
  {path:'doctor',component:DoctorComponent},
  {path:'doctorlist',component:DoctorListComponent},
  {path:'doctor/:docId',component:DoctorComponent},
  {path:'admin',component:AdminComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
