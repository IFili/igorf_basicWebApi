using igorf_basicWebApi.DataAccess.Interfaces;
using igorf_basicWebApi.Domain;
using igorf_basicWebApi.Domain.Models;
using igorF_basicWebApi.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igorf_basicWebApi.DataAccess.Repositories
{
	public class ContactRepository : IContactRepository
	{
		private readonly BasicWebApiDatabaseContext _webApiDbContext;

		public ContactRepository(BasicWebApiDatabaseContext webApiDbContext)
		{
			_webApiDbContext = webApiDbContext;
		}

		public void Create(Contact entity)
		{
			_webApiDbContext.Add(entity);
			_webApiDbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			Contact contact = _webApiDbContext.Contact.FirstOrDefault(contact => contact.ContactId.Equals(id));
			_webApiDbContext.Remove(contact);
			_webApiDbContext.SaveChanges();
		}

		public List<ViewModelContact> FilterContacts(int countryId, int companyId)
		{
			var contacts = _webApiDbContext.Contact
				.Include(x => x.Country)
				.Include(x => x.Company)
				.Include(x => x.CountryId == countryId || x.CompanyId == companyId)
				.ToList();

			return ContactMapper.ToViewModelContactList(contacts);
		}

		public List<Contact> GetAll()
		{
			return _webApiDbContext.Contact.ToList();
		}



		public List<ViewModelContact> GetContactsWithCompanyAndCountry()
		{
			var contacts = _webApiDbContext.Contact
				.Include(x => x.Country)
				.Include(x => x.Company)
				.ToList();

				return ContactMapper.ToViewModelContactList(contacts);
		}

		public void Update(Contact entity)
		{
			_webApiDbContext.Contact.Update(entity);
			_webApiDbContext.SaveChanges();
		}

		List<ViewModelContact> IContactRepository.GetAllContacts()
		{
			var contacts = _webApiDbContext.Contact
				.Include(x => x.Country)
				.Include(x => x.Company)
				.ToList();
			return ContactMapper.ToViewModelContactList(contacts);
		}



		//public List<Contact> GetContactsWithCompanyAndCountry()
		//{
		//	_webApiDbContext
		//}
	}
}
