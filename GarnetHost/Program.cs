using NetLah.GarnetHost;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService(_ => new Worker(args));

builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "Microsoft Garnet Server";
});

var host = builder.Build();
host.Run();
