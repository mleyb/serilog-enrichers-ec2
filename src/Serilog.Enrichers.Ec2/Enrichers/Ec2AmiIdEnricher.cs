using System;
using Serilog.Core;
using Serilog.Events;
using System.Net.Http;

namespace Serilog.Enrichers
{
	/// <summary>
	/// Enriches log events with an EC2-AMI-ID property containing the current EC2 AMI Id.
	/// </summary>
	public class Ec2AmiIdEnricher : ILogEventEnricher
	{
		private const string Ec2InstanceIdPropertyName = "EC2-AMI-ID";

		private LogEventProperty _cachedProperty;

		private string _ec2AmiId;

		/// <summary>
		/// Enrich the log event.
		/// </summary>
		/// <param name="logEvent">The log event to enrich.</param>
		/// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
		public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
		{
			if (_ec2AmiId == null)
			{
				_ec2AmiId = Ec2InstanceMetadata.GetProperty("/ami-id");
			}

			_cachedProperty = _cachedProperty ?? propertyFactory.CreateProperty(Ec2InstanceIdPropertyName, _ec2AmiId);

			logEvent.AddPropertyIfAbsent(_cachedProperty);
		}
	}
}
