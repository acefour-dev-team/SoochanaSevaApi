using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoochanaSeva_Model;

namespace SoochanaSeva_DataService
{
    // Database Service
    public class BeneficiaryDataService
    {
        public async Task<IList<Beneficiary>> ListOfBeneficiaries(string SoochnaPreneur, int Beneficiary)
        {
            string spName = "GetBeneficiariesNew";
            int i = 0;

            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            try
            {
                List<Beneficiary> getBeneficiary = new List<Beneficiary>();

                if (Conn.State != System.Data.ConnectionState.Open)
                    Conn.Open();

                SqlCommand objCommand = new SqlCommand(spName, Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@SoochnaPreneur", SoochnaPreneur);
                objCommand.Parameters.AddWithValue("@Beneficiary", Beneficiary);

                SqlDataReader _Reader = await objCommand.ExecuteReaderAsync();
                while (_Reader.Read())
                {
                    getBeneficiary.Add(new Beneficiary
                    {
                        Id = Convert.ToInt64(_Reader["Id"]),
                        ParentId = Beneficiary,
                        FirstName = _Reader["FirstName"].ToString(),
                        LastName = _Reader["LastName"].ToString(),
                        FathersName = _Reader["FathersName"].ToString(),
                        HusbandsName = _Reader["HusbandsName"].ToString(),
                        //DateOfBirth = (_Reader["DateOfBirth"] != DBNull.Value && !_Reader["DateOfBirth"].ToString().Contains("1/1/0001")) ? _Reader["DateOfBirth"].ToString() : string.Empty,
                        DOB = _Reader["DOB"] != DBNull.Value && _Reader["DOB"].ToString() != string.Empty ? Convert.ToDateTime(_Reader["DOB"].ToString()) : (DateTime?)null,
                        IDProof = Convert.ToInt64(_Reader["IDProof"] != DBNull.Value ? Convert.ToInt64(_Reader["IDProof"]) : 0),
                        IDDetails = _Reader["IDDetails"].ToString(),
                        State = Convert.ToInt64(_Reader["State"]),
                        District = Convert.ToInt64(_Reader["District"]),
                        EngDistrictId = _Reader["EngDistrictId"] != DBNull.Value && _Reader["EngDistrictId"] != "" ? Convert.ToInt64(_Reader["EngDistrictId"]) : 0,

                        Sex = Convert.ToInt64(_Reader["Sex"] != DBNull.Value ? Convert.ToInt64(_Reader["Sex"]) : 0),
                        Age = Convert.ToInt64(_Reader["Age"] != DBNull.Value ? Convert.ToInt64(_Reader["Age"]) : 0),
                        Religion = Convert.ToInt64(_Reader["Religion"] != DBNull.Value ? Convert.ToInt64(_Reader["Religion"]) : 0),
                        Department = Convert.ToInt64(_Reader["Department"] != DBNull.Value ? Convert.ToInt64(_Reader["Department"]) : 0),
                        EmploymentStatus = Convert.ToInt64(_Reader["EmpStatus"] != DBNull.Value ? Convert.ToInt64(_Reader["EmpStatus"]) : 0),
                        VulGroup = Convert.ToInt64(_Reader["VulGroup"] != DBNull.Value ? Convert.ToInt64(_Reader["VulGroup"]) : 0),
                        AnnualIncome = Convert.ToDouble(_Reader["AnnualIncome"] != DBNull.Value ? Convert.ToInt64(_Reader["AnnualIncome"]) : 0),
                        Disabilty = Convert.ToInt64(_Reader["Disablity"] != DBNull.Value ? Convert.ToInt64(_Reader["Disablity"]) : 0),
                        Photo = _Reader["Photo"].ToString(),
                        SoochnaPreneur = SoochnaPreneur,
                        Relationship = Convert.ToInt64(_Reader["Relationship"] != DBNull.Value ? Convert.ToInt64(_Reader["Relationship"]) : 0),
                        Sickness = Convert.ToInt64(_Reader["Sickness"] != DBNull.Value ? Convert.ToInt64(_Reader["Sickness"]) : 0),
                        Occupation = Convert.ToInt64(_Reader["Occupation"] != DBNull.Value ? Convert.ToInt64(_Reader["Occupation"]) : 0),
                        BeneficiaryId = Convert.ToInt64(_Reader["Beneficiary"] != DBNull.Value ? Convert.ToInt64(_Reader["Beneficiary"]) : 0),
                        PercentageDisablity = _Reader["PercentageDisability"] != DBNull.Value ? Convert.ToInt64(_Reader["PercentageDisability"]) : 0,
                        Address = _Reader["Address"].ToString(),
                        EMail = _Reader["EMail"].ToString(),
                        Phone = _Reader["Phone"].ToString(),
                        Qualification = _Reader["Qualification"].ToString(),
                        DateOfRegistration = _Reader["DateOfRegistration"] != DBNull.Value && _Reader["DateOfRegistration"] != "" ? Convert.ToDateTime(_Reader["DateOfRegistration"].ToString()) : (DateTime?)null,
                        Socio = Convert.ToInt64(_Reader["Socio"] != DBNull.Value ? Convert.ToInt64(_Reader["Socio"]) : 0),
                        MaritalStatus = Convert.ToInt64(_Reader["MaritulStatus"] != DBNull.Value ? Convert.ToInt64(_Reader["MaritulStatus"]) : 0),
                        Category = Convert.ToInt64(_Reader["Category"] != DBNull.Value ? Convert.ToInt64(_Reader["Category"]) : 0),
                        Block = _Reader["Block"].ToString(),
                        Village = _Reader["Village"].ToString(),
                        Panchayat = _Reader["Panchayat"].ToString()

                    });
                }

                return getBeneficiary;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public async Task<bool> AddBeneficiary(Beneficiary Beneficiary)
        {
            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            int result = 0;

            try
            {

                if (Conn.State != System.Data.ConnectionState.Open)
                    Conn.Open();

                SqlCommand objCommand = new SqlCommand("AddBeneficiaryNew", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@BeneficiaryId", Beneficiary.Id);
                objCommand.Parameters.AddWithValue("@Beneficiary ", Beneficiary.ParentId);
                objCommand.Parameters.AddWithValue("@FirstName", !string.IsNullOrEmpty(Beneficiary.FirstName) ? Beneficiary.FirstName : string.Empty);
                objCommand.Parameters.AddWithValue("@LastName", !string.IsNullOrEmpty(Beneficiary.LastName) ? Beneficiary.LastName : string.Empty);
                objCommand.Parameters.AddWithValue("@FathersName", !string.IsNullOrEmpty(Beneficiary.FathersName) ? Beneficiary.FathersName : string.Empty);
                objCommand.Parameters.AddWithValue("@HusbandsName", !string.IsNullOrEmpty(Beneficiary.HusbandsName) ? Beneficiary.HusbandsName : string.Empty);
                objCommand.Parameters.AddWithValue("@DOB", Convert.ToDateTime(Beneficiary.DOB));
                objCommand.Parameters.AddWithValue("@IDProof", Beneficiary.IDProof);
                objCommand.Parameters.AddWithValue("@IDDetails ", !string.IsNullOrEmpty(Beneficiary.IDDetails) ? Beneficiary.IDDetails : string.Empty);
                objCommand.Parameters.AddWithValue("@State", Beneficiary.State);
                objCommand.Parameters.AddWithValue("@District", Beneficiary.District);
                objCommand.Parameters.AddWithValue("@Sex", Beneficiary.Sex);
                objCommand.Parameters.AddWithValue("@Age", Beneficiary.Age);
                objCommand.Parameters.AddWithValue("@Religion", Beneficiary.Religion);
                objCommand.Parameters.AddWithValue("@Socio", Beneficiary.Socio);
                objCommand.Parameters.AddWithValue("@Occupation", Beneficiary.Occupation);
                objCommand.Parameters.AddWithValue("@MaritalStatus ", Beneficiary.MaritalStatus);
                objCommand.Parameters.AddWithValue("@Category", Beneficiary.Category);
                objCommand.Parameters.AddWithValue("@Department", Beneficiary.Department);
                objCommand.Parameters.AddWithValue("@EmpStatus", Beneficiary.EmploymentStatus);
                objCommand.Parameters.AddWithValue("@VulGroup", Beneficiary.VulGroup);
                objCommand.Parameters.AddWithValue("@AnnualIncome", Beneficiary.AnnualIncome);
                objCommand.Parameters.AddWithValue("@Disability", Beneficiary.Disabilty);
                objCommand.Parameters.AddWithValue("@SoochnaPreneur", Beneficiary.SoochnaPreneur);
                objCommand.Parameters.AddWithValue("@Photo", Beneficiary.Photo);
                objCommand.Parameters.AddWithValue("@Relationship", Beneficiary.Relationship);
                objCommand.Parameters.AddWithValue("@Sickness", Beneficiary.Sickness);
                objCommand.Parameters.AddWithValue("@Address", Beneficiary.Address);
                objCommand.Parameters.AddWithValue("@EMail", Beneficiary.EMail);
                objCommand.Parameters.AddWithValue("@Phone", Beneficiary.Phone);
                objCommand.Parameters.AddWithValue("@PercentageDisability", Beneficiary.PercentageDisablity);
                objCommand.Parameters.AddWithValue("@Qualification", Beneficiary.Qualification);
                objCommand.Parameters.AddWithValue("@Block", Beneficiary.Block);
                objCommand.Parameters.AddWithValue("@Village", Beneficiary.Village);
                objCommand.Parameters.AddWithValue("@Panchayat", Beneficiary.Panchayat);

                if (Beneficiary.DateOfRegistration != null)
                    objCommand.Parameters.AddWithValue("@DateOfRegistration", Beneficiary.DateOfRegistration);
                else
                    objCommand.Parameters.AddWithValue("@DateOfRegistration", DBNull.Value);

                result = Convert.ToInt32(await objCommand.ExecuteScalarAsync());

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

    }
}
