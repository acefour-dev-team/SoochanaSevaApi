using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoochanaSeva_Model
{
    public class SurveySection
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int SectionId { get; set; }
        public string SectionHeader { get; set; }
        public bool IsAvailable { get; set; }
        public int ClientId { get; set; }
    }
}