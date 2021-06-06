using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoochanaSeva_Model
{
    public class LCBeneficiary
    {
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public DateTime? DOB { get; set; }
        public Int64 State { get; set; }
        public Int64 District { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string MaritalStatus { get; set; }
        public string EmpStatus { get; set; }
        public string Disability { get; set; }
        public string SoochnaPreneur { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfRegistration { get; set; }
        public string Qualification { get; set; }
    }
}
