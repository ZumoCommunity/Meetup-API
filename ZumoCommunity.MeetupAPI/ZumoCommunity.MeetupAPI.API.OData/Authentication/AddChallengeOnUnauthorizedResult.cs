﻿using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ZumoCommunity.MeetupAPI.API.OData.Authentication
{
	public class AddChallengeOnUnauthorizedResult : IHttpActionResult
	{
		public AddChallengeOnUnauthorizedResult(AuthenticationHeaderValue challenge, IHttpActionResult innerResult)
		{
			Challenge = challenge;
			InnerResult = innerResult;
		}

		public AuthenticationHeaderValue Challenge { get; private set; }

		public IHttpActionResult InnerResult { get; private set; }

		public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
		{
			var response = await InnerResult.ExecuteAsync(cancellationToken);

			if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				if (!response.Headers.WwwAuthenticate.Any((h) => h.Scheme == Challenge.Scheme))
				{
					response.Headers.WwwAuthenticate.Add(Challenge);
				}
			}

			return response;
		}
	}
}