using NetLah.GarnetHost;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddHostedService(_ => new Worker(args));

builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "Microsoft Garnet Server";
});

var host = builder.Build();
host.Run();
