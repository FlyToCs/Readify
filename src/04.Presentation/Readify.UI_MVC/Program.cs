using Microsoft.EntityFrameworkCore;
using Readify.Domain.BookAgg.Contracts.RepositoryContracts;
using Readify.Domain.BookAgg.Contracts.ServiceContracts;
using Readify.Domain.CategoryAgg.Contracts.RepositoryContracts;
using Readify.Domain.CategoryAgg.Contracts.ServiceContracts;
using Readify.Domain.FileAgg;
using Readify.Domain.UserAgg.Contracts.RepositoryContracts;
using Readify.Domain.UserAgg.Contracts.ServiceContracts;
using Readify.Infrastructure.Persistence;
using Readify.Infrastructure.Repository;
using Readify.Services;
using Readify.UI_MVC.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Data Source=.;Initial Catalog=ReadifyDb;User ID=sa; Password=123456;Trust Server Certificate=True"));

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IFileService, FileService>(); 
builder.Services.AddScoped<IBookImgService, BookImgService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookImgRepository, BookImgRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<RequestTimingMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
