import { NgModule , CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { UserHomeComponent } from './user-home/user-home.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { MenuManagerComponent } from '../user/menu-manager/menu-manager.component';
import { TimeIsUpComponent } from './time-is-up/time-is-up.component';
import {MatTableModule} from '@angular/material/table';
import {MatDividerModule} from '@angular/material/divider';
import {MatListModule} from '@angular/material/list';
import { TotalSoFarComponent } from './total-so-far/total-so-far.component';
import { MinyanSelectionComponent } from './minyan-selection/minyan-selection.component';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatBadgeModule} from '@angular/material/badge';
import {MatCardModule} from '@angular/material/card';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { LiveMapComponent } from './live-map/live-map.component';
import { AgmCoreModule } from '@agm/core';
import { AgmDirectionModule } from 'agm-direction';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatDialogModule} from '@angular/material/dialog';




const routes: Routes = [
  {path:'',component:UserHomeComponent},
  {path:'live-map',component:LiveMapComponent},
  {path:'time-is-up',component:TimeIsUpComponent},
  {path:'total-so-far',component:TotalSoFarComponent},
  {path:'feedback',component:FeedbackComponent},
  {path:'minyan-selection',component:MinyanSelectionComponent},

];


@NgModule({
  declarations: [
    UserHomeComponent,
    FeedbackComponent,
    TotalSoFarComponent,
    TimeIsUpComponent,
    MinyanSelectionComponent,
    LiveMapComponent,
    MenuManagerComponent,
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    MatBadgeModule,
    MatCardModule,
    MatCheckboxModule,
    MatDividerModule,
    MatProgressBarModule,
    MatListModule,
    MatTableModule,
    MatDialogModule,
    RouterModule.forChild(routes),
    AgmCoreModule.forRoot({ // @agm/core
      apiKey: 'AIzaSyB4L4kEM_xkWvVp6jLOtOBIOKYkrFFbJus',
    }),
    AgmDirectionModule    // agm-direction
  ],
  exports:[RouterModule,
    MatButtonModule,
    MatIconModule,
    MatBadgeModule,
    MatCardModule,
    MatProgressBarModule,
    
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]

})
export class UserModule { }
