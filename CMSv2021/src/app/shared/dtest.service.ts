import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Dtest } from './dtest';
import { Ntest } from './ntest';
import { Ntestlist } from './ntestlist';

@Injectable({
  providedIn: 'root'
})
export class DtestService {
//create instance of Test
dtests: Dtest[];
dtestForm: Dtest = new Dtest();
dtestnames:Ntest[];
ntestList:Ntestlist[];
constructor(private httpClient: HttpClient) { }

//get all testnames dropdown
bindCmdNtestname() {
  this.httpClient.get(environment.apiUrl + "/api/dtest/gettestname")
    .toPromise().then(response =>
      this.dtestnames = response as Ntest[])
    }


//Add test
AddTest(dtest: Dtest): Observable<any> {
  //console.log('hi');
  console.log(dtest);
  return this.httpClient.post(
    environment.apiUrl + '/api/dtest/addtest',
    dtest
  );
}

//get all test
bindCmdPatientList(patientid:number) {
  this.httpClient.get(environment.apiUrl + "/api/dtestlist/GetTestByPatientId/"+patientid)
    .toPromise().then(response =>
      this.ntestList = response as Ntestlist[])
    }

}

  

