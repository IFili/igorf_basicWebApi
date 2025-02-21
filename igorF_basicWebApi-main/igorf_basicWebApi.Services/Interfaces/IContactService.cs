using igorf_basicWebApi.Domain;
using igorf_basicWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igorf_basicWebApi.Services.Interfaces
{
    public interface IContactService
    {
        void Create(Contact entity);

        void Update(Contact entity);

        List<ViewModelContact> GetAllContacts();

        void Delete(int id);

        List<ViewModelContact> GetContactsWithCompanyAndCountry();

        List<ViewModelContact> FilterContacts(int countryId, int companyId);
    }
}
