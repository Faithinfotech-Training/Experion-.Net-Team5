export class Bill{
    BillId : number=0;
    BillNumber: string='';
    BillDate : Date=new Date;
    Amount : number;
    PatientId : number;
    IsActive:boolean=false;
}