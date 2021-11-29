import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { StaffService } from 'src/app/shared/staff.service';
import { Staff } from '../shared/staff';

@Component({
  selector: 'app-staffs',
  templateUrl: './staffs.component.html',
  styleUrls: ['./staffs.component.css']
})
export class StaffsComponent implements OnInit {

  constructor(public staffService: StaffService) { }

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

}
