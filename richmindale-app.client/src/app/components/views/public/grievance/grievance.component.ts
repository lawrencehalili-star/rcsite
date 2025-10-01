import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CommonService } from '../../../../shared/services/common.service';
import { Grievance } from '../../../../shared/models/public/grievance.model';
import { PublicService } from '../../../../shared/services/public/public.service';

@Component({
  selector: 'app-grievance',
  templateUrl: './grievance.component.htm',
})
export class GrievanceComponent implements OnInit {

  grievance:Grievance = new Grievance();
  grievances:any[] = [];
  reveal:boolean = false;

  constructor(private common: CommonService, private service: PublicService, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.common.getCommonDropdown('Grievance').subscribe(res => { this.grievances = res;});
  }

  RevealChanged() : void {
    this.reveal = !this.reveal;
  }

  SubmitGrievance() : void {
    this.service.submitGrievance(this.grievance).subscribe(res => {
      if(res.status === 'success') {
        this.toastr.success(res.msg);
        window.location.href = '';
      } else {
        this.toastr.error(res.msg);
      }
    });
  }

}
