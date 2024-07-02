using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TackManagementModle.Data;
using TackManagementModle.Entities;
using TackManagementModle.Repository;
using ToDoList.Web.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContexts>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    , x => x.MigrationsAssembly("TackManagement")
    ));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContexts>();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();


//builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContexts>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));


builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Tasks}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
