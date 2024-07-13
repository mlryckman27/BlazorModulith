using MainShell;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CoreLibrary.Services;
using FeatureModule.TodoApp.Services;
using FeatureModule.TodoApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<LoggingService>();

builder.Services.AddHttpClient<TodoItemService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddScoped<ExampleJsInteropFeatureModule>();

builder.Services.AddHttpClient<LoggingService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

await builder.Build().RunAsync();
