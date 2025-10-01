import { Component, ViewChild, ViewContainerRef, ComponentFactoryResolver, OnInit, AfterViewInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { SchoolAdminService } from '../../../../../../shared/services/admin/school-admin.service';
import { ToastrService } from 'ngx-toastr';
import { AdmissionDetails } from '../../../../../../shared/models/admin/admission-details.model';
import { CommonService } from '../../../../../../shared/services/common.service';
import { EnrollmentAgreementComponent } from '../../../../../templates/enrollment-agreement/enrollment-agreement.component';
import { EnrollmentAgreementRcComponent } from '../../../../../templates/enrollment-agreement-rc/enrollment-agreement-rc.component';
import { Dropdowns } from '../../../../../../shared/models/dropdowns.model';
import { AgreementTemplatesComponent } from '../../../../../templates/agreement-templates/agreement-templates.component';
import { CollegeAgreementComponent } from '../../../../../templates/college-agreement/college-agreement.component';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html'
})
export class DetailsComponent implements OnInit, AfterViewInit {

  @ViewChild('agreementContainer', { read: ViewContainerRef}) agreementContainer!: ViewContainerRef;
 

  id: any;
  paramSubscription: Subscription = new Subscription();
  dtl: AdmissionDetails = new AdmissionDetails();

  countries: Dropdowns[] = [];

  aCountries: Dropdowns[] = [];
  sStates: Dropdowns[] = [];
  sCities: Dropdowns[] = [];

  fStates: Dropdowns[] = [];
  fCities: Dropdowns[] = [];

  mStates: Dropdowns[] = [];
  mCities: Dropdowns[] = [];

  gStates: Dropdowns[] = [];
  gCities: Dropdowns[] = [];

  campuses: Dropdowns[] = [];
  categories: Dropdowns[] = [];
  programs: Dropdowns[] = [];
  terms: any[] = [];
  methods: Dropdowns[] = [];
  discounts: Dropdowns[] = [];
  marital: Dropdowns[] = [];
  nationality: Dropdowns[] = [];
  religions: Dropdowns[] = [];
  phoneCodes: Dropdowns[] = [];

  qualifications: Dropdowns[] = [];
  prevPrograms: Dropdowns[] = [];

  constructor(private route: ActivatedRoute,
    private router: Router,
    private common: CommonService,
    private service: SchoolAdminService,
    private toastr: ToastrService) {
    

  }

  ngOnInit(): void {
    this.paramSubscription = this.route.params.subscribe(params => this.id = params['id']);
    this.common.getCampusCountries().subscribe(res => { this.countries = res; });
    this.common.getCommonDropdown('Programs').subscribe(res => { this.categories = res; });
    this.common.getCommonDropdown('Terms').subscribe(res => { this.terms = res; });
    this.common.getLearningMethods().subscribe(res => { this.methods = res; });
    this.common.getCommonDropdown('Discounts').subscribe(res => { this.discounts = res; });
    this.common.getMaritalStatus().subscribe(res => { this.marital = res; });
    this.common.getNationality().subscribe(res => { this.nationality = res; });
    this.common.getReligions().subscribe(res => { this.religions = res; });
    this.common.getCountries().subscribe(res => { this.aCountries = res; });
    this.common.getPhoneCodes().subscribe(res => { this.phoneCodes = res; });
    this.common.getCommonDropdown('Qualifications').subscribe(res => { this.qualifications = res; });
    this.common.getCommonDropdown('Previous Programs').subscribe(res => { this.prevPrograms = res; });
    this.service.loadAdmissionSummaryDetails(this.id).subscribe(res => { 
      this.dtl = res; 
      this.dtl.CountryId = res.CountryId;
      this.dtl.StudentState = res.StudentState;
      this.dtl.ProgramCategoryId = res.ProgramCategoryId;
      this.CountryChanged('program');
      this.CountryChanged('student');
      this.StateChanged('student');
      this.CategoryChanged();
      this.dtl.LrnCampusId = res.LrnCampusId;
      console.log('Campus Id: ' + this.dtl.LrnCampusId);
        this.LoadAgreementForm();
      });
    
    
  }

  ngAfterViewInit(): void {
    this.LoadAgreementForm();
  }

  CountryChanged(frm:any): void {
    if(this.dtl !== null || this.dtl != 'undefined') {
      switch (frm) {
        case 'program':
          this.common.getCampusByCountry(this.dtl.CountryId).subscribe(res => { this.campuses = res; });
          break;
        case 'student':
          this.common.getStatesByCountryId(this.dtl.StudentCountry).subscribe(res => { this.sStates = res; });
          break;
        case 'father':
          this.common.getStatesByCountryId(this.dtl.FatherCountry).subscribe(res => { this.fStates = res; });
          break;
        case 'mother':
          this.common.getStatesByCountryId(this.dtl.MotherCountry).subscribe(res => { this.mStates = res; });
          break;
        case 'guard':
          this.common.getStatesByCountryId(this.dtl.GuardianCountry).subscribe(res => { this.gStates = res; });
          break;
      }
    }
  }

  StateChanged(frm: any): void {
    if(this.dtl != null || this.dtl != 'undefined') {
      switch (frm) {
        case 'student':
          this.common.getCitiesByStateId(this.dtl.StudentState).subscribe(res => { this.sCities = res; });
          break;
        case 'father':
          this.common.getCitiesByStateId(this.dtl.FatherState).subscribe(res => { this.fCities = res; });
          break;
        case 'mother':
          this.common.getCitiesByStateId(this.dtl.MotherState).subscribe(res => { this.mCities = res; });
          break;
        case 'guard':
          this.common.getCitiesByStateId(this.dtl.GuardianState).subscribe(res => { this.gCities = res; });
          break;
      }
    }
  }

  CategoryChanged(): void {
    if(this.dtl != null || this.dtl != 'undefined') {
      this.common.getCommonDropdownByParent(this.dtl.ProgramCategoryId).subscribe(res => { this.programs = res; });
    }
  }

  LoadAgreementForm(): void {
    
    this.agreementContainer.clear();
    
    this.agreementContainer.createComponent(CollegeAgreementComponent).instance.LrnAdmissionApplicationId = this.id;
    
   
  }

  Print() : void {
    window.print();
  }

}
