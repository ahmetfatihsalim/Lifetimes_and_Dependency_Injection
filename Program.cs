
using Lifetime_Examples.Service; 
using Lifetime_Examples.Interface;
using Microsoft.Extensions.DependencyInjection; // Used implicitly by WebApplication.CreateBuilder
using Microsoft.AspNetCore.Http;

// 1. BUILDER SETUP
var builder = WebApplication.CreateBuilder(args);

// 2. SERVICE REGISTRATION (Copied from your original Program.cs)
builder.Services.AddSingleton<ISingletonGuidService, SingletonGuidService>(); 
builder.Services.AddScoped<IScopedGuidService, ScopedGuidService>();
builder.Services.AddTransient<ITransientGuidService, TransientGuidService>();

var app = builder.Build();

// 3. MINIMAL ENDPOINT DEFINITION (Replaces HomeController.cs)
app.MapGet("/", (
    ISingletonGuidService singletonGuidService1,
    ISingletonGuidService singletonGuidService2,
    IScopedGuidService scopedGuidService1,
    IScopedGuidService scopedGuidService2,
    ITransientGuidService transientGuidService1,
    ITransientGuidService transientGuidService2) =>
{
    var messages = new System.Text.StringBuilder();

    messages.Append("<h1>.NET Core Dependency Injection Lifetimes Demo</h1><br>");

    // TRANSIENT LIFETIME: NEW instance every time it's requested.
    messages.Append("<h2>Transient: New instance on every request, and within the same request.</h2>");
    messages.Append($"Transient 1:  {transientGuidService1.GetGuid()}<br>");
    messages.Append($"Transient 2:  {transientGuidService2.GetGuid()}<br>");
    messages.Append("These two GUIDs are different.<br><br>");

    // SCOPED LIFETIME: SAME instance within one HTTP request, NEW instance for the next request (page refresh).
    messages.Append("<h2>Scoped: Same instance within the current HTTP request (scope), new instance on page reload.</h2>");
    messages.Append($"Scoped 1:  {scopedGuidService1.GetGuid()}<br>");
    messages.Append($"Scoped 2:  {scopedGuidService2.GetGuid()}<br>");
    messages.Append("These two GUIDs are the same. They will change when you refresh the page.<br><br>");

    // SINGLETON LIFETIME: SAME instance for the entire application lifetime.
    messages.Append("<h2>Singleton: Same instance for the entire application lifetime.</h2>");
    messages.Append($"Singleton 1:  {singletonGuidService1.GetGuid()}<br>");
    messages.Append($"Singleton 2:  {singletonGuidService2.GetGuid()}<br>");
    messages.Append("These two GUIDs are the same. They will only change if you restart the application.<br>");

    return Results.Content(messages.ToString(), "text/html");
});

app.Run();