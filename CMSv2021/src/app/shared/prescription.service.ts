import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Prescription } from './prescription';
import { Prescriptionhistory } from './prescriptionhistory';

@Injectable({
  providedIn: 'root'
})
export class PrescriptionService {
  formData :Prescription = new Prescription();
  prescriptions:Prescription[];
  prescriptionHistory : Prescriptionhistory[];
  formDataOne :Prescriptionhistory = new Prescriptionhistory();

  constructor(private httpClient: HttpClient) { }
  //get bill
  getPrescription() {
    this.httpClient.get(environment.apiUrl + "/api/prescription/getprescriptions")
    .toPromise().then(response =>
      this.prescriptions = response as Prescription[])

  }
  //insert bill
  insertPrescription(bill: Prescription) : Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/prescription/addprescriptions", bill);
  }
  //update bill
  updatePrescription(bill: Prescription) : Observable<any> {
    return this.httpClient.put(environment.apiUrl + "/api/prescription/updateprescription", bill);
  }
  getPrescriptionById(bId:number) 
  {
    console.log(environment.apiUrl +  "/api/prescription/getprescriptionbyid" + bId );
    return this.httpClient.get(environment.apiUrl + "/api/prescription/getprescriptionbyid/" +bId)
    .toPromise().then(response =>
      //this.prescriptions = response as Prescription[])
      this.prescriptionHistory = response as Prescriptionhistory[] );
    

  }
  

}