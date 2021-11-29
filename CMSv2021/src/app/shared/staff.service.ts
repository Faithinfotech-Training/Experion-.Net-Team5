import { Injectable } from '@angular/core';
import { Staff } from './staff';
import { Department } from './department';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StaffService {
  //create an instance of employee
  formData: Staff = new Staff();
  staff: Staff[];
  departments: Department[];

  constructor(private httpClient: HttpClient) { }
  bindCmdDepartment() {
    this.httpClient.get(environment.apiUrl + "api/emp/GetDepartments")
      .toPromise().then(response =>
        this.departments = response as Department[])
  }
  bindStaff() {
    this.httpClient.get(environment.apiUrl + "api/staff/GetStaff")
      .toPromise().then(response =>
        this.staff = response as Staff[])

  }
  //insert employee
insertStaff(staff:Staff):Observable<any>
{
  return this.httpClient.post(environment.apiUrl+"api/emp/AddStaff",staff);

}

//update employee
updateStaff(staff:Staff):Observable<any>
{
  return this.httpClient.put(environment.apiUrl+"api/emp/UpdateStaff",staff);

}
//get employee by id
getStaffById(employeeId:number):Observable<any>
{
  return this.httpClient.get(environment.apiUrl+"api/emp/GetEmployeeById?id="+employeeId);

}

}