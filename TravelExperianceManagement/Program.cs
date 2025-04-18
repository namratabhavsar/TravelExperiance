using Microsoft.EntityFrameworkCore;
using TravelExperianceManagement.Data;
using TravelExperianceManagement.Mappings;
using TravelExperianceManagement.Repositories;
using TravelExperianceManagement.Repositories.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TravelExperienceDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TravelExperienceConnectionString")));
builder.Services.AddScoped<ITripRepository, SQLTripRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
