import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PatientListComponent } from 'src/app/patients/patient-list/patient-list.component';
import { LabTechnitionService } from 'src/app/shared/lab-technition.service';
import { PatientService } from 'src/app/shared/patient.service';

@Component({
  selector: 'app-test-list',
  templateUrl: './test-list.component.html',
  styleUrls: ['./test-list.component.css']
})
export class TestListComponent implements OnInit {
  filter: string;
  constructor(public labService: LabTechnitionService, public patientService: PatientService,
    private router: Router) { }

  ngOnInit(): void {
    this.patientService.bindPatient();
  }
  viewTest(PatientId: number) {
    //console.log(PatientId);
    this.router.navigate(['report', PatientId])
  }
  AddTest(PatientId: number) {
    //console.log(PatientId);
    this.router.navigate(['test', PatientId])
  }

  
}
