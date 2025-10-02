import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonService } from '../../../../shared/services/common.service';
import { AdmissionService } from '../../../../shared/services/public/admission.service';
import { ToastrService } from 'ngx-toastr';
import { AdmissionMain } from '../../../../shared/models/public/admission-main.model';
import { verifyEmail } from './verifyEmail';

@Component({
  selector: 'app-admissions',
  templateUrl: './admissions.component.html'
})
export class AdmissionsComponent implements OnInit, OnDestroy {

  search: any;
  codeSent: boolean = false;
  msg: any;
  validated: boolean = false;
  isViewed: boolean = false;
  isAgreed: boolean = false;
  id: string = '00000000-0000-0000-0000-000000000000';
  categories: any[] = [];
  programs: any[] = [];
  app: AdmissionMain = new AdmissionMain();

  constructor(private router: Router,
    private common: CommonService,
    private service: AdmissionService,
    private toastr: ToastrService) { }


  ngOnInit(): void {
    // For US Only
    //this.common.getDegreeCategory().subscribe(res => { this.categories = res; });
    this.common.getProgramByCategoryId(1).subscribe(res => { this.programs = res; });
    //this.common.getCommonDropdown('programs').subscribe(res => { this.categories = res; }); 
  }

  ngOnDestroy(): void {

  }

  CategoryChanged(): void {
    this.common.getProgramByCategoryId(this.app.ProgramCategoryId).subscribe(res => { this.programs = res; });
    //this.common.getProgramByCategoryId(1).subscribe(res => { this.programs = res; });
  }

  VerifyEmail(event: any): void {
    event.target.disabled = true; //changed from false to true
    this.service.verifyEmail(this.app.EmailAddress).subscribe(res => {
      console.log(res);
      if (res.status === 'success') {
        this.codeSent = true;
        this.isViewed = true;
        this.msg = res.msg;
        this.toastr.success(res.msg);
      } else {
        event.target.disabled = false;
        this.codeSent = false;
        this.toastr.error(res.msg);
      }
    }, error => {
      event.target.disabled = false;
      console.error('Error verifying email', error);
      this.toastr.error('Failed to send verification email.');
    });
  }

  ValidateOTP(event: any): void {
    event.target.disabled = false;
    this.service.validatePasskey(this.app.EmailAddress, this.app.Passkey).subscribe((res: { status: string; msg: string | undefined; }) => {
      if (res.status === 'success') {
        this.validated = false;

      } else {
        event.target.disabled = false;
        this.validated = false;
        this.toastr.error(res.msg);
      }
    });

  }

  Review(): void {
    window.open('img/Richmindale-Catalog-2502.pdf', '_blank');
    this.isViewed = true;
  }

  AgreedChanged(): void {
    this.isAgreed = !this.isAgreed;
  }

  ProceedToModify(): void {
    this.service.verifyApplication(this.app).subscribe(res => {
      if (res.status === 'success') {
        this.id = res.id;
        this.router.navigate(['rims/admissions/modify/' + this.id]);
        window.location.href = '/rims/admissions/modify/' + this.id;
      } else {
        this.toastr.error(res.msg);
      }
    });
  }

  SearchCourse(): void {
    if (this.search && this.search.trim() !== '') {
      this.router.navigate(['academics', 'courses', this.search]);
    } else {
      console.warn('Search input is empty!');
    }
  }  
}
