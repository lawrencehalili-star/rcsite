import { Component, Input, OnInit } from '@angular/core';
import { AdmissionDetails } from '../../../shared/models/admin/admission-details.model';
import { Admission } from '../../../shared/models/public/admission.model';
import { SchoolAdminService } from '../../../shared/services/admin/school-admin.service';
import { NgxPrinterService } from 'ngx-printer';

@Component({
  selector: 'app-enrollment-agreement-rc',
  templateUrl: './enrollment-agreement-rc.component.html'
})
export class EnrollmentAgreementRcComponent implements OnInit {

   @Input('LrnAdmissionApplicationId') LrnAdmissionApplicationId:any;
   dtl:AdmissionDetails = new AdmissionDetails();
  constructor(private service: SchoolAdminService, private printService: NgxPrinterService) {}

  ngOnInit(): void {
      this.service.loadAdmissionSummaryDetails(this.LrnAdmissionApplicationId).subscribe(res => {
        this.dtl = res;
        console.log('Program Code: ' + res.ProgramCode);
        this.dtl.ProgramCode = res.ProgramCode;
      });
  }

  Print() : void {
    this.printService.printDiv('agreement');
  }

}
