import { Component, OnInit } from '@angular/core';
import { PublicService } from '../../../../shared/services/public/public.service';
import { CommonService } from '../../../../shared/services/common.service';
import { ToastrService } from 'ngx-toastr';
import { StorageService } from '../../../../shared/services/auth/storage.service';
import { EnrollmentApplication } from '../../../../shared/models/public/enrollment-application.model';
import { CourseDropdown } from '../../../../shared/models/public/course-dropdown.model';

@Component({
  selector: 'app-enrollment',
  templateUrl: './enrollment.component.html'
})
export class EnrollmentComponent implements OnInit {

  
  Passkey:any;
  msg:any;
  IsLoggedIn:boolean = false;
  IsVerified:boolean = false;
  IsValidated:boolean = false;
  LocationSelected:boolean = false;
  ProgramSelected:boolean = false;
  countries:any[] = [];
  campuses:any[] = [];
  methods:any[] = [];
  categories:any[] = [];
  programs:any[] = [];
  courses:any[] = [];
  selCourse:any;
  courseIds:any[] = [];
  selectedCourses:any[] = [];
  ddlCourses:CourseDropdown = new CourseDropdown();

  enroll:EnrollmentApplication = new EnrollmentApplication();

  constructor(private storage: StorageService, private service: PublicService, private common: CommonService, private toastr: ToastrService) {}

  ngOnInit(): void {
   
    this.IsLoggedIn = this.storage.getSession('IsLoggedIn') === '1' ? true : false;
    this.common.getCampusCountries().subscribe(res => { this.countries = res; });
    this.common.getCommonDropdown('programs').subscribe(res => { this.categories = res; });
    this.common.getLearningMethods().subscribe(res => { this.methods = res; });
  }

  VerifyEmail() : void {
     this.service.verifyEmail(this.enroll.EmailAddress).subscribe(res => {
        if(res.status === 'success') {
          this.IsVerified = true;
          this.msg = res.msg;
        } else {
          this.IsVerified = false;
          this.toastr.error(res.msg);
        }
     });
  }

  ValidatePasskey() : void {
    this.service.validatePasskey(this.enroll.EmailAddress, this.Passkey).subscribe(res => {
      if(res.status === 'success') {
        this.IsValidated = true;
        this.toastr.success(res.msg);
      } else {
        this.toastr.error(res.msg);
        this.IsValidated= false;
      }
    });
  }

  countryChanged() : void {
    this.common.getCampusByCountry(this.enroll.CountryId).subscribe(res => { this.campuses = res; });
  }

  categoryChanged() : void {
    this.common.getProgramsByCategoryId(this.enroll.ProgramCategoryId).subscribe(res => { this.programs = res; });
  }

  MethodChanged() : void {
    this.LocationSelected = true;
  }

  ProgramChanged() : void {
    this.ProgramSelected = true;
    this.LoadCourses();
  }

  CourseChanged(event:any):void {
    this.courseIds.push(this.selCourse);
    this.enroll.CoursesId.push({ Id: event.target.value, CourseTitle: event.target.text } );
    this.ddlCourses.CourseIds.push(this.selCourse);
    this.LoadCourses();
  }

  LoadCourses() : void {
    this.common.getAvailableCoursesByProgram(this.enroll.ProgramId).subscribe(res => { this.courses = res; });
  }

  ProceedClicked() : void {

  }

}
