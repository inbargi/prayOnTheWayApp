import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {
  arrived!:boolean;
  succesfully!:boolean;
  message!:string;

  constructor() {
    

   }

  ngOnInit(): void {
    
  }

  setAll(completed: boolean) {
    this.arrived = completed;
    }
  

  submit()
  {
    
  }

}
