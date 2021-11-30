import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Patient} from './patient';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  
  formData: Patient = new Patient();
  patients:Patient[];

  constructor(private httpClient:HttpClient) { }

  
  bindPatient(){
    this.httpClient.get(environment.apiUrl+"/api/patient/GetAllPatients")
    .toPromise().then(response=>
      this.patients=response as Patient[])
  
  }
  
  //insert patient
  insertPatient(patient:Patient):Observable<any>
  {
    console.log("hello");
    console.log(patient);
    return this.httpClient.post(environment.apiUrl+"/api/patient/AddPatients",patient);
  
  }
  
  //update employee
  updatePatient(patient:Patient):Observable<any>
  {
    return this.httpClient.put(environment.apiUrl+"/api/patient/UpdatePatients",patient);
  
  }
  
  
  //get employee by id
  getPatientbyid(patientId:number):Observable<any>
  {
    return this.httpClient.get(environment.apiUrl+"/api/patient/getPatient?id="+patientId);
  
  }
  
  
  }
  

