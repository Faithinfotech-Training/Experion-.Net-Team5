import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Staff } from 'src/app/shared/staff';
import { StaffService } from 'src/app/shared/staff.service';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-staff',
  templateUrl: './staff.component.html',
  styleUrls: ['./staff.component.css']
})
export class StaffComponent implements OnInit {

  staffId: number;
  staff: Staff = new Staff();
  decPattern="[(0-9).]*";
   namePattern="[a-zA-Z ]*";
  constructor(public staffService: StaffService,
    private router: Router, private route: ActivatedRoute, private tostrService: ToastrService) { }

  ngOnInit(): void {
    this.staffId = this.route.snapshot.params['staffId'];
    this.resetform();
    this.staffService.bindCmdDepartment();
    this.staffService.bindCmdDesignation();
    if (this.staffId != 0 || this.staffId != null) {
      //get employee
      this.staffService.getStaffById(this.staffId).subscribe(
        data => {
          console.log(data);
          //date format
          var datePipe = new DatePipe("en-UK");
          let formatedDate: any = datePipe.transform(data.JoiningDate, 'yyyy-MM-dd');
          data.JoiningDate = formatedDate;
          this.staffService.formData = Object.assign({}, data);
          this.staffService.formData = data;
        },
        error =>
          console.log(error)
      );
    }
    this.resetform();


  }
  onSubmit(form: NgForm) {

    this.staffId = this.route.snapshot.params['staffId']
    console.log(form.value);
    let addId = this.staffService.formData.StaffId;

    //insert

    if (addId == 0 || addId == null) {
      this.insertStaff(form);
      //window.location.reload();

    }

    else {
      //update
      console.log("update");
      this.updateStaffRecord(form);


    }
  }
  //clear all content at initialisation

  resetform(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }

  }
  //insert Staff
  insertStaff(form?: NgForm) {

    console.log("inserting Staff...")
    this.staffService.insertStaff(form.value).subscribe(
      (result) => {
        console.log("result" + result);
        this.resetform(form);
        this.tostrService.success('Staff Details inserted!', 'succes!');
      }
    );
  }
  //update Staff

  updateStaffRecord(form?: NgForm) {

    console.log("updating employee...")
    this.staffService.updateStaff(form.value).subscribe(
      (result) => {
        console.log("result" + result);
        this.resetform(form);
        this.staffService.bindStaff();
        this.tostrService.success('Staff Details updated!', 'succes!');
      }
    );

  }
}