import { NgModule , CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { UserHomeComponent } from './user-home/user-home.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { RoadNavComponent } from './road-nav/road-nav.component';
import { TimeIsUpComponent } from './time-is-up/time-is-up.component';
import { TotalSoFarComponent } from './total-so-far/total-so-far.component';
import { WarningComponent } from './warning/warning.component';

const routes: Routes = [
  {path:'',component:UserHomeComponent},

];


@NgModule({
  declarations: [
    UserHomeComponent,
    RoadNavComponent,
    FeedbackComponent,
    TotalSoFarComponent,
    TimeIsUpComponent,
    WarningComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]

})
export class UserModule { }
