import { Component, OnDestroy } from '@angular/core';
import { Prayer } from './shared/models/prayer.model';
import { InformationService } from './shared/services/information.service';
import { MinyanService } from './shared/services/minyan.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnDestroy{

  constructor(private minyanService:MinyanService, private information:InformationService){}
  
  ngOnDestroy(): void {

    console.log("destroy");
    console.log("i am in minyan number:"+ this.information.resultAlgorithm.AsksToMinyanDTO?.IdMinyan!);
    
    this.minyanService.ExitFromMinyan(this.information.resultAlgorithm.AsksToMinyanDTO?.IdMinyan!)
    
  }
  
  title = 'pray-on-the-way';
}
