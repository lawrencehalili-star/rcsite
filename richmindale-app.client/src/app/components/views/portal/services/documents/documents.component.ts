import { Component, TemplateRef, OnInit, OnDestroy } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ServiceRequestService } from '../../../../../shared/services/portal/service-request.service';
import { CommonService } from '../../../../../shared/services/common.service';
import { DocumentRequest } from '../../../../../shared/models/portal/services/document-request.model';
import { StorageService } from '../../../../../shared/services/auth/storage.service';
import { Config } from 'datatables.net';
import { Subject } from 'rxjs';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';




@Component({
  selector: 'app-documents',
  templateUrl: './documents.component.html'
})
export class DocumentsComponent implements OnInit, OnDestroy {

  modalRef?:BsModalRef;
  doctypes:any[] = [];
  config = { animated: true };

  dtOption: Config = {
    pagingType: 'full_numbers',
    paging: true,
    pageLength: 10,
    search: true,
    processing: true,
    dom: 'Bfrtip'
  };

  dtTrigger: Subject<any> = new Subject();
  
  reqs: DocumentRequest[] = [];
  req: DocumentRequest = new DocumentRequest();

  constructor(private storage: StorageService, 
              private service:ServiceRequestService, 
              private common: CommonService, 
              private modal: BsModalService,
              private toastr: ToastrService) {
                
              }

  ngOnInit(): void {
    this.req.StudentId = this.storage.getSession('StudentId');
    this.loadRequest();
    this.common.getDocumentTypes().subscribe(res => { this.doctypes = res; });
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  showModal(template:TemplateRef<any>, id?:any) : void {
    this.req.Id = id;
    this.modalRef = this.modal.show(template);
  }

  GetDocumentAmount() : void {
    this.common.getDocumentAmount(this.req.DocumentTypeId).subscribe(res => { this.req.Amount = Number.parseFloat(res).toFixed(2);});
  }

  SubmitRequest() : void {
    this.service.saveDocumentRequest(this.req).subscribe(res => {
      if(res.status === 'success') {
        this.toastr.success(res.msg);
        this.dtTrigger.next(this.reqs);
       
      } else {
        this.toastr.error(res.msg);
      }
      this.modal.hide();
    });
  }

  loadRequest() : void {
    this.service.loadStudentDocumentRequest(this.req.StudentId).subscribe(res => { 
      this.reqs = res.data; 
      this.dtTrigger.next(this.reqs); 
    });
  }
  
}
