using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRandstad.DAO.Context
{
    public class ContextDataBase : DbContext
    {
        public ContextDataBase()
            : base("StringConnection")
        {
            //this.Configuration.AutoDetectChangesEnabled = false;
        }

        public virtual DbSet<PessoaModel> Pessoas { get; set; }
        public virtual DbSet<GastoModel> Gastos { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
            modelBuilder.Entity<PessoaModel>().HasKey(s => s.Id);
        }
    }
}
