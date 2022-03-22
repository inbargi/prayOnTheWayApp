import { Observable } from "rxjs";

export class LocationPoint
{
    constructor(
    public  Lat?:number,
    public  Lng?:number
    )
    {
      function  toString()
      {
        return Lat+","+Lng;
      }  
    }
    
}