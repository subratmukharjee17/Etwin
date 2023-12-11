using Etwin.DAL.Authentication;
using Etwin.DAL.DataRepository;
using Etwin.Helper.MailHelper;
using Etwin.Helper.Settings;
//using Etwin.Model;
using Etwin.DAL.Models;
using Etwin.Model.Context;
using EtwLogin.Settings;
using Microsoft.EntityFrameworkCore;
using MailSettings = Etwin.Helper.Settings.MailSettings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
});
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


builder.Services.AddDbContext<ETwinContext>(DbContextOptions =>
    DbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("MbkDbConstr")));
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Etwin.BAL.Services.AuthenticationService>();
builder.Services.AddScoped<ILoginAuthentication, LoginAuthentication>();
builder.Services.AddScoped<IGenericRepository<Operator>, GenericRepository<Operator>>();
builder.Services.AddScoped<IEmailService, EmailService>();



// Add services to the container.
builder.Services
    .AddRazorPages()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
