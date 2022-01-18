import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ErrorServiceService {
 public error:number = 0;
  constructor() { }
  
  anErrorOccurred():number{
    
    return this.error;
    
  }
}
