import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Doctor } from 'src/app/shared/doctor';
import { ToastrService } from 'ngx-toastr';
import { DoctorService } from 'src/app/shared/doctor.service';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class DoctorComponent implements OnInit {

  docId: number;
  doctor: Doctor = new Doctor();
  mobNumberPattern = "^((\\+91-?)|0)?[0-9]{10}$";
  namePattern="[a-zA-Z ]*";
  decPattern="[(0-9).]*";
  constructor(public docService: DoctorService, private tostrService: ToastrService,
    private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.docId = this.route.snapshot.params['docId'];
    this.docService.bindCmdDepartment();
    if (this.docId != 0 || this.docId != null) {
      console.log("hello");

      //get employee

      this.docService.getDoctorById(this.docId).subscribe(

        data => {

          console.log(data);

          //date format

          var datePipe = new DatePipe("en-UK");

          let formatedDate: any = datePipe.transform(data.JoiningDate, 'yyyy-MM-dd');

          data.JoiningDate = formatedDate;

          this.docService.formData = Object.assign({}, data);

          this.docService.formData = data;

        },

        error =>

          console.log(error)

      );

    }
   // this.resetform();
  }
  onSubmit(form: NgForm) {
    this.docId = this.route.snapshot.params['docId']
    console.log(form.value);
    let addId = this.docService.formData.DoctorId;
    //insert

    if (addId == 0 || addId == null) {
      this.insertDoctor(form);

      // window.location.reload();

    }
    //update
    else {
      this.updateDoctor(form);
      console.log("update");

    }
  }
  //clear all content at initialisation

  resetform(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }

  }
  //insert doctor
  insertDoctor(form?: NgForm) {
    console.log("inserting  doctor...")
    form.value.IsActive="true";
    this.docService.insertDoctor(form.value).subscribe(
      (result) => {
        console.log("result" + result);
        this.resetform(form);
        this.tostrService.success('Doctor Registered');
      }
    );
    
    //window.location.reload();
  }
  //update doctor
  updateDoctor(form?: NgForm) {
    console.log("updating a record");
    this.docService.updateDoctor(form.value).subscribe(
      (result) => {
        console.log("result" + result);
        this.resetform(form);
        this.docService.bindDoctor();
        this.tostrService.success('Doctor Details updated!', );
      
      }
    );
    
    //window.location.reload();
  }

}
