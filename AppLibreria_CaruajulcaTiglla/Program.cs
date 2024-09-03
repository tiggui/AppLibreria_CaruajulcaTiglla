using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppLibreria_CaruajulcaTiglla.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppLibreria_CaruajulcaTigllaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppLibreria_CaruajulcaTigllaContext") ?? throw new InvalidOperationException("Connection string 'AppLibreria_CaruajulcaTigllaContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppLibreria_CaruajulcaTigllaContext>();
    context.Database.EnsureCreated();    // crea la BD, si no existe.
    //DbInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
