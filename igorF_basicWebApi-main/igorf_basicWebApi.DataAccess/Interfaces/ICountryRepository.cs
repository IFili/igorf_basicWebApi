using igorf_basicWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igorf_basicWebApi.DataAccess.Interfaces
{
    public interface ICountryRepository: IRepository<Country> 
    {
		Dictionary<string, int> GetCompanyStatisticsByCountryId(int countryId);
	}

}
