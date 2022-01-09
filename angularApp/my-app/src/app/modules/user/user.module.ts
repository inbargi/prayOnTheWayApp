import { NgModule , CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { UserHomeComponent } from './user-home/user-home.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { RoadNavComponent } from './road-nav/road-nav.component';
import { TimeIsUpComponent } from './time-is-up/time-is-up.component';
import { TotalSoFarComponent } from './total-so-far/total-so-far.component';
import { WarningComponent } from './warning/warning.component';
import { MinyanSelectionComponent } from './minyan-selection/minyan-selection.component';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatBadgeModule} from '@angular/material/badge';
import {MatCardModule} from '@angular/material/card';
import {MatProgressBarModule} from '@angular/material/progress-bar';

const routes: Routes = [
  {path:'',component:UserHomeComponent},
  {path:'time-is-up',component:TimeIsUpComponent},
  {path:'total-so-far',component:TotalSoFarComponent},
  {path:'feedback',component:FeedbackComponent},
  {path:'minyan-selection',component:MinyanSelectionComponent},
];


@NgModule({
  declarations: [
    UserHomeComponent,
    RoadNavComponent,
    FeedbackComponent,
    TotalSoFarComponent,
    TimeIsUpComponent,
    WarningComponent,
    MinyanSelectionComponent
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    MatBadgeModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule,
    MatButtonModule,
    MatIconModule,
    MatBadgeModule,
    MatCardModule,
    MatProgressBarModule],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]

})
export class UserModule { }
