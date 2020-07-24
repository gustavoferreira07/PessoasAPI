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
    /// Requisições de Gastos
    /// </summary>
    public class GastoController : ApiController
    {
        GastoBLL gastoBLL = new GastoBLL();
        // GET: api/Gasto
        /// <summary>
        /// Retorna todos os Gastos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GastoModel> Get()
        {
            return gastoBLL.GetGastos();
        }

        // GET: api/Gasto/5
        /// <summary>
        /// Retorna um Gasto pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GastoModel Get(int id)
        {            
            var item = gastoBLL.GetById(id);
            if (item == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Não existe um Gasto com o id = {0}", id)),
                    ReasonPhrase = "Gasto não encontrado",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(resp);
            }
            return item;
        }

        // POST: api/Gasto
        /// <summary>
        /// Metodo de inserção de gasto
        /// </summary>
        /// <param name="gasto"></param>
        public HttpStatusCode Post(GastoModel gasto)
        {
            try
            {
                gastoBLL.AddGasto(gasto);
                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format(ex.Message)),
                    ReasonPhrase = "Gasto não encontrado",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(resp);
            }
            
        }

        // PUT: api/Gasto/5
        /// <summary>
        /// Metodo de alteração de Gasto
        /// </summary>
        /// <param name="gasto"></param>
        public void Put(GastoModel gasto)
        {
           
            var item = gastoBLL.GetById(gasto.Id);
            if (item == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Não existe um Gasto com o id = {0}", gasto.Id)),
                    ReasonPhrase = "Gasto não encontrado",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(resp);
            }
            else
            {
                gastoBLL.Update(gasto);
            }
        }

        // DELETE: api/Gasto/5
        /// <summary>
        /// Metodo de exclusão de Gasto
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
           
            var item = gastoBLL.GetById(id);
            if (item == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Não existe um Gasto com o id = {0}", id)),
                    ReasonPhrase = "Gasto não encontrado",
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new HttpResponseException(resp);
            }
            else
            {
                gastoBLL.Delete(id);
            }
        }
    }
}
