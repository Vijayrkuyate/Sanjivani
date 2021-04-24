
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandooDataLinkLayer
{
   public class DBConnection
    {
        private string Constring = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString.ToString();

        SqlConnection conn;
        public bool InsrtUpdtDlt(SqlCommand command)
        {
            conn = new SqlConnection(Constring);
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conn;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //ExceptionDetails.saveException("Insert", "insert "+command.CommandText, ex.Message.ToString());
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable GetDtByCommand(SqlCommand command)
        {
            try
            {
                DataTable dtList = new DataTable();
                conn = new SqlConnection(Constring);
                command.Connection = conn;
                SqlDataAdapter ado = new SqlDataAdapter(command);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();
                ado.Fill(dtList);
                conn.Close();
                return dtList;
            }
            catch (Exception ex)
            {

               // ExceptionDetails.saveException("GetDtByCommand", "get data "+command.CommandText, ex.Message.ToString());
                throw;
            }
        }
        public DataSet GetDsByCommand(SqlCommand command)
        {
            try
            {
                DataSet dsList = new DataSet();
                conn = new SqlConnection(Constring);
                command.Connection = conn;
                SqlDataAdapter ado = new SqlDataAdapter(command);
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();
                ado.Fill(dsList);
                conn.Close();
                return dsList;
            }
            catch (Exception ex)
            {
                //ExceptionDetails.saveException("GetDsByCommand", "get data "+command.CommandText, ex.Message.ToString());
                throw;
            }

        }
        public Int32 GetExcuteScaler(SqlCommand command)
        {
            try
            {
                conn = new SqlConnection(Constring);
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                conn.Open();
                Int32 result = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                return result;
            }
            catch (Exception ex)
            {

                //ExceptionDetails.saveException("GetExcuteScaler", "get data "+command.CommandText, ex.Message.ToString());
                throw;
            }
          
        }
        public Int32 getInt(SqlCommand command)
        {
            try
            {
                conn = new SqlConnection(Constring);
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                conn.Open();
                Int32 result = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                return result;
            }
            catch (Exception ex)
            {

                //ExceptionDetails.saveException("getInt", "get data "+command.CommandText, ex.Message.ToString());
                throw;
            }
           
        }
        public bool GetExcuteScalerBool(SqlCommand command)
        {
            try
            {
                conn = new SqlConnection(Constring);
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                conn.Open();
                bool result = Convert.ToBoolean(command.ExecuteScalar());
                conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                //ExceptionDetails.saveException("getInt", "get data "+command.CommandText, ex.Message.ToString());
                throw;
            }
           
        }
        
    }
}
