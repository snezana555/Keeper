using Keeper.Library.Dto;
using Keeper.Library.Services;
using Keeper.Library.Validators;
using Keeper.Library;
using Keeper.WebApi;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FluentValidation;

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


await builder.Build().RunAsync();
