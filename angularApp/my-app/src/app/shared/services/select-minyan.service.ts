import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { LocationPoint } from '../models/locationPoint.model';
import { SelectMinyan } from '../models/selectMinyan.model';
import { Result } from '../models/result.model';

@Injectable({
  providedIn: 'root'
})
export class SelectMinyanService {

  constructor(private http:HttpClient) { }
  updateSelectMinyan(selectsMinyan:SelectMinyan[],IdAskMinyan:number,idSelect:number):Observable<Result>
  {
    return this.http.post<Result>(environment.api_url+'selectMinyan/SavingSelectionMinyan?selects=',selectsMinyan);
  } 
 
}
