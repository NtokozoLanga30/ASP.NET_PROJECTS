using LangaN_Assign1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddDbContext<EntityDbContext>(options => options
        .UseSqlServer(builder.Configuration
        .GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<IdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>();


var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
SeedData.EnsurePopulated(app);
SeedDataIdentity.EnsurePopulated(app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Event}/{action=Index}/{id?}/{slug?}");

app.Run();