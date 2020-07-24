using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRandstad.DAO.Context;

namespace TesteRandstad.DAO
{
    class PessoaDAO
    {
        public void AdicionaPessoa(PessoaModel pessoa)
        {
            using (var context = new ContextDataBase())
            {
                try
                {
                    context.Pessoas.Add(pessoa);
                    context.SaveChanges();
                }
                catch (Exception exception)
                {

                    throw;
                }
                
            }
        }

        public IEnumerable<PessoaModel> GetAll()
        {
            using (var context = new ContextDataBase())
            {
                return context.Pessoas.ToList();
            }
        }
        public void Update(PessoaModel pessoa)
        {
            using (var context = new ContextDataBase())
            {
                context.Pessoas.Attach(pessoa);
                context.Entry(pessoa).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(PessoaModel pessoa)
        {
            using (var context = new ContextDataBase())
            {
                context.Pessoas.Attach(pessoa);
                context.Entry(pessoa).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}

