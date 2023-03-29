using MergeMe.Controllers;
using MergeMe.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddCors();
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionStrings:MergeMe"]);
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JwtBearerTokenSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtBearerTokenSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtBearerTokenSettings:SecretKey"]))
    };
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
//Post Methods
app.MapMethods(DeveloperPost.Template, DeveloperPost.Method, DeveloperPost.Handler);
app.MapMethods(RecruiterPost.Template, RecruiterPost.Method, RecruiterPost.Handler);
app.MapMethods(LoginPost.Template, LoginPost.Method, LoginPost.Handler);

//Get Methods
app.MapMethods(DashboardRecruiterGet.Template, DashboardRecruiterGet.Method, DashboardRecruiterGet.Handler);
app.MapMethods(DashboardDeveloperGet.Template, DashboardDeveloperGet.Method, DashboardDeveloperGet.Handler);
app.MapMethods(StacksGET.Template, StacksGET.Method, StacksGET.Handler);
app.MapMethods(RecruiterStackGET.Template, RecruiterStackGET.Method, RecruiterStackGET.Handler);
app.MapMethods(DeveloperStackGET.Template, DeveloperStackGET.Method, DeveloperStackGET.Handler);

//PUT Methods
app.MapMethods(DeveloperPUT.Template, DeveloperPUT.Method, DeveloperPUT.Handler);
app.MapMethods(StackDeveloperPUT.Template, StackDeveloperPUT.Method, StackDeveloperPUT.Handler);

app.UseStaticFiles();
app.UseRouting();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:44404"));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
