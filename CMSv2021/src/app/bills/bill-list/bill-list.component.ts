import { Component, OnInit } from '@angular/core';
import { PaymentbillService } from 'src/app/shared/paymentbill.service';
import { Router } from '@angular/router';
import { Bill } from '../../shared/bill';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-bill-list',
  templateUrl: './bill-list.component.html',
  styleUrls: ['./bill-list.component.css']
})
export class BillListComponent implements OnInit {
  filter:string;

  constructor(private router: Router, public paymentservice: PaymentbillService) { }

  ngOnInit(): void {
    this.paymentservice.getBill();
  }
  //populate form by clicking the column fields
  populateForm(bill: Bill) {
    console.log(bill);
    //date format
    var datePipe = new DatePipe("en-uk");
    let formatedDate: any = datePipe.transform(bill.BillDate, 'yyy-MM-dd');
    bill.BillDate = formatedDate
    this.paymentservice.formData = Object.assign({}, bill);
  }
  //delete employee
  deleteBill(bil:Bill){
    var value=confirm("Are you sure to delete bill number "+bil.BillNumber+"?")
    if(value){
      console.log("deleting bill!");
      bil.IsActive=false;
      console.log(bil);
      console.log("hello");
      this.paymentservice.updateBill(bil).subscribe(
        (result)=>{
          console.log(result);
          this.paymentservice.getBill();
        });
    }

    }

  updateBillRecord(BillId: number){
    console.log(BillId);
    this.router.navigate(['bill', BillId]);
    
  } 


}
