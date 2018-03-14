using System;
using Serilog.Configuration;
using Serilog.Enrichers;

namespace Serilog
{
    /// <summary>
    /// Extends <see cref="LoggerConfiguration"/> to add enrichers for AWS EC2.
    /// </summary>
    public static class Ec2LoggerConfigurationExtensions
    {
		/// <summary>
		/// Enrich log events with an Ec2InstanceId property containing the current EC2 instance Id.
		/// </summary>
		/// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
		/// <returns>Configuration object allowing method chaining.</returns>
		public static LoggerConfiguration WithEc2InstanceId(
           this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null)
				throw new ArgumentNullException(nameof(enrichmentConfiguration));

            return enrichmentConfiguration.With<Ec2InstanceIdEnricher>();
        }
    }
}