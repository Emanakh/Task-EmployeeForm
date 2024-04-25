using Microsoft.EntityFrameworkCore;
using Task_EmployeeForm.Configuration;
using Task_EmployeeForm.Data;
using Task_EmployeeForm.Models;
using Task_EmployeeForm.Models.DTOs;
using Task_EmployeeForm.Repositories;
using Task_EmployeeForm.Repositories.IRepositories;
using Task_EmployeeForm.Services;
using Task_EmployeeForm.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<IGenericRepo<Employee>, GenericRepo<Employee>>();

builder.Services.AddScoped<APIResponse>();
builder.Services.AddAutoMapper(typeof(MappingConfig));



builder.Services.AddControllers()
     .ConfigureApiBehaviorOptions(options =>
     {
        
         options.SuppressModelStateInvalidFilter = true;
        
     });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
