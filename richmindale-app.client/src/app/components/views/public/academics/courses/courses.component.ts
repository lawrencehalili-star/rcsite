import { Component, OnInit } from '@angular/core';
import { CommonService } from '../../../../../shared/services/common.service';
import { Courses } from '../../../../../shared/models/public/courses.model';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html'
})
export class CoursesComponent implements OnInit {

  paramSubscription: Subscription = new Subscription();

  constructor(private service: CommonService, private route: ActivatedRoute) {}

  search:any = '';
  courses:Courses[] = [];

  ngOnInit(): void {
    this.paramSubscription = this.route.params.subscribe(params => this.search = params['keyword'] == 'undefined' || params['keyword'] == null ? '' : params['keyword']);
    this.LoadCourses();
  }

  SearchChange() : void {
    this.LoadCourses();
  }

  LoadCourses() : void {
    this.service.loadUploadedCourses(this.search).subscribe(res => {
      this.courses = res;
    });
  }

}
