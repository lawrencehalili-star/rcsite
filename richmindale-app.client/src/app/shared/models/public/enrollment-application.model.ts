import { SelectedCourses } from "./selected-courses.model";

export class EnrollmentApplication {
    EmailAddress:any;
    StudentId:any;
    ProgramCategoryId:any;
    ProgramId:any;
    CountryId:any;
    CampusId:any;
    LearningMethodId:any;
    CoursesId:SelectedCourses[] = [];
}


