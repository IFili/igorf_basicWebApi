using igorf_basicWebApi.DataAccess.Interfaces;
using igorf_basicWebApi.Domain.Models;
using igorf_basicWebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igorf_basicWebApi.Services.Implementations
{
	public class CountryService : ICountryService
	{
		ICountryRepository _countryRepository;

		public CountryService(ICountryRepository countryRepository)
		{
			_countryRepository = countryRepository;
		}

		public void Create(Country entity)
		{
			_countryRepository.Create(entity);
		}

		public void Delete(int id)
		{
			_countryRepository.Delete(id);
		}

		public List<Country> GetAll()
		{
			return _countryRepository.GetAll();
		}

		public Dictionary<string, int> GetCompanyStatisticsByCountryId(int countryId)
		{
			return _countryRepository.GetCompanyStatisticsByCountryId(countryId);
		}

		public void Update(Country entity)
		{
			_countryRepository.Update(entity);
		}
	}
}
