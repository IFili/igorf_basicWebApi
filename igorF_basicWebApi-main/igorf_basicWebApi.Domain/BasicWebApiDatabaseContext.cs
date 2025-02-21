using igorf_basicWebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace igorf_basicWebApi.Domain
{
	public class BasicWebApiDatabaseContext : DbContext
	{
		public BasicWebApiDatabaseContext(DbContextOptions<BasicWebApiDatabaseContext> options) : base(options) { }

		public DbSet<Company> Company { get; set; }

		public DbSet<Contact> Contact { get; set; }

		public DbSet<Country> Country { get; set; }

	}
}
