import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { PublicService } from '../../../../../shared/services/public/public.service';
import { CommonService } from '../../../../../shared/services/common.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html'
})
export class CoursesComponent implements OnInit, OnDestroy {

  id:any;
  paramSubscription: Subscription = new Subscription();

  constructor(private route: ActivatedRoute, 
              private router: Router,
              private common: CommonService, 
              private service: PublicService,
              private toastr: ToastrService) {}

  ngOnInit(): void {
    this.paramSubscription = this.route.params.subscribe(params => this.id = params['id']);
  }

  ngOnDestroy(): void {
    
  }


}
