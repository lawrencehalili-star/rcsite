import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DocumentRequestsRoutingModule } from './document-requests-routing.module';
import { DocumentRequestsComponent } from './document-requests.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    DocumentRequestsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    DocumentRequestsRoutingModule
  ]
})
export class DocumentRequestsModule { }
