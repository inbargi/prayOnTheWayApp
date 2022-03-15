import { Component, Input, OnInit } from '@angular/core';
import * as echarts from 'echarts';
import { EChartsOption } from 'echarts';
import { StatisticsService } from 'src/app/shared/services/statistics.service';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css']
})
export class PieChartComponent implements OnInit {

  @Input() pieChartData:any[] = []
  @Input() currentStatisticName: string=""
  constructor(private statisticsService:StatisticsService) {
    
  }


  ngOnInit(): void {
   this.option={
    title: {
        text: '',
        subtext: '',
        left: 'center'
    },
    tooltip: {
        trigger: 'item'
    },
    legend: {
        orient: 'vertical',
        left: 'left',
    },
    series: [
        {
            name: this.currentStatisticName,
            type: 'pie',
            radius: '50%',
            data: this.pieChartData,
            emphasis: {
                itemStyle: {
                    shadowBlur: 10,
                    shadowOffsetX: 0,
                    shadowColor: 'rgba(0, 0, 0, 0.5)'
                }
            }
        }
    ]
};
  }

  option : EChartsOption = {}
  
  
  
  
  

}

