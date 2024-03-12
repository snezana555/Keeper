using Keeper.Data;
using Keeper.WebService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Keeper.Data.KeeperDbContext>(options => options.UseSqlServer(connection));

await builder.Build().RunAsync();
