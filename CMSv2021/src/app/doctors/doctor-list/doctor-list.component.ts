import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Doctor } from 'src/app/shared/doctor';
import { DoctorService } from 'src/app/shared/doctor.service';

@Component({
  selector: 'app-doctor-list',
  templateUrl: './doctor-list.component.html',
  styleUrls: ['./doctor-list.component.css']
})
export class DoctorListComponent implements OnInit {
  page: number = 1;
  filter: string;
  dateFilter:string;
  constructor(public docService: DoctorService,
    private router: Router) { }

  ngOnInit(): void {
    this.docService.bindDoctor();
  }
  //populate form by clicking the column fields
  populateForm(doc: Doctor) {
    console.log(doc);
    var datePipe = new DatePipe("en-UK");
    let formatedDate: any = datePipe.transform(doc.JoiningDate, 'yyyy-MM-dd');
    doc.JoiningDate = formatedDate;

    this.docService.formData = Object.assign({}, doc);

  }
  //delete employee
  
  //update a doctor
  updateDoctor(docId: number) {
    console.log(docId);
    this.router.navigate(['doctor', docId])

  }
  deleteDoctor(doc:Doctor){
    var value=confirm("Are you sure to delete  "+doc.DoctorName+"?")
    if(value){
      console.log("deleting patient!");
      doc.IsActive=false;
      console.log(doc);
      console.log("hello");
      this.docService.updateDoctor(doc).subscribe(
        (result)=>{
          console.log(result);
          this.docService.bindDoctor();
        });
    }
  
    }

}
