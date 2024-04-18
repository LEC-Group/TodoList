using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoList.WebApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient();
builder.Services.AddScoped<HttpService, HttpService>();

await builder.Build().RunAsync();