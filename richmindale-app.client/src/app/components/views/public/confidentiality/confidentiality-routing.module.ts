import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfidentialityComponent } from './confidentiality.component';

const routes: Routes = [
  {
    path: '',
    component: ConfidentialityComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConfidentialityRoutingModule { }
