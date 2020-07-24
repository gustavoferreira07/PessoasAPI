using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRandstad.DAO;
using TesteRandstad.DAO.Repositorio;

namespace TesteRandstad.BLL
{
    public class PessoaBLL
    {
        PessoaRepository pessoaRepository = new PessoaRepository();
        public IEnumerable<PessoaModel> GetPessoas()
        {            
            return pessoaRepository.GetAllProcedure(new PessoaModel(), "GetPessoasProcedure");
        }

        public void AddPessoa(PessoaModel pessoa)
        {
            pessoaRepository.Add(pessoa);
        }

        public PessoaModel GetById(int id)
        {
          return pessoaRepository.GetById(id);
        }
        public void Update(PessoaModel pessoa)
        {
            pessoaRepository.Update(pessoa);
        }
        public void Delete(int id)
        {
            var pessoa = pessoaRepository.GetById(id);
            pessoaRepository.Remove(pessoa);
        }
    }
}
