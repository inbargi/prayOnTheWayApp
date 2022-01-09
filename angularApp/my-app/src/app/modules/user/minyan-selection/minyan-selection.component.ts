import { Component, OnInit } from '@angular/core';
import { Inject } from '@angular/core';
import { SelectMinyanService } from 'src/app/shared/services/select-minyan.service';
import { AskMinyanService } from 'src/app/shared/services/askMinyan.service';
import { LocationPoint } from 'src/app/shared/models/locationPoint.model';
import { SelectMinyan } from 'src/app/shared/models/selectMinyan.model';

@Component({
  selector: 'app-minyan-selection',
  templateUrl: './minyan-selection.component.html',
  styleUrls: ['./minyan-selection.component.css']
})
export class MinyanSelectionComponent implements OnInit {
  
  
  constructor(private askMinyanService:AskMinyanService, private selectMinyanService: SelectMinyanService,@Inject('selects') public selects: SelectMinyan[] ) { }
  
  ngOnInit(): void {
  
    this.selectMinyanService.updateSelectMinyan(this.askMinyanService.location).subscribe(res => {
      this.selects = res;
   }); 
  }
  hidden = false;

  toggleBadgeVisibility() {
    this.hidden = !this.hidden;
  }
}
