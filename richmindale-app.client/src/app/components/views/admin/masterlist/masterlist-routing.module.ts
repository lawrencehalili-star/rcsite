import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MasterlistComponent } from './masterlist.component';

const routes: Routes = [
  {
    path: '',
    component: MasterlistComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MasterlistRoutingModule { }
