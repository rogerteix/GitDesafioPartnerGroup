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

    [RoutePrefix("marca")]
    public class MarcaController : ApiController
    {
        [HttpPost]
        [Route("POST/marca")]
        public Task<HttpResponseMessage> Inserir(MarcaModel model)
        {
            try
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, new MarcaRepositorio().Inserir(model.ID, model.Nome)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, ex.GetBaseException().Message));
            }
        }

        [HttpPost]
        [Route("GET/marca/id")]
        public Task<HttpResponseMessage> Obter(MarcaIDModel model)
        {
            try
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, new MarcaRepositorio().Obter(model.ID)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, ex.GetBaseException().Message));
            }
        }

        [HttpPost]
        [Route("GET/marcas/id/patrimonio")]
        public Task<HttpResponseMessage> ObterPatrimonio(PatrimonioIDModel model)
        {
            try
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, new MarcaRepositorio().ObterPatrimonio(model.NTombo)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, ex.GetBaseException().Message));
            }
        }

        [HttpPost]
        [Route("GET/marcas")]
        public Task<HttpResponseMessage> Lista()
        {
            try
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, new MarcaRepositorio().Lista()));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, ex.GetBaseException().Message));
            }
        }

        [HttpPost]
        [Route("PUT/marca/id")]
        public Task<HttpResponseMessage> Update(MarcaModel model)
        {
            try
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, new MarcaRepositorio().Update(model.ID, model.Nome)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, ex.GetBaseException().Message));
            }
        }

        [HttpPost]
        [Route("DELETE/marca/id")]
        public Task<HttpResponseMessage> Delete(MarcaIDModel model)
        {
            try
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, new MarcaRepositorio().Delete(model.ID)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, ex.GetBaseException().Message));
            }
        }




    }
}
