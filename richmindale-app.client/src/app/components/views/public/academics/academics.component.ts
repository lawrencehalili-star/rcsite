import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonService } from '../../../../shared/services/common.service';
import { ProgramDetails } from '../../../../shared/models/public/program-details.model';

@Component({
  selector: 'app-academics',
  templateUrl: './academics.component.html'
})
export class AcademicsComponent implements OnInit {

  search: any;
  course: any;
  programs: ProgramDetails[] = [];

  constructor(private router: Router, private service: CommonService) {}

  ngOnInit(): void {
    this.service.getProgramWithDetails().subscribe(res => {
      this.programs = res.data;
    });
  }

  SearchCourse() {
    this.router.navigate(['/academics/courses/' + this.search]);
  }
}
