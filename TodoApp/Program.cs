using TodoApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlite("Data Source=todo.db"));

// Add Swagger/OpenAPI services  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Version = "v1" });
});

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

// Enable Swagger middleware  
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                         // serve /swagger/v1/swagger.json
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApp API V1");
        c.RoutePrefix = "swagger";            // UI at /swagger
    });
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todos}/{action=Index}/{id?}");
app.Run();
