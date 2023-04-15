using MedicalTech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "Server=DESKTOP-9HO92VC\\SQLEXPRESS;Database=labmedicinebd;Trusted_Connection=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<MedicalTechContext>(o => o.UseSqlServer(connectionString));
 void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMedicalTechInitializer initializer)
{

    initializer.Seed();
}
void ConfigureServices(IServiceCollection services)
{
    

    services.AddScoped<IMedicalTechInitializer, MedicalTechInitializer>();

    
}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
