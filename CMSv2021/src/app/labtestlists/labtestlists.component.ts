import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DtestService } from '../shared/dtest.service';

@Component({
  selector: 'app-labtestlists',
  templateUrl: './labtestlists.component.html',
  styleUrls: ['./labtestlists.component.css']
})
export class LabtestlistsComponent implements OnInit {
  patientid:number;
  page: number = 1;
  constructor(public dtestService: DtestService,
    private router: Router,private route: ActivatedRoute) { }
 
  ngOnInit(): void {
    this.patientid = this.route.snapshot.params['patientId'];
    this.dtestService.bindCmdPatientList(this.patientid)
  }
  addTest(testId: number) {
    console.log(testId);
    this.router.navigate(['labresult', testId])
 
  }
 
}

