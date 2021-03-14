using SoochanaSeva_DataService;
using SoochanaSeva_Model;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SoochanaSeva_Api.Controllers.apiController
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Sync")]
    public class SyncController : ApiController
    {
        SyncDataService adSync = new SyncDataService();
        [HttpGet]
        public async Task<Sync> GetSyncStatus(string syncFunction, string userName)
        {
            var returnValue = await adSync.GetSyncStatus(syncFunction, userName);
            return returnValue;
        }

    }
}
