import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { CommonService } from '../../../../shared/services/common.service';
import { CoursesDetails } from '../../../../shared/models/public/courses-details.model';
import { ProgramDetails } from '../../../../shared/models/public/program-details.model';

@Component({
  selector: 'app-programs',
  templateUrl: './programs.component.html'
})
export class ProgramsComponent implements OnInit {

  id:any;
  paramSubscription: Subscription = new Subscription();
  program: ProgramDetails = new ProgramDetails();
  courses: CoursesDetails[] = [];
  
  constructor(private route: ActivatedRoute, private service: CommonService ) {}

  ngOnInit(): void {
    this.paramSubscription = this.route.params.subscribe(params => this.id = params['id']);
    this.service.getProgramDetails(this.id).subscribe(res => {
      this.program = res;
    });
    this.service.loadProgramSemesterCourses(this.id).subscribe(res => {
      this.courses = res.data;
      this.courses = this.courses.sort((a, b) => a.Semester > b.Semester ? 1 : -1);
      console.log(JSON.stringify(this.courses));
    });
  }

  
}
