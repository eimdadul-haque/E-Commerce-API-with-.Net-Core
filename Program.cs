using OnlineShop_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionStrings");
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(connectionString));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod(); 
        builder.AllowAnyHeader();
    });
});


// Configure the HTTP request pipeline.
var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Images")),
    RequestPath = "/Images"
});
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
