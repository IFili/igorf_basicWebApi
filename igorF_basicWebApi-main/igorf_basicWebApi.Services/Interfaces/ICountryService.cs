using igorf_basicWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igorf_basicWebApi.Services.Interfaces
{
    public interface ICountryService
    {
		void Create(Country entity);

		void Update(Country entity);

		List<Country> GetAll(); //Must have generic name, as it will call dataaccess

		void Delete(int id);

		Dictionary<string, int> GetCompanyStatisticsByCountryId(int countryId);


	}
}
