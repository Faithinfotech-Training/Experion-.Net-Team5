export class Medicine{
    MedicineId : number=0;
    MedicineName: string='';
    StartDate : Date=new Date;
    EndDate : Date=new Date;
    Dosage : number;
    PatientId : number;
    DoctorId : number;
    IsActive:boolean=false;
}