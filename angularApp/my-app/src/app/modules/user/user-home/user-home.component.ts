import { Component, OnInit } from '@angular/core';
import { AskMinyan } from 'src/app/shared/models/askMinyan.model';
import { LocationPoint } from 'src/app/shared/models/locationPoint.model';
import { AskMinyanService } from 'src/app/shared/services/askMinyan.service';
import { InformationService } from 'src/app/shared/services/information.service';

@Component({
  selector: 'app-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.css']
})
export class UserHomeComponent implements OnInit {

  constructor( private askMinyanService:AskMinyanService, private informationService:InformationService) { }
  askMinyan: any={};
  ngOnInit(): void {
    this.getLocation().then((location:any)=>
      {
        const driverLocation= new LocationPoint(location.coords.latitude,location.coords.longitude);
        this.askMinyanService.driverLocation(driverLocation)
        .subscribe(res=> this.askMinyan=res);
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
