import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ManagerService {

  constructor(private http:HttpClient) { }

  login(userName:string,password:string):Observable<boolean>
  {
    return this.http.get<boolean>(environment.api_url+'manager/'+userName+'/'+password);
  }
}
