using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace igorf_basicWebApi.Domain.Models
{
	public class Contact
	{
		public int ContactId { get; set; }

		public string ContactName { get; set; }

		public int? CompanyId { get; set; } // A contact may not be associated with a company, that's why it's nullable.

		public int? CountryId { get; set; } // A contact may not be associated with a country, that's why it's nullable.

		[ForeignKey("CompanyId")]
		public Company Company { get; set; } // Defines the navigation property for the Company relationship

		[ForeignKey("CountryId")]
		public Country Country { get; set; } // Defines the navigation property for the Country relationship
	}
}
