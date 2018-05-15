using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.IRepository
{
    public interface IRepository<T> where T : class
    { 
        void Create(T model);
        void Update(T model);
        void Delete(T model);
        T Get(string key);
        IEnumerable<T> GettAll();
    }
}
