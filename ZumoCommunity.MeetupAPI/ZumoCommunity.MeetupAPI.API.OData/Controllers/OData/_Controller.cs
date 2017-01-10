using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using ZumoCommunity.MeetupAPI.API.OData.Helpers;
using ZumoCommunity.MeetupAPI.Data.Context;
using ZumoCommunity.MeetupAPI.Data.Entity;

namespace ZumoCommunity.MeetupAPI.API.OData.Controllers.OData
{
	public abstract class _Controller<T> : ODataController where T : _Data
	{
		private DataContext db;

		public _Controller()
		{
			var task = Factory.GetDataContextAsync();
			Task.Run(() => task);
			task.Wait();

			db = task.Result;
		}

		// GET: odata/<name>
		[EnableQuery]
		public IQueryable<T> Get()
		{
			return db.Set<T>();
		}

		// GET: odata/<name>(5)
		[EnableQuery]
		public SingleResult<T> Get([FromODataUri] Guid key)
		{
			return SingleResult.Create(db.Set<T>().Where(entity => entity.Id == key));
		}

		// PUT: odata/<name>(5)
		public async Task<IHttpActionResult> Put([FromODataUri] Guid key, Delta<T> patch)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var entity = await db.Set<T>().FindAsync(key);
			if (entity == null)
			{
				return NotFound();
			}

			patch.Put(entity);

			try
			{
				await db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await IsEntityExistsAsync(key))
				{
					throw;
				}
				else
				{
					return NotFound();
				}
			}

			return Updated(entity);
		}

		// POST: odata/<name>
		public async Task<IHttpActionResult> Post(T entity)
		{
			if (entity.Id == null || entity.Id == Guid.Empty)
			{
				entity.Id = Guid.NewGuid();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.Set<T>().Add(entity);

			try
			{
				await db.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (await IsEntityExistsAsync(entity.Id))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return Created(entity);
		}

		// PATCH: odata/<name>(5)
		[AcceptVerbs("PATCH", "MERGE")]
		public async Task<IHttpActionResult> Patch([FromODataUri] Guid key, Delta<T> patch)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var entity = await db.Set<T>().FindAsync(key);
			if (entity == null)
			{
				return NotFound();
			}

			patch.Patch(entity);

			try
			{
				await db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (await IsEntityExistsAsync(key))
				{
					throw;
				}
				else
				{
					return NotFound();
				}
			}

			return Updated(entity);
		}

		// DELETE: odata/<name>(5)
		public async Task<IHttpActionResult> Delete([FromODataUri] Guid key)
		{
			var entity = await db.Set<T>().FindAsync(key);
			if (entity == null)
			{
				return NotFound();
			}

			db.Set<T>().Remove(entity);
			await db.SaveChangesAsync();

			return StatusCode(HttpStatusCode.NoContent);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private async Task<bool> IsEntityExistsAsync(Guid key)
		{
			return await db.Set<T>().AnyAsync(e => e.Id == key);
		}
	}
}