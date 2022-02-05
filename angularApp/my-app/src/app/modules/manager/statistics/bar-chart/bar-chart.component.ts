import { Component, Input, OnInit } from '@angular/core';
import { EChartsOption } from 'echarts';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.css']
})
export class BarChartComponent implements OnInit {

  @Input() barChartData:any[] = [[],[]]
  initOpts = {
    renderer: 'svg',
    width: 300,
    height: 300
  }

  options: EChartsOption= {
    color: ['#3398DB'],
    tooltip: {
      trigger: 'axis',
      axisPointer: {
        type: 'shadow'
      }
    },
    grid: {
      left: '3%',
      right: '4%',
      bottom: '3%',
      containLabel: true
    },
    xAxis: [
      {
        type: 'category',
        data: this.barChartData[0],
        axisTick: {
          alignWithLabel: true
        }
      }
    ],
    yAxis: [{
      type: 'value'
    }],
    series: [{
      name: '',
      type: 'bar',
      barWidth: '60%',
      data: this.barChartData[1]
    }]
  }

  constructor() { }

  ngOnInit(): void {
  }

}
