import { Component, OnDestroy, OnInit } from '@angular/core';
import { Filter } from '../../../../shared/models/admin/filter.model';
import { Router } from '@angular/router';
import { CommonService } from '../../../../shared/services/common.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-document-editor',
  templateUrl: './document-editor.component.html'
})
export class DocumentEditorComponent implements OnInit, OnDestroy {
  filter: Filter = new Filter()

  constructor(private router: Router, private common: CommonService, private toastr: ToastrService) {}

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

  NavigateEdit(id:any) : void {
    this.router.navigate(['/admin/document-editor/editor/' + id]);
  }
}
