using igorf_basicWebApi.Domain;
using igorf_basicWebApi.Domain.Models;
using System.Net;



namespace igorF_basicWebApi.Mappers
{
	public class ContactMapper
	{
		public static ViewModelContact ToViewModelContact (Contact contact)
		{
			ViewModelContact viewModelContact = new ViewModelContact()
			{
				ContactName = contact.ContactName,
				CompanyName = contact.Company.CompanyName,
				CountryName = contact.Country.CountryName
			};
			return viewModelContact;
		}

		public static List<ViewModelContact> ToViewModelContactList(List<Contact> contactList)
		{
			var viewModelContacts = new List<ViewModelContact>(contactList.Select(x => new ViewModelContact()
			{
				CompanyName = x.Company.CompanyName,
				ContactName = x.ContactName,
				CountryName = x.Country.CountryName
			})
				.ToList());

			return viewModelContacts;
		}
		
	}
}
