import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DishonestyComponent } from './dishonesty.component';

const routes: Routes = [
  {
    path: '',
    component: DishonestyComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DishonestyRoutingModule { }
