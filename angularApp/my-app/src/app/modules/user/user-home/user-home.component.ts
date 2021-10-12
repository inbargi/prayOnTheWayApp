import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.css']
})
export class UserHomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    navigator.geolocation.getCurrentPosition( function( location ) {
      console.log( `User location - Latitude: ${location.coords.latitude} | Longitude: ${location.coords.longitude}` );
    
    } );
  }

}
