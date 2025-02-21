using igorf_basicWebApi.Domain.Models;
using igorf_basicWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace igorf_basicWebApi.Controllers
{
	[Route("api/controller")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private ICompanyService _companyService;

		private readonly ILogger<CompanyController> _logger;

		public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
		{
			_companyService = companyService;
			_logger = logger;
		}

		[HttpPost("create")]
		public IActionResult CreateCompany(Company company)
		{
			try
			{
				_companyService.Create(company);
				return StatusCode(StatusCodes.Status201Created);
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, $"Error while creating company with name {company.CompanyName} & id {company.CompanyId}");
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
		[HttpGet("getAll")]
		public IActionResult GetCompanies()
		{
			try
			{
				var allCompanies = _companyService.GetAll();
				return StatusCode(StatusCodes.Status200OK, allCompanies);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while getting companies");
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCompany(int id)
		{
			try
			{
				_companyService.Delete(id);
				return StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error while deleting company with id{id}");
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
		[HttpPut]
		public IActionResult UpdateCompany(Company company)
		{
			try
			{
				_companyService.Update(company);
				return StatusCode(StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Couldnt update company {company.CompanyName} with id {company.CompanyId}");
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

	}
}
