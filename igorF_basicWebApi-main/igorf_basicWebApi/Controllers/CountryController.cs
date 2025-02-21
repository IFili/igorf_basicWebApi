using igorf_basicWebApi.Domain.Models;
using igorf_basicWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace igorf_basicWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CountryController : ControllerBase
	{
		private ICountryService _countryService;
		private readonly ILogger<ContactController> _logger;

		public CountryController(ICountryService countryService, ILogger<ContactController> logger)
		{
			_countryService = countryService;
			_logger = logger;
		}

		[HttpPost("create")]
		public IActionResult CreateCountry(Country country)
		{
			try
			{
				_countryService.Create(country);
				return StatusCode(StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{
				//LOG EX
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpGet("getAll")]
		public IActionResult GetCountries()
		{
			try
			{
				var allCountries = _countryService.GetAll();
				return StatusCode(StatusCodes.Status200OK, allCountries);
			}
			catch (Exception ex)
			{
				//LOG EX
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpDelete("delete/{id}")]
		public IActionResult DeleteCountry(int id)
		{
			try
			{
				_countryService.Delete(id);
				return StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				//LOG EX
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpPut("update")]
		public IActionResult UpdateCountry(Country country)
		{
			try
			{
				_countryService.Update(country);
				return StatusCode(StatusCodes.Status200OK);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpGet("company-statistics/{countryId}")]
		public IActionResult GetCompanyStatistics(int countryId)
		{
			try
			{
				var stats = _countryService.GetCompanyStatisticsByCountryId(countryId);
				return Ok(stats);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error fetching company statistics for countryId: {CountryId}", countryId);
				return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred.");
			}
		}

	}
}
