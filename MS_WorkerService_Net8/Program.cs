using MS_WorkerService_Net8;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;

var builder = Host.CreateApplicationBuilder(args);

//builder.Services.AddHostedService<WindowsBackgroundService>();
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = ".NET Joke Service";
});

LoggerProviderOptions.RegisterProviderOptions<
    EventLogSettings, EventLogLoggerProvider>(builder.Services);

builder.Services.AddSingleton<JokeService>();
builder.Services.AddHostedService<WindowsBackgroundService>();

var host = builder.Build();
host.Run();
