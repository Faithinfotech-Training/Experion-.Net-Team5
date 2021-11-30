import { Injectable } from '@angular/core';
import { Staff } from './staff';
import { Department } from './department';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Designation } from './designation'
@Injectable({
  providedIn: 'root'
})
export class StaffService {
  //create an instance of employee
  formData: Staff = new Staff();
  departments: Department[];
  designation: Designation[];
  staff:Staff[];

  constructor(private httpClient: HttpClient) { }

  bindCmdDepartment() {
    this.httpClient.get(environment.apiUrl + "/api/staff/getdepartment")
      .toPromise().then(response =>
        this.departments = response as Department[])
  }

  bindCmdDesignation() {
    this.httpClient.get(environment.apiUrl + "/api/staff/getdesignation")
      .toPromise().then(response =>
        this.designation = response as Designation[])
  }

  bindStaff() {
    this.httpClient.get(environment.apiUrl + "/api/staff/getstaffByid")
      .toPromise().then(response =>
        this.staff = response as Staff[])

  }
  //insert Staff
  insertStaff(staff: Staff): Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/staff/AddStaff", staff);

  }
  //update employee
  updateStaff(staff: Staff): Observable<any> {
    return this.httpClient.put(environment.apiUrl + "/api/staff/UpdateStaff", staff);

  }
  //get employee by id
//getStaffById(staffId:number):Observable<any>
//{
  //return this.httpClient.get(environment.apiUrl+"/api/staff/GetstaffById?id="+staffId);

//}
}