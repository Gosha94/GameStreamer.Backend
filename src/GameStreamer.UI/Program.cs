using Serilog;
using GameStreamer.UI.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServices(
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

//builder.Host.UseSerilog((context, configuration) =>
//    configuration.ReadFrom.Configuration(context.Configuration));

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
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

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

//app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();

app.Run();

//void ConfigureGameStreamerHost(HostBuilderContext builderContext, ContainerBuilder containerBuilder)
//{

//    #region Persistence Setup

//    containerBuilder.Register(context =>
//                    new DbContextOptionsBuilder<GameStreamerContext>()
//                        .UseNpgsql("Host=localhost;Database=123")
//                        .Options)
//                .As<DbContextOptions<GameStreamerContext>>().SingleInstance();

//    containerBuilder.RegisterType<GameStreamerContext>().InstancePerDependency();

//    #endregion

//}

void InitializeDatabase(IApplicationBuilder application)
{
    //using (var scope = application.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
    //{
    //    scope.ServiceProvider.GetRequiredService<GameStreamerContext>().Database.Migrate();
    //}
}