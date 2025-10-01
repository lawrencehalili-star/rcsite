import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CatalogRoutingModule } from './catalog-routing.module';
import { FormsModule } from '@angular/forms';
import { CatalogComponent } from './catalog.component';
import { PdfViewerModule } from 'ng2-pdf-viewer';

@NgModule({
  declarations: [
    CatalogComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    PdfViewerModule,
    CatalogRoutingModule
  ]
})
export class CatalogModule { }
