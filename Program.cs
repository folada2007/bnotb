using BooksNotBoobs.Data;
using BooksNotBoobs.Domain.Entities;
using BooksNotBoobs.Domain.Factory;
using BooksNotBoobs.Domain.Interfaces;
using BooksNotBoobs.Domain.Services;
using BooksNotBoobs.Factory;
using BooksNotBoobs.Interfaces;
using BooksNotBoobs.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<IUpdateFactory, UpdateFactory>();
builder.Services.AddScoped<IShelfFactory, ShelfFactory>();
builder.Services.AddScoped<IUserFactory, UserFactory>();
builder.Services.AddScoped<IUSerRepository, UserRepository>();
builder.Services.AddScoped<IUrlImgService, UrlImgService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IBookFactory, BookFactory>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options => 
{
    options.LoginPath = "/Login/Index";
    options.LogoutPath = "/Login/LogOut";
    options.Cookie.Name = "UserAuthenticated";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.SlidingExpiration = true;
});
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );



app.Run();
