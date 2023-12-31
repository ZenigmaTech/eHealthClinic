﻿using Integration.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using eHealthClinic.Monitoring.JaegerTracingExtensions;
using eHealthClinic.Monitoring.ElasticsearchExtensions;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
builder.Services.AddJaegerTracing(builder.Configuration);

// Add services to the container.
builder.Services.AddGrpc();
builder.Host.ConfigureLogging();
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MinRequestBodyDataRate = null;

    options.ListenAnyIP(50050,
          listenOptions => { listenOptions.Protocols = HttpProtocols.Http1; });

    options.ListenAnyIP(50051,
       listenOptions => { listenOptions.Protocols = HttpProtocols.Http2; });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<TimeSlotServiceImpl>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.UseSerilogRequestLogging();
app.Run();

