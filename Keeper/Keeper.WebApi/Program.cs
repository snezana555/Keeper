using Keeper.Library.Dto;
using Keeper.Library.Services;
using Keeper.Library.Validators;
using Keeper.WebApi;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Keeper.Api.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IValidator<VisitorCreationDto>, VisitorValidator>();
builder.Services.AddScoped<IValidator<RequestCreationDto>, RequestCreationDtoValidator>();
builder.Services.AddScoped<IVisitorService, VisitorService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();


IServiceCollection serviceCollection = builder.Services.AddDbContext<BdKeeperContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("dbKeeperConnectionString"))
);

await builder.Build().RunAsync();
