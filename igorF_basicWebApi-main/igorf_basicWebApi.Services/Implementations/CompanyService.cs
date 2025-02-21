using igorf_basicWebApi.DataAccess.Interfaces;
using igorf_basicWebApi.Domain.Models;
using igorf_basicWebApi.Services.Interfaces;

namespace igorf_basicWebApi.Services.Implementations
{
	public class CompanyService : ICompanyService
    {
		//Declare Data Access repo
		ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
			_companyRepository = companyRepository;
        }

		public void Create(Company entity)
		{
			_companyRepository.Create(entity);
			
		}

		public void Delete(int id)
		{
			_companyRepository.Delete(id);
		}

		public List<Company> GetAll()
		{
			return _companyRepository.GetAll();
		}

		public void Update(Company entity)
		{
			_companyRepository.Update(entity);
		}
	}
}
