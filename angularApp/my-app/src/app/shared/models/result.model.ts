import { AskToMinyan } from "./askToMinyan.model";
import { SelectMinyan } from "./selectMinyan.model";

export class Result{
    constructor(
        public  AskToMinyanDTO?:AskToMinyan,
        public  IdAskMinyan?:number,
        public  SelectMinyan?:SelectMinyan[],
        public  Error?:number
        ){}
}