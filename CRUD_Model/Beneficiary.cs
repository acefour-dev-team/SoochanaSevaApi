using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoochanaSeva_Model
{
    public class Beneficiary
    {
        public Int64 Id { get; set; }
        public Int64 ParentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public string HusbandsName { get; set; }
        public DateTime? DOB { get; set; }
        public string IDDetails { get; set; }
        public Int64 IDProof { get; set; }
        public Int64 State { get; set; }
        public Int64 District { get; set; }

        public Int64 EngDistrictId { get; set; }
        public Int64 Sex { get; set; }
        public Int64 Age { get; set; }
        public Int64 Religion { get; set; }
        public Int64 Socio { get; set; }
        public Int64 Occupation { get; set; }
        public Int64 MaritalStatus { get; set; }
        public Int64 Category { get; set; }
        public Int64 Department { get; set; }
        public Int64 EmploymentStatus { get; set; }
        public Int64 VulGroup { get; set; }
        public double AnnualIncome { get; set; }
        public Int64 Disabilty { get; set; }
        public string SoochnaPreneur { get; set; }
        public string Photo { get; set; }
        public Int64 Relationship { get; set; }
        public string IDProofName { get; set; }
        public Int64 Sickness { get; set; }
        public Int64 BeneficiaryId { get; set; }
        public Int64 PercentageDisablity { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfRegistration { get; set; }
        public string Qualification { get; set; }
        public string Block { get; set; }
        public string Village { get; set; }
        public string Panchayat { get; set; }
    }
    public class AllBeneficiaries
    {
        public Int64 Id { get; set; }
        public string TempBeneficiaryId { get; set; }
        public string BeneficiaryName { get; set; }
        public string BeneficiaryMobile { get; set; }
        public string BeneficiaryEMail { get; set; }
        public string StateName { get; set; }
        public string SoochnaPreneur { get; set; }
        public string SoochnaPreneurMobile { get; set; }
        public Int64 BeneficiaryId { get; set; }
        public string Qualification { get; set; }
        public string District { get; set; }
        public string FatherName { get; set; }
        public string HusbandName { get; set; }
        public string DateOfBirth { get; set; }
        public Int64 Age { get; set; }
        public string IDProof { get; set; }
        public string Occupation { get; set; }
        public string Religon { get; set; }
        public string MaritalStatus { get; set; }
        public string Category { get; set; }
        public string Department { get; set; }
        public string EmploymentStatus { get; set; }
        public string VulnerableGroup { get; set; }
        public string Disability { get; set; }
        public string Relationship { get; set; }
        public string Sickness { get; set; }
        public string BeneficiaryRelationship { get; set; }
        public decimal AnnualIncome { get; set; }
        public string IDDetails { get; set; }
        public string PercentageDisability { get; set; }
        public string Sex { get; set; }
        public string DateOfRegistration { get; set; }
        public string SchemeName { get; set; }
        public string Status { get; set; }
        public string DateApplied { get; set; }
        public string ProgrameName { get; set; }
        public string ServiceName { get; set; }

    }
}
