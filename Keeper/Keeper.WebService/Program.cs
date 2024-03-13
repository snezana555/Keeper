using Keeper.Data;
using Keeper.WebService;
using KeeperLibrary.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using FluentValidation;
using Keeper.WebService.Validators;
using Keeper.WebService.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
////
builder.Services.AddScoped<IValidator<Visitor>, VisitorValidator>();
builder.Services.AddScoped<IValidator<Request>, RequestValidator>();
builder.Services.AddScoped<IVisitorService, VisitorService>();
builder.Services.AddScoped<IRequestService, RequestService>();

builder.Services.AddDbContext<KeeperDbContext>(options => options.UseSqlServer("Host=localhost;Database=DefaultConnection;Username=admin;Password=admin"));
////
await builder.Build().RunAsync();
