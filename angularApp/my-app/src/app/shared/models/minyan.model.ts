import { Time } from "@angular/common";

export class Minyan
{
    constructor(
    public  IdMinyan?:number,
    public  IdPrayer?:number,
    public  DateMinyan?:Date,
    public  BeginningTimeNavToMinyan?:Time,
    public  IdLocationMinyan?:number,
    public  NumOfPeopleInMinyan?:number,
    public  SuccessfullyMinyan?:Boolean
    )
    {
        
    }
}
