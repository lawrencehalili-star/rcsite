import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { AdmissionService } from '../../../../../shared/services/public/admission.service';
import { ToastrService } from 'ngx-toastr';
import { Admission } from '../../../../../shared/models/public/admission.model';
import { UploadService } from '../../../../../shared/services/upload.service';
import { CommonService } from '../../../../../shared/services/common.service';
import { AdmissionDocs } from '../../../../../shared/models/public/admission-docs.model';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-modify',
  templateUrl: './modify.component.html',
})
export class ModifyComponent implements OnInit, OnDestroy {
  id: any;
  paramSubscription: Subscription = new Subscription();
  adm: Admission = new Admission();
  steps: any[] = [
    {
      idx: 0,
      label: '1',
      page: 'page-01',
      title: 'Program Details',
      isCompleted: false,
    },
    {
      idx: 1,
      label: '2',
      page: 'page-02',
      title: 'Student Details',
      isCompleted: false,
    },
    {
      idx: 2,
      label: '3',
      page: 'page-03',
      title: 'Previous School',
      isCompleted: false,
    },
    {
      idx: 3,
      label: '4',
      page: 'page-04',
      title: "Father's Information",
      isCompleted: false,
    },
    {
      idx: 4,
      label: '5',
      page: 'page-05',
      title: "Mother's Information",
      isCompleted: false,
    },
    {
      idx: 5,
      label: '6',
      page: 'page-06',
      title: "Guardian's Information",
      isCompleted: false,
    },
    {
      idx: 6,
      label: '7',
      page: 'page-07',
      title: 'Supporting Documents',
      isCompleted: false,
    },
  ];
  activeTabIndex: number = 0;

  categories: any[] = [];
  terms: any[] = [];
  programs: any[] = [];
  campusCountries: any[] = [];
  campuses: any[] = [];
  methods: any[] = [];
  discounts: any[] = [];
  marital: any[] = [];
  religions: any[] = [];
  nationalities: any[] = [];
  phoneCodes: any[] = [];
  qualifications: any[] = [];
  prevPrograms: any[] = [];

  countries: any[] = [];

  sStates: any[] = [];
  sCities: any[] = [];

  fStates: any[] = [];
  fCities: any[] = [];

  mStates: any[] = [];
  mCities: any[] = [];

  gStates: any[] = [];
  gCities: any[] = [];

  docTypes: any[] = [];
  doc: AdmissionDocs = new AdmissionDocs();
  docs: AdmissionDocs[] = [];

  TORFiles: any[] = [];
  COEFiles: any[] = [];
  GovIDFiles: any[] = [];
  RACFiles: any[] = [];

  frmAdm!: FormGroup;
  formData!: FormData;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private service: AdmissionService,
    private upload: UploadService,
    private common: CommonService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.paramSubscription = this.route.params.subscribe(
      (params) => (this.id = params['id'])
    );
    this.common.getDegreeCategory().subscribe((res) => {
      this.categories = res;
    });
    //this.common.getCommonDropdown('programs').subscribe(res => { this.categories = res;});
    this.common.getUSCountry().subscribe((res) => {
      this.campusCountries = res;
    });
    //this.common.getCampusCountries().subscribe(res => { this.campusCountries = res;});
    this.common.getCommonDropdown('Discounts').subscribe((res) => {
      this.discounts = res;
    });
    this.common.getCommonDropdown('Qualifications').subscribe((res) => {
      this.qualifications = res;
    });
    this.common.getCommonDropdown('Previous Programs').subscribe((res) => {
      this.prevPrograms = res;
    });
    this.common.getUsLearningMethod().subscribe((res) => {
      this.methods = res;
    });
    this.common.getCommonDropdown('Terms').subscribe((res) => {
      this.terms = res;
    });
    //this.common.getLearningMethods().subscribe(res => { this.methods = res;});
    this.common.getMaritalStatus().subscribe((res) => {
      this.marital = res;
    });
    this.common.getReligions().subscribe((res) => {
      this.religions = res;
    });
    this.common.getNationality().subscribe((res) => {
      this.nationalities = res;
    });
    this.common.getCountries().subscribe((res) => {
      this.countries = res;
    });
    this.common.getPhoneCodes().subscribe((res) => {
      this.phoneCodes = res;
    });
    this.common.getCommonDropdown('Admission Documents').subscribe((res) => {
      this.docTypes = res;
    });
    this.service.loadAdmissionSummaryDetails(this.id).subscribe((res) => {
      this.adm = res;
      this.adm.CountryId = res.CountryId;
      this.adm.ProgramCategoryId = res.ProgramCategoryId;
      this.CountriesChange('main');
      this.CountriesChange('student');
      this.CountriesChange('mom');
      this.CountriesChange('dad');
      this.CountriesChange('guard');
      this.StatesChange('student');
      this.StatesChange('mom');
      this.StatesChange('dad');
      this.StatesChange('guard');
      this.CategoryChange();
    });
    this.BuildForm();
  }

  ngOnDestroy(): void {}

  BuildForm(): void {
    this.frmAdm = this.formBuilder.group({});
  }

  PagerClick(index: number): void {
    this.activeTabIndex = index;
  }

  CategoryChange(): void {
    this.common
      .getProgramByCategoryId(this.adm.ProgramCategoryId)
      .subscribe((res) => {
        this.programs = res;
      });
  }

  //added null/undefined checks before making the api calls
  CountriesChange(frm: any) {
    switch (frm) {
      case 'main':
        if (this.adm.CountryId) {
          this.common
            .getCampusByCountry(this.adm.CountryId)
            .subscribe((res) => {
              this.campuses = res;
            });
        }
        break;
      case 'student':
        if (this.adm.StudentCountry) {
          this.common
            .getStatesByCountryId(this.adm.StudentCountry)
            .subscribe((res) => {
              this.sStates = res;
            });
        }
        break;
      case 'dad':
        if (this.adm.FatherCountry) {
          this.common
            .getStatesByCountryId(this.adm.FatherCountry)
            .subscribe((res) => {
              this.fStates = res;
            });
        }
        break;
      case 'mom':
        if (this.adm.MotherCountry) {
          this.common
            .getStatesByCountryId(this.adm.MotherCountry)
            .subscribe((res) => {
              this.mStates = res;
            });
        }
        break;
      case 'guard':
        if (this.adm.GuardianCountry) {
          this.common
            .getStatesByCountryId(this.adm.GuardianCountry)
            .subscribe((res) => {
              this.gStates = res;
            });
        }
        break;
    }
  }

  StatesChange(frm: any) {
    switch (frm) {
      case 'student':
        if (this.adm.StudentState) {
          this.common
            .getCitiesByStateId(this.adm.StudentState)
            .subscribe((res) => {
              this.sCities = res;
            });
        }
        break;
      case 'dad':
        if (this.adm.FatherState) {
          this.common
            .getCitiesByStateId(this.adm.FatherState)
            .subscribe((res) => {
              this.fCities = res;
            });
        }
        break;
      case 'mom':
        if (this.adm.MotherState) {
          this.common
            .getCitiesByStateId(this.adm.MotherState)
            .subscribe((res) => {
              this.mCities = res;
            });
        }
        break;
      case 'guard':
        if (this.adm.GuardianState) {
          this.common
            .getCitiesByStateId(this.adm.GuardianState)
            .subscribe((res) => {
              this.gCities = res;
            });
        }
        break;
    }
  }

  UploadClick(): void {
    this.upload.uploadAdmissionFiles(this.doc).subscribe((res) => {
      if (res.status === 'success') {
        this.toastr.success(res.msg);
        this.service.loadAdmissionDocs(this.adm.Id).subscribe((result) => {
          this.docs = result.data;
        });
      } else {
        this.toastr.error(res.msg);
      }
    });
  }

  MovePrev(): void {
    if (this.activeTabIndex > 0) {
      this.activeTabIndex = this.activeTabIndex - 1;
    }
  }

  MoveNext(): void {
    this.service.updateAdmissionApplication(this.adm).subscribe((res) => {
      if (res.status === 'success') {
        this.toastr.success(res.msg);
        this.steps[this.activeTabIndex].isCompleted = true;
      } else {
        this.toastr.error(res.msg);
      }
    });

    if (this.activeTabIndex < 6) {
      this.activeTabIndex = this.activeTabIndex + 1;
    }
  }

  SubmitApplication(): void {
    this.service.submitAdmissionApplication(this.adm).subscribe((res) => {
      if (res.status === 'success') {
        this.toastr.success(res.msg);
        this.router.navigate(['rims/admissions/success/' + this.id]);
      } else {
        this.toastr.error(res.msg);
      }
    });
  }

  onFileDropped(type: any, evt: any): void {
    this.preparedFileList(type, evt);
  }

  preparedFileList(type: any, files: Array<any>) {
    for (const item of files) {
      item.progress = 0;

      switch (type) {
        case 'tor':
          this.TORFiles.push(item);
          this.uploadFilesSimulator(this.TORFiles, 0);
          break;
        case 'coe':
          this.COEFiles.push(item);
          this.uploadFilesSimulator(this.COEFiles, 0);
          break;
        case 'gov':
          this.GovIDFiles.push(item);
          this.uploadFilesSimulator(this.GovIDFiles, 0);
          break;
        case 'rac':
          this.RACFiles.push(item);
          this.uploadFilesSimulator(this.RACFiles, 0);
          break;
      }
    }
  }

  fileBrowseHandler(type: any, evt: any) {
    this.preparedFileList(type, evt.target.files);
  }

  uploadFilesSimulator(sfiles: any[], index: number) {
    setTimeout(() => {
      if (index === sfiles.length) {
        return;
      } else {
        const progressInterval = setInterval(() => {
          if (sfiles[index].progress === 100) {
            clearInterval(progressInterval);
            this.uploadFilesSimulator(sfiles, index + 1);
          } else {
            sfiles[index].progress += 5;
          }
        }, 200);
      }
    }, 1000);
  }

  deleteFile(type: any, index: number) {
    switch (type) {
      case 'tor':
        this.TORFiles.splice(index, 1);
        break;
      case 'coe':
        this.COEFiles.splice(index, 1);
        break;
      case 'gov':
        this.GovIDFiles.splice(index, 1);
        break;
      case 'rac':
        this.RACFiles.splice(index, 1);
        break;
    }
  }

  formatBytes(bytes?: any, decimals?: any) {
    if (bytes === 0) {
      return '0 Bytes';
    }
    const k = 1024;
    const dm = decimals <= 0 ? 0 : decimals || 2;
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + ' ' + sizes[i];
  }

  PayNow(): void {
    this.service.submitAdmissionApplication(this.adm).subscribe((res) => {
      if (res.status === 'success') {
        this.toastr.success(res.msg);
        this.router.navigate(['rims/admissions/payment/' + this.id]);
      } else {
        this.toastr.error(res.msg);
      }
    });
  }
}
