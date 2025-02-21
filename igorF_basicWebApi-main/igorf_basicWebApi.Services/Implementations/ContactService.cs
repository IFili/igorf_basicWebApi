using igorf_basicWebApi.DataAccess.Interfaces;
using igorf_basicWebApi.Domain;
using igorf_basicWebApi.Domain.Models;
using igorf_basicWebApi.Services.Interfaces;

namespace igorf_basicWebApi.Services.Implementations
{
	public class ContactService : IContactService
	{
		private IContactRepository _contactRepository;
		public ContactService(IContactRepository contactRepository)
		{
			_contactRepository = contactRepository;
		}
		public void Create(Contact entity)
		{
			_contactRepository.Create(entity);	
		}

		public void Delete(int id)
		{
			_contactRepository.Delete(id);
		}

		public List<ViewModelContact> FilterContacts(int countryId, int companyId)
		{
		    var viewModelContacts = _contactRepository.FilterContacts(countryId, companyId);
			return viewModelContacts;
		}

		public List<ViewModelContact> GetAllContacts()
		{
			var allContacts = _contactRepository.GetAllContacts();
			return allContacts;
		}

		public List<ViewModelContact> GetContactsWithCompanyAndCountry()
		{
			var vmCountryAndCompany = _contactRepository.GetContactsWithCompanyAndCountry();
			return vmCountryAndCompany;
		}

		public void Update(Contact entity)
		{
			_contactRepository.Update(entity);
		}
	}
}
