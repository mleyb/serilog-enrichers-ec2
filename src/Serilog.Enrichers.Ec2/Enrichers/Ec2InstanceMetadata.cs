using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Serilog.Enrichers
{
    internal static class Ec2InstanceMetadata
    {
		private const string MetadataUrlLatest = "http://169.254.169.254/latest/meta-data";

		public static string GetProperty(string path)
		{
			using (var client = new HttpClient())
			{
				return client
					.GetStringAsync(MetadataUrlLatest + path)
					.GetAwaiter()
					.GetResult();
			}
		}
	}
}
