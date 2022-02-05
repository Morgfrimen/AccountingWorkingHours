using HostedService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Serilog;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseKestrel();
        webBuilder.ConfigureKestrel(option => option.ListenLocalhost(443, o => o.Protocols = HttpProtocols.Http2));
        webBuilder.UseStartup<Startup>();
    })
    .UseWindowsService(conf => conf.ServiceName = "HostedService")
    .ConfigureServices(services =>
    {
        services.AddTransient<TestConnection.TestConnectionBase, TestConnectionService>();
        services.AddGrpc();
    }).UseSerilog((hostingContext, _, loggerConfiguration) => loggerConfiguration.ReadFrom
        .Configuration(hostingContext.Configuration).Enrich.FromLogContext().WriteTo
        .File(Path.Combine(Environment.CurrentDirectory, "bin", "logs", "logs.log"), rollingInterval: RollingInterval.Day)).Build();

host.Run();

public class Startup
{
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints => { endpoints.MapGrpcService<TestConnectionService>(); });
    }
}