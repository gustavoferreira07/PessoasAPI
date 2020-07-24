using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRandstad.DAO.Context;
using TesteRandstad.DAO.Repositorio.Interfaces;

namespace TesteRandstad.DAO.Repositorio
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ContextDataBase context = new ContextDataBase();
        public void Add(TEntity obj)
        {            
            context.Set<TEntity>().Add(obj);
            context.SaveChanges();                    
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAllProcedure(TEntity obj,string procedure)
        {
            return context.Set<TEntity>().SqlQuery($"exec {procedure}").ToList();            
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            context.Set<TEntity>().Remove(obj);
            context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
