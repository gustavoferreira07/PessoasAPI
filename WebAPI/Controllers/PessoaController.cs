using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteRandstad.BLL;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Requisições de Pessoas
    /// </summary>
    public class PessoaController : ApiController
    {
        PessoaBLL pessoaBLL = new PessoaBLL();
        // GET: api/Pessoa
        /// <summary>
        /// Retorna todas as Pessoas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PessoaModel> Get()
        {
            return pessoaBLL.GetPessoas();
        }

        // GET: api/Pessoa/5
        /// <summary>
        /// Retorna uma Pessoa pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PessoaModel Get(int id)
        {
            var item= pessoaBLL.GetById(id);
            if (item == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Não existe uma pessoa com o id = {0}", id)),
                    ReasonPhrase = "Pessoa não encontrada",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(resp);
            }
            return item;
        }

        // POST: api/Pessoa
        /// <summary>
        /// Metodo de Inserção de Pessoas
        /// </summary>
        /// <param name="pessoa"></param>
        public HttpStatusCode Post(PessoaModel pessoa)
        {
            try
            {
                pessoaBLL.AddPessoa(pessoa);
                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format(ex.Message)),
                    ReasonPhrase = "Erro ao salvar Pessoa",
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(resp);
            }           
        }

        // PUT: api/Pessoa/5
        /// <summary>
        /// Metodo de Edição de Pessoas
        /// </summary>
        /// <param name="pessoa"></param>
        public void Put( PessoaModel pessoa)
        {
           
            var item = pessoaBLL.GetById(pessoa.Id);
            if (item == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Não existe uma pessoa com o id = {0}", pessoa.Id)),
                    ReasonPhrase = "Pessoa não encontrada",
                    StatusCode = HttpStatusCode.NotFound                    
                };
                throw new HttpResponseException(resp);
            }
            else
            {
                pessoaBLL.Update(pessoa);
            }           
        }

        // DELETE: api/Pessoa/5
        /// <summary>
        /// Deleta uma Pessoa pelo ID
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            pessoaBLL.Delete(id);
        }
    }
}
