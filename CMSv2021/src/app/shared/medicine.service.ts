import { Injectable } from '@angular/core';
import {Medicine} from './medicine';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class MedicineService {

  formData : Medicine = new Medicine();
  medicines : Medicine[];
  //parameter
 medicine:Medicine[];

  constructor(private httpClient: HttpClient) { }
  //get bill
  getMedicine() {
    this.httpClient.get(environment.apiUrl + "/api/medicine/getmedicines")
    .toPromise().then(response =>
      this.medicines = response as Medicine[])

  }
  //insert bill
  insertMedicine(medicine: Medicine) : Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/medicine/addmedicine", medicine);
  }
  //update bill
  updateMedicine(medicine: Medicine) : Observable<any> {
    return this.httpClient.put(environment.apiUrl + "/api/medicine/updatemedicine", medicine);
  }
  getMedicineById(bId:number) :Observable<any>
  {
    console.log("hello");
    return this.httpClient.get(environment.apiUrl+"/api/medicine/"+bId);
  
  }
}


