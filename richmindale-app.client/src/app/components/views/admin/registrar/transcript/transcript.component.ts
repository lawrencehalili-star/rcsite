import { Component, OnDestroy, OnInit } from '@angular/core';
import { Filter } from '../../../../../shared/models/admin/filter.model';


@Component({
  selector: 'app-transcript',
  templateUrl: './transcript.component.html'
})
export class TranscriptComponent implements OnInit, OnDestroy {
  filter: Filter = new Filter()

  constructor() {}

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
