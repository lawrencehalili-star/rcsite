using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.FileProviders;
using richmindale_app.Server.DapperContext;
using richmindale_app.Server.Repositories;
using richmindale_app.Server.Helpers;


var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("Email From config: " + builder.Configuration["EmailSettings:From"]);




// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();   
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<richmindale_app.Server.Helpers.IEmailSender, richmindale_app.Server.Helpers.EmailSender>();
// Richmindale 
builder.Services.AddTransient<DapperDbContext, DapperDbContext>();
builder.Services.AddTransient<IAuthentication, AuthenticationRepository>();
builder.Services.AddTransient<ICommonRepository, CommonRepository>();
builder.Services.AddTransient<IPublicRepository, PublicRepository>();
builder.Services.AddTransient<IAdmission, AdmissionRepository>();
builder.Services.AddTransient<IServicesRepository, ServicesRepository>();
builder.Services.AddTransient<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddTransient<IRegistrarRepository, RegistrarRepository>();
builder.Services.AddTransient<IProfileRepository, ProfileRepository>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<ISchoolAdminRepository, SchoolAdminRepository>();
builder.Services.AddTransient<IFinanceRepository, FinanceRepository>();



// Expense Tracker
builder.Services.AddTransient<ExpenseTrackerDbContext, ExpenseTrackerDbContext>();
builder.Services.AddTransient<IExpenseTrackerRepository, ExpenseTrackerRepository>();



builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
    
});

builder.Services.Configure<FormOptions>(o => {
  o.ValueLengthLimit = int.MaxValue;
  o.MultipartBodyLengthLimit = int.MaxValue;
  o.MemoryBufferThreshold = int.MaxValue;
});

var app = builder.Build();
app.UseCors(options => 
  options.AllowAnyOrigin()
  .AllowAnyMethod()
  .AllowAnyHeader()
  
);
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthorization();
/* app.UseStaticFiles(new StaticFileOptions() {
  FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Uploads" )),
  RequestPath = new PathString("/Uploads")
}); */

app.UseSwagger();
app.UseSwaggerUI();


if (!app.Environment.IsDevelopment())
{
  app.UseHsts();
  app.UseSwagger();
  app.UseSwaggerUI();
}
else
{
  app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.MapFallbackToFile("/index.html");


//testing if be is connected to fe
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapFallbackToFile("index.html");


app.Run();



