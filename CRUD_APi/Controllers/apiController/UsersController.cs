using Newtonsoft.Json;
using SoochanaSeva_DataService;
using SoochanaSeva_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;


namespace SoochanaSeva_Api.Controllers.apiController
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //[RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("api/soochnapreneurs/{state}")]
        public async Task<IList<SoochnaPreneur>> GetSoochnaPrenuer(string state)
        {
            UserDataService userDataService = new UserDataService();
            return await userDataService.GetSoochnaPrenuer(state);
        }

        [HttpPost]
        [Route("api/soochnapreneurs/Beneficiary/Add")]
        public async Task<HttpResponseMessage> AddBeneficiary(LCBeneficiary Beneficiary)
        {
            try
            {
                if (Beneficiary == null)
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
               
                UserDataService userDataService = new UserDataService();
                var result = await userDataService.AddBeneficiary_LCAsync(Beneficiary);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

        }
    }
}
