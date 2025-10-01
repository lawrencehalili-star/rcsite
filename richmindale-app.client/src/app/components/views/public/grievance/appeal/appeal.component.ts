import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-appeal',
  templateUrl: './appeal.component.html'
})
export class AppealComponent implements OnInit, OnDestroy {
  id:any;
  paramSubscription:Subscription = new Subscription();

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.paramSubscription = this.route.params.subscribe(params => this.id = params['id']);
  }

  ngOnDestroy(): void {
    
  }
}
