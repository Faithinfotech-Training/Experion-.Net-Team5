import { Role } from "./Roles";

export class Users {
    UserId :number;
    UserName:string;
    Password:string;
    RoleId:number;

    //object oriented Model
    Role:Role;
    IsActive:boolean;
}
