using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));



builder.Services.AddSession();

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
//app.UseMiddleware<RequestTimingMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();

app.CustomExceptionHandlingMiddleware();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
