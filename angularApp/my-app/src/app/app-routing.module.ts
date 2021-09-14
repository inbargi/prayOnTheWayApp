import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path:'manager',loadChildren:()=>import('./modules/manager/manager.module').then(m => m.ManagerModule)},
  {path:'',loadChildren:()=>import('./modules/user/user.module').then(m => m.UserModule)},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  
  exports: [RouterModule]
})
export class AppRoutingModule { }
