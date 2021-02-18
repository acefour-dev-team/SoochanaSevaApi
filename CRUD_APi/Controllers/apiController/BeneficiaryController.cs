using SoochanaSeva_DataService;
using SoochanaSeva_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace SoochanaSeva_Api.Controllers.apiController
{
    [RoutePrefix("api/Beneficiary")]
    public class BeneficiaryController : ApiController
    {
        BeneficiaryDataService adBeneficiary = new BeneficiaryDataService();

        [HttpPost]
        public bool AddBeneficiary(Beneficiary Beneficiary)
        {
            bool result = false;
            result = adBeneficiary.AddBeneficiary(Beneficiary);
            return result;

        }

        public IList<Beneficiary> GetBeneficiaries(string SoochnaPreneur, int Beneficiary)
        {
            return adBeneficiary.ListOfBeneficiaries(SoochnaPreneur, Beneficiary);
        }
    }
}
