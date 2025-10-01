import { Component, PipeTransform, OnDestroy, OnInit } from '@angular/core';
import { StorageService } from '../../../../../shared/services/auth/storage.service';
import { CommonService } from '../../../../../shared/services/common.service';


@Component({
  selector: 'app-exam-permit',
  templateUrl: './exam-permit.component.html'
})
export class ExamPermitComponent implements OnInit, OnDestroy {

  exams: any[] = [];
  

  constructor(private storage: StorageService, private common: CommonService) {
    
  }

  ngOnInit(): void {
    
  }

  ngOnDestroy(): void {
    
  }

}
