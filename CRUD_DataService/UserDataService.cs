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
    }
}
