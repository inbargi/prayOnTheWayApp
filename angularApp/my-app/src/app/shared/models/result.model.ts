import { AskToMinyan } from "./askToMinyan.model";
import { LocationPoint } from "./locationPoint.model";
import { SelectMinyan } from "./selectMinyan.model";

export class Result{
    constructor(
        public  AsksToMinyanDTO?:AskToMinyan,
        public  IdAskMinyan?:number,
        public  SelectMinyan?:SelectMinyan[],
        public  Error?:number,
        public Origin?:LocationPoint,
        public Destination?:LocationPoint,
        ){}
}