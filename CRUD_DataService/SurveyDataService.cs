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
    public class SurveyDataService
    {
        public async Task<bool> InsertSurveyData(IList<SurveyData> surveyData)
        {
            string spName = "UpsertSurveyData_NewAPI";
            bool retResult = true;
            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();
            try
            {
                foreach (var sData in surveyData)
                {
                    SqlCommand objCommand = new SqlCommand(spName, Conn);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@SurveyId", sData.SurveyId);
                    objCommand.Parameters.AddWithValue("@SurveyDataId", sData.SurveyDataId);
                    objCommand.Parameters.AddWithValue("@SoochnaPrenuer", sData.SoochnaPrenuer);
                    objCommand.Parameters.AddWithValue("@BeneficiaryId", sData.BeneficiaryId);
                    objCommand.Parameters.AddWithValue("@Latitude", sData.Latitude);
                    objCommand.Parameters.AddWithValue("@Longitude", sData.Longitude);

                    await (objCommand.ExecuteNonQueryAsync());

                }
            }
            catch (Exception ex)
            {
                retResult = false;
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
            return retResult;
        }

        public async Task<IList<SurveyData>> GetSurveyData(string username)
        {
            string spName = "GetSurveyData_NewAPI";

            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            List<SurveyData> getSurveyData = new List<SurveyData>();
            Conn.Open();
            try
            {
                SqlCommand objCommand = new SqlCommand(spName, Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Soochnapreneur", username);
                SqlDataReader _Reader = await objCommand.ExecuteReaderAsync();
                while (_Reader.Read())
                {
                    getSurveyData.Add(new SurveyData
                    {
                        Id = Convert.ToInt32(_Reader["Id"]),
                        SurveyId = Convert.ToInt32(_Reader["SurveyId"]),
                        SurveyDataId = _Reader["SurveyDataId"].ToString(),
                        BeneficiaryId = Convert.ToInt32(_Reader["SurveyDetailsData"]),
                        SoochnaPrenuer = _Reader["SurveyDetailsData"].ToString(),
                        Latitude = _Reader["SurveyDetailsData"].ToString(),
                        Longitude = _Reader["SurveyDetailsData"].ToString(),
                        Timestamp = _Reader["SurveyDetailsData"].ToString()

                    });

                }

            }
            catch
            {

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
            return getSurveyData;
        }

        public async Task<bool> InsertSurveyDataDetails(IList<SurveyDataDetail> surveyData)
        {
            string spName = "UpsertSurveyDataDetails_NewAPI";
            bool retResult = true;
            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();
            try
            {
                foreach (var sData in surveyData)
                {
                    SqlCommand objCommand = new SqlCommand(spName, Conn);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@Id", sData.Id);
                    objCommand.Parameters.AddWithValue("@SurveyDataId", sData.SurveyDataId);
                    objCommand.Parameters.AddWithValue("@SurveyDetailsId", sData.SurveyDetailsId);
                    objCommand.Parameters.AddWithValue("@SurveyDetailsData", sData.SurveyDetailsData);
                    objCommand.Parameters.AddWithValue("@InputType", sData.InputType);
                    objCommand.Parameters.AddWithValue("@SurveyId", sData.SurveyId);
                    objCommand.Parameters.AddWithValue("@SurveyDataId_FK", sData.SurveyDataIdFK);

                    await (objCommand.ExecuteNonQueryAsync());
                }
            }
            catch (Exception ex)
            {
                retResult = false;
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
            return retResult;
        }

        public async Task<IList<SurveyDataDetail>> GetSurveyDataDetails(string username)
        {
            string spName = "GetSurveyDataDetails_NewAPI";

            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            List<SurveyDataDetail> getSurveyDataDetails = new List<SurveyDataDetail>();
            Conn.Open();
            try
            {
                SqlCommand objCommand = new SqlCommand(spName, Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Soochnapreneur", username);
                SqlDataReader _Reader = await objCommand.ExecuteReaderAsync();
                while (_Reader.Read())
                {
                    getSurveyDataDetails.Add(new SurveyDataDetail
                    {
                        Id = Convert.ToInt32(_Reader["Id"]),
                        SurveyDataId = _Reader["SurveyDataId"].ToString(),
                        SurveyDetailsId = _Reader["SurveyDetailsId"].ToString(),
                        SurveyDetailsData = _Reader["SurveyDetailsData"].ToString(),
                        InputType = _Reader["InputType"].ToString(),
                        SurveyId = Convert.ToInt32(_Reader["SurveyId"]),
                        SurveyDataIdFK = Convert.ToInt64(_Reader["SurveyDataId_FK"])



                    });

                }

            }
            catch
            {

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
            return getSurveyDataDetails;


        }

    }
}
