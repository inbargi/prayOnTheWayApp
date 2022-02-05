import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AskMinyan } from 'src/app/shared/models/askMinyan.model';
import { LocationPoint } from 'src/app/shared/models/locationPoint.model';
import { Result } from 'src/app/shared/models/result.model';
import { AskMinyanService } from 'src/app/shared/services/askMinyan.service';
import { InformationService } from 'src/app/shared/services/information.service';

@Component({
  selector: 'app-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.css']
})
export class UserHomeComponent implements OnInit {

  constructor( private askMinyanService:AskMinyanService,private route:Router, private informationService:InformationService) { }
  askMinyan: any={};
  resultAlgorithm: Result={};
  ngOnInit(): void {
    this.getLocation().then((location:any)=>
      {
        console.log(location);
        const driverLocation= new LocationPoint(location.coords.latitude,location.coords.longitude);
        this.askMinyanService.driverLocation(driverLocation)
        .subscribe(res=>{
          console.log(res);
          this.resultAlgorithm=res
          this.informationService.resultAlgorithm=res
          console.log("infor: "+ this.informationService.resultAlgorithm)
          if(this.resultAlgorithm.Error != 0)
            this.route.navigate(['/time-is-up'])
          if(this.resultAlgorithm.SelectMinyan!=null)
            this.route.navigate(['/minyan-selection'])
          if(this.resultAlgorithm.AskToMinyanDTO!=null)
            this.route.navigate(['/live-map'])
        } );
        this.askMinyanService.location=location;
        this.informationService.askMinyan=(this.askMinyan as AskMinyan)
      });
    }
  getLocation()
  {
    return new Promise((res, rej) => {
      navigator.geolocation.getCurrentPosition(res, rej);
    });
  }

}
