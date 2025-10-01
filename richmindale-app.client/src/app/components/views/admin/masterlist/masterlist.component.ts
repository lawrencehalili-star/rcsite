import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegistrarService } from '../../../../shared/services/admin/registrar.service';
import { Masterlist } from '../../../../shared/models/admin/masterlist';
import { Filter } from '../../../../shared/models/admin/filter.model';

@Component({
  selector: 'app-masterlist',
  templateUrl: './masterlist.component.html'
})
export class MasterlistComponent implements OnInit {

  filter:Filter = new Filter();
  master:Masterlist[] = [];

  constructor(private router: Router, private service: RegistrarService) {}

  ngOnInit(): void {
    this.LoadMasterList();
  }

  LoadMasterList() : void {
    this.service.loadPaginatedMasterlist(this.filter).subscribe(res => { this.master = res.data;});
  }

  SearchChanged() : void {
     this.LoadMasterList();
  }

  PageSizeChanged() : void {
    this.LoadMasterList();
  }

  SortNameChanged() : void {
    this.LoadMasterList();
  }

  SortDirectionChanged() : void {
    this.LoadMasterList();
  }

  CardClicked(id:any) : void {
    this.router.navigate(['admin/masterlist/details/' + id]);
  }

}
