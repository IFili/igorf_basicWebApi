using igorf_basicWebApi.Domain;
using igorf_basicWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igorf_basicWebApi.DataAccess.Interfaces
{
    public interface IContactRepository : IRepository<Contact> 
    {
		List<ViewModelContact> GetAllContacts();

		List<ViewModelContact> GetContactsWithCompanyAndCountry();

		List<ViewModelContact> FilterContacts(int countryId, int companyId);
	}



}
