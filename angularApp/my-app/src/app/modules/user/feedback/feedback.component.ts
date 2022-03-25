import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AskToMinyan } from 'src/app/shared/models/askToMinyan.model';
import { Minyan } from 'src/app/shared/models/minyan.model';
import { FeedbeckService } from 'src/app/shared/services/feedbeck.service';
import { InformationService } from 'src/app/shared/services/information.service';
import { MenuManagerComponent } from '../menu-manager/menu-manager.component';


@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {
  arrivedm:boolean = true;
  succesfullym:boolean = false;
  messageText!:string;
  askToMinyan!:AskToMinyan;
  isCome:boolean=true;
  element!:HTMLInputElement
   minyan!:number

  constructor(private feedbackService:FeedbeckService,private informationService:InformationService,public dialog: MatDialog) {
    

   }
  ngOnInit(): void {
    
  }

  setAll(completed: boolean) {
    this.arrivedm = completed;
    }
    arrived()
    {
      this.arrivedm=!this.arrivedm;
      console.log(this.arrivedm);
   /*   let element = <HTMLInputElement> document.getElementById("#arrived");  
     if (element.checked) {
       this.arrivedm=true;
      }
      else{
        this.arrivedm=false;
      } */
      
    }
    succesfully()
    {
        this.succesfullym=!this.succesfullym
        console.log(this.succesfullym);
        
     /*  let element = <HTMLInputElement> document.getElementById("#succesfully");  
     if (element.checked) {
       this.succesfullym=true;
      }
      else{
        this.succesfullym=false;
      } */
    }
    message(){
      let element = <HTMLInputElement> document.getElementById("message");  
        this.messageText=element.value ;
        
    }
  submit()
  {
    this.askToMinyan=this.informationService.resultAlgorithm.AsksToMinyanDTO!;
    this.askToMinyan.IsComming=this.arrivedm
    this.askToMinyan.Message = this.messageText  
    this.feedbackService.updateComming(this.askToMinyan).subscribe(res=>{
      console.log(res) 
    })
    //this.succesfullym=
    this.minyan=this.informationService.resultAlgorithm.AsksToMinyanDTO!.IdMinyan!
    
    this.feedbackService.UpdateMinyan(this.minyan).subscribe()
    const dialogRef = this.dialog.open(MenuManagerComponent);

  }

}
