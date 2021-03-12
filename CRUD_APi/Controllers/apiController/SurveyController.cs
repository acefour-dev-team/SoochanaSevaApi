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
    [RoutePrefix("api/Survey")]
    public class SurveyController : ApiController
    {
        SurveyDataService adSurvey = new SurveyDataService();

        [HttpPost]
        public async Task<bool> InsertSurveyDataDetails(IList<SurveyDataDetail> surveyDataDetails)
        {
            var returnValue = await adSurvey.InsertSurveyDataDetails(surveyDataDetails);
            return returnValue;
        }
        [HttpPost]
        public async Task<bool> InsertSurveyData(IList<SurveyData> surveyData)
        {
            var returnValue = await adSurvey.InsertSurveyData(surveyData);
            return returnValue;
        }
        [HttpGet]
        public async Task<IList<SurveyDataDetail>> GetAllSurveyDataDetails(string username)
        {
            var returnValue = await adSurvey.GetSurveyDataDetails(username);
            return returnValue;
        }
        [HttpGet]
        public async Task<IList<SurveyData>> GetAllSurveyData(string username)
        {
            var returnValue = await adSurvey.GetSurveyData(username);
            return returnValue;
        }
    }
}
