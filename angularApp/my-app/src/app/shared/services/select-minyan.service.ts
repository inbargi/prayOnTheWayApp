import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { LocationPoint } from '../models/locationPoint.model';
import { SelectMinyan } from '../models/selectMinyan.model';

@Injectable({
  providedIn: 'root'
})
export class SelectMinyanService {

  constructor(private http:HttpClient) { }
  updateSelectMinyan(location:LocationPoint):Observable<SelectMinyan[]>
  {
    return this.http.get<SelectMinyan[]>(environment.api_url+'selectMinyan/DataToSelectionMinyan/'+location);
  } 
 
}
