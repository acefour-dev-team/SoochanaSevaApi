using SoochanaSeva_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoochanaSeva_DataService
{
    public class UserDataService
    {
        public async Task<IList<SoochnaPreneur>> GetSoochnaPrenuer(string state)
        {
            string spName = "GetDEFSoochnaPreneur";

            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            try
            {
                List<SoochnaPreneur> SoochnaPreneurs = new List<SoochnaPreneur>();

                if (Conn.State != System.Data.ConnectionState.Open)
                    Conn.Open();

                SqlCommand objCommand = new SqlCommand(spName, Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@State", state);

                SqlDataReader _Reader = await objCommand.ExecuteReaderAsync();
                while (_Reader.Read())
                {
                    SoochnaPreneurs.Add(new SoochnaPreneur
                    {
                        UserName = _Reader["UserName"].ToString(),
                        Name = _Reader["Name"].ToString(),
                        StateName = _Reader["StateName"].ToString(),
                        Mobile = _Reader["MobileNumber"].ToString(),
                        Email = _Reader["Email"].ToString()
                    });
                }

                return SoochnaPreneurs;
            }
            catch (Exception ex)
            {
                throw ex;
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

        public async Task<int> AddBeneficiary_LCAsync(LCBeneficiary beneficiary)
        {
            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            int result = 0;

            try
            {

                if (Conn.State != System.Data.ConnectionState.Open)
                    Conn.Open();

                SqlCommand objCommand = new SqlCommand("AddBeneficiary_LC", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@BeneficiaryId", beneficiary.Id);
                objCommand.Parameters.AddWithValue("@FirstName", !string.IsNullOrEmpty(beneficiary.FirstName) ? beneficiary.FirstName : string.Empty);
                objCommand.Parameters.AddWithValue("@LastName", !string.IsNullOrEmpty(beneficiary.LastName) ? beneficiary.LastName : string.Empty);
                objCommand.Parameters.AddWithValue("@FathersName", !string.IsNullOrEmpty(beneficiary.FathersName) ? beneficiary.FathersName : string.Empty);
                objCommand.Parameters.AddWithValue("@DOB", Convert.ToDateTime(beneficiary.DOB));
                objCommand.Parameters.AddWithValue("@State", beneficiary.State);
                objCommand.Parameters.AddWithValue("@LCGenderCode", beneficiary.Gender);
                objCommand.Parameters.AddWithValue("@Age", beneficiary.Age);
                objCommand.Parameters.AddWithValue("@LCMaritalStatus", beneficiary.MaritalStatus);
                objCommand.Parameters.AddWithValue("@LCEmpStatus", beneficiary.EmpStatus);
                objCommand.Parameters.AddWithValue("@LCDisability", beneficiary.Disability);
                objCommand.Parameters.AddWithValue("@SoochnaPreneur", beneficiary.SoochnaPreneur);
                objCommand.Parameters.AddWithValue("@Address", beneficiary.Address);
                objCommand.Parameters.AddWithValue("@EMail", beneficiary.EMail);
                objCommand.Parameters.AddWithValue("@Phone", beneficiary.Phone);
                objCommand.Parameters.AddWithValue("@LCQualification", beneficiary.Qualification);

                if (beneficiary.DateOfRegistration != null)
                    objCommand.Parameters.AddWithValue("@DateOfRegistration", beneficiary.DateOfRegistration);
                else
                    objCommand.Parameters.AddWithValue("@DateOfRegistration", DBNull.Value);

                var response = Convert.ToInt32(await objCommand.ExecuteScalarAsync());

                return response;
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
