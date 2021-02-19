using SoochanaSeva_DataService;
using SoochanaSeva_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;


namespace SoochanaSeva_Api.Controllers.apiController
{
    [RoutePrefix("api/Beneficiary")]
    public class BeneficiaryController : ApiController
    {
        BeneficiaryDataService adBeneficiary = new BeneficiaryDataService();

        [HttpPost]
        public async Task<bool> AddBeneficiary(Beneficiary Beneficiary)
        {
            bool result = false;
            result = await adBeneficiary.AddBeneficiary(Beneficiary);
            return result;

        }

        public async Task<IList<Beneficiary>> GetBeneficiaries(string SoochnaPreneur, int Beneficiary)
        {
            return await adBeneficiary.ListOfBeneficiaries(SoochnaPreneur, Beneficiary);
        }

        [HttpPost]
        public async Task<bool> SyncBeneficiary(IList<Beneficiary> Beneficiaries)
        {
            bool result = false;
            if (Beneficiaries != null)
            {
                result = await adBeneficiary.SyncBeneficiary(Beneficiaries);
            }
            return result;
        }
    }
}
