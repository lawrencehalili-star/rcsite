import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-success',
  templateUrl: './success.component.html'
})
export class SuccessComponent implements OnInit, OnDestroy {

    id:any;
    paramSubscription: Subscription = new Subscription();


    constructor(private route: ActivatedRoute) {}

    ngOnInit(): void {
      this.paramSubscription = this.route.params.subscribe(params => this.id = params['id']);
    }

    ngOnDestroy(): void {
      
    }

}
