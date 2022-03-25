import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FeedbeckService } from 'src/app/shared/services/feedbeck.service';

@Component({
  selector: 'app-menu-manager',
  templateUrl: './menu-manager.component.html',
  styleUrls: ['./menu-manager.component.css']
})
export class MenuManagerComponent implements OnInit {

  constructor(private feedbackservice:FeedbeckService) { }
  public feedbacks?: string[] = [];

  ngOnInit(): void {
      this.feedbackservice.getAllMessage().subscribe(res => {
        this.feedbacks=res;
      });
  }
  
  
}


