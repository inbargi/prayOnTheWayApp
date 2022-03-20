/* import { google } from 'googlemaps';
 */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AskMinyanService } from 'src/app/shared/services/askMinyan.service';
import { InformationService } from 'src/app/shared/services/information.service';
/* import { } from '@types/googlemaps';
import {} from 'googlemaps | google.maps';
import * as googleMaps from '@google/maps'; */

let map: google.maps.Map;


@Component({
  selector: 'app-live-map',
  templateUrl: './live-map.component.html',
  styleUrls: ['./live-map.component.css'],
  

})
export class LiveMapComponent implements OnInit {

  public lat:number = this.askminyan.location.Lat! ;
  public lng:number = this.askminyan.location.Lng!;
  
 
  public origin: any;
  public destination: any;

  constructor(private information:InformationService,private askminyan:AskMinyanService, private route: Router) { 
    console.log(this.information.askMinyan);
    this.getDirection();
    console.log(this.information);
  }
  
  
  getDirection() {
    console.log("התחללללתי");
    
    this.origin =this.information.askMinyan.LocationPoint?.toString();
    console.log(this.information.askMinyan.LocationPoint?.toString());
    
    // { lat: this.information.askMinyan.LocationPoint?.Lat, lng: this.information.askMinyan.LocationPoint?.Lng};
    console.log("loca:", this.information.askMinyan.LocationPoint?.toString());
    
    this.destination =this.information.resultAlgorithm.Destination?.toString();
    console.log(this.information.resultAlgorithm.Destination?.toString());
     

    this.origin = 'Netivot';
    this.destination = 'Ofakim';
  }  
  ngOnInit(): void {
    
   /*  declare function require(path: string): any;
    var googleMap = require('@google/maps') */
  }
  moveTotal(){
    this.route.navigate(['/total-so-far']);
  }
 initMap(): void {
      const directionsService = new google.maps.DirectionsService();
      const directionsRenderer = new google.maps.DirectionsRenderer();

    /*   const map = new google.maps.Map( */
        map = new google.maps.Map(document.getElementById("map") as HTMLElement, {
          center: { lat: -34.397, lng: 150.644 },
          zoom: 8,
        });
       /*  document.getElementById("map") as HTMLElement,
        {
          
           center: {lat: 30, lng: -110},
            zoom: 8,
             mapId: '1234' 
        } as google.maps.MapOptions
      ); */
    
      directionsRenderer.setMap(map);
    
     /*  const onChangeHandler = function () {
        calculateAndDisplayRoute(directionsService, directionsRenderer);
      };
    
      (document.getElementById("start") as HTMLElement).addEventListener(
        "change",
        onChangeHandler
      );
      (document.getElementById("end") as HTMLElement).addEventListener(
        "change",
        onChangeHandler
      ); */
    }
    
   calculateAndDisplayRoute(directionsService: google.maps.DirectionsService, directionsRenderer: google.maps.DirectionsRenderer) :void
    {
      directionsService
        .route({ origin: { query: (document.getElementById("start") as HTMLInputElement).value, },
                 destination: { query: (document.getElementById("end") as HTMLInputElement).value,  },
                 travelMode: google.maps.TravelMode.DRIVING}, (response, status) =>{
                  console.log(status);

                  if (status == 'OK') {
                    directionsRenderer.setDirections(response);
                  }
          })

       /*  .then((response) => {
          directionsRenderer.setDirections(response);
        })
        .catch((e) => window.alert("Directions request failed due to " + status)); */
    }
    
     
 /*     var axios = require('axios'); 

    var config = {
  method: 'get',
  url: "https://maps.googleapis.com/maps/api/directions/json
  ?avoid=highways
  &destination=31.768319,35.21371
  &mode=driving
  &origin=Jerusalem
  &key=AIzaSyCh20t1cystYQqfW329T9O9Hos-vIDqZKs",
  headers: { }
};

axios(config)
.then(function (response) {
  console.log(JSON.stringify(response.data));
})
.catch(function (error) {
  console.log(error);
});
     var axios = require('axios');  */
/* 
    var config = {
  method: 'get',
  url: "https://maps.googleapis.com/maps/api/directions/json
  ?avoid=highways
  &destination=31.768319,35.21371
  &mode=driving
  &origin=Jerusalem
  &key=AIzaSyCh20t1cystYQqfW329T9O9Hos-vIDqZKs",
  headers: { }
};

axios(config)
.then(function (response) {
  console.log(JSON.stringify(response.data));
})
.catch(function (error) {
  console.log(error);
});*/

  /*}*/
}

function lanchWaze()
{
 /*  void launchWaze(double lat, double lng) async {
    var url = 'waze://?ll=${lat.toString()},${lng.toString()}';
    var fallbackUrl =
        'https://waze.com/ul?ll=${lat.toString()},${lng.toString()}&navigate=yes';
    try {
      bool launched =
          await launch(url, forceSafariVC: false, forceWebView: false);
      if (!launched) {
        await launch(fallbackUrl, forceSafariVC: false, forceWebView: false);
      }
    } catch (e) {
      await launch(fallbackUrl, forceSafariVC: false, forceWebView: false);
      //https://stackoverflow.com/questions/63847357/flutter-deeplink-to-google-maps-and-waze
    }
  } */
}