import { Component } from '@angular/core';
import { Filter } from '../../../../shared/models/admin/filter.model';
@Component({
  selector: 'app-inquiries',
  templateUrl: './inquiries.component.html'
})
export class InquiriesComponent {
  filter: Filter = new Filter();

  constructor() {}

  SearchChanged(): void {

  }

  PageSizeChanged(): void {

  }

  SortNameChanged(): void {

  }

  SortDirectionChanged(): void {

  }
}
