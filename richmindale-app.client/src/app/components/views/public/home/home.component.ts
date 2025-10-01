import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonService } from '../../../../shared/services/common.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {

  programs:any[] = [];

  constructor(private common: CommonService, private router: Router, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.common.getProgramsByCategoryId(1).subscribe(res => { this.programs = res;});
  }

  Admission() : void {
    window.location.href = 'rims/admissions';
  }



}
