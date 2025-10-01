import { importProvidersFrom, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PublicLayoutComponent } from './components/layouts/public-layout/public-layout.component';
import { PortalLayoutComponent } from './components/layouts/portal-layout/portal-layout.component';
import { AdminLayoutComponent } from './components/layouts/admin-layout/admin-layout.component';


const routes: Routes = [
  {
    path: '',
    component: PublicLayoutComponent,
    children: [
      {
        path: '',
        loadChildren: () =>
          import('../app/components/views/public/home/home.module').then(
            (m) => m.HomeModule
          ),
      },
      {
        path: 'rims/login',
        loadChildren: () =>
          import('../app/components/views/public/login/login.module').then(
            (m) => m.LoginModule
          ),
      },
      {
        path: 'rims/authentication',
        loadChildren: () =>
          import(
            '../app/components/views/public/authentication/authentication.module'
          ).then((m) => m.AuthenticationModule),
      },
      {
        path: 'rims/academics',
        loadChildren: () =>
          import(
            '../app/components/views/public/academics/academics.module'
          ).then((m) => m.AcademicsModule),
      },
      {
        path: 'rims/academics/courses',
        loadChildren: () =>
          import(
            '../app/components/views/public/academics/courses/courses.module'
          ).then((m) => m.CoursesModule),
      },
      {
        path: 'rims/academics/courses/:keyword',
        loadChildren: () =>
          import(
            '../app/components/views/public/academics/courses/courses.module'
          ).then((m) => m.CoursesModule),
      },
      {
        path: 'rims/admissions',
        loadChildren: () =>
          import(
            '../app/components/views/public/admissions/admissions.module'
          ).then((m) => m.AdmissionsModule),
      },
      {
        path: 'rims/admissions/modify/:id',
        loadChildren: () =>
          import(
            '../app/components/views/public/admissions/modify/modify.module'
          ).then((m) => m.ModifyModule),
      },
      {
        path: 'rims/admissions/payment/:id',
        loadChildren: () =>
          import(
            '../app/components/views/public/admissions/payment/payment.module'
          ).then((m) => m.PaymentModule),
      },
      {
        path: 'rims/admissions/success/:id',
        loadChildren: () =>
          import(
            '../app/components/views/public/admissions/success/success.module'
          ).then((m) => m.SuccessModule),
      },
      {
        path: 'rims/academics/programs',
        loadChildren: () =>
          import(
            '../app/components/views/public/academics/programs/programs.module'
          ).then((m) => m.ProgramsModule),
      },
      {
        path: 'rims/academics/programs/:id',
        loadChildren: () =>
          import(
            '../app/components/views/public/programs/programs.module'
          ).then((m) => m.ProgramsModule),
      },
      {
        path: 'agreement/:code',
        loadChildren: () =>
          import(
            '../app/components/views/public/agreement/agreement.module'
          ).then((m) => m.AgreementModule),
      },
      {
        path: 'enrollment',
        loadChildren: () =>
          import(
            '../app/components/views/public/enrollment/enrollment.module'
          ).then((m) => m.EnrollmentModule),
      },
      {
        path: 'enrollment/courses/:id',
        loadChildren: () =>
          import(
            '../app/components/views/public/enrollment/courses/courses.module'
          ).then((m) => m.CoursesModule),
      },
      {
        path: 'catalog',
        loadChildren: () =>
          import('../app/components/views/public/catalog/catalog.module').then(
            (m) => m.CatalogModule
          ),
      },
      {
        path: 'policies',
        loadChildren: () =>
          import(
            '../app/components/views/public/policies/policies.module'
          ).then((m) => m.PoliciesModule),
      },
      {
        path: 'services',
        loadChildren: () =>
          import(
            '../app/components/views/public/services/services.module'
          ).then((m) => m.ServicesModule),
      },
      {
        path: 'orientation/students',
        loadChildren: () =>
          import(
            '../app/components/views/public/services/orientation/orientation.module'
          ).then((m) => m.OrientationModule),
      },
      {
        path: 'services/library',
        loadChildren: () =>
          import('../app/components/views/public/library/library.module').then(
            (m) => m.LibraryModule
          ),
      },
      {
        path: 'contact',
        loadChildren: () =>
          import(
            '../app/components/views/public/contacts/contacts.module'
          ).then((m) => m.ContactsModule),
      },
      {
        path: 'rims/grievance',
        loadChildren: () =>
          import(
            '../app/components/views/public/grievance/grievance.module'
          ).then((m) => m.GrievanceModule),
      },
      {
        path: 'rims/grievance/appeal/:id',
        loadChildren: () =>
          import(
            '../app/components/views/public/grievance/appeal/appeal.module'
          ).then((m) => m.AppealModule),
      },
      {
        path: 'faq',
        loadChildren: () =>
          import('../app/components/views/public/faq/faq.module').then(
            (m) => m.FaqModule
          ),
      },
      {
        path: 'terms',
        loadChildren: () =>
          import('../app/components/views/public/terms/terms.module').then(
            (m) => m.TermsModule
          ),
      },
      {
        path: 'confidentiality',
        loadChildren: () =>
          import(
            '../app/components/views/public/confidentiality/confidentiality.module'
          ).then((m) => m.ConfidentialityModule),
      },
      {
        path: 'payment',
        loadChildren: () =>
          import('../app/components/views/public/paypal/paypal.module').then(
            (m) => m.PaypalModule
          ),
      },
      {
        path: 'rims/media',
        loadChildren: () =>
          import('../app/components/views/public/media/media.module').then(
            (m) => m.MediaModule
          ),
      },
      {
        path: 'alumni',
        loadChildren: () =>
          import('../app/components/views/public/alumni/alumni.module').then(
            (m) => m.AlumniModule
          ),
      },
      {
        path: 'jobsearch',
        loadChildren: () =>
          import(
            '../app/components/views/public/job-search/job-search.module'
          ).then((m) => m.JobSearchModule),
      },
    ],
  },

  // Student Portal
  {
    path: 'rims',
    component: PortalLayoutComponent,
    children: [
      {
        path: 'dashboard',
        loadChildren: () =>
          import(
            '../app/components/views/portal/dashboard/dashboard.module'
          ).then((m) => m.DashboardModule),
      },
      // Classes

      {
        path: 'classes/attendance',
        loadChildren: () =>
          import(
            '../app/components/views/portal/classes/attendance/attendance.module'
          ).then((m) => m.AttendanceModule),
      },
      {
        path: 'classes/loa',
        loadChildren: () =>
          import(
            '../app/components/views/portal/classes/attendance/loa/loa.module'
          ).then((m) => m.LoaModule),
      },
      {
        path: 'classes/incomplete',
        loadChildren: () =>
          import(
            '../app/components/views/portal/classes/incomplete/incomplete.module'
          ).then((m) => m.IncompleteModule),
      },
      {
        path: 'classes/quizzes',
        loadChildren: () =>
          import(
            '../app/components/views/portal/classes/quizzes/quizzes.module'
          ).then((m) => m.QuizzesModule),
      },
      {
        path: 'classes/exams',
        loadChildren: () =>
          import(
            '../app/components/views/portal/classes/exams/exams.module'
          ).then((m) => m.ExamsModule),
      },
      {
        path: 'registrar/reportcard',
        loadChildren: () =>
          import(
            '../app/components/views/portal/classes/report-card/report-card.module'
          ).then((m) => m.ReportCardModule),
      },
      {
        path: 'registrar/transcript',
        loadChildren: () =>
          import(
            '../app/components/views/portal/classes/transcript/transcript.module'
          ).then((m) => m.TranscriptModule),
      },
      {
        path: 'registrar/transcript/view/:id',
        loadChildren: () =>
          import(
            '../app/components/views/portal/services/transcript/tor-view/tor-view.module'
          ).then((m) => m.TorViewModule),
      },

      // Academics
      {
        path: 'academics/enrollments',
        loadChildren: () =>
          import(
            './components/views/portal/academics/enrollment/enrollment.module'
          ).then((m) => m.EnrollmentModule),
      },
      {
        path: 'academics/enrollments/studyload/:id',
        loadChildren: () =>
          import(
            './components/views/portal/academics/enrollment/studyload/studyload.module'
          ).then((m) => m.StudyloadModule),
      },
      {
        path: 'grading', // Academics Performance
        loadChildren: () =>
          import(
            '../app/components/views/portal/academics/grading/grading.module'
          ).then((m) => m.GradingModule),
      },
      {
        path: 'grading/challenge/:id', // Academics Challenge Grades
        loadChildren: () =>
          import(
            '../app/components/views/portal/academics/grading/challenge/challenge.module'
          ).then((m) => m.ChallengeModule),
      },
      {
        path: 'academics/dishonesty',
        loadChildren: () =>
          import(
            '../app/components/views/portal/academics/dishonesty/dishonesty.module'
          ).then((m) => m.DishonestyModule),
      },
      {
        path: 'academics/dishonesty/appeal/:id',
        loadChildren: () =>
          import(
            '../app/components/views/portal/academics/dishonesty/appeal/appeal.module'
          ).then((m) => m.AppealModule),
      },
      {
        path: 'sap', // Academics SAP
        loadChildren: () =>
          import(
            '../app/components/views/portal/academics/sap/sap.module'
          ).then((m) => m.SapModule),
      },
      {
        path: 'sap/appeal', // Academic SAP
        loadChildren: () =>
          import(
            '../app/components/views/portal/academics/sap/appeal/appeal.module'
          ).then((m) => m.AppealModule),
      },
      // Financial
      {
        path: 'financials/ledger',
        loadChildren: () =>
          import(
            '../app/components/views/portal/financials/ledger/ledger.module'
          ).then((m) => m.LedgerModule),
      },
      {
        path: 'financials/payments',
        loadChildren: () =>
          import(
            '../app/components/views/portal/financials/payments/payments.module'
          ).then((m) => m.PaymentsModule),
      },
      {
        path: 'financials/balances',
        loadChildren: () =>
          import(
            '../app/components/views/portal/financials/balances/balances.module'
          ).then((m) => m.BalancesModule),
      },

      // Services
      {
        path: 'services/documents',
        loadChildren: () =>
          import(
            '../app/components/views/portal/services/documents/documents.module'
          ).then((m) => m.DocumentsModule),
      },
      {
        path: 'services/graduation',
        loadChildren: () =>
          import(
            '../app/components/views/portal/services/graduation/graduation.module'
          ).then((m) => m.GraduationModule),
      },
      {
        path: 'services/transcript',
        loadChildren: () =>
          import(
            '../app/components/views/portal/services/transcript/transcript.module'
          ).then((m) => m.TranscriptModule),
      },
      {
        path: 'services/permits',
        loadChildren: () =>
          import(
            '../app/components/views/portal/services/exam-permit/exam-permit.module'
          ).then((m) => m.ExamPermitModule),
      },
      {
        path: 'services/student-library',
        loadChildren: () =>
          import(
            '../app/components/views/portal/services/library/library.module'
          ).then((m) => m.LibraryModule),
      },
      {
        path: 'services/success',
        loadChildren: () =>
          import(
            '../app/components/views/portal/services/success/success.module'
          ).then((m) => m.SuccessModule),
      },
      {
        path: 'services/studentid',
        loadChildren: () =>
          import(
            '../app/components/views/portal/services/studentid/studentid.module'
          ).then((m) => m.StudentidModule),
      },

      // Accounts
      {
        path: 'accounts/profile',
        loadChildren: () =>
          import(
            '../app/components/views/portal/accounts/profile/profile.module'
          ).then((m) => m.ProfileModule),
      },
      {
        path: 'accounts/profile/ferpa',
        loadChildren: () =>
          import(
            '../app/components/views/portal/accounts/profile/ferpa/ferpa.module'
          ).then((m) => m.FerpaModule),
      },
    ],
  },

  // Admin
  {
    path: 'admin',
    component: AdminLayoutComponent,
    children: [
      {
        path: 'dashboard',
        loadChildren: () =>
          import(
            '../app/components/views/admin/dashboard/dashboard.module'
          ).then((m) => m.DashboardModule),
      },
      // School Admin
      {
        path: 'grievances',
        loadChildren: () =>
          import(
            '../app/components/views/admin/school-admin/grievances/grievances.module'
          ).then((m) => m.GrievancesModule),
      },
      {
        path: 'grievances/details/:id',
        loadChildren: () =>
          import(
            '../app/components/views/admin/school-admin/grievances/details/details.module'
          ).then((m) => m.DetailsModule),
      },

      // School Admin, Registrar
      {
        path: 'masterlist',
        loadChildren: () =>
          import(
            '../app/components/views/admin/masterlist/masterlist.module'
          ).then((m) => m.MasterlistModule),
      },
      {
        path: 'masterlist/details/:id',
        loadChildren: () =>
          import(
            '../app/components/views/admin/masterlist/details/details.module'
          ).then((m) => m.DetailsModule),
      },
      {
        path: 'admissions',
        loadChildren: () =>
          import(
            '../app/components/views/admin/school-admin/admissions/admissions.module'
          ).then((m) => m.AdmissionsModule),
      },
      {
        path: 'admissions/details/:id',
        loadChildren: () =>
          import(
            '../app/components/views/admin/school-admin/admissions/details/details.module'
          ).then((m) => m.DetailsModule),
      },
      {
        path: 'document-editor',
        loadChildren: () =>
          import(
            '../app/components/views/admin/document-editor/document-editor.module'
          ).then((m) => m.DocumentEditorModule),
      },
      {
        path: 'document-editor/editor/:id',
        loadChildren: () =>
          import(
            '../app/components/views/admin/document-editor/editor/editor.module'
          ).then((m) => m.EditorModule),
      },

      // Registrar
      {
        path: 'document-requests',
        loadChildren: () =>
          import(
            '../app/components/views/admin/registrar/document-requests/document-requests.module'
          ).then((m) => m.DocumentRequestsModule),
      },
      {
        path: 'document-requests/details/:id',
        loadChildren: () =>
          import(
            '../app/components/views/admin/registrar/document-requests/details/details.module'
          ).then((m) => m.DetailsModule),
      },
      {
        path: 'transcript',
        loadChildren: () =>
          import(
            '../app/components/views/admin/registrar/transcript/transcript.module'
          ).then((m) => m.TranscriptModule),
      },
      {
        path: 'transcript/view:id',
        loadChildren: () =>
          import(
            '../app/components/views/admin/registrar/transcript/view/view.module'
          ).then((m) => m.ViewModule),
      },
      {
        path: 'report-cards',
        loadChildren: () =>
          import(
            '../app/components/views/admin/registrar/report-cards/report-cards.module'
          ).then((m) => m.ReportCardsModule),
      },
      {
        path: 'report-cards/view/:id',
        loadChildren: () =>
          import(
            '../app/components/views/admin/registrar/report-cards/view/view.module'
          ).then((m) => m.ViewModule),
      },

      // School Admin, Registrar, Sales , CS
      {
        path: 'inquiries',
        loadChildren: () =>
          import(
            '../app/components/views/admin/inquiries/inquiries.module'
          ).then((m) => m.InquiriesModule),
      },
      {
        path: 'inquiries/details/:id',
        loadChildren: () =>
          import(
            '../app/components/views/admin/inquiries/details/details.module'
          ).then((m) => m.DetailsModule),
      },

      // Finance
      {
        path: 'finance/paypal-transactions',
        loadChildren: () =>
          import(
            '../app/components/views/admin/finance/paypal-transactions/paypal-transactions.module'
          ).then((m) => m.PaypalTransactionsModule),
      },

      // System Administration
      {
        path: 'system/organizations',
        loadChildren: () =>
          import(
            '../app/components/views/admin/system/organizations/organizations.module'
          ).then((m) => m.OrganizationsModule),
      },
      {
        path: 'system/learning-methods',
        loadChildren: () =>
          import(
            '../app/components/views/admin/system/organizations/learning-methods/learning-methods.module'
          ).then((m) => m.LearningMethodsModule),
      },
      {
        path: 'system/campuses',
        loadChildren: () =>
          import(
            '../app/components/views/admin/system/organizations/campuses/campuses.module'
          ).then((m) => m.CampusesModule),
      },
      {
        path: 'system/users',
        loadChildren: () =>
          import(
            '../app/components/views/admin/system/users/users.module'
          ).then((m) => m.UsersModule),
      },
      {
        path: 'system/students',
        loadChildren: () =>
          import(
            '../app/components/views/admin/system/student-accounts/student-accounts.module'
          ).then((m) => m.StudentAccountsModule),
      },
      {
        path: 'system/users/details/:id',
        loadChildren: () =>
          import(
            '../app/components/views/admin/system/users/details/details.module'
          ).then((m) => m.DetailsModule),
      },
      {
        path: 'system/roles',
        loadChildren: () =>
          import(
            '../app/components/views/admin/system/roles/roles.module'
          ).then((m) => m.RolesModule),
      },
      {
        path: 'system/categories',
        loadChildren: () =>
          import(
            '../app/components/views/admin/system/categories/categories.module'
          ).then((m) => m.CategoriesModule),
      },
      {
        path: 'system/statuses',
        loadChildren: () =>
          import(
            '../app/components/views/admin/system/statuses/statuses.module'
          ).then((m) => m.StatusesModule),
      },
      {
        path: 'system/workflows',
        loadChildren: () =>
          import(
            '../app/components/views/admin/system/workflows/workflows.module'
          ).then((m) => m.WorkflowsModule),
      },
    ],
  },

];
 

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
