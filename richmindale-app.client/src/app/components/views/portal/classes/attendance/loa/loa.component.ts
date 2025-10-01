import { Component } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CommonService } from '../../../../../../shared/services/common.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-loa',
  templateUrl: './loa.component.html'
})
export class LoaComponent {

  modalRef?:BsModalRef;


  constructor(private common: CommonService, private modal: BsModalService, private toastr: ToastrService) {}

  ShowModal(template:any, id:any) : void {
    this.modalRef = this.modal.show(template);
  }

  SubmitRequest() : void {

  }
}
