import { Injectable } from '@angular/core';
import { Appointment } from './appointment';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Labhappointment } from './labhappointment';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  formData : Appointment = new Appointment();
  appointments : Appointment[];
  //parameter
  appointment:Appointment[];
  appdates:Appointment[];
  labdates:Labhappointment[];
  constructor(private httpClient: HttpClient) { }
  //get bill
  getAppointment() {
    this.httpClient.get(environment.apiUrl + "/api/appointment/getappointment")
    .toPromise().then(response =>
      this.appointments = response as Appointment[])

  }
  getAppointmentByDate(docId:number, appdate:Date){
    
    console.log("hello");
    console.log(docId);
    return this.httpClient.get(environment.apiUrl+"/api/appointment/getappointmentbydoctoridanddate/" +docId +"/" +appdate)
    .toPromise().then(response =>
      this.appdates = response as Appointment[])
      
  }
  //insert bill
  insertAppointment(appointment: Appointment) : Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/appointment/addappointment", appointment);
  }
  //update bill
  updateAppointment(appointment: Appointment) : Observable<any> {
    return this.httpClient.put(environment.apiUrl + "/api/appointment/updateappointment", appointment);
  }
  getAppointmentById(bId:number) :Observable<any>
  {
    console.log("hello");
    return this.httpClient.get(environment.apiUrl+"/api/appointment/getappointmentbyid?id="+bId);
  
  }
  getLabAppointmentByDate(labdate:Date){
    console.log("hello");
    console.log(labdate);
    return this.httpClient.get(environment.apiUrl+"/api/dtest/GetLabAppointmentByDate/"+labdate)
    .toPromise().then(response =>
      this.labdates = response as Labhappointment[])
 
  }

}

