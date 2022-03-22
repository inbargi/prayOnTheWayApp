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
  statistics = ["המניין התקיים בהצלחה", "תפילה נפוצה", "זמן יצירת מניין"]
  diagrams = ["line-chart", "bar-chart", "pie-chart", "doughnut-chart"]
  statistics_chart = [[this.diagrams[0]], [this.diagrams[1], this.diagrams[2], this.diagrams[3]], [this.diagrams[2], this.diagrams[3]]]
  lineChartData?: any[] = [[], []];
  barChartData?: any[] = [[], []];
  pieChartData?: any[] = [];
  doughnutChartData?: any[] = [];
  

  selectedStatistics = 0;
  currentStatisticName = "";

  selectedDiagramaYour: any;

  selectedChanged(index: number) {
    this.selectedStatistics = index;
    this.currentStatisticName=this.statistics[index];
  }
  showDiagrama(selectDiagrama: number) {
    this.selectedDiagramaYour = selectDiagrama;
    this.showdiagram();
  }

  prayers: Prayer[] = []
  constructor(private prayerSevice: PrayerService, private statisticsService: StatisticsService) { }

  ngOnInit(): void {
    /*this.prayerSevice.getPrayers().subscribe((res:Prayer[])=>this.prayers=res)*/
  }
  showdiagram(){
    if (this.selectedStatistics == 0) 
    {
      this.statisticsService.successfullyMinyan().subscribe(res => {
        
        console.log(res);
        
        this.pieChartData = res;
        this.doughnutChartData = res;
        for (let data of res) {
          this.barChartData = [[], []]
          this.lineChartData = [[], []]
          this.lineChartData[0].push(data.name)
          this.lineChartData[1].push(data.value)
          this.barChartData[0].push(data.name)
          this.barChartData[1].push(data.value)
        }
        console.log("bar"+this.barChartData);
        console.log("pie"+this.pieChartData);
        console.log("line"+this.lineChartData);
        console.log("dought"+this.doughnutChartData);
      })
    }
    if (this.selectedStatistics == 1) 
    {
      this.statisticsService.numberAskayers().subscribe(res => {
        this.pieChartData = res;
        this.doughnutChartData = res;
        for (let data of res) {
          this.barChartData = [[], []]
          this.lineChartData = [[], []]
          this.lineChartData[0].push(data.name)
          this.lineChartData[1].push(data.value)
          this.barChartData[0].push(data.name)
          this.barChartData[1].push(data.value)
        }
      })
    }
    if (this.selectedStatistics == 2) 
    {
      this.statisticsService.timeCreateMinyan().subscribe(res => {
        this.pieChartData = res;
        this.doughnutChartData = res;
        for (let data of res) {
          this.barChartData = [[], []]
          this.lineChartData = [[], []]
          this.lineChartData[0].push(data.name)
          this.lineChartData[1].push(data.value)
          this.barChartData[0].push(data.name)
          this.barChartData[1].push(data.value)
        }
      })
    }
  }
}
