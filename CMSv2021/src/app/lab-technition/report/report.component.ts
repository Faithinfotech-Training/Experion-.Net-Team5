import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LabTechnitionService } from 'src/app/shared/lab-technition.service';
import { Test } from 'src/app/shared/test';


@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  //assign default page number and filter
  page: number = 1;
  filter: string;
  tempFilter: string;

  //tempDateFilter : Date;
  test: Test[];
  dateFilter: Date
  patientId: number;
  constructor(public labService: LabTechnitionService, private router: Router,private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.patientId = this.route.snapshot.params['patientId'];
    console.log("hello");
    //this.labService.bindListTest();
    console.log(this.patientId);
  
  //Get Report Details
  this.labService.getReport(this.patientId);
  
}
  populateForm(test: Test) {
    console.log(test);
    var datePipe = new DatePipe("en-UK");
    let formatedDate: any = datePipe.transform(test.TestDate, 'yyyy-mm-dd');
    test.TestDate = formatedDate;
    this.labService.testFormData = Object.assign({}, test);

  }
}

