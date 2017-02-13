using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using ZumoCommunity.MeetupAPI.Infrastructure.Configuration;

namespace ZumoCommunity.MeetupAPI.API.OData.Authentication
{
	public class HardcodedAuthentication : Attribute, IAuthenticationFilter
	{
		public bool AllowMultiple => false;
		protected AccessLevel AccessLevel { get; private set; }

		public HardcodedAuthentication(AccessLevel accessLevel)
		{
			AccessLevel = accessLevel;
		}

		public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
		{
			if (AccessLevel == AccessLevel.Anonymous)
			{
				return;
			}

			var request = context.Request;
			var queryParameters = request.RequestUri.ParseQueryString();
			var apiKey = queryParameters.Get("api_key");

			if (string.IsNullOrEmpty(apiKey))
			{
				context.ErrorResult = new AuthenticationFailureResult("Missing api key", request);
				return;
			}

			var masterKeyExpected = await Global.ConfigurationProvider.GetConfigValueAsync(ConfigurationKeys.MasterApiKey.ToKeyString());
			if (apiKey != masterKeyExpected)
			{
				context.ErrorResult = new AuthenticationFailureResult("Master authorization key is not valid", request);
				return;
			}

			context.Principal = new ClaimsPrincipal();
		}

		public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
		{
			var challenge = new AuthenticationHeaderValue("MasterApiKey");
			context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
		}
	}
}