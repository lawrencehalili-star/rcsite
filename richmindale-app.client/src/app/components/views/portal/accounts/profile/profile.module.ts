import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfileRoutingModule } from './profile-routing.module';
import { FormsModule } from '@angular/forms';
import { ProfileComponent } from './profile.component';


@NgModule({
  declarations: [
    ProfileComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    ProfileRoutingModule
  ]
})
export class ProfileModule { }
