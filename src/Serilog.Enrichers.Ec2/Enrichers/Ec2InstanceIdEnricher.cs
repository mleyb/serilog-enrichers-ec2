using System;
using Serilog.Core;
using Serilog.Events;
using System.Net.Http;

namespace Serilog.Enrichers
{
	/// <summary>
	/// Enriches log events with an Ec2InstanceId property containing the current EC2 instance Id.
	/// </summary>
	public class Ec2InstanceIdEnricher : ILogEventEnricher
	{
		private const string Ec2InstanceIdPropertyName = "Ec2InstanceId";

		private const string InstanceMetadataUrl = "http://169.254.169.254/latest/meta-data";

		private LogEventProperty _cachedProperty;

		private string _ec2InstanceId;

		/// <summary>
		/// Enrich the log event.
		/// </summary>
		/// <param name="logEvent">The log event to enrich.</param>
		/// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
		public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
		{
			if (_ec2InstanceId == null)
			{
				_ec2InstanceId = GetEc2InstanceId();
			}
			
			_cachedProperty = _cachedProperty ?? propertyFactory.CreateProperty(Ec2InstanceIdPropertyName, _ec2InstanceId);

			logEvent.AddPropertyIfAbsent(_cachedProperty);
		}

		private static string GetEc2InstanceId()
		{
			using (var client = new HttpClient())
			{
				return client
					.GetStringAsync(InstanceMetadataUrl + "/instance-id")
					.GetAwaiter()
					.GetResult();
			}
		}
	}
}
