using DesafioPartnerGroup.Model;
using DesafioPartnerGroup.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DesafioPartnerGroup.Controllers
{

    [RoutePrefix("patrimonio")]
    public class PatrimonioController : ApiController
    {
        [HttpPost]
        [Route("POST/patrimonios")]
        public Task<HttpResponseMessage> Inserir(PatrimonioSemIDModel model)
        {
            try
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, new PatrimonioRepositorio().Inserir(model.MarcaID, model.Nome, model.Descricao)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, ex.GetBaseException().Message));
            }
        }

        [HttpPost]
        [Route("GET/patrimonios/id")]
        public Task<HttpResponseMessage> Obter(PatrimonioIDModel model)
        {
            try
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, new PatrimonioRepositorio().Obter(model.NTombo)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, ex.GetBaseException().Message));
            }
        }

        [HttpPost]
        [Route("GET/patrimonios")]
        public Task<HttpResponseMessage> Lista()
        {
            try
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, new PatrimonioRepositorio().Lista()));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, ex.GetBaseException().Message));
            }
        }

        [HttpPost]
        [Route("PUT/patrimonios/id")]
        public Task<HttpResponseMessage> Update(PatrimonioModel model)
        {
            try
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, new PatrimonioRepositorio().Update(model.NTombo, model.Nome, model.Descricao, model.MarcaID)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, ex.GetBaseException().Message));
            }
        }

        [HttpPost]
        [Route("DELETE/patrimonios/id")]
        public Task<HttpResponseMessage> Delete(PatrimonioIDModel model)
        {
            try
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, new PatrimonioRepositorio().Delete(model.NTombo)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, ex.GetBaseException().Message));
            }
        }
    }

}
