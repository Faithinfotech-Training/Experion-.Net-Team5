import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Doctor } from 'src/app/shared/doctor';
import { DoctorService } from 'src/app/shared/doctor.service';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class DoctorComponent implements OnInit {

  docId: number;
  doctor: Doctor = new Doctor();

  constructor(public docService: DoctorService,
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
    this.docService.insertDoctor(form.value).subscribe(
      (result) => {
        console.log("result" + result);
        this.resetform(form);
        //this.toxterService.success('Employee details Inserted!', 'succes!');
      }
    );
    window.alert("Doctor record has been inserted");
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
        //this.toxterService.success('Employee details Updated!', 'succes!');
      }
    );
    window.alert("Doctor record has been updated");
    window.location.reload();
  }

}
