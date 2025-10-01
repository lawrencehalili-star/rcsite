export class AgreementCourses {
    Id:any;
    ProgramId: any;
    Sequence: any;
    TermName: any;
    TermCourses:TermCourses[] = [];
}

export class TermCourses {
    Id: any;
    CourseCode: any;
    CourseTitle: any;
    PreRequisite: any;
    PreRequisiteCode: any;
    PreRequisiteTitle: any;
    CreditUnits: any;
}
