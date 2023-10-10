using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace eHealthClinic.Monitoring.JaegerTracingExtensions
{
    public static class OpenTelemetryExtensions
    {
        public static IServiceCollection AddJaegerTracing(this IServiceCollection services, IConfiguration configuration)
        {
            var jaegerConfig = configuration.GetSection("Jaeger");

            services.AddOpenTelemetry()
                    .WithTracing(builder => builder
                        .AddAspNetCoreInstrumentation()
                        .AddJaegerExporter(
                            o =>
                            {
                                o.AgentHost = jaegerConfig["JAEGER_AGENT_HOST"];
                                o.AgentPort = int.Parse(jaegerConfig["JAEGER_AGENT_PORT"] ?? "6831");
                            })
                        .AddGrpcClientInstrumentation(o => o.SuppressDownstreamInstrumentation = true)
                        .AddHttpClientInstrumentation()
                        .AddEntityFrameworkCoreInstrumentation()
                        .AddSource(jaegerConfig["JAEGER_SERVICE_NAME"] ?? Assembly.GetExecutingAssembly().FullName)
                        .SetResourceBuilder(ResourceBuilder.CreateDefault()
                            .AddService(serviceName: jaegerConfig["JAEGER_SERVICE_NAME"] ?? Assembly.GetExecutingAssembly().FullName)
                        )
    );

            return services;
        }
    }
}
