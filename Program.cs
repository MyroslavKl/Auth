using Lab2.Additional;
using Lab2.Data;
using Lab2.Repositories.Contracts;
using Lab2.Repositories.Contracts.Common;
using Lab2.Repositories.RepositoryImplementation;
using Lab2.Repositories.RepositoryImplementation.Common;
using Lab2.Unit;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Default")));

int saltLength = int.Parse(builder.Configuration.GetSection("HashOptions:SaltLength").Value!);
int keyLength = int.Parse(builder.Configuration.GetSection("HashOptions:KeyLength").Value!);
int iterations = int.Parse(builder.Configuration.GetSection("HashOptions:Iterations").Value!);

HashOptions hashOptions = new HashOptions { SaltLength = saltLength, KeyLength = keyLength, Iterations = iterations };
builder.Services.AddSingleton<IHashService>(_ => new Hash(hashOptions));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "/login";
    });


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITutorRepository, TutorRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeStudentsRepository, GradeStudentsRepository>();
builder.Services.AddScoped<ICourseTutorRepository, CourseTutorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
