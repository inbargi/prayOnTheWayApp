import { Component, OnInit } from '@angular/core';
import { LocationPoint } from 'src/app/shared/models/locationPoint.model';
import { AskMinyanService } from 'src/app/shared/services/askMinyan.service';

@Component({
  selector: 'app-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.css']
})
export class UserHomeComponent implements OnInit {

  constructor( private askMinyanService:AskMinyanService ) { }
  ngOnInit(): void {
    this.getLocation().then((location:any)=>
      {
        const driverLocation= new LocationPoint(location.coords.latitude,location.coords.longitude);
        this.askMinyanService.driverLocation(driverLocation)
        .subscribe(res=>console.log(res));
        this.askMinyanService.location=location;
      });
    }
  getLocation()
  {
    return new Promise((res, rej) => {
      navigator.geolocation.getCurrentPosition(res, rej);
    });
  }

}
