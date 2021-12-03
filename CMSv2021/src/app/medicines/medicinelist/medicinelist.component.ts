import { Component, OnInit } from '@angular/core';
import { MedicineService } from 'src/app/shared/medicine.service';
import {Router} from '@angular/router';
import { Medicine } from 'src/app/shared/medicine';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-medicinelist',
  templateUrl: './medicinelist.component.html',
  styleUrls: ['./medicinelist.component.css']
})
export class MedicinelistComponent implements OnInit {

  filter : string;
  constructor(public medicineService:MedicineService,
    private router:Router) { }

  ngOnInit(): void {
    this.medicineService.getMedicine();
  }
  //populate form by clicking the column fields
  populateForm(pat: Medicine){
     console.log(pat);
     var datePipe = new DatePipe("en-uk");
    let formatedDate: any = datePipe.transform(pat.StartDate, 'yyyy-MM-dd');
    pat.StartDate= formatedDate
    let formatedDateNew: any = datePipe.transform(pat.EndDate, 'yyyy-MM-dd');
    pat.EndDate= formatedDateNew
     this.medicineService.formData=Object.assign({} ,pat);
  }
  //delete employee
  deleteMedicine(pat:Medicine){
    var value=confirm("Are you sure to delete  "+pat.MedicineName+"?")
    if(value){
      console.log("deleting patient!");
      pat.IsActive=false;
      console.log(pat);
      console.log("hello");
      this.medicineService.updateMedicine(pat).subscribe(
        (result)=>{
          console.log(result);
          this.medicineService.getMedicine();
        });
    }

    }
  //update an employee
  updateMedicineRecord(MedicineId: number){
  console.log("hello");
  console.log(MedicineId);
  this.router.navigate(['medicine', MedicineId]);
  
} 
  
}



  


