import { DatePipe } from '@angular/common';
import { Component,  OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AppointmentService } from '../shared/appointment.service';
import { Doctor } from '../shared/doctor';
import { DoctorService } from '../shared/doctor.service';
import { PatientService } from '../shared/patient.service';

@Component({
  selector: 'app-dappoinment',
  templateUrl: './dappoinment.component.html',
  styleUrls: ['./dappoinment.component.css']
})
export class DappoinmentComponent implements OnInit {
  doctor:Doctor =new Doctor();
  docId:number;
  location: any;
  constructor(public docService: DoctorService,public appservice: AppointmentService,
    private router: Router, private route: ActivatedRoute) { }
 
  ngOnInit(): void {
    this.docService.bindDoctor();
  }
  onSubmit(form: NgForm) {
   // this.docId = this.route.snapshot.params['docId']
    //console.log(this.docId);
    console.log(form.value);
    let docId = this.docService.formData.DoctorId;
    let appdate=form.controls['AppointmentDate'].value;
    var datePipe = new DatePipe("en-UK");
    let formatedDate: any = datePipe.transform(appdate, 'yyyy-MM-dd');
    console.log(docId);
    console.log(formatedDate);
    this.appservice.getAppointmentByDate(docId, appdate)
  }
  AddTest(DoctorId:number,PatientId:number){
    console.log(PatientId);
    console.log(DoctorId);
    this.router.navigate(['dtest', DoctorId,PatientId]);
  }
  ViewTests(DoctorId:number,PatientId:number){
    console.log(PatientId);
    console.log(DoctorId);
    this.router.navigate(['viewtest', DoctorId,PatientId]);
  }
  ViewTest(PatientId:number){
    console.log(PatientId);
    console.log("view");
    this.router.navigate(['viewtest', PatientId]);
  }
  AddPres(PatientId:number,AppointmentDate:number){
    console.log(PatientId);
    console.log(AppointmentDate);
    console.log("view");
    this.router.navigate(['addpres', PatientId, AppointmentDate]);
  }
  AddMed(PatientId:number, DoctorId:number){
    console.log(PatientId);
    //console.log(AppointmentDate);
    console.log("view");
    this.router.navigate(['addmed', PatientId]);
  }
 
}
