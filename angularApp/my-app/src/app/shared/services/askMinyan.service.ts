import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AskMinyan } from '../models/askMinyan.model';
import { LocationPoint } from '../models/locationPoint.model';
import { Result } from '../models/result.model';
@Injectable({
  providedIn: 'root'
})
export class AskMinyanService {
  location: LocationPoint={};
 
  constructor(private http:HttpClient)
  { 
     
  }

  driverLocation(location:LocationPoint):Observable<Result>
  {
    console.log("ask:"+location.Lat+","+location.Lng)
     return this.http.post(environment.api_url+'AskMinyan/AddAskMinyan',location)
  }

/*   }  selectMinyan(selectMinyanList){
 */
  

  askMinyanByID(idAskMinyan:number|undefined):Observable<AskMinyan>{
     return this.http.post(environment.api_url+'AskMinyan/GetAskMinyan',idAskMinyan)
  }
}
