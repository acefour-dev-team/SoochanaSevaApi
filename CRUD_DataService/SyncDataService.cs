﻿using SoochanaSeva_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoochanaSeva_DataService
{
    public class SyncDataService
    {
       
        public async Task<Sync> GetSyncStatus(string syncFunctionName, string userName)
        {
            string spName = "GetSyncStatus";

            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            var sync = new Sync();
            Conn.Open();
            try
            {
                SqlCommand objCommand = new SqlCommand(spName, Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@SyncName", syncFunctionName);
                objCommand.Parameters.AddWithValue("@UserName", userName);
                SqlDataReader _Reader = await objCommand.ExecuteReaderAsync();
                while (_Reader.Read())
                {
                    sync.Id = Convert.ToInt32(_Reader["Id"]);
                    sync.SyncFunctionName = _Reader["SyncFunctionName"].ToString();
                    sync.SyncStatus = Convert.ToBoolean(_Reader["SyncStatus"]);
                    sync.TimeStamp = Convert.ToDateTime(_Reader["Timestamp"]);
                    sync.User = _Reader["Users"].ToString();
    }

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
            return sync;
        } 
        public async Task<IList<SurveyDetail>> GetSurveyDetails(string username)
        {
            string spName = "GetSurveyDetails_NewAPI";

            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            List<SurveyDetail> getSurveyDetails = new List<SurveyDetail>();
            Conn.Open();
            try
            {
                SqlCommand objCommand = new SqlCommand(spName, Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Soochnapreneur", username);
                SqlDataReader _Reader = await objCommand.ExecuteReaderAsync();
                while (_Reader.Read())
                {
                    getSurveyDetails.Add(new SurveyDetail
                    {
                        Id = Convert.ToInt32(_Reader["Id"]),
                        SurveyId = Convert.ToInt32(_Reader["SurveyId"]),
                        Question = _Reader["Question"].ToString(),
                        InputTypes = _Reader["InputTypes"].ToString(),
                        HasSubQuestion = Convert.ToBoolean(_Reader["HasSubQuestion"]),
                        SectionId = Convert.ToInt32(_Reader["SectionId"]),
                        Condition = _Reader["Condition"].ToString(),
                        ValidationMessage = _Reader["ValidationMessage"].ToString(),
                        isMandatory = Convert.ToBoolean(_Reader["isMandatory"]),
                        isAvailable = Convert.ToBoolean(_Reader["isAvailable"]),
                        isSearchable = Convert.ToBoolean(_Reader["isSearchable"]),
                        SelectValues = _Reader["SelectValues"].ToString(),
                        LangId = Convert.ToInt32(_Reader["LangId"]),
                        LinkQuestion = Convert.ToInt32(_Reader["LinkQuestion"]),
                        ClientId = _Reader["ClientId"].ToString(),
                        Size = Convert.ToInt32(_Reader["Size"])
                    });

                }

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
            return getSurveyDetails;
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
                        BeneficiaryId = Convert.ToInt32(_Reader["BeneficiaryId"]),
                        SoochnaPrenuer = _Reader["SoochnaPrenuer"].ToString(),
                        Latitude = _Reader["Latitude"].ToString(),
                        Longitude = _Reader["Longitude"].ToString(),
                        Timestamp = _Reader["Timestamp"].ToString()

                    });

                }

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
            return getSurveyDataDetails;


        }

    }
}
