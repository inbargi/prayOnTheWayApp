import { Component, OnInit } from '@angular/core';
import { InformationService } from 'src/app/shared/services/information.service';
import { TotalService } from 'src/app/shared/services/total.service';

@Component({
  selector: 'app-total-so-far',
  templateUrl: './total-so-far.component.html',
  styleUrls: ['./total-so-far.component.css']
})
export class TotalSoFarComponent implements OnInit {

  constructor(private totalService: TotalService, private informationService:InformationService) { }
  totalNumOfPeople:number=9;
  ngOnInit(): void {
    this.totalService.totalSoFar(this.informationService.askMinyan.IdAskMinyan)
    .subscribe(res => {this.totalNumOfPeople = res})
  }

}
