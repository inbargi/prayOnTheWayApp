import { Injectable } from '@angular/core';
import { Prayer } from '../models/prayer.model';
import {HttpClient} from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PrayerService {

  constructor(private http:HttpClient) { }

  getPrayers():Observable<Prayer[]>
  {
    return this.http.get<Prayer[]>(environment.api_url+'prayer');
  }

  addPrayer(prayer:Prayer):Observable<boolean>
  {
    return this.http.post<boolean>(environment.api_url+'prayer',prayer)

  }
}
