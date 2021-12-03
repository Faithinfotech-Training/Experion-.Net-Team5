import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
//assign default page number and filter
page : number=1;
filter:string;
tempFilter:string;
//tempDateFilter : Date;
dateFilter : Date
  constructor() { }

  ngOnInit(): void {
  }

}
