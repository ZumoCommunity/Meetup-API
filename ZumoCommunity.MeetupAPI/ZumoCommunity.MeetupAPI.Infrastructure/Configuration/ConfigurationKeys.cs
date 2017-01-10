using System;

namespace ZumoCommunity.MeetupAPI.Infrastructure.Configuration
{
	public enum ConfigurationKeys
	{
		Database
	}

	public static class ConfigurationKeysExtensions
	{
		public static string ToKeyString(this ConfigurationKeys en)
		{
			switch (en)
			{
				case ConfigurationKeys.Database:
					return "Database";
				default:
					throw new NotImplementedException();
			}
		}
	}
}
