import { SelectMinyan } from "./selectMinyan.model";

export class selectResult{
    constructor(
        public  IdAskMinyan?:number,
        public  SelectMinyan?:SelectMinyan[],
        public  IdSelect?:number
        ){}
    }