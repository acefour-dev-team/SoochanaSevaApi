using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoochanaSeva_Model
{
    public class SurveyData
    {
        public Int64? Id { get; set; }
        public int SurveyId { get; set; }
        public string SurveyDataId { get; set; }
        public string SoochnaPrenuer { get; set; }
        public int BeneficiaryId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Timestamp { get; set; }
    }
}
