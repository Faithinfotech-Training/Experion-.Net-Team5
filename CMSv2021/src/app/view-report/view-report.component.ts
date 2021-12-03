import { Component, OnInit } from '@angular/core';
import { LabTechnitionService } from '../shared/lab-technition.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-view-report',
  templateUrl: './view-report.component.html',
  styleUrls: ['./view-report.component.css']
})
export class ViewReportComponent implements OnInit {
  //assign default page number and filter
  page: number = 1;
  filter: string;
  tempFilter: string;
  //tempDateFilter : Date;
  dateFilter: Date
  constructor(public labService: LabTechnitionService, private router: Router) { }
  //lifecycle hook
  ngOnInit(): void {
    //Get all reports From Service
    this.labService.bindListReport();

  }
  //View Tests Of that report
  viewTest(rtId: number) {
    console.log(rtId);
    this.router.navigate(['detailedreport', rtId])
  }
  resetform(form?: NgForm) {
    if (form != null) {
      form.resetForm();

    }
  }
}
