using MediatR;
using GameStreamer.Hubs;
using GameStreamer.Infrastructure;
using GameStreamer.UI.Configuration;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.InstallServices(
    builder.Configuration,
    typeof(IServiceCollection).Assembly);

builder
    .Services
    .Scan(
        selector => selector
            .FromAssemblies(
                GameStreamer.Infrastructure.AssemblyReference.Assembly)
            .AddClasses(false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

services.AddInfrastructureLayer(builder.Configuration);

services.AddMediatR(GameStreamer.Application.AssemblyReference.Assembly);

services
    .AddControllers()
    .AddApplicationPart(GameStreamer.Presentation.AssemblyReference.Assembly);

services.AddCors(options =>
{
    options.AddDefaultPolicy(b =>
        b.SetIsOriginAllowed(_ => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(60);
});

WebApplication app = builder.Build();

var logger = app.Logger;
var lifetime = app.Lifetime;
var env = app.Environment;

new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
    .AddEnvironmentVariables()
    .Build();

lifetime.ApplicationStarted
    .Register(() =>
    logger
        .LogInformation(
        $"The application {env.ApplicationName} is started with Environment: {app.Environment.EnvironmentName}")
);

if (app.Environment.IsDevelopment())
{
    app.UseCors();

    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // In Production we have to use proxy server instead Asp.net Core redirection
    //app.UseExceptionHandler("/Error");
    //app.UseHsts();
}

app.MapHub<RoomsHub>("/lobbies");
app.MapHub<GameHub>("/game");

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();
app.Run();