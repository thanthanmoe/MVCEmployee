using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEmployee.Repository
{
    interface IEmployeeRepo<T> where T :class
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);
        void Update(T Object);
        void Insert(T Object);
        void Delete(object Id);
        void Save();
    }
}
