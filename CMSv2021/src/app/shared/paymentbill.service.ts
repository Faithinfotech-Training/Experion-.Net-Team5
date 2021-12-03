import { Injectable } from '@angular/core';
import { Bill } from './bill';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class PaymentbillService {
  formData : Bill = new Bill();
  bills : Bill[];
  //parameter
  bill:Bill[];

  constructor(private httpClient: HttpClient) { }
  //get bill
  getBill() {
    this.httpClient.get(environment.apiUrl + "/api/paymentbill/getpaymentbill")
    .toPromise().then(response =>
      this.bills = response as Bill[])

  }
  //insert bill
  insertBill(bill: Bill) : Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/paymentbill/addpaymentbill", bill);
  }
  //update bill
  updateBill(bill: Bill) : Observable<any> {
    return this.httpClient.put(environment.apiUrl + "/api/paymentbill/updatepaymentbill", bill);
  }
  getBillById(bId:number) :Observable<any>
  {
    return this.httpClient.get(environment.apiUrl + "/api/paymentbill/getpaymentbillbyid?id=" +bId);
  
  }
}
