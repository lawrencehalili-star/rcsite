import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TorViewComponent } from './tor-view.component';

const routes: Routes = [
  {
    path: '',
    component: TorViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TorViewRoutingModule { }
