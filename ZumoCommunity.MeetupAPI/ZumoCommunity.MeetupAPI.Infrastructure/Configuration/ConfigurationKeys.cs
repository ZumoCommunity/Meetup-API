using System;

namespace ZumoCommunity.MeetupAPI.Infrastructure.Configuration
{
	public enum ConfigurationKeys
	{
		Database,
		MasterApiKey
	}

	public static class ConfigurationKeysExtensions
	{
		public static string ToKeyString(this ConfigurationKeys en)
		{
			switch (en)
			{
				case ConfigurationKeys.Database:
					return "Database";
				case ConfigurationKeys.MasterApiKey:
					return "MasterApiKey";
				default:
					throw new NotImplementedException();
			}
		}
	}
}
