using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoochanaSeva_Model
{
    public class SurveyDataDetail
    {
        public int? Id { get; set; }
        public int SurveyId { get; set; }
        public string SurveyDataId { get; set; }
        public string SurveyDetailsId { get; set; }
        public string SurveyDetailsData { get; set; }
        public string InputType { get; set; }
        public Int64 SurveyDataIdFK { get; set; }
    }
}
