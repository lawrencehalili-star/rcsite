import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MediaRoutingModule } from './media-routing.module';
import { MediaComponent } from './media.component';
import { FormsModule } from '@angular/forms';
import { NgbCarouselModule} from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    MediaComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    NgbCarouselModule,
    MediaRoutingModule
  ]
})
export class MediaModule { }
