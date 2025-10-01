import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentAccountsComponent } from './student-accounts.component';

const routes: Routes = [
  {
    path: '',
    component: StudentAccountsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentAccountsRoutingModule { }
