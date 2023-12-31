﻿using eHealthClinic.Core.Event.Implementation.Kafka;
using eHealthClinic.Core.Event.Interface;
using Microsoft.EntityFrameworkCore;
using eHealthClinic.Monitoring.JaegerTracingExtensions;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using eHealthClinic.Monitoring.ElasticsearchExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
builder.Services.AddSingleton<IEventProducer>(new KafkaProducer("localhost:9092"));
builder.Services.AddDbContext<eHealthClinic.Patient.Service.Data.PatientDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddJaegerTracing(builder.Configuration);
builder.Host.ConfigureLogging();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
});
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MinRequestBodyDataRate = null;

    options.ListenAnyIP(40001,
          listenOptions => { listenOptions.Protocols = HttpProtocols.Http1; });

    options.ListenAnyIP(40002,
       listenOptions => { listenOptions.Protocols = HttpProtocols.Http2; });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors();
app.UseSerilogRequestLogging();
app.Run();

