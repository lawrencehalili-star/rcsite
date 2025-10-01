import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SapComponent } from './sap.component';

const routes: Routes = [
  {
    path:'',
    component: SapComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SapRoutingModule { }
