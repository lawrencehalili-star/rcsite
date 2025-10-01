import { ClassCardAttendance } from "./class-card-attendance.model";
import { ClassCardGrades } from "./class-card-grades.model";
import { ClassCardValues } from "./class-card-values.model";

export class ClassCards {
    StudentId: any;
    EnrollmentId: any;
    GivenName: any;
    Lastname: any;
    MiddleName: any;
    StudentCode: any;
    DateOfBirth: any;
    Age: any;
    GradeLevel: any;
    Gender: any;
    TeacherRegistrar: any;
    TeacherRegistrarSign: any;
    Principal: any;
    PrincipalSign: any;
    AdmittedToGrade: any;
    AdmittedToSection: any;
    EligibleForAdmission: any;
    CancelAdmissionToGrade: any;
    CancelAdmissionDate: any;
    ParentComment1Q: any;
    ParentComment2Q: any;
    ParentComment3Q: any;
    ParentComment4Q: any;
    Grades: ClassCardGrades[] = [];
    Attendance: ClassCardAttendance[] = [];
    Values: ClassCardValues[] = [];
}
