import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AppointmentService } from '../shared/appointment.service';
import { Doctor } from '../shared/doctor';
import { DoctorService } from '../shared/doctor.service';
import { DtestService } from '../shared/dtest.service';

@Component({
  selector: 'app-labappointment',
  templateUrl: './labappointment.component.html',
  styleUrls: ['./labappointment.component.css']
})
export class LabappointmentComponent implements OnInit {
  doctor:Doctor =new Doctor();
  docId:number;
  constructor(public docService: DoctorService,public dtestService: DtestService,public appservice: AppointmentService,
    private router: Router, private route: ActivatedRoute) { }
 
  ngOnInit(): void {
 
  }
  onSubmit(form: NgForm) {
    console.log(form.value);
    let docId = this.docService.formData.DoctorId;
    let labdate=form.controls['TestDate'].value;
    var datePipe = new DatePipe("en-UK");
    let formatedDate: any = datePipe.transform(labdate, 'yyyy-MM-dd');
    console.log(docId);
    console.log(formatedDate);
    this.appservice.getLabAppointmentByDate(labdate);
  }
 
  ViewLabTest(DoctorId:number,PatientId:number){
    console.log(PatientId);
    console.log(DoctorId);
    this.router.navigate(['labtest', DoctorId,PatientId]);
  }
 
}

