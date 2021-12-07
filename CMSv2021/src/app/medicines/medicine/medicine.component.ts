import { Component, OnInit } from '@angular/core';
import {MedicineService} from 'src/app/shared/medicine.service';
import { NgForm } from '@angular/forms';
import { Medicine } from 'src/app/shared/medicine';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-medicine',
  templateUrl: './medicine.component.html',
  styleUrls: ['./medicine.component.css']
})
export class MedicineComponent implements OnInit {

  patId:number;
  medicine: Medicine= new Medicine(); 
  //filter:string;
  mobNumberPattern = "^((\\+91-?)|0)?[0-9]{10}$";
  namePattern="[a-zA-Z ]*";
  decPattern="[(0-9).]*";

  constructor(public medicineService: MedicineService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.medicineService.getMedicine();

  this.patId=this.route.snapshot.params['MedicineId'];
  console.log(this.patId);
  console.log("hi");
 
    if(this.patId!=0||this.patId!=null){
      this.medicineService.getMedicineById(this.patId).subscribe(
        data=>{
          console.log(data);
          this,this.medicineService.formData=data;
           
        this.medicineService.formData=Object.assign({},data);
     
        },
        error=>
        console.log(error)
      );
    }
 
  
  }
  onSubmit(form:NgForm){
    console.log(form.value);
    let addId =this.medicineService.formData.MedicineId;
   
    if(addId==0||addId==null){
       //insert
       console.log("insert");
      this.insertMedicineRecord(form);
    }
    else
    {
      //update
     console.log("update")
     this.updateMedicineRecord(form);
    }
  
  }

  //reset/clear all content from form  at initialization
  /*resetform(m:MedicineName){
    
      MedicineName='';

    }
   

  }*/
  resetform(form?:NgForm){
    if(form!=null){
      //this.medicineService.formData.MedicineName='';
      form.resetForm();

    }
   

  
  }


  //insert
  insertMedicineRecord(form?:NgForm){
    console.log("inserting a record...");
    console.log(form.value);
    form.value.IsActive='true';
    this.medicineService.insertMedicine(form.value).subscribe
    ((result)=>
    {
      console.log(result);
      this.resetform(form);
     
     
    }
    );
    window.alert("Medicine has been inserted");
    //window.location.reload();
  }

    //update
    updateMedicineRecord(form?:NgForm)
    {
      console.log("running");
      console.log("updating a record...");
      this.medicineService.updateMedicine(form.value).subscribe
      ((result)=>
      {
        console.log(result);
        this.resetform(form);
        //this.toastrService.success('Course record has been inserted','CRM appv2021');
       this.medicineService.getMedicine();
      }
      );
     window.alert("Medicine record has been updated");
      //window.location.reload();

    
  }


}


