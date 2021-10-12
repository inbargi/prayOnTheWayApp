import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgxEchartsModule } from 'ngx-echarts';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BarChartComponent } from './modules/manager/statistics/bar-chart/bar-chart.component';
import { RoadNavComponent } from './road-nav/road-nav.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { TotalSoFarComponent } from './total-so-far/total-so-far.component';
import { TimeIsUpComponent } from './time-is-up/time-is-up.component';
import { WarningComponent } from './warning/warning.component';


@NgModule({
  declarations: [
    AppComponent,
    RoadNavComponent,
    FeedbackComponent,
    TotalSoFarComponent,
    TimeIsUpComponent,
    WarningComponent


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxEchartsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
