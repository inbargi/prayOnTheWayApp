import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MinyanService {

  constructor(private http:HttpClient) { }

  ExitFromMinyan(idMinyan:number)
  {
    return this.http.put(environment.api_url+'Minyan/ExitFromMinyan',idMinyan); 
  }

}
