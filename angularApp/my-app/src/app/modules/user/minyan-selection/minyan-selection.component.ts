import { Component, OnInit } from '@angular/core';
import { Inject } from '@angular/core';
import { SelectMinyanService } from 'src/app/shared/services/select-minyan.service';
import { AskMinyanService } from 'src/app/shared/services/askMinyan.service';
import { LocationPoint } from 'src/app/shared/models/locationPoint.model';
import { SelectMinyan } from 'src/app/shared/models/selectMinyan.model';
import { InformationService } from 'src/app/shared/services/information.service';
import { Router } from '@angular/router';
import { selectResult } from 'src/app/shared/models/selectResult.model';

@Component({
  selector: 'app-minyan-selection',
  templateUrl: './minyan-selection.component.html',
  styleUrls: ['./minyan-selection.component.css']
})
export class MinyanSelectionComponent implements OnInit {
  
  
  constructor(private askMinyanService:AskMinyanService,private route:Router, private informationService:InformationService, private selectService:SelectMinyanService) { }
  selects!:SelectMinyan[] /* = [{NumKM:12,NumOfPeople:9,TimeDriver:14,PercentSuccess:95},{NumKM:12,NumOfPeople:6,TimeDriver:10,PercentSuccess:65},{NumKM:50,NumOfPeople:5,TimeDriver:7,PercentSuccess:50},{NumKM:22,NumOfPeople:6,TimeDriver:4,PercentSuccess:80}];
   */
  ngOnInit(): void {
    this.selects = this.informationService.resultAlgorithm.SelectMinyan!;
   /*  this.selectMinyanService.updateSelectMinyan(this.askMinyanService.location).subscribe(res => {
      this.selects = res;
   }); */
  }
  hidden = false;

  toggleBadgeVisibility() {
    this.hidden = !this.hidden;
  }
  SavingChoose(idSelect:number) 
  {
      console.log(idSelect);
      this.selectService.updateSelectMinyan(new selectResult(this.informationService.resultAlgorithm.IdAskMinyan!,this.selects,idSelect))
      .subscribe(res =>
        {
          console.log(res)
          this.informationService.resultAlgorithm=res
          
          if(res.AsksToMinyanDTO != null)
          {
            console.log("begging navigation")
            this.route.navigate(['live-map'])
          }
        }
        ); 
  }
}
