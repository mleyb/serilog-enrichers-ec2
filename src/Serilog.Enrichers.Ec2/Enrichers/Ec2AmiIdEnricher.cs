using System;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Enrichers
{
	/// <summary>
	/// Enriches log events with an EC2AMIId property containing the current EC2 AMI Id.
	/// </summary>
	public class Ec2AmiIdEnricher : ILogEventEnricher
	{
		private LogEventProperty _cachedProperty;

		/// <summary>
		/// The property name added to enriched log events.
		/// </summary>
		public const string Ec2AmiIdPropertyName = "EC2AMIId";

		/// <summary>
		/// Enrich the log event.
		/// </summary>
		/// <param name="logEvent">The log event to enrich.</param>
		/// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
		public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
		{
			_cachedProperty = _cachedProperty ?? propertyFactory.CreateProperty(Ec2AmiIdPropertyName, Ec2InstanceMetadata.GetProperty("/ami-id"));

			logEvent.AddPropertyIfAbsent(_cachedProperty);
		}
	}
}
