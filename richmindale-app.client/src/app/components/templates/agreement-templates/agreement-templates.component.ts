import { Component, Input, OnInit } from '@angular/core';
import { AdmissionDetails } from '../../../shared/models/admin/admission-details.model';
import { Admission } from '../../../shared/models/public/admission.model';
import { SchoolAdminService } from '../../../shared/services/admin/school-admin.service';
import { NgxPrinterService } from 'ngx-printer';
import { AgreementCourses } from '../../../shared/models/admin/agreement-courses.model';
import { CommonService } from '../../../shared/services/common.service';
import { CoursesDetails } from '../../../shared/models/public/courses-details.model';
import { ProgramDetails } from '../../../shared/models/public/program-details.model';

@Component({
  selector: 'app-agreement-templates',
  templateUrl: './agreement-templates.component.html'
})
export class AgreementTemplatesComponent implements OnInit {

  @Input('LrnAdmissionApplicationId') LrnAdmissionApplicationId: any;
  dtl: AdmissionDetails = new AdmissionDetails();
  courses: CoursesDetails[] = [];
  program: ProgramDetails = new ProgramDetails();
  str:any = '';

  constructor(private service: SchoolAdminService, private common: CommonService, private printService: NgxPrinterService) { }

  ngOnInit(): void {

    this.service.loadAdmissionSummaryDetails(this.LrnAdmissionApplicationId).subscribe(res => {
      this.dtl = res;
      this.dtl.ProgramCode = res.ProgramCode;
      this.dtl.ProgramId = res.ProgramId;
      this.common.getProgramDetails(this.dtl.ProgramId).subscribe(prog => {
        this.program = prog;
      });
      
      this.common.loadProgramSemesterCourses(this.dtl.ProgramId).subscribe(result => {
        this.courses = result.data;
        this.courses = this.courses.sort((a,b) => a.Semester > b.Semester ? 1 : -1);
        
        
        for(let i = 0;i < this.courses.length;i ++) {
          if(i !== i - 1 || this.courses[i].Semester !== this.courses[i - 1].Semester) {
            this.str = this.str + '<tr> ' +
                        '   <td class="td-field"></td>' +
                        '   <td colspan="3" class="td-field"><strong>Semester ' + this.courses[i].Semester +'</strong></td>' +
                        '</tr>';
          } else {
            this.str = this.str + '<tr>' +
                         '  <td class="td-field">' + this.courses[i].CourseCode + '</td>' +
                         '   <td>' + this.courses[i].CourseTitle + '</td> ' +
                         '   <td>' + this.courses[i].PreRequisites + '</td> ' +
                         '   <td>' + this.courses[i].Credits + '</td> ' +
                         '</tr>';
          }
        }
        

      });
    });

    
  }

  Print(): void {
    this.printService.printDiv('agreement');
  }

}
