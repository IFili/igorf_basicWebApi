using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igorf_basicWebApi.DataAccess
{
    public interface IRepository<T> //Generic parameter, placeholder type
    {
        void Create(T entity);

        void Update(T entity);

        List<T> GetAll();

        void Delete(int id);
    }
}
