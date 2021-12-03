export class Report {
    ReportId : number=0;
    ReportNumber : number=0;
    ReportDate : Date = new Date(); //
    ReportNotes : string;
    StaffId : number;
    PatientId : number;
    StaffName : string;
    DoctorId : number;
    DoctorName : string='';
    IsActive : boolean;
}