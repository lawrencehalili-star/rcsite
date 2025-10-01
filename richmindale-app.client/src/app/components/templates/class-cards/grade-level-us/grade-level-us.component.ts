import { Component, OnDestroy, OnInit } from '@angular/core';
import { ClassCards } from '../../../../shared/models/portal/class-cards/class-cards.model';
import { StorageService } from '../../../../shared/services/auth/storage.service';
import { ClassCardTemplatesService } from '../../../../shared/services/portal/class-card-templates.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-grade-level-us',
  templateUrl: './grade-level-us.component.html'
})
export class GradeLevelUsComponent implements OnInit, OnDestroy {
  id: any;
  card: ClassCards = new ClassCards();

  constructor(private storage: StorageService, private service: ClassCardTemplatesService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.id = this.storage.getSession('StudentId');
    this.service.loadReportCardDetails(this.id).subscribe(res => { this.card = res; });
  }

  ngOnDestroy(): void {

  }
}
