using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRandstad.DAO.Repositorio.Interfaces
{
    interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAllProcedure(TEntity obj,string procedure);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
