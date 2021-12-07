import { Doctor } from "./doctor";
import { Ntest } from "./ntest";
import { Patient } from "./patient";

export class Labhappointment {
    TestId:number;
    TestNameId:number;
    TestDate:Date =new Date();
    PatientId:number;
    DoctorId:number;
    IsActive:boolean;
 
    Ntest:Ntest;
    TestName:string='';
    NormalRange:string='';
 
    Doctor:Doctor;
    DoctorName:string='';
 
    Patient:Patient;
    PatientName: string='';

}
