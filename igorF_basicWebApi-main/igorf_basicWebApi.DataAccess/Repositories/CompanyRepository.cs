using igorf_basicWebApi.DataAccess.Interfaces;
using igorf_basicWebApi.Domain;
using igorf_basicWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igorf_basicWebApi.DataAccess.Repositories
{
   public class CompanyRepository : ICompanyRepository
    {
        private readonly BasicWebApiDatabaseContext  _webApiDbContext;

        public CompanyRepository(BasicWebApiDatabaseContext  webApiDbContext)
        {
            _webApiDbContext = webApiDbContext;
        }

        public void Create (Company entity) //insers a company record into a database
        {
            _webApiDbContext.Company.Add(entity);
            _webApiDbContext.SaveChanges();
        }

        public void Update (Company entity)
        {
            _webApiDbContext.Company.Update(entity);
            _webApiDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Company company = _webApiDbContext.Company.FirstOrDefault(c => c.CompanyId.Equals(id)); //No time, would implement a ThrowIfNull generic extension
            _webApiDbContext.Company.Remove(company);
            _webApiDbContext.SaveChanges();
        }

        public List<Company> GetAll()
        {
            return _webApiDbContext.Company.ToList();
        }
    }
}
