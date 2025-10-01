import { Component, OnInit } from '@angular/core';
import { ProgramDetails } from '../../../../../shared/models/public/program-details.model';
import { CommonService } from '../../../../../shared/services/common.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-programs',
  templateUrl: './programs.component.html'
})
export class ProgramsComponent implements OnInit {


  programs: ProgramDetails[] = [];

  constructor(private service: CommonService, private router: Router) {}

  ngOnInit(): void {
    this.service.getProgramWithDetails().subscribe(res => {
      this.programs = res.data;
    });
  }

  ViewProgramDetails(id:any) : void {
    this.router.navigate(['/academics/programs/' + id]);
  }

}
