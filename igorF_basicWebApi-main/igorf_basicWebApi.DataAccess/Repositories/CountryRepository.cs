using igorf_basicWebApi.DataAccess.Interfaces;
using igorf_basicWebApi.Domain;
using igorf_basicWebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igorf_basicWebApi.DataAccess.Repositories
{
	public class CountryRepository : ICountryRepository
    {
		private readonly BasicWebApiDatabaseContext _webApiDbContext;

		public CountryRepository(BasicWebApiDatabaseContext webApiDbContext)
		{
			_webApiDbContext = webApiDbContext;
		}

		public void Create(Country entity)
		{
			_webApiDbContext.Country.Add(entity);
			_webApiDbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var country = _webApiDbContext.Country.FirstOrDefault(c => c.CountryId.Equals(id)); //Implement ThrowIfNull generic extension
			_webApiDbContext.Country.Remove(country);
			_webApiDbContext.SaveChanges();
		}

		public List<Country> GetAll()
		{
			return _webApiDbContext.Country.ToList();
		}

		public Dictionary<string, int> GetCompanyStatisticsByCountryId(int countryId)
		{
			return _webApiDbContext.Contact //Query contacts
				 .Where(contact => contact.CountryId == countryId) // Filter by country id
				 .GroupBy(contact => contact.Company.CompanyName) // Group by Company Name
				 .Select(group => new
				 {
					CompanyName = group.Key,
					ContactCount = group.Count()
				 })
				 .ToDictionary(x => x.CompanyName, x => x.ContactCount);
		}
		
		

		public void Update(Country entity)
		{
			_webApiDbContext.Country.Update(entity);
			_webApiDbContext.SaveChanges();
		}
	}
}
