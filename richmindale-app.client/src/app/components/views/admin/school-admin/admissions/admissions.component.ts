import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonService } from '../../../../../shared/services/common.service';
import { Filter } from '../../../../../shared/models/admin/filter.model';
import { SchoolAdminService } from '../../../../../shared/services/admin/school-admin.service';
import { ToastrService } from 'ngx-toastr';
import { Admission } from '../../../../../shared/models/admin/admission.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admissions',
  templateUrl: './admissions.component.html'
})
export class AdmissionsComponent implements OnInit, OnDestroy {

  filter: Filter = new Filter();
  admissions: Admission[] = [];
  stats:any[] = []
  modalRef?:BsModalRef;
  update = {
    ApplicationRefNo: '',
    Id: '',
    Status: 8,
    Reason: ''
  }

  constructor(private router:Router,  private common: CommonService, private modal: BsModalService, private service: SchoolAdminService, private toastr: ToastrService ) {}

  ngOnInit(): void {
    this.common.getStatusDropdown('Admission').subscribe(res => {this.stats = res;});
    this.LoadAllAdmissionRequests();
    
  }

  ngOnDestroy(): void {
    
  }

  SearchChanged() : void {
    this.LoadAllAdmissionRequests();
  }

  PageSizeChanged() : void {
   this.LoadAllAdmissionRequests();
  }

  SortNameChanged() : void {
   this.LoadAllAdmissionRequests();
  }

  SortDirectionChanged() : void {
   this.LoadAllAdmissionRequests();
  }

  LoadAllAdmissionRequests() : void {
    this.service.loadAllAdmissionRequests(this.filter).subscribe(res => { this.admissions = res.data; });
  }

  StatusChange(template:any,ref:any, id:any, status: any ) : void {
     this.update = {
      ApplicationRefNo: ref,
      Id: id,
      Status: status,
      Reason: ''
     }
     this.modalRef = this.modal.show(template);
  }

  UpdateStatus() : void {
    this.service.updateAdmissionStatus(this.update.Id, this.update.Status, this.update.Reason).subscribe(res => {
      if(res.status === 'success') {
        this.modal.hide();
        this.toastr.success(res.msg);
        this.LoadAllAdmissionRequests();
      } else {
        this.toastr.error(res.msg);
      }
    });
  }

  ViewDetails(id:any) : void {
    this.router.navigate(['admin/admissions/details/' + id]);
  }



}
