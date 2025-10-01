using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace richmindale_app.Server.Models.Entities;

public partial class RichmindaleDbContext : DbContext
{
    public RichmindaleDbContext()
    {
    }

    public RichmindaleDbContext(DbContextOptions<RichmindaleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessMatrix> AccessMatrices { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CrmContact> CrmContacts { get; set; }

    public virtual DbSet<CrmContactAddress> CrmContactAddresses { get; set; }

    public virtual DbSet<CrmCustomer> CrmCustomers { get; set; }

    public virtual DbSet<CrmGrievance> CrmGrievances { get; set; }

    public virtual DbSet<CrmGrievanceDetail> CrmGrievanceDetails { get; set; }

    public virtual DbSet<CrmGroup> CrmGroups { get; set; }

    public virtual DbSet<CrmInquiry> CrmInquiries { get; set; }

    public virtual DbSet<CrmMember> CrmMembers { get; set; }

    public virtual DbSet<CrmOrg> CrmOrgs { get; set; }

    public virtual DbSet<CrmOrgContact> CrmOrgContacts { get; set; }

    public virtual DbSet<CrmPaymentTerm> CrmPaymentTerms { get; set; }

    public virtual DbSet<CrmPaymentTermApply> CrmPaymentTermApplies { get; set; }

    public virtual DbSet<CrmPaymentTermItem> CrmPaymentTermItems { get; set; }

    public virtual DbSet<CrmPriceList> CrmPriceLists { get; set; }

    public virtual DbSet<CrmPriceListItem> CrmPriceListItems { get; set; }

    public virtual DbSet<CrmPromo> CrmPromos { get; set; }

    public virtual DbSet<CrmReceipt> CrmReceipts { get; set; }

    public virtual DbSet<CrmReceiptItem> CrmReceiptItems { get; set; }

    public virtual DbSet<CrmSalesFee> CrmSalesFees { get; set; }

    public virtual DbSet<CrmSalesInvoice> CrmSalesInvoices { get; set; }

    public virtual DbSet<CrmSalesInvoiceItem> CrmSalesInvoiceItems { get; set; }

    public virtual DbSet<CrmSalesOrder> CrmSalesOrders { get; set; }

    public virtual DbSet<CrmSalesOrderItem> CrmSalesOrderItems { get; set; }

    public virtual DbSet<CrmSalesQuotation> CrmSalesQuotations { get; set; }

    public virtual DbSet<CrmSalesQuotationItem> CrmSalesQuotationItems { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<GlobalTagging> GlobalTaggings { get; set; }

    public virtual DbSet<LrnAdmissionApplication> LrnAdmissionApplications { get; set; }

    public virtual DbSet<LrnAdmissionContact> LrnAdmissionContacts { get; set; }

    public virtual DbSet<LrnAdmissionDoc> LrnAdmissionDocs { get; set; }

    public virtual DbSet<LrnAdmissionHistory> LrnAdmissionHistories { get; set; }

    public virtual DbSet<LrnAdmissionPreviousSchool> LrnAdmissionPreviousSchools { get; set; }

    public virtual DbSet<LrnCampus> LrnCampuses { get; set; }

    public virtual DbSet<LrnCampusLearningMethod> LrnCampusLearningMethods { get; set; }

    public virtual DbSet<LrnClass> LrnClasses { get; set; }

    public virtual DbSet<LrnClassActivity> LrnClassActivities { get; set; }

    public virtual DbSet<LrnClassActivityTest> LrnClassActivityTests { get; set; }

    public virtual DbSet<LrnClassFacilitator> LrnClassFacilitators { get; set; }

    public virtual DbSet<LrnClassSection> LrnClassSections { get; set; }

    public virtual DbSet<LrnCourse> LrnCourses { get; set; }

    public virtual DbSet<LrnCourseActivityTest> LrnCourseActivityTests { get; set; }

    public virtual DbSet<LrnCustomerStudent> LrnCustomerStudents { get; set; }

    public virtual DbSet<LrnExaminationPermit> LrnExaminationPermits { get; set; }

    public virtual DbSet<LrnGradeCriterion> LrnGradeCriteria { get; set; }

    public virtual DbSet<LrnGradingSystem> LrnGradingSystems { get; set; }

    public virtual DbSet<LrnIssuedDocument> LrnIssuedDocuments { get; set; }

    public virtual DbSet<LrnLearningMethod> LrnLearningMethods { get; set; }

    public virtual DbSet<LrnOnlineDocument> LrnOnlineDocuments { get; set; }

    public virtual DbSet<LrnOnlineDocumentSection> LrnOnlineDocumentSections { get; set; }

    public virtual DbSet<LrnOrgProgram> LrnOrgPrograms { get; set; }

    public virtual DbSet<LrnProgram> LrnPrograms { get; set; }

    public virtual DbSet<LrnProgramCategory> LrnProgramCategories { get; set; }

    public virtual DbSet<LrnPromisoryNote> LrnPromisoryNotes { get; set; }

    public virtual DbSet<LrnRelatedOnlineDocument> LrnRelatedOnlineDocuments { get; set; }

    public virtual DbSet<LrnSchoolWeek> LrnSchoolWeeks { get; set; }

    public virtual DbSet<LrnStudent> LrnStudents { get; set; }

    public virtual DbSet<LrnStudentClass> LrnStudentClasses { get; set; }

    public virtual DbSet<LrnStudentDocumentRequest> LrnStudentDocumentRequests { get; set; }

    public virtual DbSet<LrnStudentProgram> LrnStudentPrograms { get; set; }

    public virtual DbSet<LrnStudentProgramRequirement> LrnStudentProgramRequirements { get; set; }

    public virtual DbSet<LrnSubject> LrnSubjects { get; set; }

    public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }

    public virtual DbSet<PageModule> PageModules { get; set; }

    public virtual DbSet<PageSection> PageSections { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Religion> Religions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleAccess> RoleAccesses { get; set; }

    public virtual DbSet<ScmCategory> ScmCategories { get; set; }

    public virtual DbSet<ScmItem> ScmItems { get; set; }

    public virtual DbSet<ScmItemCategory> ScmItemCategories { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<SubRegion> SubRegions { get; set; }

    public virtual DbSet<SysCategory> SysCategories { get; set; }

    public virtual DbSet<SysDocumentType> SysDocumentTypes { get; set; }

    public virtual DbSet<SysDomain> SysDomains { get; set; }

    public virtual DbSet<SysNotification> SysNotifications { get; set; }

    public virtual DbSet<SysPasskey> SysPasskeys { get; set; }

    public virtual DbSet<SysStatus> SysStatuses { get; set; }

    public virtual DbSet<SysWorkflow> SysWorkflows { get; set; }

    public virtual DbSet<SysWorkflowAssignment> SysWorkflowAssignments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<ViewCollegeCourse> ViewCollegeCourses { get; set; }

    public virtual DbSet<ViewCollegeCoursesByProgram> ViewCollegeCoursesByPrograms { get; set; }

    public virtual DbSet<ViewCollegeCoursesDistinct> ViewCollegeCoursesDistincts { get; set; }

    public virtual DbSet<ViewCollegeCoursesPerSem> ViewCollegeCoursesPerSems { get; set; }

    public virtual DbSet<ViewCourseCodeToIdMap> ViewCourseCodeToIdMaps { get; set; }

    public virtual DbSet<ViewFeesByLearningMethod> ViewFeesByLearningMethods { get; set; }

    public virtual DbSet<VwStudentMasterList> VwStudentMasterLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=74.208.74.11;Initial Catalog=richmindale_test;User=sa;Password=Sy5adm!n01;Encrypt=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessMatrix>(entity =>
        {
            entity.ToTable("AccessMatrix");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addresse__3214EC07618DACF9");

            entity.Property(e => e.Building)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.Phone1)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.Phone2)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.Room)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Areas__3214EC07348B4A4A");

            entity.Property(e => e.AreaName).HasMaxLength(200);
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cities__3214EC07AA9AE337");

            entity.Property(e => e.CityCode)
                .HasMaxLength(10)
                .HasDefaultValue("");
            entity.Property(e => e.CityName).HasMaxLength(200);
            entity.Property(e => e.CountryCode).HasMaxLength(10);
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.PhoneCode)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.StateCode).HasMaxLength(50);
            entity.Property(e => e.StateName).HasMaxLength(300);
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Countrie__3214EC074C70073F");

            entity.Property(e => e.CountryCode)
                .HasMaxLength(10)
                .HasDefaultValue("");
            entity.Property(e => e.CountryName).HasMaxLength(200);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.CurrencyName).HasMaxLength(300);
            entity.Property(e => e.CurrencySymbol).HasMaxLength(300);
            entity.Property(e => e.Emoji).HasMaxLength(100);
            entity.Property(e => e.EmojiUi)
                .HasMaxLength(100)
                .HasColumnName("EmojiUI");
            entity.Property(e => e.Iso3).HasMaxLength(10);
            entity.Property(e => e.Nationality).HasMaxLength(500);
            entity.Property(e => e.Native).HasMaxLength(500);
            entity.Property(e => e.PhoneCode)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Region).HasMaxLength(300);
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
            entity.Property(e => e.SubRegion).HasMaxLength(300);
            entity.Property(e => e.WebDomain)
                .HasMaxLength(8)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<CrmContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmConta__3214EC07905F3063");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.ContactCode)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.ContactHashValue).HasMaxLength(255);
            entity.Property(e => e.ContactType).HasDefaultValueSql("('1')");
            entity.Property(e => e.DisplayName).HasMaxLength(200);
            entity.Property(e => e.Email1)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.Email2)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.EmployerName)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Gender).HasDefaultValueSql("('0')");
            entity.Property(e => e.GivenName).HasMaxLength(240);
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.MaidenName)
                .HasMaxLength(200)
                .HasDefaultValue("");
            entity.Property(e => e.MaritalStatus).HasDefaultValueSql("('0')");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(200)
                .HasDefaultValue("");
            entity.Property(e => e.PhoneNo1)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.PhoneNo2)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.PhotoFilename)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.ReligionId).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");
            entity.Property(e => e.Suffix).HasMaxLength(100);
        });

        modelBuilder.Entity<CrmContactAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmConta__3214EC074FEE4D1E");

            entity.Property(e => e.AddressDetails)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.AddressName).HasMaxLength(100);
            entity.Property(e => e.Area)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.Building)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.CityId).HasDefaultValueSql("('0')");
            entity.Property(e => e.CountryId).HasDefaultValueSql("('0')");
            entity.Property(e => e.PhoneNo1)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.PhoneNo2)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.Room)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.StateId).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<CrmCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmCusto__3214EC076282CCC7");

            entity.Property(e => e.CurrencyCode).HasMaxLength(50);
            entity.Property(e => e.CustomerCode)
                .HasMaxLength(40)
                .HasDefaultValue("");
            entity.Property(e => e.DefaultCurrencyCode)
                .HasMaxLength(10)
                .HasDefaultValue("0");
            entity.Property(e => e.DefaultOrgCode)
                .HasMaxLength(40)
                .HasDefaultValue("0");
            entity.Property(e => e.DefaultPaymentTermName).HasMaxLength(50);
            entity.Property(e => e.DefaultPriceListName).HasMaxLength(50);
            entity.Property(e => e.DefaultPromoCode)
                .HasMaxLength(40)
                .HasDefaultValue("0");
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");
            entity.Property(e => e.TotalOrderAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalUnpaidAmount).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<CrmGrievance>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateCreated).HasColumnType("smalldatetime");
            entity.Property(e => e.EmailAddress).HasMaxLength(300);
            entity.Property(e => e.GrievanceCode).HasMaxLength(50);
        });

        modelBuilder.Entity<CrmGrievanceDetail>(entity =>
        {
            entity.Property(e => e.ResponseDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<CrmGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmGroup__3214EC07BF4DCA83");

            entity.HasIndex(e => new { e.Id, e.GroupName }, "idxSysCrmGroups1").IsUnique();

            entity.HasIndex(e => e.GroupName, "idxSysCrmGroupsGroupName");

            entity.HasIndex(e => e.LastWorkFlowId, "idxSysCrmGroupsLastWorkFlowId");

            entity.HasIndex(e => e.Status, "idxSysCrmGroupsStatus");

            entity.Property(e => e.GroupName)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.Status).HasDefaultValue(0);
        });

        modelBuilder.Entity<CrmInquiry>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ContactNumber).HasMaxLength(50);
            entity.Property(e => e.EmailAddress).HasMaxLength(300);
            entity.Property(e => e.Fullname).HasMaxLength(300);
            entity.Property(e => e.InquiryDate).HasColumnType("datetime");
            entity.Property(e => e.Subject).HasMaxLength(300);
        });

        modelBuilder.Entity<CrmMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmMembe__3214EC075F3798CF");

            entity.Property(e => e.Level1MemberCount).HasDefaultValueSql("('0')");
            entity.Property(e => e.Level2MemberCount).HasDefaultValueSql("('0')");
            entity.Property(e => e.Level3MemberCount).HasDefaultValueSql("('0')");
            entity.Property(e => e.Level4MemberCount).HasDefaultValueSql("('0')");
            entity.Property(e => e.MembershipNo).HasMaxLength(40);
            entity.Property(e => e.ParentMemberId).HasDefaultValueSql("('0')");
            entity.Property(e => e.ReferredByMemberId).HasDefaultValueSql("('0')");
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");
        });

        modelBuilder.Entity<CrmOrg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmOrgs__3214EC07F50776AB");

            entity.Property(e => e.CityId).HasDefaultValueSql("('0')");
            entity.Property(e => e.CountryId).HasDefaultValueSql("('0')");
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.Email1)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.Email2)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.OfficeName)
                .HasMaxLength(128)
                .HasDefaultValue("");
            entity.Property(e => e.OrgCode)
                .HasMaxLength(40)
                .HasDefaultValue("");
            entity.Property(e => e.OrgName).HasMaxLength(200);
            entity.Property(e => e.OrgType).HasDefaultValueSql("('0')");
            entity.Property(e => e.PhoneNo1)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.PhoneNo2)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.PhoneNo3)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.PhoneNo4)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.RegNo)
                .HasMaxLength(40)
                .HasDefaultValue("");
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.SchoolCredentialLevel).HasDefaultValueSql("('0')");
            entity.Property(e => e.StateId).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");
            entity.Property(e => e.TaxNo)
                .HasMaxLength(40)
                .HasDefaultValue("");
            entity.Property(e => e.Website)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<CrmOrgContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmOrgCo__3214EC0773CAC98C");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.IsMainContact)
                .IsRequired()
                .HasDefaultValueSql("('1')");
            entity.Property(e => e.PhoneNo1)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.PhoneNo2)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");
        });

        modelBuilder.Entity<CrmPaymentTerm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmPayme__3214EC07EF60F506");

            entity.HasIndex(e => e.PaymentTermName, "idxCrmPaymentTerms1").IsUnique();

            entity.HasIndex(e => e.Descr, "idxCrmPaymentTermsDescr");

            entity.HasIndex(e => e.ExcludeAmount, "idxCrmPaymentTermsExcludeAmount");

            entity.HasIndex(e => e.Period, "idxCrmPaymentTermsPeriod");

            entity.HasIndex(e => e.PeriodCount, "idxCrmPaymentTermsPeriodCount");

            entity.HasIndex(e => e.PeriodDueDateType, "idxCrmPaymentTermsPeriodDueDateType");

            entity.HasIndex(e => e.PeriodWorkingDaysOnly, "idxCrmPaymentTermsPeriodWorkingDaysOnly");

            entity.HasIndex(e => e.Status, "idxCrmPaymentTermsStatus");

            entity.Property(e => e.Descr).HasMaxLength(200);
            entity.Property(e => e.ExcludeAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(38, 2)");
            entity.Property(e => e.PaymentTermName).HasMaxLength(50);
            entity.Property(e => e.Period).HasDefaultValue(0);
            entity.Property(e => e.PeriodCount).HasDefaultValue(1);
            entity.Property(e => e.PeriodDueDateType).HasDefaultValue(0);
            entity.Property(e => e.PeriodWorkingDaysOnly).HasDefaultValue(0);
            entity.Property(e => e.Status).HasDefaultValue(0);
        });

        modelBuilder.Entity<CrmPaymentTermApply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmPayme__3214EC0749DA75DE");

            entity.ToTable("CrmPaymentTermApply");

            entity.Property(e => e.ItemId).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");
        });

        modelBuilder.Entity<CrmPaymentTermItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmPayme__3214EC07983BC316");

            entity.Property(e => e.Amount)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 1)");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.DueDays).HasDefaultValueSql("('0')");
            entity.Property(e => e.PaymentTitle).HasMaxLength(300);
            entity.Property(e => e.SequenceNo).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");
        });

        modelBuilder.Entity<CrmPriceList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmPrice__3214EC0708972E4D");

            entity.HasIndex(e => e.PriceListName, "idxCrmPriceLists1").IsUnique();

            entity.HasIndex(e => e.CurrencyCode, "idxCrmPriceListsCurrencyCode");

            entity.HasIndex(e => e.EndDate, "idxCrmPriceListsEndDate");

            entity.HasIndex(e => e.StartDate, "idxCrmPriceListsStartDate");

            entity.HasIndex(e => e.Status, "idxCrmPriceListsStatus");

            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.PriceListName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CrmPriceListItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmPrice__3214EC07066C3DA9");

            entity.HasIndex(e => new { e.PriceListId, e.ItemId, e.PriceName }, "idxCrmPriceListItems1").IsUnique();

            entity.HasIndex(e => e.Amount, "idxCrmPriceListItemsAmount");

            entity.HasIndex(e => e.ItemId, "idxCrmPriceListItemsItemId");

            entity.HasIndex(e => e.MinOrderQuantity, "idxCrmPriceListItemsMinOrderQuantity");

            entity.HasIndex(e => e.PriceListId, "idxCrmPriceListItemsPriceListId");

            entity.HasIndex(e => e.PriceName, "idxCrmPriceListItemsPriceName");

            entity.HasIndex(e => e.PriceType, "idxCrmPriceListItemsPriceType");

            entity.HasIndex(e => e.Rate, "idxCrmPriceListItemsRate");

            entity.HasIndex(e => e.SequenceNo, "idxCrmPriceListItemsSequenceNo");

            entity.HasIndex(e => e.Status, "idxCrmPriceListItemsStatus");

            entity.HasIndex(e => e.UnitCode, "idxCrmPriceListItemsUnitCode");

            entity.Property(e => e.Amount).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.MinOrderQuantity).HasDefaultValue(1.0);
            entity.Property(e => e.PriceName).HasMaxLength(100);
            entity.Property(e => e.PriceType).HasDefaultValue(0);
            entity.Property(e => e.Rate)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(38, 2)");
            entity.Property(e => e.SequenceNo).HasDefaultValue(0);
            entity.Property(e => e.Status).HasDefaultValue(0);
            entity.Property(e => e.UnitCode)
                .HasMaxLength(50)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<CrmPromo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmPromo__3214EC07973FCB30");

            entity.HasIndex(e => e.PromoCode, "idxCrmPromos1").IsUnique();

            entity.HasIndex(e => e.DiscountAmount, "idxCrmPromosDiscountAmount");

            entity.HasIndex(e => e.DiscountRate, "idxCrmPromosDiscountRate");

            entity.HasIndex(e => e.EarnValue, "idxCrmPromosEarnValue");

            entity.HasIndex(e => e.EndDate, "idxCrmPromosEndDate");

            entity.HasIndex(e => e.StartDate, "idxCrmPromosStartDate");

            entity.HasIndex(e => e.Status, "idxCrmPromosStatus");

            entity.HasIndex(e => e.UseThisPrice, "idxCrmPromosUseThisPrice");

            entity.HasIndex(e => e.UseThisPriceListId, "idxCrmPromosUseThisPriceListId");

            entity.Property(e => e.DiscountAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(38, 2)");
            entity.Property(e => e.DiscountRate).HasDefaultValue(0.0);
            entity.Property(e => e.EarnValue)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(38, 2)");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.PromoCode)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UseThisPrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(38, 2)");
            entity.Property(e => e.UseThisPriceListId).HasDefaultValue(0L);
        });

        modelBuilder.Entity<CrmReceipt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmRecei__3214EC07FAA4A630");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CurrencyExchangeRate)
                .HasDefaultValueSql("('1')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CurrencyId).HasDefaultValueSql("('0')");
            entity.Property(e => e.ReceiptDate).HasColumnType("datetime");
            entity.Property(e => e.ReceiptDesc).HasMaxLength(240);
            entity.Property(e => e.ReceivedByUserId).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
            entity.Property(e => e.TotalAmountPaid)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalDiscountAmount)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalDiscountPercent)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<CrmReceiptItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmRecei__3214EC07E126F493");

            entity.Property(e => e.AmountPaid)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 1)");
            entity.Property(e => e.DiscountAmount)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 1)");
            entity.Property(e => e.DiscountPercent)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 1)");
            entity.Property(e => e.PaymentTermItemId).HasDefaultValueSql("('0')");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 1)");
            entity.Property(e => e.ReceiptItemDesc).HasMaxLength(200);
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.SalesInvoiceItemId).HasDefaultValueSql("('0')");
            entity.Property(e => e.SalesOrderItemId).HasDefaultValueSql("('0')");
            entity.Property(e => e.SequenceNo).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<CrmSalesFee>(entity =>
        {
            entity.Property(e => e.Blended).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BlendedMisc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateCreated).HasColumnType("smalldatetime");
            entity.Property(e => e.Distance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DistanceMisc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EffectivityDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Hybrid).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HybridMisc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SchoolYear).HasMaxLength(20);
            entity.Property(e => e.Tradition).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TraditionMisc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Virtual).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VirtualMisc).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<CrmSalesInvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmSales__3214EC075527813C");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CurrencyExchangeRate).HasDefaultValue("1");
            entity.Property(e => e.CurrencyId).HasDefaultValueSql("('0')");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.DueDays).HasDefaultValueSql("('0')");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceDesc).HasMaxLength(240);
            entity.Property(e => e.InvoiceNo).HasMaxLength(40);
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
            entity.Property(e => e.TotalAmountPaid)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalDiscountAmount)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalDiscountPercent)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalInterestAmount)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalInterestPercent)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalNetAmount)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<CrmSalesInvoiceItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmSales__3214EC0718F763D3");

            entity.Property(e => e.AmountPaid)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DiscountAmount)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DiscountPercent)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InterestAmount)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InterestPercent)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InvoiceItemDesc)
                .HasMaxLength(200)
                .HasDefaultValue("");
            entity.Property(e => e.LineTotal)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentTermItemId).HasDefaultValueSql("('0')");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.SalesOrderItemId).HasDefaultValueSql("('0')");
            entity.Property(e => e.SequenceNo).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
            entity.Property(e => e.UnitId).HasDefaultValueSql("('0')");
            entity.Property(e => e.UnitPrice)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<CrmSalesOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmSales__3214EC07CD84FBA0");

            entity.Property(e => e.SalesOrderDate).HasColumnType("datetime");
            entity.Property(e => e.SalesOrderDocFilename)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.SalesOrderNo).HasMaxLength(40);
            entity.Property(e => e.SalesQuotationId).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
            entity.Property(e => e.TotalAmountPaid)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<CrmSalesOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmSales__3214EC0714E2ABEB");

            entity.Property(e => e.AmountPaid)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.SequenceNo).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<CrmSalesQuotation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmSales__3214EC07605D2B50");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DocumentRef)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.QuotationDate).HasColumnType("datetime");
            entity.Property(e => e.QuotationNo).HasMaxLength(40);
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<CrmSalesQuotationItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CrmSales__3214EC07FFD9D705");

            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.SequenceNo).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.Property(e => e.GenderName).HasMaxLength(50);
        });

        modelBuilder.Entity<GlobalTagging>(entity =>
        {
            entity.ToTable("GlobalTagging");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.Tag).HasMaxLength(200);
            entity.Property(e => e.TagIdentifier).HasMaxLength(300);
        });

        modelBuilder.Entity<LrnAdmissionApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnAdmis__3214EC071DE66501");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ApplicationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ApplicationRefNo).HasMaxLength(80);
            entity.Property(e => e.DiscountCode).HasMaxLength(50);
            entity.Property(e => e.EmailAddress).HasMaxLength(255);
            entity.Property(e => e.FatherBirthDate).HasColumnType("smalldatetime");
            entity.Property(e => e.FatherEmail1).HasMaxLength(300);
            entity.Property(e => e.FatherEmail2).HasMaxLength(300);
            entity.Property(e => e.FatherGivenName).HasMaxLength(300);
            entity.Property(e => e.FatherLastname).HasMaxLength(300);
            entity.Property(e => e.FatherMiddleName).HasMaxLength(300);
            entity.Property(e => e.FatherPhone1).HasMaxLength(20);
            entity.Property(e => e.FatherPhone2).HasMaxLength(20);
            entity.Property(e => e.FatherPhoneCode1).HasMaxLength(50);
            entity.Property(e => e.FatherPhoneCode2).HasMaxLength(50);
            entity.Property(e => e.FatherZipCode).HasMaxLength(10);
            entity.Property(e => e.GuardianBirthDate).HasColumnType("smalldatetime");
            entity.Property(e => e.GuardianEmail1).HasMaxLength(300);
            entity.Property(e => e.GuardianEmail2).HasMaxLength(300);
            entity.Property(e => e.GuardianGivenName).HasMaxLength(300);
            entity.Property(e => e.GuardianLastname).HasMaxLength(300);
            entity.Property(e => e.GuardianMaidenName).HasMaxLength(300);
            entity.Property(e => e.GuardianMiddleName).HasMaxLength(300);
            entity.Property(e => e.GuardianPhone1).HasMaxLength(20);
            entity.Property(e => e.GuardianPhone2).HasMaxLength(20);
            entity.Property(e => e.GuardianPhoneCode1).HasMaxLength(50);
            entity.Property(e => e.GuardianPhoneCode2).HasMaxLength(50);
            entity.Property(e => e.GuardianZipCode).HasMaxLength(10);
            entity.Property(e => e.InvoiceNumber).HasMaxLength(50);
            entity.Property(e => e.MotherBirthDate).HasColumnType("smalldatetime");
            entity.Property(e => e.MotherEmail1).HasMaxLength(300);
            entity.Property(e => e.MotherEmail2).HasMaxLength(300);
            entity.Property(e => e.MotherGivenName).HasMaxLength(300);
            entity.Property(e => e.MotherLastname).HasMaxLength(300);
            entity.Property(e => e.MotherMaidenName).HasMaxLength(300);
            entity.Property(e => e.MotherMiddleName).HasMaxLength(300);
            entity.Property(e => e.MotherPhone1).HasMaxLength(20);
            entity.Property(e => e.MotherPhone2).HasMaxLength(20);
            entity.Property(e => e.MotherPhoneCode1).HasMaxLength(50);
            entity.Property(e => e.MotherPhoneCode2).HasMaxLength(50);
            entity.Property(e => e.MotherZipCode).HasMaxLength(10);
            entity.Property(e => e.PaymentDate).HasColumnType("smalldatetime");
            entity.Property(e => e.PaymentRefNo).HasMaxLength(50);
            entity.Property(e => e.SchoolContact).HasMaxLength(300);
            entity.Property(e => e.SchoolContactDesignation).HasMaxLength(300);
            entity.Property(e => e.SchoolContactEmail).HasMaxLength(300);
            entity.Property(e => e.SchoolContactNumber).HasMaxLength(20);
            entity.Property(e => e.SchoolEmail).HasMaxLength(300);
            entity.Property(e => e.SchoolName).HasMaxLength(300);
            entity.Property(e => e.SchoolOtherProgram).HasMaxLength(300);
            entity.Property(e => e.SchoolPhoneCode).HasMaxLength(50);
            entity.Property(e => e.Status).HasDefaultValue(1);
            entity.Property(e => e.StudentBirthDate).HasColumnType("smalldatetime");
            entity.Property(e => e.StudentCode).HasMaxLength(50);
            entity.Property(e => e.StudentEmail1).HasMaxLength(300);
            entity.Property(e => e.StudentEmail2).HasMaxLength(300);
            entity.Property(e => e.StudentGivenName).HasMaxLength(300);
            entity.Property(e => e.StudentLastname).HasMaxLength(300);
            entity.Property(e => e.StudentMaidenName).HasMaxLength(300);
            entity.Property(e => e.StudentMiddleName).HasMaxLength(300);
            entity.Property(e => e.StudentPhone1).HasMaxLength(20);
            entity.Property(e => e.StudentPhone2).HasMaxLength(20);
            entity.Property(e => e.StudentPhoneCode1).HasMaxLength(50);
            entity.Property(e => e.StudentPhoneCode2).HasMaxLength(50);
            entity.Property(e => e.StudentZipCode).HasMaxLength(10);
        });

        modelBuilder.Entity<LrnAdmissionContact>(entity =>
        {
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email1).HasMaxLength(300);
            entity.Property(e => e.Email2).HasMaxLength(300);
            entity.Property(e => e.GivenName).HasMaxLength(300);
            entity.Property(e => e.Lastname).HasMaxLength(300);
            entity.Property(e => e.MaidenName).HasMaxLength(300);
            entity.Property(e => e.MiddleName).HasMaxLength(300);
            entity.Property(e => e.PhoneNo1).HasMaxLength(50);
            entity.Property(e => e.PhoneNo2).HasMaxLength(50);
            entity.Property(e => e.StudentCode).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasMaxLength(50);
        });

        modelBuilder.Entity<LrnAdmissionDoc>(entity =>
        {
            entity.Property(e => e.DocumentName).HasMaxLength(200);
            entity.Property(e => e.DocumentRefNo).HasMaxLength(50);
            entity.Property(e => e.UploadDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<LrnAdmissionHistory>(entity =>
        {
            entity.ToTable("LrnAdmissionHistory");

            entity.Property(e => e.AdmissionApplicationId).HasColumnName("AdmissionApplicationID");
            entity.Property(e => e.Remarks).HasMaxLength(300);
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<LrnAdmissionPreviousSchool>(entity =>
        {
            entity.ToTable("LrnAdmissionPreviousSchool");

            entity.Property(e => e.ContactPerson).HasMaxLength(200);
            entity.Property(e => e.ContactPersonEmail).HasMaxLength(300);
            entity.Property(e => e.ContactPersonJob).HasMaxLength(200);
            entity.Property(e => e.ContactPersonNumber).HasMaxLength(50);
            entity.Property(e => e.OtherProgram).HasMaxLength(300);
            entity.Property(e => e.SchoolEmail).HasMaxLength(300);
            entity.Property(e => e.SchoolName).HasMaxLength(300);
        });

        modelBuilder.Entity<LrnCampus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnCampu__3214EC07AD5F89D8");

            entity.Property(e => e.CampusCode).HasMaxLength(20);
            entity.Property(e => e.CampusName).HasMaxLength(100);
            entity.Property(e => e.CampusOfOrgCode).HasMaxLength(40);
            entity.Property(e => e.Prefix).HasMaxLength(4);
        });

        modelBuilder.Entity<LrnClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnClass__3214EC07D8A2565E");

            entity.HasIndex(e => new { e.ProgramId, e.CourseId, e.OrgCode, e.ClassSectionId, e.GroupId, e.SectionName }, "idxLrnClasses1");

            entity.HasIndex(e => e.ActualDurationDays, "idxLrnClassesActualDurationDays");

            entity.HasIndex(e => e.ActualEndDate, "idxLrnClassesActualEndDate");

            entity.HasIndex(e => e.ActualSessionDurationMins, "idxLrnClassesActualSessionDurationMins");

            entity.HasIndex(e => e.ActualSessionEndTime, "idxLrnClassesActualSessionEndTime");

            entity.HasIndex(e => e.ActualSessionStartTime, "idxLrnClassesActualSessionStartTime");

            entity.HasIndex(e => e.ActualStartDate, "idxLrnClassesActualStartDate");

            entity.HasIndex(e => e.CampusCode, "idxLrnClassesCampusCode");

            entity.HasIndex(e => e.CourseCode, "idxLrnClassesCourseCode");

            entity.HasIndex(e => e.CourseId, "idxLrnClassesCourseId");

            entity.HasIndex(e => e.FacilitatorContactId, "idxLrnClassesFacilitatorContactId");

            entity.HasIndex(e => e.ClassSectionId, "idxLrnClassesGroupId");

            entity.HasIndex(e => e.IsFinished, "idxLrnClassesIsFinished");

            entity.HasIndex(e => e.IsStarted, "idxLrnClassesIsStarted");

            entity.HasIndex(e => e.LastWorkFlowId, "idxLrnClassesLastWorkFlowId");

            entity.HasIndex(e => e.LearningMethodCode, "idxLrnClassesLearningMethodCode");

            entity.HasIndex(e => e.OrgCode, "idxLrnClassesOrgCode");

            entity.HasIndex(e => e.PlannedDurationDays, "idxLrnClassesPlannedDurationDays");

            entity.HasIndex(e => e.PlannedEndDate, "idxLrnClassesPlannedEndDate");

            entity.HasIndex(e => e.PlannedSessionDurationMins, "idxLrnClassesPlannedSessionDurationMins");

            entity.HasIndex(e => e.PlannedSessionEndTime, "idxLrnClassesPlannedSessionEndTime");

            entity.HasIndex(e => e.PlannedSessionStartTime, "idxLrnClassesPlannedSessionStartTime");

            entity.HasIndex(e => e.PlannedStartDate, "idxLrnClassesPlannedStartDate");

            entity.HasIndex(e => e.ProgramId, "idxLrnClassesProgramId");

            entity.HasIndex(e => e.SectionName, "idxLrnClassesSectionName");

            entity.HasIndex(e => e.SequenceNo, "idxLrnClassesSequenceNo");

            entity.HasIndex(e => e.Status, "idxLrnClassesStatus");

            entity.HasIndex(e => e.TermName, "idxLrnClassesTermName");

            entity.Property(e => e.ActualDurationDays).HasDefaultValue(0);
            entity.Property(e => e.ActualEndDate).HasColumnType("datetime");
            entity.Property(e => e.ActualSessionDurationMins).HasDefaultValue(0);
            entity.Property(e => e.ActualSessionEndTime)
                .HasMaxLength(50)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.ActualSessionStartTime)
                .HasMaxLength(50)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.ActualStartDate).HasColumnType("datetime");
            entity.Property(e => e.CampusCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CourseCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IsFinished).HasDefaultValue(false);
            entity.Property(e => e.IsOpenTime).HasColumnName("isOpenTime");
            entity.Property(e => e.IsStarted).HasDefaultValue(false);
            entity.Property(e => e.LearningMethodCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OrgCode)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.PlannedDurationDays).HasDefaultValue(0);
            entity.Property(e => e.PlannedEndDate).HasColumnType("datetime");
            entity.Property(e => e.PlannedSessionDurationMins).HasDefaultValue(0);
            entity.Property(e => e.PlannedSessionEndTime)
                .HasMaxLength(50)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.PlannedSessionStartTime)
                .HasMaxLength(50)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.PlannedStartDate).HasColumnType("datetime");
            entity.Property(e => e.SectionName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.SequenceNo).HasDefaultValue(0);
            entity.Property(e => e.Status).HasDefaultValue(0);
            entity.Property(e => e.TermName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LrnClassActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnClass__3214EC076615A23B");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ActivityResourceId).HasDefaultValueSql("('0')");
            entity.Property(e => e.SequenceNo).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");
        });

        modelBuilder.Entity<LrnClassActivityTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnClass__3214EC07946DEAB4");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BreakAfterMins).HasDefaultValue("0");
            entity.Property(e => e.DurationMins)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IsShowAfterLecture).HasDefaultValueSql("('1')");
            entity.Property(e => e.IsShowTestAnswer).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");
        });

        modelBuilder.Entity<LrnClassFacilitator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnClass__3214EC07FFD48754");

            entity.HasIndex(e => new { e.ClassId, e.ContactId, e.RoleId }, "idxLrnClassFacilitators1").IsUnique();

            entity.HasIndex(e => e.ClassId, "idxLrnClassFacilitatorsClassId");

            entity.HasIndex(e => e.ContactId, "idxLrnClassFacilitatorsContactId");

            entity.HasIndex(e => e.LastWorkFlowId, "idxLrnClassFacilitatorsLastWorkFlowId");

            entity.HasIndex(e => e.RoleId, "idxLrnClassFacilitatorsRoleId");

            entity.HasIndex(e => e.Status, "idxLrnClassFacilitatorsStatus");

            entity.Property(e => e.Status).HasDefaultValue(0);
        });

        modelBuilder.Entity<LrnClassSection>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IdNumber).HasMaxLength(100);
            entity.Property(e => e.Path).HasMaxLength(255);
            entity.Property(e => e.SectionName).HasMaxLength(255);
            entity.Property(e => e.Theme).HasMaxLength(50);
        });

        modelBuilder.Entity<LrnCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnCours__3214EC0780B0C8D5");

            entity.Property(e => e.CourseCode).HasMaxLength(40);
            entity.Property(e => e.CourseTitle).HasMaxLength(200);
            entity.Property(e => e.CreditUnits).HasDefaultValue("0");
            entity.Property(e => e.DurationHours).HasDefaultValueSql("('0')");
            entity.Property(e => e.DurationMonths).HasDefaultValueSql("('0')");
            entity.Property(e => e.DurationWeeks).HasDefaultValueSql("('0')");
            entity.Property(e => e.DurationYears).HasDefaultValueSql("('0')");
            entity.Property(e => e.IsGeneral).HasColumnName("isGeneral");
            entity.Property(e => e.ItemId).HasDefaultValueSql("('0')");
            entity.Property(e => e.ParentCourseId).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");
            entity.Property(e => e.SubjectId).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<LrnCourseActivityTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnCours__3214EC07026FA1E5");

            entity.Property(e => e.BreakAfterMins).HasDefaultValue("0");
            entity.Property(e => e.DurationMins).HasDefaultValue("0");
            entity.Property(e => e.IsShowAfterLecture).HasDefaultValueSql("('1')");
            entity.Property(e => e.IsShowTestAnswer).HasDefaultValueSql("('0')");
            entity.Property(e => e.SequenceNo).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");
        });

        modelBuilder.Entity<LrnCustomerStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnCusto__3214EC077BD48526");

            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<LrnExaminationPermit>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.GeneratedDate).HasColumnType("datetime");
            entity.Property(e => e.Outstandingbalance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PermitCode).HasMaxLength(50);
        });

        modelBuilder.Entity<LrnGradeCriterion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnGrade__3214EC07E779E8E7");

            entity.HasIndex(e => new { e.GradingSystemId, e.GradeText }, "idxLrnGradeCriteria1").IsUnique();

            entity.HasIndex(e => e.GradeText, "idxLrnGradeCriteriaGradeText");

            entity.HasIndex(e => e.GradeValue, "idxLrnGradeCriteriaGradeValue");

            entity.HasIndex(e => e.GradingSystemId, "idxLrnGradeCriteriaGradingSystemId");

            entity.HasIndex(e => e.LastWorkFlowId, "idxLrnGradeCriteriaLastWorkFlowId");

            entity.HasIndex(e => e.RatingFrom, "idxLrnGradeCriteriaRatingFrom");

            entity.HasIndex(e => e.RatingIsPass, "idxLrnGradeCriteriaRatingIsPass");

            entity.HasIndex(e => e.RatingTo, "idxLrnGradeCriteriaRatingTo");

            entity.HasIndex(e => e.Status, "idxLrnGradeCriteriaStatus");

            entity.Property(e => e.GradeText).HasMaxLength(50);
            entity.Property(e => e.GradeValue).HasDefaultValue(0.0);
            entity.Property(e => e.RatingFrom).HasDefaultValue(0.0);
            entity.Property(e => e.RatingIsPass).HasDefaultValue(1);
            entity.Property(e => e.RatingTo).HasDefaultValue(0.0);
            entity.Property(e => e.Status).HasDefaultValue(0);
        });

        modelBuilder.Entity<LrnGradingSystem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnGradi__3214EC078983D7C2");

            entity.ToTable("LrnGradingSystem");

            entity.HasIndex(e => e.GradingName, "idxLrnGradingSystem1").IsUnique();

            entity.HasIndex(e => e.GradingType, "idxLrnGradingSystemGradingType");

            entity.HasIndex(e => e.Status, "idxLrnGradingSystemStatus");

            entity.Property(e => e.GradingName).HasMaxLength(80);
        });

        modelBuilder.Entity<LrnIssuedDocument>(entity =>
        {
            entity.Property(e => e.DocumentNumber).HasMaxLength(50);
            entity.Property(e => e.IssuedDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<LrnLearningMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnLearn__3214EC077C2FADD1");

            entity.Property(e => e.LearningMethodCode).HasMaxLength(20);
            entity.Property(e => e.LearningMethodName).HasMaxLength(100);
            entity.Property(e => e.LearningMethodType).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<LrnOnlineDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LrnOnineDocuments");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DocumentCode).HasMaxLength(50);
            entity.Property(e => e.DocumentUrl).HasMaxLength(300);
            entity.Property(e => e.MainNo).HasMaxLength(50);
            entity.Property(e => e.MainTitle).HasMaxLength(300);
            entity.Property(e => e.NextReviewDate).HasColumnType("datetime");
            entity.Property(e => e.PurposeNo).HasMaxLength(50);
            entity.Property(e => e.PurposeTitle).HasMaxLength(300);
            entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.ScopeNo).HasMaxLength(50);
            entity.Property(e => e.ScopeTitle).HasMaxLength(300);
            entity.Property(e => e.Title).HasMaxLength(300);
            entity.Property(e => e.VersionNo).HasMaxLength(50);
        });

        modelBuilder.Entity<LrnOnlineDocumentSection>(entity =>
        {
            entity.Property(e => e.DateCreated).HasColumnType("smalldatetime");
            entity.Property(e => e.SectionNo).HasMaxLength(20);
            entity.Property(e => e.SectionTitle).HasMaxLength(50);
        });

        modelBuilder.Entity<LrnOrgProgram>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnOrgPr__3214EC07B7301705");

            entity.HasIndex(e => new { e.ProgramId, e.OrgId }, "idxLrnOrgPrograms1").IsUnique();

            entity.HasIndex(e => e.IsVisible, "idxLrnOrgProgramsIsVisible");

            entity.HasIndex(e => e.LastWorkFlowId, "idxLrnOrgProgramsLastWorkFlowId");

            entity.HasIndex(e => e.OrgId, "idxLrnOrgProgramsOrgId");

            entity.HasIndex(e => e.ProgramId, "idxLrnOrgProgramsProgramId");

            entity.HasIndex(e => e.SequenceNo, "idxLrnOrgProgramsSequenceNo");

            entity.HasIndex(e => e.Status, "idxLrnOrgProgramsStatus");

            entity.Property(e => e.IsVisible).HasDefaultValue(true);
            entity.Property(e => e.SequenceNo).HasDefaultValue(0);
            entity.Property(e => e.Status).HasDefaultValue(0);
        });

        modelBuilder.Entity<LrnProgram>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnProgr__3214EC07CD51817F");

            entity.Property(e => e.CoursesAutoEnroll).HasDefaultValueSql("('0')");
            entity.Property(e => e.CreditUnits)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DurationDays)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DurationHours).HasDefaultValueSql("('0')");
            entity.Property(e => e.DurationMonths)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DurationTerms)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DurationWeeks)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DurationYears)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EffectiveDateEnd).HasColumnType("datetime");
            entity.Property(e => e.EffectiveDateStart).HasColumnType("datetime");
            entity.Property(e => e.GradingSystemId).HasDefaultValueSql("('0')");
            entity.Property(e => e.ItemId).HasDefaultValueSql("('0')");
            entity.Property(e => e.ParentId).HasDefaultValueSql("('0')");
            entity.Property(e => e.ProgramCode).HasMaxLength(20);
            entity.Property(e => e.ProgramHeadContactId).HasDefaultValueSql("('0')");
            entity.Property(e => e.ProgramTitle).HasMaxLength(200);
            entity.Property(e => e.RevisionNo).HasMaxLength(20);
            entity.Property(e => e.SequenceNo).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<LrnProgramCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnProgr__3214EC07841A4FEB");

            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<LrnPromisoryNote>(entity =>
        {
            entity.Property(e => e.ExaminationDate).HasColumnType("datetime");
            entity.Property(e => e.OutstandingBalance).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<LrnSchoolWeek>(entity =>
        {
            entity.Property(e => e.DateGenerated).HasColumnType("datetime");
            entity.Property(e => e.SchoolYear).HasMaxLength(50);
        });

        modelBuilder.Entity<LrnStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnStude__3214EC0799CFB7E2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DepEdLrn)
                .HasMaxLength(50)
                .HasColumnName("DepEdLRN");
            entity.Property(e => e.FatherContactId).HasDefaultValueSql("('0')");
            entity.Property(e => e.GuardianContactId).HasDefaultValueSql("('0')");
            entity.Property(e => e.MotherContactId).HasDefaultValueSql("('0')");
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.SiblingOrdinalNo).HasDefaultValueSql("('0')");
            entity.Property(e => e.SponsorContactId).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
            entity.Property(e => e.StudentCode).HasMaxLength(40);
            entity.Property(e => e.StudentOldCode).HasMaxLength(50);
        });

        modelBuilder.Entity<LrnStudentClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnStude__3214EC07FA46B161");

            entity.Property(e => e.AdmissionDate).HasColumnType("datetime");
            entity.Property(e => e.CredentialProviderId).HasDefaultValueSql("('0')");
            entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");
            entity.Property(e => e.FinalAverage)
                .HasDefaultValueSql("('-1')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FinalRating)
                .HasDefaultValueSql("('-1')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FinalScore)
                .HasDefaultValueSql("('-1')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GroupName)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.NextActivitySequenceNo).HasDefaultValueSql("('1')");
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.SalesOrderId).HasDefaultValueSql("('0')");
            entity.Property(e => e.SchoolYear).HasMaxLength(50);
            entity.Property(e => e.SequenceNo).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<LrnStudentDocumentRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LrnStudentRequests");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ChangeStatusDate).HasColumnType("smalldatetime");
            entity.Property(e => e.DocumentNumber).HasMaxLength(50);
            entity.Property(e => e.IssuedDate).HasColumnType("smalldatetime");
            entity.Property(e => e.PaymentRefNo).HasMaxLength(50);
            entity.Property(e => e.RequestDate).HasColumnType("smalldatetime");
            entity.Property(e => e.RequestNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<LrnStudentProgram>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnStude__3214EC07EB9CFA95");

            entity.Property(e => e.AdmissionPaymentStatus).HasDefaultValueSql("('1')");
            entity.Property(e => e.CredentialProviderId).HasDefaultValueSql("('0')");
            entity.Property(e => e.DownPaymentStatus).HasDefaultValueSql("('1')");
            entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");
            entity.Property(e => e.EnrollmentReferenceNo)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.LearningMethodId).HasDefaultValueSql("('0')");
            entity.Property(e => e.SalesOrderId).HasDefaultValueSql("('0')");
            entity.Property(e => e.SchoolCampusId).HasDefaultValueSql("('0')");
            entity.Property(e => e.SchoolYear)
                .HasMaxLength(80)
                .HasDefaultValue("");
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<LrnStudentProgramRequirement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnStude__3214EC078A973DCC");

            entity.Property(e => e.CustomFieldId).HasDefaultValueSql("('0')");
            entity.Property(e => e.DateSubmitted).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.RequirementRating)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RequirementScore).HasDefaultValue("0");
            entity.Property(e => e.SequenceNo).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<LrnSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LrnSubje__3214EC0764887B6C");

            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
            entity.Property(e => e.SubjectCode).HasMaxLength(20);
            entity.Property(e => e.SubjectTitle).HasMaxLength(200);
        });

        modelBuilder.Entity<MaritalStatus>(entity =>
        {
            entity.ToTable("MaritalStatus");

            entity.Property(e => e.MaritalStatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<PageModule>(entity =>
        {
            entity.Property(e => e.CssClass).HasMaxLength(300);
            entity.Property(e => e.ModuleName).HasMaxLength(300);
            entity.Property(e => e.TargetUrl).HasMaxLength(200);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<PageSection>(entity =>
        {
            entity.Property(e => e.CssClass).HasMaxLength(300);
            entity.Property(e => e.Icon).HasMaxLength(200);
            entity.Property(e => e.PageSectionName).HasMaxLength(300);
            entity.Property(e => e.SubElementId).HasMaxLength(50);
            entity.Property(e => e.TargetUrl).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.WikiDataId).HasColumnType("money");
        });

        modelBuilder.Entity<Religion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Religion__3214EC0752B6D2CA");

            entity.Property(e => e.ReligionCode).HasMaxLength(20);
            entity.Property(e => e.ReligionName).HasMaxLength(200);
            entity.Property(e => e.Status).HasDefaultValueSql("('0')");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07A9268C85");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.RoleName).HasMaxLength(80);
        });

        modelBuilder.Entity<RoleAccess>(entity =>
        {
            entity.ToTable("RoleAccess");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
        });

        modelBuilder.Entity<ScmCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ScmCateg__3214EC075FE7AA7F");

            entity.HasIndex(e => e.CategoryName, "idxScmCategories1").IsUnique();

            entity.HasIndex(e => e.ParentCategoryName, "idxScmCategoriesParentCategoryName");

            entity.HasIndex(e => e.Status, "idxScmCategoriesStatus");

            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.ParentCategoryName)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Status).HasDefaultValue(0);
        });

        modelBuilder.Entity<ScmItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ScmItems__3214EC074ECC8A6C");

            entity.HasIndex(e => e.ItemCode, "idxScmItems1").IsUnique();

            entity.HasIndex(e => e.ItemName, "idxScmItems2").IsUnique();

            entity.HasIndex(e => e.CostPrice, "idxScmItemsCostPrice");

            entity.HasIndex(e => e.CurrencyCode, "idxScmItemsCurrencyCode");

            entity.HasIndex(e => e.IsInventory, "idxScmItemsIsInventory");

            entity.HasIndex(e => e.ItemType, "idxScmItemsItemType");

            entity.HasIndex(e => e.ItemTypeClass, "idxScmItemsItemTypeClass");

            entity.HasIndex(e => e.ItemTypeUse, "idxScmItemsItemTypeUse");

            entity.HasIndex(e => e.ListPrice, "idxScmItemsListPrice");

            entity.HasIndex(e => e.Status, "idxScmItemsStatus");

            entity.Property(e => e.CostPrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(38, 2)");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.IsInventory).HasDefaultValue(1);
            entity.Property(e => e.ItemCode)
                .HasMaxLength(40)
                .HasDefaultValue("");
            entity.Property(e => e.ItemName).HasMaxLength(100);
            entity.Property(e => e.ItemTypeClass).HasDefaultValue(0);
            entity.Property(e => e.ItemTypeUse).HasDefaultValue(1);
            entity.Property(e => e.ListPrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<ScmItemCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ScmItemC__3214EC0745FC842F");

            entity.HasIndex(e => new { e.ItemId, e.CategoryId }, "idxScmItemCategories1").IsUnique();

            entity.HasIndex(e => e.CategoryId, "idxScmItemCategoriesCategoryId");

            entity.HasIndex(e => e.ItemId, "idxScmItemCategoriesItemId");

            entity.HasIndex(e => e.Status, "idxScmItemCategoriesStatus");

            entity.Property(e => e.Status).HasDefaultValue(0);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__States__3214EC072BD897EC");

            entity.Property(e => e.CountryCode).HasMaxLength(10);
            entity.Property(e => e.StateCode).HasMaxLength(10);
            entity.Property(e => e.StateName).HasMaxLength(200);
            entity.Property(e => e.StateType).HasMaxLength(200);
        });

        modelBuilder.Entity<SubRegion>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.WikiDataId).HasColumnType("money");
        });

        modelBuilder.Entity<SysCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SysCateg__3214EC0750FAAE9F");

            entity.Property(e => e.CategoryCode).HasMaxLength(10);
            entity.Property(e => e.CategoryGroup).HasMaxLength(200);
            entity.Property(e => e.CategoryName).HasMaxLength(80);
            entity.Property(e => e.IconUrl).HasMaxLength(300);
        });

        modelBuilder.Entity<SysDocumentType>(entity =>
        {
            entity.Property(e => e.DocumentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DocumentName).HasMaxLength(200);
            entity.Property(e => e.Prefix).HasMaxLength(10);
        });

        modelBuilder.Entity<SysDomain>(entity =>
        {
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DomainDescription).HasMaxLength(300);
            entity.Property(e => e.DomainName).HasMaxLength(300);
            entity.Property(e => e.DomainUrl).HasMaxLength(300);
        });

        modelBuilder.Entity<SysNotification>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.NotificationDate).HasColumnType("datetime");
            entity.Property(e => e.ReferenceId).HasMaxLength(50);
            entity.Property(e => e.ReturnUrl).HasMaxLength(500);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<SysPasskey>(entity =>
        {
            entity.ToTable("SysPasskey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(300);
            entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");
            entity.Property(e => e.GeneratedDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Passkey).HasMaxLength(16);
            entity.Property(e => e.StudentNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<SysStatus>(entity =>
        {
            entity.Property(e => e.StatusDesc).HasMaxLength(300);
            entity.Property(e => e.StatusGroup).HasMaxLength(300);
            entity.Property(e => e.StatusName).HasMaxLength(300);
        });

        modelBuilder.Entity<SysWorkflow>(entity =>
        {
            entity.Property(e => e.WorkflowDesc).HasMaxLength(300);
            entity.Property(e => e.WorkflowName).HasMaxLength(300);
        });

        modelBuilder.Entity<SysWorkflowAssignment>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(300);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07600FA14C");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DisplayName).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.ExitPassword)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastLoginInfo)
                .HasMaxLength(200)
                .HasDefaultValue("");
            entity.Property(e => e.Locale)
                .HasMaxLength(16)
                .HasDefaultValue("en-US");
            entity.Property(e => e.MaxDisplayRows).HasDefaultValueSql("('40')");
            entity.Property(e => e.PaperSize)
                .HasMaxLength(16)
                .HasDefaultValue("A4");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Theme)
                .HasMaxLength(32)
                .HasDefaultValue("default");
            entity.Property(e => e.Username).HasMaxLength(40);
            entity.Property(e => e.Username2).HasMaxLength(50);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.LoginDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ViewCollegeCourse>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_CollegeCourses");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("CODE");
            entity.Property(e => e.Credit).HasColumnName("CREDIT");
            entity.Property(e => e.Date)
                .HasMaxLength(50)
                .HasColumnName("DATE");
            entity.Property(e => e.Prerequisite).HasColumnName("PREREQUISITE");
            entity.Property(e => e.Program)
                .HasMaxLength(50)
                .HasColumnName("PROGRAM");
            entity.Property(e => e.Semester)
                .HasMaxLength(50)
                .HasColumnName("SEMESTER");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("TITLE");
        });

        modelBuilder.Entity<ViewCollegeCoursesByProgram>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_CollegeCoursesByProgram");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("CODE");
            entity.Property(e => e.Coursetitle)
                .HasMaxLength(4000)
                .HasColumnName("COURSETITLE");
            entity.Property(e => e.Credit).HasColumnName("CREDIT");
            entity.Property(e => e.Origtitle)
                .HasMaxLength(100)
                .HasColumnName("ORIGTITLE");
            entity.Property(e => e.Prerequisite).HasColumnName("PREREQUISITE");
            entity.Property(e => e.Program)
                .HasMaxLength(50)
                .HasColumnName("PROGRAM");
            entity.Property(e => e.Programid).HasColumnName("PROGRAMID");
            entity.Property(e => e.Sectioname)
                .HasMaxLength(101)
                .HasColumnName("SECTIONAME");
        });

        modelBuilder.Entity<ViewCollegeCoursesDistinct>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_CollegeCourses_DISTINCT");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("CODE");
            entity.Property(e => e.Coursetitle)
                .HasMaxLength(4000)
                .HasColumnName("COURSETITLE");
            entity.Property(e => e.Credit).HasColumnName("CREDIT");
            entity.Property(e => e.Prerequisite).HasColumnName("PREREQUISITE");
        });

        modelBuilder.Entity<ViewCollegeCoursesPerSem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_CollegeCoursesPerSem");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("CODE");
            entity.Property(e => e.Coursetitle)
                .HasMaxLength(4000)
                .HasColumnName("COURSETITLE");
            entity.Property(e => e.Credit).HasColumnName("CREDIT");
            entity.Property(e => e.Date)
                .HasMaxLength(50)
                .HasColumnName("DATE");
            entity.Property(e => e.Origtitle)
                .HasMaxLength(100)
                .HasColumnName("ORIGTITLE");
            entity.Property(e => e.Prerequisite).HasColumnName("PREREQUISITE");
            entity.Property(e => e.Program)
                .HasMaxLength(50)
                .HasColumnName("PROGRAM");
            entity.Property(e => e.Programid).HasColumnName("PROGRAMID");
            entity.Property(e => e.Sectioname)
                .HasMaxLength(163)
                .HasColumnName("SECTIONAME");
            entity.Property(e => e.Semester)
                .HasMaxLength(50)
                .HasColumnName("SEMESTER");
        });

        modelBuilder.Entity<ViewCourseCodeToIdMap>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_CourseCodeToIdMap");

            entity.Property(e => e.CourseCode).HasMaxLength(40);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ViewFeesByLearningMethod>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_FeesByLearningMethod");

            entity.Property(e => e.CategoryCode).HasMaxLength(10);
            entity.Property(e => e.CategoryName).HasMaxLength(80);
            entity.Property(e => e.DateCreated).HasColumnType("smalldatetime");
            entity.Property(e => e.EffectivityDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Fee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LearningMethod)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.MiscFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SchoolYear).HasMaxLength(20);
        });

        modelBuilder.Entity<VwStudentMasterList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_StudentMasterList");

            entity.Property(e => e.CampusName).HasMaxLength(100);
            entity.Property(e => e.CategoryName).HasMaxLength(80);
            entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");
            entity.Property(e => e.GivenName).HasMaxLength(240);
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.LearningMethodName).HasMaxLength(100);
            entity.Property(e => e.MaidenName).HasMaxLength(200);
            entity.Property(e => e.MiddleName).HasMaxLength(200);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.SchoolYear).HasMaxLength(50);
            entity.Property(e => e.SectionName).HasMaxLength(255);
            entity.Property(e => e.StatusName).HasMaxLength(300);
            entity.Property(e => e.StudentCode).HasMaxLength(40);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
