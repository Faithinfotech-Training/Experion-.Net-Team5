import { Component, OnInit } from '@angular/core';
import { PatientService } from 'src/app/shared/patient.service';
import {Router} from '@angular/router';
import { Patient } from 'src/app/shared/patient';
@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit {

  
  filter : string;
  constructor(public patientService:PatientService,
    private router:Router) { }

  ngOnInit(): void {
    this.patientService.bindPatient();
  }
  //populate form by clicking the column fields
  populateForm(pat: Patient){
     console.log(pat);
     this.patientService.formData=Object.assign({} ,pat);
  }
  /*//delete employee
  deleteEmployee(id:number){
    console.log("deleting employee...");
    if(confirm('Are you sure to delete')){
      this.empService.deleteEmployee(id).subscribe(
        (result)=>
        {
          console.log("result"+result);
          this.empService.bindEmployee();
          this.toastrService.error('Employee details deleted!', 'success!');
         
        },
        (error)=>{
          console.log("error");
        }
      );

    }*/

    //delete employee
  deletePatient(pat:Patient){
    var value=confirm("Are you sure to delete  "+pat.PatientName+"?")
    if(value){
      console.log("deleting patient!");
      pat.IsActive=false;
      console.log(pat);
      console.log("hello");
      this.patientService.updatePatient(pat).subscribe(
        (result)=>{
          console.log(result);
          this.patientService.bindPatient();
        });
    }

    }
  //update an employee
updatePatient(PatientId: number){
  console.log(PatientId);
  this.router.navigate(['patient', PatientId]);
  
} 
  
}



  

