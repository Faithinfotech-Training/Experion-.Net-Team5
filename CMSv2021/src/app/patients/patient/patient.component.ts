import { Component, OnInit } from '@angular/core';
import {PatientService} from 'src/app/shared/patient.service';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {

  constructor(patientService :PatientService) { }

  ngOnInit(): void {
  }
  onSubmit(form: NgForm) {

    console.log(form.value);
  }

}
