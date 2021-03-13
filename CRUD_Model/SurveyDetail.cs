using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoochanaSeva_Model
{
    public class SurveyDetail
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string Question { get; set; }
        public string InputTypes { get; set; }
        public bool HasSubQuestion { get; set; }
        public int? SectionId { get; set; }
        public string Condition { get; set; }
        public string ValidationMessage { get; set; }
        public bool isMandatory { get; set; }
        public bool isAvailable { get; set; }
        public bool isSearchable { get; set; }
        public string SelectValues { get; set; }
        public int LangId { get; set; }
        public string ClientId { get; set; }
        public int LinkQuestion { get; set; }
        public int Size { get; set; }
    }
}
