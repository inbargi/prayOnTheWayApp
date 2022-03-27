import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AskMinyan } from '../models/askMinyan.model';
import { AskToMinyan } from '../models/askToMinyan.model';
import { Minyan } from '../models/minyan.model';

@Injectable({
  providedIn: 'root'
})
export class FeedbeckService {

  constructor(private http:HttpClient) {   }

   updateComming(isComming:AskToMinyan){
      console.log(isComming);
      return this.http.put(environment.api_url+'AsksToMinyan/UpdateAsksToMinyan',isComming)
   }
   UpdateMinyan(idMinyan:number):Observable<boolean>
   {
     return this.http.put<boolean>(environment.api_url+'AsksToMinyan/UpdateMinyanItem',idMinyan)
   }
   getAllMessage():Observable<any>
   {
      return this.http.get<any>(environment.api_url+'AsksToMinyan/GetAllMessage')
   }
} 
