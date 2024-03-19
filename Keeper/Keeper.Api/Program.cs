using FluentValidation;
using Keeper.Api;
using Keeper.Library.Dto;
using Keeper.Library.Services;
using Keeper.Library.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Globalization;
using Keeper.Api.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Keeper.Api", Version = "v1" });///////////
});
builder.Services.AddScoped<IValidator<VisitorCreationDto>, VisitorValidator>();
builder.Services.AddScoped<IValidator<RequestCreationDto>, RequestCreationDtoValidator>();
builder.Services.AddScoped<IVisitorService, VisitorService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

IServiceCollection serviceCollection = builder.Services.AddDbContext<BdKeeperContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("dbKeeperConnectionString"))
);
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); ///////////////
        c.RoutePrefix = string.Empty; // Делает Swagger UI страницей по умолчанию//////////////////
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
