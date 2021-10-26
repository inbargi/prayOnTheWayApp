import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StatisticsService {

  constructor(private http:HttpClient) { }

  numberAskayers():Observable<any[]>
  {
    return this.http.get<any[]>(environment.api_url+'statistic/DataToStatisticPrayer');
  }
 

}
