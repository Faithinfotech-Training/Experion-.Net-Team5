import { Component, OnInit } from '@angular/core';
import { Test } from 'src/app/shared/test';
import { ActivatedRoute, Router } from '@angular/router';
import { LabTechnitionService } from 'src/app/shared/lab-technition.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  //Declaring Variables
  //Declare Variables

  test: Test = new Test();
  patientId: number;
  isSubmitted = false;

  constructor(public labService: LabTechnitionService, private router: Router,private tostrService: ToastrService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    //Get value from activated Route
    this.patientId = this.route.snapshot.params['PatientId'];
    console.log(this.patientId)
    //console.log(this.rptId)
    this.labService.bindStaffByDepartment();
    this.labService.bindListDoctor();
   
  }
  //clear all contents at Initialization  
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }
  onSubmit(form: NgForm){
    this.isSubmitted = true;
    console.log(form.value);
    //Setting The Values That do not need input
    //form.value.ReportId = this.rptId;
    form.value.IsActive = true;    
    console.log(form.value);
    //Insert 
    this.insertTestRecord(form);
  }
   //INSERT
   insertTestRecord(form: NgForm){
    console.log("Inserting a Record...");
    this.labService.insertTest(form.value).subscribe(
      (result)=>{
        //form.value.PatientId = this.patientId;
        console.log(result);        
        this.resetForm(form); 
        this.tostrService.success('Test Details inserted!', 'succes!');       
      }      
    );
    }
}
