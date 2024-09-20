using Microsoft.EntityFrameworkCore;
using pubs1.Models;
using pubs1.Services.Implementation;
using pubs1.Services.Interface;
using pubs1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PUBSContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStringDB")));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<ITitleService, TitleService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
