import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Prescriptionhistory } from '../shared/prescriptionhistory';
import { PrescriptionService } from '../shared/prescription.service';
import { Prescription } from '../shared/prescription';
import {Location} from '@angular/common';
@Component({
  selector: 'app-prescriptionhistory',
  templateUrl: './prescriptionhistory.component.html',
  styleUrls: ['./prescriptionhistory.component.css']
})
export class PrescriptionhistoryComponent implements OnInit {
  prescriptions:Prescription[]
  patientid:number;

  constructor(public pservice:PrescriptionService, private router: Router, private route:ActivatedRoute) { }

  ngOnInit(): void {
    //this.pservice.getPrescriptionById(1);
    this.patientid = this.route.snapshot.params['PatientId'];
    console.log(this.patientid);
   this.pservice.getPrescriptionById(this.patientid)
  }
  populateForm(pat: Prescriptionhistory){
    console.log(pat);
    this.pservice.formDataOne=Object.assign({} ,pat);
 }
 

}

