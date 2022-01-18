import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AskMinyan } from '../models/askMinyan.model';
import { LocationPoint } from '../models/locationPoint.model';
@Injectable({
  providedIn: 'root'
})
export class AskMinyanService {
  location: LocationPoint={};
 
  constructor(private http:HttpClient)
  { 
     
  }

  driverLocation(location:LocationPoint):Observable<AskMinyan>
  {
     return this.http.post(environment.api_url+'AskMinyan',location)
  }

/*   }  selectMinyan(selectMinyanList){
 */
  feedback(succesfullyMinyan:Boolean)
  {
    return this.http.put(environment.api_url+'Minyan',succesfullyMinyan)
  }

}
