import { Component, OnInit } from '@angular/core';
import { LocationPoint } from 'src/app/shared/models/locationPoint.model';

@Component({
  selector: 'app-road-nav',
  templateUrl: './road-nav.component.html',
  styleUrls: ['./road-nav.component.css']
})
export class RoadNavComponent implements OnInit {

  
  /* url:string = "waze://?ll=" + location.toString + "&navigate=yes";
  intentWaze:Intent = new Intent(Intent.ACTION_VIEW, Uri.parse(url));
  
  intentWaze.setPackage("com.waze");
  // and more importantly, this:
  intentGoogleNav.setPackage("com.google.android.apps.maps");
  
  String uriGoogle = "google.navigation:q=" + latitude + "," + longitude;
  Intent intentGoogleNav = new Intent(Intent.ACTION_VIEW, Uri.parse(uriGoogle));
  
  String title = context.getString(R.string.title);
  Intent chooserIntent = Intent.createChooser(intentGoogleNav, title);
  Intent[] arr = new Intent[1];
  arr[0] = intentWaze;
  chooserIntent.putExtra(Intent.EXTRA_INITIAL_INTENTS, arr);
  context.startActivity(chooserIntent); */

  constructor() { }
 
  
  ngOnInit(): void {
 
  }
  async launchWaze(lat:string, lng:string):Promise<void> {
    let url:string = 'waze://?ll=${lat},${lng}';
    let fallbackUrl ='https://waze.com/ul?ll=${lat.toString()},${lng.toString()}&navigate=yes&zoom=13';
    try {
        launched:Boolean = await launch(url, forceSafariVC: false, forceWebView: false);
      if (!launched) {
        await launch(fallbackUrl, forceSafariVC: false, forceWebView: false);
      }
    } catch (e) {
      await launch(fallbackUrl, forceSafariVC: false, forceWebView: false);
    }
  }
}

