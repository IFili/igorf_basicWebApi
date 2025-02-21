using igorf_basicWebApi.Domain;
using igorf_basicWebApi.Domain.Models;
using igorf_basicWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace igorf_basicWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private  IContactService _contactService;
		private readonly ILogger<ContactController> _logger;

		public ContactController(IContactService contactService, ILogger<ContactController> logger)
		{
			_contactService = contactService;
			_logger = logger;
		}

		[HttpPost("create")]
		public IActionResult CreateContact(Contact contact)
		{
			try
			{
				_contactService.Create(contact);
				return StatusCode(StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Couldnt create contact");
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
		[HttpPut("update")]

		public IActionResult UpdateContact (Contact contact)
		{
			try
			{
				_contactService.Update(contact);
				return StatusCode(StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Couldnt update contact");
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpDelete("delete/{id}")]
		public ActionResult DeleteContact(int id)
		{
			try
			{
				_contactService.Delete(id);
				return StatusCode(StatusCodes.Status202Accepted);
			}
			catch (Exception ex)
			{

				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}

		}

		[HttpGet("getAll")]
		public IActionResult GetAllContacts()
		{
			try
			{
				List<ViewModelContact> contacts = _contactService.GetAllContacts();
				return StatusCode(StatusCodes.Status200OK, contacts);
			}
			catch (Exception ex)
			{

				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
		
		[HttpGet("filter/companyOrCountry")]
		public IActionResult FilterContacts(int countryId, int companyId)
		{

			List<ViewModelContact> filteredContacts = _contactService.FilterContacts(countryId, companyId);
			if (filteredContacts == null)
			{
				return StatusCode(StatusCodes.Status404NotFound);
			}
			return StatusCode(StatusCodes.Status200OK, filteredContacts);
		}


		[HttpGet("filter/companyAndCountry")]
		public IActionResult FilterContactsCompanyAndCountry()
		{

			List<ViewModelContact> filteredContacts = _contactService.GetContactsWithCompanyAndCountry();
			if (filteredContacts == null)
			{
				return StatusCode(StatusCodes.Status404NotFound);
			}
			return StatusCode(StatusCodes.Status200OK, filteredContacts);
		}

	}
}
