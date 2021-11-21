import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LocationPoint } from '../models/locationPoint.model';
@Injectable({
  providedIn: 'root'
})
export class AskMinyanService {


  constructor(private http:HttpClient)
  { 
     
  }

  driverLocation(location:LocationPoint)
  {
     return this.http.post(environment.api_url+'AskMinyan',location)
  }

}
