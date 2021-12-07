import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Prescription } from '../shared/prescription';
import { PrescriptionService } from '../shared/prescription.service';

@Component({
  selector: 'app-prescription',
  templateUrl: './prescription.component.html',
  styleUrls: ['./prescription.component.css']
})
export class PrescriptionComponent implements OnInit {

  prescription: Prescription = new Prescription();
  patId: number;
  
  bId:number;
  addId:number;
  PrescriptionDate:Date;
  toastr: any;

  constructor(public pservice: PrescriptionService, private router: Router, private route: ActivatedRoute,private tostrService: ToastrService) { }

  ngOnInit(): void {
    this.pservice.getPrescription();
    console.log("happy");
    this.bId=this.route.snapshot.params['PatientId'];
    this.PrescriptionDate=this.route.snapshot.params['AppointmentDate'];
    var datePipe = new DatePipe("en-uk");
    let formatedDate: any = datePipe.transform(this.PrescriptionDate, 'yyyy-MM-dd');
    this.PrescriptionDate = formatedDate
    console.log(this.bId);





  }
  onSubmit(form: NgForm) {
    console.log(form.value);
    let addId = this.pservice.formData.PatientId;
    console.log(this.bId)

    if (addId == 0 || addId == null) {
      //insert
      console.log("insert");
      form.value.PatientId = this.bId;
      form.value.PrescriptionDate=this.PrescriptionDate;
      this.insertPrescriptionRecord(form);
    }
    else {
      //update
      console.log("update")
      this.updatePrescriptionRecord(form);
    }

  }


  resetform(form?: NgForm) {
    if (form != null) {
      form.resetForm();

    }



  }


  //insert
  insertPrescriptionRecord(form?: NgForm) {
    console.log("inserting a record...");
    form.value.PatientId = this.bId;
    form.value.PrescriptionDate=this.PrescriptionDate;
    console.log(form.value);
    this.pservice.insertPrescription(form.value).subscribe
      ((result) => {
        console.log(result);
        this.resetform(form);
        this.tostrService.success('Prescription Added');
      }
      );
    //window.alert("Prescription has been inserted");
  }

  //update
  updatePrescriptionRecord(form?: NgForm) {
    console.log("running");
    console.log("updating a record...");
    this.pservice.updatePrescription(form.value).subscribe
      ((result) => {
        console.log(result);
        this.resetform(form);
        //this.toastrService.success('Prescription updated successfully');
        this.pservice.getPrescription();
      }
      );
    window.alert("Medicine record has been updated");
    //window.location.reload();


  }
  


}



