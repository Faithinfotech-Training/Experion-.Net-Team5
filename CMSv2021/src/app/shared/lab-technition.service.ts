import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Report } from './reports';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Doctor } from './doctor';
import { Staff } from './staff';
import { Test } from './test';
import { Patient } from './patient';

@Injectable({
  providedIn: 'root'
})
export class LabTechnitionService {
  tests: Test[];
  testFormData : Test = new Test();
  reportFormData: Report = new Report();
  reports: Report[];
  doctors: Doctor[];
  patients: Patient[];
  staffs: Staff[];
  constructor(private httpClient: HttpClient) { }

  //Get All Reports
  bindListReport() {
    this.httpClient.get(environment.apiUrl + "/api/labreport")
      .toPromise().then(response =>
        this.reports = response as Report[]
      );
  }

  //Get All Doctors
  bindListDoctor() {
    this.httpClient.get(environment.apiUrl + "/api/doctor/getalldoctors")
      .toPromise().then(response =>
        this.doctors = response as Doctor[]
      );
  }

  //Get All Staff
  bindListStaff() {
    this.httpClient.get(environment.apiUrl + "/api/staff/getstaff")
      .toPromise().then(response =>
        this.staffs = response as Staff[]
      );
      //console.log(this.staffs)
  }
  //Get Staff by Department
  bindStaffByDepartment() {
    this.httpClient.get(environment.apiUrl + "/api/test/getstaffbyid/2")
      .toPromise().then(response =>
        this.staffs = response as Staff[]
      );
      //console.log(this.staffs)
  }
  //Get All Test  in a Report
  bindListTest() {
    this.httpClient.get(environment.apiUrl + "/api/test/gettest")
      .toPromise().then(response =>
        this.tests = response as Test[]
        
      );
      //console.log(reportId);
  }

  //GET a particular Report By ID
  getReport(patientId: number){
    this.httpClient.get(environment.apiUrl + "/api/test/GetTestByPatientId/" + patientId )
      .toPromise().then(response =>
      this.tests = response as Test[]
      );
      
  }

  //INSERT
  insertReport(report: Report): Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/labreport", report);
  }

  //INSERT
  insertTest(test: Test): Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/test", test);
  }
}
