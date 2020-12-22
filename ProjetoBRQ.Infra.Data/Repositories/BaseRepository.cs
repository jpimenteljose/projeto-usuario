using Microsoft.EntityFrameworkCore;
using ProjetoBRQ.Domain.Contracts.Repositories;
using ProjetoBRQ.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBRQ.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        //atributo..
        private readonly DataContext dataContext;

        //construtor para inicialização do atributo
        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Create(T obj)
        {
            dataContext.Entry(obj).State = EntityState.Added;
            dataContext.SaveChanges();
        }

        public void Update(T obj)
        {
            dataContext.Entry(obj).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public void Delete(T obj)
        {
            dataContext.Entry(obj).State = EntityState.Deleted;
            dataContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return dataContext.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return dataContext.Set<T>().Find(id);
        }
    }
}
