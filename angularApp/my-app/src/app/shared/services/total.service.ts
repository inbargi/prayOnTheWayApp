import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { InformationService } from './information.service';

@Injectable({
  providedIn: 'root'
})
export class TotalService {

  constructor(private http:HttpClient, private informationService:InformationService) {
    
  }
  totalSoFar(idAskMinyan:number | null | undefined):Observable<number>
  {
    return this.http.get<number>(environment.api_url+'totalSoFar/GetTotalSoFar?idAskMinyan='+idAskMinyan);
  };
}
  

