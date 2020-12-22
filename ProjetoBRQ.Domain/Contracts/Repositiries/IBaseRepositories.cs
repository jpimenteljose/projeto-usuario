using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBRQ.Domain.Contracts.Repositories
{
    public interface IBaseRepository<T>
        where T : class
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);

        List<T> GetAll();        
        T GetById(Guid id);
    }
}
