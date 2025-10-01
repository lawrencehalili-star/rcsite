import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentidComponent } from './studentid.component';

const routes: Routes = [
  {
    path: '',
    component: StudentidComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentidRoutingModule { }
