import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QrCodeModule} from 'ng-qrcode';
import { ModifyRoutingModule } from './modify-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxCountriesDropdownModule } from 'ngx-countries-dropdown';
import { ModifyComponent } from './modify.component';
import { DndDirective } from '../../../../../shared/directives/dnd.directive';
import { UploadProgressComponent } from '../../../../templates/upload-progress/upload-progress.component';

@NgModule({
  declarations: [
    ModifyComponent,
    DndDirective,
    UploadProgressComponent,
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    QrCodeModule,
    NgxCountriesDropdownModule,
    ModifyRoutingModule
  ]
})
export class ModifyModule { }
