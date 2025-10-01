import { HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PublicLayoutComponent } from './components/layouts/public-layout/public-layout.component';
import { AdminLayoutComponent } from './components/layouts/admin-layout/admin-layout.component';
import { PortalLayoutComponent } from './components/layouts/portal-layout/portal-layout.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { loadingInterceptor } from './shared/interceptors/loading.interceptor';
import { BsModalService } from 'ngx-bootstrap/modal';
import { DataTablesModule } from 'angular-datatables';
import { NgxPrinterModule } from 'ngx-printer';
import { AgreementTemplatesComponent } from './components/templates/agreement-templates/agreement-templates.component';
import { AgreementTemplatesModule } from './components/templates/agreement-templates/agreement-templates.module';
import { CollegeAgreementComponent } from './components/templates/college-agreement/college-agreement.component';
import { CollegeAgreementModule } from './components/templates/college-agreement/college-agreement.module';



@NgModule({
  declarations: [
    AppComponent,
    PublicLayoutComponent,
    AdminLayoutComponent,
    PortalLayoutComponent,
  ],
  imports: [
    BrowserModule, 
    HttpClientModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    NgxSpinnerModule,
    DataTablesModule,
    ToastrModule.forRoot({
      timeOut: 2000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true,
      progressAnimation: 'decreasing'
    }),
    NgxPrinterModule.forRoot({
      printOpenWindow: true,
      renderClass: "custom-print",
      printPreviewOnly: false
    }),
    AgreementTemplatesModule,
    CollegeAgreementModule
  ],
  providers: [
    BsModalService,
    provideHttpClient(withInterceptors([loadingInterceptor]))
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
