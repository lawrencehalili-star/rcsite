import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { environment } from '../../../../../environment/environment';

@Component({
  selector: 'app-agreement',
  templateUrl: './agreement.component.html'
})
export class AgreementComponent implements OnInit {

  code:any;
  title: any;
  paramSubscription: Subscription = new Subscription();
  src:any = environment.ROOT_URL + 'img/agreement/';

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => this.code = params['code']);
    this.title = this.code.toUpperCase();
    this.src = environment.ROOT_URL + 'img/agreements/' + this.code.toUpperCase() + '-0225.pdf';
  }

  
}
