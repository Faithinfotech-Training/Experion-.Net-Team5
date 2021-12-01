import { Component, OnInit } from '@angular/core';
import {PatientService} from 'src/app/shared/patient.service';
import { NgForm } from '@angular/forms';
import { Patient } from 'src/app/shared/patient';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {
  patId:number;
  patient: Patient= new Patient();  
  constructor(public patientService: PatientService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.patientService.bindPatient();

  this.patId=this.route.snapshot.params['patId'];
 
    if(this.patId!=0||this.patId!=null){
      this.patientService.getPatient(this.patId).subscribe(
        data=>{
          console.log(data);
          this,this.patientService.formData=data;
           
        this.patientService.formData=Object.assign({},data);
     
        },
        error=>
        console.log(error)
      );
    }
 
  
  }
  onSubmit(form:NgForm){
    console.log(form.value);
    let addId =this.patientService.formData.PatientId;
   
    if(addId==0||addId==null){
       //insert
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
    this.patientService.insertPatient(form.value).subscribe
    ((result)=>
    {
      console.log(result);
      this.resetform(form);
      //this.toastrService.success('Course record has been inserted','CRM appv2021');
     
    }
    );
    //window.alert("Patient has been inserted");
    //window.location.reload();
  }

    //update
    updatePatients(form?:NgForm)
    {
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
     // window.alert("Patient record has been updated");
      //window.location.reload();

    
  }


}


