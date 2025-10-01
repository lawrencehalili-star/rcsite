import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FerpaComponent } from './ferpa.component';

const routes: Routes = [
  {
    path: '',
    component:FerpaComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FerpaRoutingModule { }
