import { Component, OnInit } from '@angular/core';
import { InformationService } from 'src/app/shared/services/information.service';

@Component({
  selector: 'app-time-is-up',
  templateUrl: './time-is-up.component.html',
  styleUrls: ['./time-is-up.component.css']
})
export class TimeIsUpComponent implements OnInit {

  constructor(private informationService:InformationService) { }
  error !: number
  ngOnInit(): void {
    console.log("error: (time-is-up): "+this.informationService.resultAlgorithm.Error)
    this.error = this.informationService.resultAlgorithm.Error!
  }

}
