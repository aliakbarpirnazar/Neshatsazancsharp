using _0_Framework.Application;
using DataLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NeshatSazan.Hubs;
using ServiceLayer.Interfaces;
using ServiceLayer.PublicClass;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie(options =>
{
    options.LoginPath = "/Login";
    options.LogoutPath = "/SignOut";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
});


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
});

builder.Services.Configure<SecurityStampValidatorOptions>(x =>
{
    x.ValidationInterval = TimeSpan.Zero;
});


//SQL Connection
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

//PublicManagement
builder.Services.AddScoped<IFileUploader, FileUploader>();
builder.Services.AddScoped<PanelLayoutScope>();

//IdentityManagement
builder.Services.AddScoped<IIdentityService, IdentityService>();


//ProjectManagement
builder.Services.AddScoped<IProject, ProjectService>();
builder.Services.AddScoped<ISliderProject, SliderProjectService>();

//AskedQustionManagement
builder.Services.AddScoped<IQusetion, QusetionService>();

//CertificateManagement
builder.Services.AddScoped<ICertificate, CertificateService>();

//PodcastManagement
builder.Services.AddScoped<IPodcast, PodcastService>();


//ProjectManagement
builder.Services.AddScoped<INewsSite, NewsSiteService>();
builder.Services.AddScoped<ISliderNewsSite, SliderNewsSiteService>();
builder.Services.AddScoped<IVideoNewsSite, VideoNewsSiteService>();


//BlogManageMent
builder.Services.AddScoped<IArticleCategory, ArticleCategoryService>();
builder.Services.AddScoped<IArticle, ArticleService>();


//InformationManageMent
builder.Services.AddScoped<ISiteInfo, SiteInfoService>();
builder.Services.AddScoped<ISettings, SettingsService>();
builder.Services.AddScoped<IVisit, VisitService>();


//HeaderManageMent
builder.Services.AddScoped<ISlide, SlideService>();

//ChartManageMent
builder.Services.AddScoped<IchartPicture, ChartPictureService>();
builder.Services.AddScoped<IChartDesign, ChartDesignService>();


//RenderClientManageMent
builder.Services.AddScoped<IQueryClients, QueryClientsService>();

builder.Services.AddSignalR();



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
app.UseAuthentication();


app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
      name: "administration",
      pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
      name: "EN",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{controller=dashboard}/{action=Index}/{id?}"
    );


    endpoints.MapHub<VisitStatisticsHub>("/hubs/VisitStatistics");

});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
