using System.Net;
using System.Web.Http;
using calculo_b3.Models;
using calculo_b3.Services;



namespace calculo_b3.Controllers
{
    
   

    public class CdbController : ApiController
    {
        private readonly ICdbService _cdbService;

        
        public CdbController(ICdbService cdbService)
        {
            _cdbService = cdbService;
        }


        [HttpPost]
        [Route("api/calculo/cdb")]
        public IHttpActionResult Calcula([FromBody] CdbRequest cdbRequest)
        {
            CdbResponse cdbResponse = _cdbService.CalculaCDB(cdbRequest);


            if (cdbResponse.Erro)
            {
                return Content(HttpStatusCode.BadRequest, cdbResponse.MsgErro);
            }
            return Ok(cdbResponse);
        }

      
    }
}
