import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AppointmentService } from '../shared/appointment.service';
import { ActivatedRoute} from '@angular/router';
import{DtestService} from 'src/app/shared/dtest.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-dtest',
  templateUrl: './dtest.component.html',
  styleUrls: ['./dtest.component.css']
})
export class DtestComponent implements OnInit {

  docId: number;
  patientId: number;
  
  constructor(public dtestService: DtestService,public appservice: AppointmentService,
    private router: Router,private tostrService: ToastrService,
    private route: ActivatedRoute) { }
 
 
 
  ngOnInit(): void {
     //get docId from activated route
     this.docId = this.route.snapshot.params['docId'];
     this.patientId = this.route.snapshot.params['patientId'];
     this.dtestService. bindCmdNtestname();
     console.log(this.docId);
     console.log(this.patientId);
   }
   //onSubmit function
   onSubmit(form: NgForm) {
     console.log(form.value);
     let addId = this.dtestService.dtestForm.TestId;
     //insert
     if (addId == 0 || addId == null) {
       this.insertTest(form);
     }
   }
   //clear all contents and Initialization
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }
  //Insert
  insertTest(form?: NgForm) {
    console.log('Inserting a test...');
    form.value.PatientId = this.patientId;
    form.value.DoctorId = this.docId;
    form.value.IsActive="true";
    this.dtestService.AddTest(form.value).subscribe(
      (result) => {
        console.log("result" + result);
        this.resetForm(form);
        this.tostrService.success('Test added');
      }
    );
    }


}
