import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LabTechnitionService } from 'src/app/shared/lab-technition.service';
import { Result } from 'src/app/shared/result';

@Component({
  selector: 'app-addreport',
  templateUrl: './addreport.component.html',
  styleUrls: ['./addreport.component.css']
})
export class AddreportComponent implements OnInit {
  result: Result = new Result();
  patId: number;
  
  bId:number;
  addId:number;
  PrescriptionDate:Date;
  toastr: any;

  constructor(public labservice: LabTechnitionService, private router: Router, private route: ActivatedRoute,private tostrService: ToastrService) { }

  ngOnInit(): void {
    this.labservice.bindListTest()
    console.log("happy");
    this.bId=this.route.snapshot.params['TestId'];
    //this.PrescriptionDate=this.route.snapshot.params['AppointmentDate'];
    //var datePipe = new DatePipe("en-uk");
    //let formatedDate: any = datePipe.transform(this.PrescriptionDate, 'yyyy-MM-dd');
    //this.PrescriptionDate = formatedDate
    console.log(this.bId);





  }
  onSubmit(form: NgForm) {
    console.log(form.value);
    let addId = this.labservice.resultFormData.ResultId;
    console.log(this.bId)

    if (addId == 0 || addId == null) {
      //insert
      console.log("insert");
      form.value.TestId = this.bId;
      //form.value.PrescriptionDate=this.PrescriptionDate;
      this.insertPrescriptionRecord(form);
    }
    else {
      //update
      console.log("update")
      
    }

  }


  resetform(form?: NgForm) {
    if (form != null) {
      form.resetForm();

    }



  }


  //insert
  insertPrescriptionRecord(form?: NgForm) {
    console.log("inserting a record...");
    form.value.TestId = this.bId;
    //form.value.PrescriptionDate=this.PrescriptionDate;
    console.log(form.value);
    this.labservice.insertLabReport(form.value).subscribe
      ((result) => {
        console.log(result);
        this.resetform(form);
        this.tostrService.success('report Added');
      }
      );
    //window.alert("Prescription has been inserted");
  }
}
