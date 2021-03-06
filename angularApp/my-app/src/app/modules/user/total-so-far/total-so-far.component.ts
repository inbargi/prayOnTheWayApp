import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Route, Router } from '@angular/router';
import { InformationService } from 'src/app/shared/services/information.service';
import { TotalService } from 'src/app/shared/services/total.service';


@Component({
  selector: 'app-total-so-far',
  templateUrl: './total-so-far.component.html',
  styleUrls: ['./total-so-far.component.css'],
  encapsulation: ViewEncapsulation.None

})
export class TotalSoFarComponent implements OnInit {

  constructor(private totalService: TotalService, private informationService:InformationService, private route: Router) { }
  totalNumOfPeople!:number;
  ngOnInit(): void {
    this.totalService.totalSoFar(this.informationService.resultAlgorithm.IdAskMinyan!)
    .subscribe(res => {this.totalNumOfPeople = res})
  }
  moveNavigate(){
    this.route.navigate(['/live-map']);
  }
}
