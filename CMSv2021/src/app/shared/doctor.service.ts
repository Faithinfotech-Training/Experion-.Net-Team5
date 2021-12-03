import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Doctor } from './doctor';
import { Department } from './department';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  //create an instance of doctor
  formData: Doctor = new Doctor();
  departments: Department[];
  doctors: Doctor[];

  constructor(private httpClient: HttpClient) { }

  bindCmdDepartment() {
    this.httpClient.get(environment.apiUrl + "/api/doctor/getdepartments")
      .toPromise().then(response =>
        this.departments = response as Department[])

  }
  bindDoctor() {
    this.httpClient.get(environment.apiUrl + "/api/doctor/GetallDoctors")
      .toPromise().then(response =>
        this.doctors = response as Doctor[])

  }
  //insert Doctor
  insertDoctor(doctor: Doctor): Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/doctor/AddDoctor", doctor);

  }

  //update doctor
  updateDoctor(doctor: Doctor): Observable<any> {
    return this.httpClient.put(environment.apiUrl + "/api/doctor/UpdateDoctor", doctor);

  }

  //get doctor by id
  getDoctorById(doctorId: number): Observable<any> {

    return this.httpClient.get(environment.apiUrl + "/api/doctor/GetDoctorById?id=" + doctorId);

  }

}
