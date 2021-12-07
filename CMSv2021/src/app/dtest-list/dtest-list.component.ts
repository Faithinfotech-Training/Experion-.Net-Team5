import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DtestService } from '../shared/dtest.service';

@Component({
  selector: 'app-dtest-list',
  templateUrl: './dtest-list.component.html',
  styleUrls: ['./dtest-list.component.css']
})
export class DtestListComponent implements OnInit {
  patientid:number;
  page: number = 1;
  constructor(public dtestService: DtestService,
    private router: Router,private route: ActivatedRoute) { }
 
  ngOnInit(): void {
    this.patientid = this.route.snapshot.params['patientId'];
    this.dtestService.bindCmdPatientList(this.patientid)
  }


}
