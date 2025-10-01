import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GrievancesComponent } from './grievances.component';

const routes: Routes = [
  {
    path: '',
    component: GrievancesComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GrievancesRoutingModule { }
