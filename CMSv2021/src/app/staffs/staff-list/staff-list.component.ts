import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Staff } from 'src/app/shared/staff';
import { StaffService } from 'src/app/shared/staff.service';

@Component({
  selector: 'app-staff-list',
  templateUrl: './staff-list.component.html',
  styleUrls: ['./staff-list.component.css']
})
export class StaffListComponent implements OnInit {
  //assign default page

  page: number = 0;
  filter: string;
  
  constructor(public staffService: StaffService, private router: Router) { }

  ngOnInit(): void {
    this.staffService.bindStaff();
  }
  //populate form by clicking the coloum


  populateForm(staff: Staff) {
    console.log(staff);

    //date format
    var datePipe = new DatePipe("en-uk");
    let formatedDate: any = datePipe.transform(staff.JoiningDate, 'yyy-MM-dd');
    staff.JoiningDate = formatedDate
    this.staffService.formData = Object.assign({}, staff);
  }
//delete staff
deleteStaff(staff:Staff){
  var value=confirm("Are you sure to delete  "+staff.StaffName+"?")
  if(value){
    console.log("deleting staff!");
    staff.IsActive=false;
    console.log(staff);
    console.log("hello");
    this.staffService.updateStaff(staff).subscribe(
      (result)=>{
        console.log(result);
        this.staffService.bindStaff();
      });
  }

  }

  //update staff

  updateStaffRecord(staffId: number) {

    console.log(staffId);

    this.router.navigate(['staff', staffId]);

  }
  //delete staff
  deleteStaff(staff:Staff){
  var value=confirm("Are you sure to delete  "+staff.StaffName+"?")
  if(value){
    console.log("deleting staff!");
    staff.IsActive=false;
    console.log(staff);
    console.log("hello");
    this.staffService.updateStaff(staff).subscribe(
      (result)=>{
        console.log(result);
        this.staffService.bindStaff();
      });
  }

  }

}








