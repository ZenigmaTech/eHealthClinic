using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace eHealthClinic.Monitoring.ElasticsearchExtensions
{
    public static class LoggingExtensions
    {
        public static IHostBuilder ConfigureLogging(this IHostBuilder host)
        {
            host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
            return host;

        }


    }


}
