
using Readify.Infa.Db.SqlServer.EfCore.DbContexts;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Readify.Domain.Core.Book.Data;
using Readify.Domain.Core.Book.Services;
using Readify.Domain.Core.Category.Data;
using Readify.Domain.Core.Category.Services;
using Readify.Domain.Core.File.Services;
using Readify.Domain.Core.User.AppServices;
using Readify.Domain.Core.User.Data;
using Readify.Domain.Services.Book;
using Readify.Domain.Services.Category;
using Readify.Domain.Services.File;
using Readify.Domain.Services.User;
using Readify.EndPoint.UI_MVC.CustomMiddlewares;
using Readify.Infa.Data.Repo.EfCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


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
