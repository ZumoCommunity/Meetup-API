﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using ZumoCommunity.MeetupAPI.API.OData.Authentication;
using ZumoCommunity.MeetupAPI.Data.Entity;

namespace ZumoCommunity.MeetupAPI.API.OData.Controllers.OData.v1
{
	public class RegistrationsController : _Controller<Registration>
	{
		[HardcodedAuthentication(AccessLevel.Master)]
		public override IQueryable<Registration> Get()
		{
			return base.Get();
		}

		[HardcodedAuthentication(AccessLevel.Master)]
		public override SingleResult<Registration> Get([FromODataUri]Guid key)
		{
			return base.Get(key);
		}

		[HardcodedAuthentication(AccessLevel.Master)]
		public override Task<IHttpActionResult> Put([FromODataUri]Guid key, Delta<Registration> patch)
		{
			return base.Put(key, patch);
		}

		[HardcodedAuthentication(AccessLevel.Anonymous)]
		public override Task<IHttpActionResult> Post([FromBody]Registration entity)
		{
			return base.Post(entity);
		}

		[HardcodedAuthentication(AccessLevel.Master)]
		public override Task<IHttpActionResult> Patch([FromODataUri]Guid key, Delta<Registration> patch)
		{
			return base.Patch(key, patch);
		}

		[HardcodedAuthentication(AccessLevel.Master)]
		public override Task<IHttpActionResult> Delete([FromODataUri]Guid key)
		{
			return base.Delete(key);
		}
	}
}