import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IncompleteComponent } from './incomplete.component';

const routes: Routes = [
  {
    path: '',
    component: IncompleteComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IncompleteRoutingModule { }
