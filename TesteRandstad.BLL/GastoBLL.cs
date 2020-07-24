using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRandstad.DAO.Repositorio;

namespace TesteRandstad.BLL
{
    public class GastoBLL
    {
        GastoRepository gastoRepository = new GastoRepository();
        public IEnumerable<GastoModel> GetGastos()
        {
            return gastoRepository.GetAllProcedure(new GastoModel(), "GetGastoProcedure");
        }
      
        public void AddGasto(GastoModel gasto)
        {
            gastoRepository.Add(gasto);
        }

        public GastoModel GetById(int id)
        {
            return gastoRepository.GetById(id);
        }
        public void Update(GastoModel gasto)
        {
            gastoRepository.Update(gasto);
        }
        public void Delete(int id)
        {
            var pessoa = gastoRepository.GetById(id);
            gastoRepository.Remove(pessoa);
        }
    }
}
