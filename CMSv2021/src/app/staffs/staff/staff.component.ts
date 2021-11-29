import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Staff } from 'src/app/shared/staff';
import { StaffService } from 'src/app/shared/staff.service';
import { ActivatedRoute} from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-staff',
  templateUrl: './staff.component.html',
  styleUrls: ['./staff.component.css']
})
export class StaffComponent implements OnInit {

  staffId: number;
  staff: Staff = new Staff;

  constructor(public staffService: StaffService,private router: Router,private route: ActivatedRoute) { }

  ngOnInit(): void {
     //get empId from ActiveyedRoute
     this.staffId = this.route.snapshot.params['StaffId'];
     this.resetform();
     this.staffService.bindCmdDepartment();

    //get Staff
    this.staffService.getStaffById(this.staffId).subscribe(
      data => {
        console.log(data);
        //date format
        var datePipe = new DatePipe("en-uk");
        let formatedDate: any = datePipe.transform(data.DateOfJoining, 'yyy-MM-dd');
        data.DateOfJoining = formatedDate
        this.staffService.formData = Object.assign({}, data);
        //this.empService.formData = data;
      }
    ) 
}
onSubmit(form: NgForm) {

  console.log(form.value);
  let addId = this.staffService.formData.StaffId;
  //insert

  if (addId == 0 || addId == null) {
    this.insertEmployee(form);
    //window.location.reload();

  }

  else {
    //update
    console.log("update");
    this.updateEmployeeRecord(form);


  }

}

//clear all content at initialisation

resetform(form?: NgForm) {
  if (form != null) {
    form.resetForm();
  }
}
//insert employee
insertEmployee(form?: NgForm) {

  console.log("inserting employee...")
  this.staffService.insertStaff(form.value).subscribe(
    (result) => {
      console.log("result" + result);
      this.resetform(form);
      
    }
  );
  window.location.reload();
}

//update employee

updateEmployeeRecord(form?: NgForm) {

  console.log("updating employee...")
  this.staffService.updateStaff(form.value).subscribe(
    (result) => {
      console.log("result" + result);
      this.resetform(form);
      this.staffService.bindStaff();
      
    }
  );
  window.location.reload();
}
  
}