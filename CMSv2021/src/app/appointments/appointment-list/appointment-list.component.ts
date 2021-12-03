import { Component, OnInit } from '@angular/core';
import { AppointmentService } from 'src/app/shared/appointment.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Appointment } from 'src/app/shared/appointment';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-appointment-list',
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.css']
})
export class AppointmentListComponent implements OnInit {
 filter:string;

  constructor(public appservice: AppointmentService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.appservice.getAppointment();
  }
  //populate form by clicking the column fields
  populateForm(appointment: Appointment) {
    console.log(appointment);
    //date format
    var datePipe = new DatePipe("en-uk");
    let formatedDate: any = datePipe.transform(appointment.AppointmentDate, 'yyyy-MM-dd');
    appointment.AppointmentDate= formatedDate
    this.appservice.formData = Object.assign({}, appointment);
  }
  //delete employee
  deleteAppointment(appointment:Appointment){
    var value=confirm("Are you sure to delete"+appointment.PatientName+"?")
    if(value){
      console.log("deleting a record!");
      appointment.IsActive=false;
      console.log(appointment);
      console.log("hello");
      this.appservice.updateAppointment(appointment).subscribe(
        (result)=>{
          console.log(result);
          this.appservice.getAppointment();
        });
    }

    }
  //update an employee
  updateAppointmentRecord(AppointmentId: number) {
    console.log(AppointmentId);
    this.router.navigate(['appointment', AppointmentId]);

  }

}







