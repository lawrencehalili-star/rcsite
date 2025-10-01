import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonService } from '../../../../../shared/services/common.service';
import { RegistrarService } from '../../../../../shared/services/admin/registrar.service';
import { ToastrService } from 'ngx-toastr';
import { Filter } from '../../../../../shared/models/admin/filter.model';

@Component({
  selector: 'app-document-requests',
  templateUrl: './document-requests.component.html'
})
export class DocumentRequestsComponent implements OnInit, OnDestroy {

  filter: Filter = new Filter();

  constructor(private common: CommonService, private service: RegistrarService, private toastr: ToastrService) { }

  ngOnInit(): void {

  }

  ngOnDestroy(): void {

  }

  SearchChanged(): void {

  }

  PageSizeChanged(): void {

  }

  SortNameChanged(): void {

  }

  SortDirectionChanged(): void {

  }
}
