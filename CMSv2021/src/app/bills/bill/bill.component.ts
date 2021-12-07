import { Component, OnInit } from '@angular/core';
import {PaymentbillService} from 'src/app/shared/paymentbill.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Bill } from '../../shared/bill';
import { NgForm } from '@angular/forms';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-bill',
  templateUrl: './bill.component.html',
  styleUrls: ['./bill.component.css']
})
export class BillComponent implements OnInit {
  bId : number;
  bill : Bill = new Bill();
  filter:string;
  mobNumberPattern = "^((\\+91-?)|0)?[0-9]{10}$";
  namePattern="[a-zA-Z ]*";
  decPattern="[(0-9).]*";
  PatientId:number;
  constructor(public paymentservice : PaymentbillService , private router: Router, private route: ActivatedRoute ) { }

  ngOnInit(): void {
    this.paymentservice.getBill();
    this.paymentservice.getPatients();
    this.bId=this.route.snapshot.params['BillId'];
    //this.PatientId=this.route.snapshot.params['PatientId'];
    console.log(this.bId);

    if(this.bId !=0 || this.bId != null){
      this.paymentservice.getBillById(this.bId).subscribe(
        data=>{
          console.log(data);
          var datePipe = new DatePipe("en-UK");
          let formatedDate: any = datePipe.transform(data.BillDate, 'yyyy-MM-dd');
          data.BillDate = formatedDate;
          //data.PatientId=this.PatientId;
          this.paymentservice.formData = Object.assign({}, data);
          this.paymentservice.formData=data;
          
        },
        error=>
        console.log(error)
      );
    }
     //this.resetform();
  }
  onSubmit(form:NgForm){
    this.bId=this.route.snapshot.params['bId'];
    console.log(form.value);
    let addId =this.paymentservice.formData.BillId;
   
    if(addId==0||addId==null){
       //insert
      this.insertBillRecord(form);
    }
    else
    {
      //update
     console.log("update")
     this.updateBillRecord(form);
    }
  
  }

  //reset/clear all content from form  at initialization
  resetform(form?:NgForm){
    if(form!=null){
      form.resetForm();

    }

  }


  //insert
  insertBillRecord(form?:NgForm){
    console.log("inserting a record...");
    //form.value.PatientId = this.bId;
    console.log(this.bId)
    console.log(form.value);
    this.paymentservice.insertBill(form.value).subscribe
    ((result)=>
    {
      console.log("result" + result);
      this.resetform(form);
      //this.toastrService.success('Course record has been inserted','CRM appv2021');
     
     
    }
    );
    window.alert("Bill has been inserted");
    //window.location.reload();
  }

    //update
    updateBillRecord(form?:NgForm)
    {
      console.log("updating a record...");
      this.paymentservice.updateBill(form.value).subscribe
      ((result)=>
      {
        console.log("result" + result);
        this.resetform(form);
        //this.toastrService.success('Course record has been updated','CRM appv2021');
       this.paymentservice.getBill();
      }
      );
     window.alert("Bill record has been updated");
      //window.location.reload();

    
  }


}


