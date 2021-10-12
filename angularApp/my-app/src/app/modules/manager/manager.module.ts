import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginManagerComponent } from 'src/app/modules/manager/login-manager/login-manager.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { RouterModule, Routes } from '@angular/router';
import { NgxEchartsModule } from 'ngx-echarts';
import { BarChartComponent } from './statistics/bar-chart/bar-chart.component';
import { LineChartComponent } from './statistics/line-chart/line-chart.component';
import { PieChartComponent } from './statistics/pie-chart/pie-chart.component';
import { DoughnutChartComponent } from './statistics/doughnut-chart/doughnut-chart.component';
import { MenuManagerComponent } from './menu-manager/menu-manager.component';


const routes: Routes = [
  {path:'',component:LoginManagerComponent},
  {path:'menu-manager',component:MenuManagerComponent},
  {path:'statistics',component:StatisticsComponent},
  {path:'statistics/bar-chart',component:BarChartComponent},
  {path:'statistics/line-chart',component:LineChartComponent},
  {path:'statistics/pie-chart',component:PieChartComponent},
  {path:'statistics/doughnut-chart',component:DoughnutChartComponent},


];



@NgModule({
  declarations: [LoginManagerComponent,
  StatisticsComponent,
  BarChartComponent,
  LineChartComponent,
  PieChartComponent,
  DoughnutChartComponent
 ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgxEchartsModule.forRoot({
      echarts: () => import('echarts')
    }),
    RouterModule.forChild(routes)
  ],
  exports:[LoginManagerComponent,RouterModule]
})
export class ManagerModule { }
