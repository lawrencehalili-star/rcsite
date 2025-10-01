import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkflowsRoutingModule } from './workflows-routing.module';
import { WorkflowsComponent } from './workflows.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    WorkflowsComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    WorkflowsRoutingModule
  ]
})
export class WorkflowsModule { }
