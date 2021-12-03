export class Appointment {
    AppointmentId : number=0;
    AppointmentDate :  Date=new Date;
    IsActive :boolean=false;
    PatientId : number;
    DoctorId : number;
    DoctorName : string;
    PatientName : string;
    Contact : number;
}
