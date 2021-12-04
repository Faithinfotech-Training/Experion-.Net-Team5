import { Component, OnInit } from '@angular/core';

import { LabTechnitionService } from 'src/app/shared/lab-technition.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Report } from 'src/app/shared/reports';
import { DatePipe } from '@angular/common';
import { Test } from 'src/app/shared/test';

@Component({
  selector: 'app-detailed-report',
  templateUrl: './detailed-report.component.html',
  styleUrls: ['./detailed-report.component.css']
})
export class DetailedReportComponent implements OnInit {

   //Variable to recieve prescription ID
   rtId:number;
   report :any ;
   patientId : number;
   tests:  Test[];
  constructor(public labService: LabTechnitionService ,private router:Router , private route:ActivatedRoute) { }

  ngOnInit(): void {
    //Get all Tests From Service
    this.rtId = this.route.snapshot.params['rtId'];
    this.labService.bindListTest();
  
  //Get Report Details
  /*this.labService.getReport(this.rtId).subscribe(
    data => {
      //console.log(data);  
      var datePipe = new DatePipe("en-UK");
          let formatedDate: any = datePipe.transform(data.ReportDate, 'yyyy-MM-dd');
          data.ReportDate = formatedDate;
          this.labService.reportFormData = Object.assign({}, data);
          this.labService.reportFormData = data;
          this.report=data;
    }
  );*/
}
//INSERT
insertReportRecord(form?: NgForm){
  console.log("Inserting a Record...");
  this.labService.insertReport(form.value).subscribe(
    (result)=>{
      console.log(result); 
      //this.hId = result;       
      //this.resetForm(form);        
    }      
  );
  //window.location.reload()
}
}
