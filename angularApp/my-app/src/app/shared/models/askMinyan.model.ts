import { LocationPoint } from "./locationPoint.model";

export class AskMinyan
{
    constructor(
    public  IdAskMinyan?:number,
    public LocationPoint?:LocationPoint,
    public  IdPrayer?:number,
    public  AskTime?:string
    ){}
}


