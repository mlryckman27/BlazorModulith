using BlazorModulith.MainShell;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorModulith.CoreLibrary.Services;
using FeatureModule.TodoApp.Services;
using FeatureModule.TodoApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<ILoggingService, LoggingService>();
builder.Services.AddScoped<ExampleJsInteropFeatureModule>();
builder.Services.AddHttpClient<TodoItemService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

await builder.Build().RunAsync();
