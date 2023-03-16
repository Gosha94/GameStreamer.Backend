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

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors();

//app.MapHub<RoomsHub>("/lobbies");

//app.MapHub<GameHub>("/game");

//var logger = app.Logger;
//var lifetime = app.Lifetime;
//var env = app.Environment;

//lifetime.ApplicationStarted.Register(() =>
//    logger.LogInformation(
//        $"The application {env.ApplicationName} is started.")
//);

//app.Logger.LogInformation("GameStreamer is Running!");

//InitializeDatabase(app);

//app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

//app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();

app.Run();