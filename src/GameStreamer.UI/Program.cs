using Serilog;
using GameStreamer.Infrastructure;
using GameStreamer.UI.Configuration;
using MediatR;

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
    .AddSwaggerGen()
    .AddEndpointsApiExplorer();

services
    .AddControllers()
    .AddApplicationPart(GameStreamer.Presentation.AssemblyReference.Assembly);

//builder.Host.UseSerilog((context, configuration) =>
//    configuration.ReadFrom.Configuration(context.Configuration));

WebApplication app = builder.Build();

var logger = app.Logger;
var lifetime = app.Lifetime;
var env = app.Environment;

var configuration = new ConfigurationBuilder()
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

    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(corsPolicyBuilder => corsPolicyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

//app.MapHub<RoomsHub>("/lobbies");

//app.MapHub<GameHub>("/game");

//InitializeDatabase(app);

//app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

//app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();

app.Run();