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
    }
}
