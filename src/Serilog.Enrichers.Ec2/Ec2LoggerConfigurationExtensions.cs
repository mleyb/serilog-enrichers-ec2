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
		/// Enrich log events with an EC2-INSTANCE-ID property containing the current EC2 instance Id.
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

		/// <summary>
		/// Enrich log events with an EC2-AMI-ID property containing the current EC2 AMI Id.
		/// </summary>
		/// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
		/// <returns>Configuration object allowing method chaining.</returns>
		public static LoggerConfiguration WithEc2AmiId(
		   this LoggerEnrichmentConfiguration enrichmentConfiguration)
		{
			if (enrichmentConfiguration == null)
				throw new ArgumentNullException(nameof(enrichmentConfiguration));

			return enrichmentConfiguration.With<Ec2AmiIdEnricher>();
		}
	}
}