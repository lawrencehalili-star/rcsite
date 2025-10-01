import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrientationComponent } from './orientation.component';

const routes: Routes = [
  {
    path: '',
    component: OrientationComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrientationRoutingModule { }
