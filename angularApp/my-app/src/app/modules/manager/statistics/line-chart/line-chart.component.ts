import { Component, Input, OnInit } from '@angular/core';
import { EChartsOption } from 'echarts';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit {
  @Input() lineChartData:any[] = [[],[]]
  chartOption: EChartsOption = {
   
  }
  constructor() { }

  ngOnInit(): void {
    this.chartOption={ xAxis: {
      type: 'category',
      boundaryGap: false,
      data: this.lineChartData[0]
    },
    yAxis: {
      type: 'value'
    },
    series: [{
      data: this.lineChartData[1],
      type: 'line',
      
    }]}
  }
}