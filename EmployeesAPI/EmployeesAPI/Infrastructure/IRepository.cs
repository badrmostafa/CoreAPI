using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.Infrastructure
{
    public interface IRepository<T> where T:class
    {
        List<T> GetAll();
        T GetById(int? id);
        int Add(T t);
        void Update(T t);
        int Delete(int? id);

    }
}
