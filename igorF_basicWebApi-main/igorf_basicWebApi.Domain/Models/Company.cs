using System.ComponentModel.DataAnnotations;

namespace igorf_basicWebApi.Domain.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

    }
}
