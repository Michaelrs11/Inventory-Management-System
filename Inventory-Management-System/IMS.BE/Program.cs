using IMS.BE.Commons.Constants;
using IMS.BE.Commons.Services;
using IMS.BE.Services;
using IMS.BE.Services.Masters;
using IMS.BE.Services.Transactions;
using IMS.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddMvc().AddRazorPagesOptions(options => options.Conventions.AddPageRoute("/Auth/login", ""));

var conf = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: false)
               .Build();


builder.Services.AddAuthentication(Clients.WebApp)
               .AddCookie(Clients.WebApp, options =>
               {
                   options.LoginPath = "/Auth/login";
                   options.ExpireTimeSpan = TimeSpan.FromHours(1);
               });

//Configure SQL Server
builder.Services.AddEntityFrameworkSqlServer();
builder.Services.AddDbContextPool<IMSDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IMS"));
});

//Register Service
builder.Services.AddTransient<RegisterService>();
builder.Services.AddTransient<LoginService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<UserIdentityService>();
builder.Services.AddTransient<BarangService>();
builder.Services.AddTransient<GudangService>();
builder.Services.AddTransient<CategoryService>();
builder.Services.AddTransient<InOutBoundService>();
builder.Services.AddTransient<DropdownService>();
builder.Services.AddTransient<RekapTransactionService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
