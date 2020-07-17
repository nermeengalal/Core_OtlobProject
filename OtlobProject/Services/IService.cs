using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.Services
{
    public interface IService<T>
    {
        List<T> GetAll();
        int Add(T Model);
        T GetDetails(int id);
        int Update(int id, T Model);
        int Delete(int id);
    }
}
