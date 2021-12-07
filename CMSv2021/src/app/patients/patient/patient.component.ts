import { Component, OnInit } from '@angular/core';
import {PatientService} from 'src/app/shared/patient.service';
import { NgForm } from '@angular/forms';
import { Patient } from 'src/app/shared/patient';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { LabTechnitionService } from 'src/app/shared/lab-technition.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {
  patId:number;
  patient: Patient= new Patient(); 
  //filter:string;
  mobNumberPattern = "^((\\+91-?)|0)?[0-9]{10}$";
  namePattern="[a-zA-Z ]*";
  decPattern="[(0-9).]*";
  

  constructor(public labService: LabTechnitionService,public patientService: PatientService, private router: Router, private route: ActivatedRoute, private tostrService: ToastrService) { }

  ngOnInit(): void {
    //this.staffService.bindDoctor();
    this.labService.bindListDoctor();
    
    this.patientService.bindPatient();

  this.patId=this.route.snapshot.params['PatientId'];
  console.log(this.patId);
 
    if(this.patId!=0||this.patId!=null){
      this.patientService.getPatientbyid(this.patId).subscribe(
        data=>{
          console.log(data);
          this.patientService.formData = data;
          this.patientService.formData = Object.assign({}, data);
        },
        error=>
        console.log(error)
      );
    }
 
  
  }
  onSubmit(form:NgForm){
    console.log(form.value);
    let addId =this.patientService.formData.PatientId;
    //console.log("addid",+addId);
    if(addId==0||addId==null){
       //insert
       console.log("insert");
      this.insertPatients(form);
    }
    else
    {
      //update
     console.log("update")
     this.updatePatients(form);
    }
  
  }

  //reset/clear all content from form  at initialization
  resetform(form?:NgForm){
    if(form!=null){
      form.resetForm();

    }

  }


  //insert
  insertPatients(form?:NgForm){
    console.log("inserting a record...");
    console.log(form.value);
    form.value.IsActive="true";
    this.patientService.insertPatient(form.value).subscribe
    ((result)=>
    {
      console.log(result);
      this.resetform(form);
      this.tostrService.success('Patient Has been Registered');
      
    }
    );
    
    //window.location.reload();
  }

    //update
    updatePatients(form?:NgForm)
    {
      console.log("running");
      console.log("updating a record...");
      this.patientService.updatePatient(form.value).subscribe
      ((result)=>
      {
        console.log(result);
        this.resetform(form);
        //this.toastrService.success('Course record has been inserted','CRM appv2021');
       this.patientService.bindPatient();
      }
      );
     window.alert("Patient record has been updated");
      //window.location.reload();

    
  }


}


