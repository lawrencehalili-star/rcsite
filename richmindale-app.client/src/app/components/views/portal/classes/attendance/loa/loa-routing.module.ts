import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoaComponent } from './loa.component';

const routes: Routes = [
  {
    path: '',
    component: LoaComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoaRoutingModule { }
