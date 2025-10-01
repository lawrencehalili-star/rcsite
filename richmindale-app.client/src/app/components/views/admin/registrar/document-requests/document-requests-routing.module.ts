import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DocumentRequestsComponent } from './document-requests.component';

const routes: Routes = [
  {
    path: '',
    component: DocumentRequestsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DocumentRequestsRoutingModule { }
