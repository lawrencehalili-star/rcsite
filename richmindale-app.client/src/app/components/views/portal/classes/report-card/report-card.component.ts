import { Component, OnDestroy, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { JuniorSeniorUsComponent } from '../../../../templates/class-cards/junior-senior-us/junior-senior-us.component';
import { JuniorSeniorDepedComponent } from '../../../../templates/class-cards/junior-senior-deped/junior-senior-deped.component';
import { GradeLevelDepedComponent } from '../../../../templates/class-cards/grade-level-deped/grade-level-deped.component';
import { GradeLevelUsComponent } from '../../../../templates/class-cards/grade-level-us/grade-level-us.component';

@Component({
  selector: 'app-report-card',
  templateUrl: './report-card.component.html'
})
export class ReportCardComponent implements OnInit, OnDestroy {
 
 
  @ViewChild('reportCardsContainer', { read: ViewContainerRef, static: true}) reportCardsContainer!: ViewContainerRef;

  constructor() {}

  ngOnInit(): void {
    this.LoadReportCards();
  }

  ngOnDestroy(): void {
    
  }

  LoadReportCards() : void {
    this.reportCardsContainer.clear();

    this.reportCardsContainer.createComponent(GradeLevelDepedComponent);
  }

}
