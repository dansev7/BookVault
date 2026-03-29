using BookVaultApi.Data;
using BookVaultApi.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// --- SERVICE REGISTRATION (The DI Container) ---
builder.Services.AddControllers(); // Registers your "Police Officers"
builder.Services.AddOpenApi();
builder.Services.AddValidation();


// Add AutoMapper registration
builder.Services.AddAutoMapper(cfg => {}, typeof(Program));

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// --- MIDDLEWARE PIPELINE (The "Express.use" section) ---
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); 
}

app.UseHttpsRedirection();
app.UseAuthorization(); 

app.MapControllers(); 

app.Run();