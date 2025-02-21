using igorf_basicWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igorf_basicWebApi.Services.Interfaces
{
    public interface ICompanyService
    {
        void Create(Company entity);

        void Update(Company entity);//Wondering between updating whole object or int & string

        List<Company> GetAll(); //Must have generic name, as it will call dataaccess

        void Delete(int id);

    }
}
