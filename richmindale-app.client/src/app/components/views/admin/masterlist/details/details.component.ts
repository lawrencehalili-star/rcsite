import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CommonService } from '../../../../../shared/services/common.service';
import { ActivatedRoute } from '@angular/router';
import { RegistrarService } from '../../../../../shared/services/admin/registrar.service';


@Component({
  selector: 'app-details',
  templateUrl: './details.component.html'
})
export class DetailsComponent implements OnInit {

  id:any;
  paramSubscription: Subscription = new Subscription();

  constructor(private route: ActivatedRoute, private common: CommonService, private service: RegistrarService) {}

  ngOnInit(): void {
    this.paramSubscription = this.route.params.subscribe(params => this.id = params['id']);
  }

}
