import { Component, Input, OnInit } from '@angular/core';
import { DataService } from '../../../shared/services/data-service.service';
import { AdmissionDetails } from '../../../shared/models/admin/admission-details.model';

@Component({
  selector: 'app-enrollment-agreement',
  templateUrl: './enrollment-agreement.component.html'
})
export class EnrollmentAgreementComponent implements OnInit {

  @Input('LrnAdmissionApplicationId') LrnAdmissionApplicationId:any;
  
  constructor() {}

  ngOnInit(): void {
    
  }

}
