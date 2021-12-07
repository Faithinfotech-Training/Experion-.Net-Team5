import { Component, OnInit } from '@angular/core';
import { Appointment } from 'src/app/shared/appointment';
import { AppointmentService } from 'src/app/shared/appointment.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { PatientService } from 'src/app/shared/patient.service';
import { Patient } from 'src/app/shared/patient';
import { DoctorService } from 'src/app/shared/doctor.service';
import { Doctor } from 'src/app/shared/doctor';



@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css']
})
export class AppointmentComponent implements OnInit {
  //bId: number;
  mobNumberPattern = "^((\\+91-?)|0)?[0-9]{10}$";
  namePattern="[a-zA-Z ]*";
  decPattern="[(0-9).]*";
  bId: number;
  Pbill: Appointment = new Appointment();
  patient : Patient = new Patient();
  doctor:Doctor =new Doctor(); 
  tostrService: any;
  
  //filter:string;


  constructor(public docService: DoctorService, public patService : PatientService ,public appservice: AppointmentService, private router: Router, private route: ActivatedRoute ) { }

  ngOnInit(): void {
    this.patService.bindPatient();
    this.docService.bindDoctor();
    this.appservice.getAppointment();
    this.bId = this.route.snapshot.params['AppointmentId'];
    console.log(this.bId);
    if (this.bId != 0 || this.bId != null) {
      console.log("shallet");
      this.appservice.getAppointmentById(this.bId).subscribe(
        data => {
          console.log(data);
          this.appservice.formData = data;
          //date format
          var datePipe = new DatePipe("en-uk");
          let formatedDate: any = datePipe.transform(data.AppointmentDate, 'yyyy-MM-dd');
          data.AppointmentDate = formatedDate

          this.appservice.formData = Object.assign({}, data);

        },
        error =>
          console.log(error)
      );
    }
  }
  onSubmit(form: NgForm) {
    console.log(form.value);
    let addId = this.appservice.formData.AppointmentId;

    if (addId == 0 || addId == null) {
      //insert
      this.insertAppointmentRecord(form);
    }
    else {
      //update
      console.log("update")
      this.updateAppointmentRecord(form);
    }

  }

  //reset/clear all content from form  at initialization
  resetform(form?: NgForm) {
    if (form != null) {
      form.resetForm();

    }

  }


  //insert
  insertAppointmentRecord(form?: NgForm) {
    console.log("inserting a record...");
    console.log(form.value);
    form.value.IsActive="true";
    this.appservice.insertAppointment(form.value).subscribe
      ((result) => {
        console.log(result);
        this.resetform(form);
        this.tostrService.success('Appointment Added');


      }
      );
    
    //window.location.reload();
  }

  //update
  updateAppointmentRecord(form?: NgForm) {
    console.log("updating a record...");
    this.appservice.updateAppointment(form.value).subscribe
      ((result) => {
        console.log(result);
        this.resetform(form);
        //this.toastrService.success('Course record has been inserted','CRM appv2021');
        this.appservice.getAppointment();
      }
      );
    window.alert("Appointment record has been updated");
    //window.location.reload();


  }


}



