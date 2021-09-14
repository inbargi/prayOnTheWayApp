import { Component, Input, OnInit } from '@angular/core';
import { Prayer } from 'src/app/shared/models/prayer.model';
import { PrayerService } from 'src/app/shared/services/prayer.service';
import { StatisticsService } from 'src/app/shared/services/statistics.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {
  statistics=["המניין התקיים בהצלחה","תפילה נפוצה","זמן יצירת מניין"]
  diagrams=["line-chart","bar-chart","pie-chart","doughnut-chart"]
  statistics_chart=[[this.diagrams[0]],[this.diagrams[1],this.diagrams[2],this.diagrams[3]],[this.diagrams[2],this.diagrams[3]]]
  lineChartData:any[]=[[],[]];
  barChartData:     any[]=[];
  pieChartData:     any[]=[];
  doughnutChartData:any[]=[];

  selectedStatistics=0;
  @Input() selectedDiagramaYour: any;
  selectedChanged(index:number){
    this.selectedStatistics=index;
  }
  showDiagrama(selectDiagrama:number){
    this.selectedDiagramaYour=selectDiagrama;
  }

  prayers:Prayer[]=[]
  constructor(private prayerSevice:PrayerService, private statisticsService:StatisticsService) { }

  ngOnInit(): void {
    
    this.statisticsService.numberAskayers().subscribe(res=>
      {
          this.pieChartData=res;
          for(let data of res)
          {
            this.lineChartData[0].push(data.name)
            this.lineChartData[1].push(data.value)

          }
          console.log(res)
      }
      )

    /*this.prayerSevice.getPrayers().subscribe((res:Prayer[])=>this.prayers=res)*/
  }

}
