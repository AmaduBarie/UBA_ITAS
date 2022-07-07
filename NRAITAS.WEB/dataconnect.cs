using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace NRA_ITAS
{
    public class dataconnect
    {
        public DataSet getSMSDB_Details()
        {
            string res = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string consString = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;

            StringBuilder sb = new StringBuilder();
            string queryStr = "SELECT ID, ConnectionName, DB_SCHEMA, HOST_ID, Port_Num, DB_Name, DBUSRName, DB_PWD, TBL_Name, Params FROM smsengine.sms_config";
            try
            {
                //conn
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand(queryStr.ToString(), Oraconn);

                if (Oraconn.State == ConnectionState.Closed)
                {
                    Oraconn.Open();
                }

                SqlDataAdapter oda = new SqlDataAdapter(oracmd);
                oda.Fill(ds);
                Oraconn.Close();
            }
            catch (Exception ex)
            {
            }

            return ds;
        }


       

        internal static DataTable getlocation()
        {
            

                 try
            {
                SqlConnection Oraconn = null;
                SqlCommand oracmd = new SqlCommand();
                string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
                Oraconn = new SqlConnection(consString);
                oracmd.CommandText = "getlocation"; 


                oracmd.Connection = Oraconn;
                oracmd.CommandType = CommandType.StoredProcedure;
                if (Oraconn.State != ConnectionState.Open)
                {
                    Oraconn.Open();
                }
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(oracmd);
                adp.Fill(dt);
                Oraconn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public static DataTable getCountEbank(string from)
        {
            SqlConnection Oraconn = null;
            if (from.IndexOf("gaps") != -1 || from.IndexOf("Gaps") != -1)
            {
                string consString = ConfigurationManager.ConnectionStrings["Datastringe_GAPSNEW"].ConnectionString;
                Oraconn = new SqlConnection(consString);
            }
            else
            {
                string consString = ConfigurationManager.ConnectionStrings["Datastringe_OnePLC"].ConnectionString;
                Oraconn = new SqlConnection(consString);
            }
            SqlCommand oracmd = new SqlCommand();
            oracmd.Connection = Oraconn;
            oracmd.CommandText = from;
            oracmd.CommandType = CommandType.StoredProcedure;
            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }

            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(oracmd);
            adp.Fill(dt);
            Oraconn.Close();
            return dt;
        }

        public static DataTable EBusinessBigPortal(string from, string intExt, string startDate, string endDate)
        {
            SqlConnection Oraconn = null;
            SqlCommand oracmd = new SqlCommand();

            if (intExt == "customers")
            {
                string consString = ConfigurationManager.ConnectionStrings["Datastringe_GAPSNEW"].ConnectionString;
                Oraconn = new SqlConnection(consString);
                oracmd.CommandText = "getGapsCustomers";
            }
            else if (intExt == "users")
            {
                string consString = ConfigurationManager.ConnectionStrings["Datastringe_GAPSNEW"].ConnectionString;
                Oraconn = new SqlConnection(consString);
                oracmd.CommandText = "getGapsUsers";
            }
            else if (from.IndexOf("gaps") != -1)
            {
                string consString = ConfigurationManager.ConnectionStrings["Datastringe_GAPSNEW"].ConnectionString;
                Oraconn = new SqlConnection(consString);
                oracmd.CommandText = "EBusinessBigPortalGaps";
            }
            else
            {
                string consString = ConfigurationManager.ConnectionStrings["Datastringe_OnePLC"].ConnectionString;
                Oraconn = new SqlConnection(consString);
                if (from == "inetBankingUsersCount")
                {
                    oracmd.CommandText = "EBusinessBigPortalUsers";
                }
                else
                {
                    oracmd.CommandText = "EBusinessBigPortal";
                }
            }
            oracmd.Connection = Oraconn;
            oracmd.CommandType = CommandType.StoredProcedure;
            if (intExt != "customers" && intExt != "users")
            {
                oracmd.Parameters.AddWithValue("@from", intExt);
            }
            oracmd.Parameters.AddWithValue("@startDate", startDate);
            oracmd.Parameters.AddWithValue("@endDate", endDate);
            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(oracmd);
            adp.Fill(dt);
            Oraconn.Close();
            return dt;
        }

        public string PostTrans(string pi_cod_acct_dr, string pi_cod_acct_cr, string brn1, string brn2, string pi_txn_amount, string drcr, string pi_ref_chq_no, DateTime pi_dat_value, string pi_narrative, string eod, string p_err_msg)
        {
            try
            {
                string res = "|OK";
                DataSet ds = new DataSet();
                OracleConnection oraconn = new OracleConnection(ConfigurationManager.ConnectionStrings["OraconnStr"].ConnectionString);
                OracleCommand oracmd = new OracleCommand("ACPN_FN_FLEX_POST.post_transaction", oraconn);
                oracmd.CommandType = CommandType.StoredProcedure;
                if (oraconn.State == ConnectionState.Closed)
                {
                    oraconn.Open();
                }
                oracmd.Parameters.Add("pi_cod_acct_dr", OracleDbType.Varchar2, 21).Value = pi_cod_acct_dr;
                oracmd.Parameters.Add("pi_cod_acct_cr", OracleDbType.Varchar2, 21).Value = pi_cod_acct_cr;
                oracmd.Parameters.Add("brn1", OracleDbType.Varchar2, 15).Value = brn1;
                oracmd.Parameters.Add("brn2", OracleDbType.Varchar2, 15).Value = brn2;
                oracmd.Parameters.Add("pi_txn_amount", OracleDbType.Double, 15).Value = Convert.ToDouble(pi_txn_amount);
                oracmd.Parameters.Add("drcr", OracleDbType.Varchar2, 21).Value = drcr;

                oracmd.Parameters.Add("pi_ref_chq_no", OracleDbType.Varchar2, 21).Value = pi_ref_chq_no;
                oracmd.Parameters.Add("pi_dat_value", OracleDbType.Date).Value = pi_dat_value;
                oracmd.Parameters.Add("pi_narrative", OracleDbType.Varchar2, 500).Value = pi_narrative;
                oracmd.Parameters.Add("eod", OracleDbType.Varchar2, 21).Value = eod;
                oracmd.Parameters.Add("p_err_msg", OracleDbType.Varchar2, 21).Value = p_err_msg;
                oracmd.Parameters.Add("p_response", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;

                oracmd.ExecuteNonQuery();
                res = oracmd.Parameters["p_response"].Value.ToString();
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //
        public static DataTable GraphAndCount(string from)
        {
            SqlConnection Oraconn = null;
            SqlCommand oracmd = new SqlCommand();
            string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
            Oraconn = new SqlConnection(consString);
            oracmd.CommandText = "GraphAndCount";
            oracmd.Parameters.AddWithValue("@from", from);
            oracmd.Connection = Oraconn;
            oracmd.CommandType = CommandType.StoredProcedure;
            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(oracmd);
            adp.Fill(dt);
            Oraconn.Close();

            return dt;
        }

        //exec  '2021-08-20' ,'2021-08-25'

        //
        public static DataTable dateFilter(string start, string end, string user)
        {
            SqlConnection Oraconn = null;
            SqlCommand oracmd = new SqlCommand();
            string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
            Oraconn = new SqlConnection(consString);

            if (start == "no" && end == "no")
            {
                oracmd.CommandText = "dateFilternodate";
                oracmd.Parameters.AddWithValue("@username", user);
                
            }
            else
            {
                oracmd.CommandText = "dateFilter";
                oracmd.Parameters.AddWithValue("@start", start);
                oracmd.Parameters.AddWithValue("@end", end);
                oracmd.Parameters.AddWithValue("@username", user);
            }

            oracmd.Connection = Oraconn;
            oracmd.CommandType = CommandType.StoredProcedure;

            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(oracmd);
            adp.Fill(dt);
            Oraconn.Close();

            return dt;
        }

        public string addNewConfig(string ConnectionName, string DB_SCHEMA, string HOST_ID, string Port_Num, string DB_Name, string DBUSRName, string DB_PWD, string TBL_Name, string Params)
        {
            string res = "|OK";
            string connect = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;
            string dateCreated = DateTime.Now.ToString("yyyy-MM-dd");
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO smsengine.sms_config (ConnectionName, DB_SCHEMA, HOST_ID, Port_Num, DB_Name, DBUSRName, DB_PWD, TBL_Name, Params) ");
            sb.Append("VALUES('" + ConnectionName + "', '" + DB_SCHEMA + "', '" + HOST_ID + "', '" + Port_Num + "', '" + DB_Name + "', '" + DBUSRName + "','" + DB_PWD + "', '" + TBL_Name + "', '" + Params + "')");
            string query = sb.ToString();

            try
            {
                SqlConnection myConn = new SqlConnection(connect);
                SqlCommand myCmd = new SqlCommand(query, myConn);
                myCmd.CommandType = CommandType.Text;

                if (myConn.State == ConnectionState.Closed)
                {
                    myConn.Open();
                }
                myCmd.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }

            return res;
        }

        public Boolean updatePendingTransactFX(string id)
        {
            try
            {
                //
                string build = $"UPDATE [dbo].[FXTransfer_Log] SET [Status] = 'SUCCESS', [ConfirmationState] = 'SUCCESS', [LastUpdateTime] =  '{DateTime.Now.ToString("yyyy-MM-dd")}' WHERE [TransRef] = '" + id + "'";
                string consString = ConfigurationManager.ConnectionStrings["FTUPortalConnectionString2view"].ConnectionString;
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand(build, Oraconn);
                if (Oraconn.State != ConnectionState.Open)
                {
                    Oraconn.Open();
                }
                string ret = oracmd.ExecuteNonQuery().ToString();
                Oraconn.Close();
                return true;
            }
            catch (Exception ee)
            {
                return false;
            }
        }

        public Boolean updatePendingTransact(string id)
        {
            try
            {
                //FTUPortalConnectionString2view
                string build = $"UPDATE [dbo].[NEFT_TRANS] SET [Status] = 'SUCCESS', [date_processed] =  '{DateTime.Now.ToString("yyyy-MM-dd")}' WHERE [Log_Seq] = '" + id + "'";
                string consString = ConfigurationManager.ConnectionStrings["Datastringe_OnePLC"].ConnectionString;
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand(build, Oraconn);
                if (Oraconn.State != ConnectionState.Open)
                {
                    Oraconn.Open();
                }
                string ret = oracmd.ExecuteNonQuery().ToString();
                Oraconn.Close();
                return true;
            }
            catch (Exception ee)
            {
                return false;
            }
        }

        public string filter(string group, string startdate, string enddate)
        {
            string build = $"UPDATE [dbo].[NEFT_TRANS] SET [Status] = 'SUCCESS', [time_updated] = FORMAT(GETDATE(),'yyyy-mm-dd') WHERE [Log_Seq] = '{group}'";
            string consString = ConfigurationManager.ConnectionStrings["Datastringe_OnePLC"].ConnectionString;
            SqlConnection Oraconn = new SqlConnection(consString);
            SqlCommand oracmd = new SqlCommand(build, Oraconn);
            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }
            string ret = oracmd.ExecuteNonQuery().ToString();
            Oraconn.Close();
            return ret;
        }

        public DataSet Filterbtn(string group, string datetype, string datesearch)
        {
            string build = string.Empty;

            if (datesearch == "")
            {
                build = $"SELECT * FROM NEFT_TRANS  WHERE [Status] LIKE '%{group}%'";
            }
            else
            {
                build = $"SELECT * FROM NEFT_TRANS  WHERE [Status] LIKE '%{group}%' AND CAST ([{datetype}] AS date) = '{datesearch}'";
            }
            string consString = ConfigurationManager.ConnectionStrings["Datastringe_OnePLC"].ConnectionString;
            SqlConnection Oraconn = new SqlConnection(consString);
            SqlCommand oracmd = new SqlCommand(build, Oraconn);
            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }

            SqlDataAdapter oda = new SqlDataAdapter(oracmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            Oraconn.Close();
            return ds;
        }

        public string addNewUser(string FirstName, string LastName, string email, string user_role, string username, string created_by, string date_created)
        {
            string res = "|OK";
            string connect = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;
            string dateCreated = DateTime.Now.ToString("yyyy-MM-dd");
            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO USERS (FIRST_NAME, LAST_NAME, EMAIL, USER_ROLE, USER_NAME, CREATED_BY, DATE_CREATED) ");
            sb.Append("VALUES('" + FirstName + "', '" + LastName + "', '" + email + "', '" + user_role + "', '" + username + "', '" + created_by + "', '" + date_created + "')");
            string query = sb.ToString();

            try
            {
                SqlConnection myConn = new SqlConnection(connect);
                SqlCommand myCmd = new SqlCommand(query, myConn);
                myCmd.CommandType = CommandType.Text;

                if (myConn.State == ConnectionState.Closed)
                {
                    myConn.Open();
                }
                myCmd.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }

            return res;
        }

        public string DeleteUser(int id)
        {
            string res = "|OK";
            string connect = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;
            string dateCreated = DateTime.Now.ToString("yyyy-MM-dd");
            StringBuilder sb = new StringBuilder();

            sb.Append("DELETE FROM USERS WHERE LOG_SEQ = " + id);
            string query = sb.ToString();

            try
            {
                SqlConnection myConn = new SqlConnection(connect);
                SqlCommand myCmd = new SqlCommand(query, myConn);
                myCmd.CommandType = CommandType.Text;

                if (myConn.State == ConnectionState.Closed)
                {
                    myConn.Open();
                }
                myCmd.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }

            return res;
        }

        public string UpdatePendingTrans(string id, string resp, string usrid)
        {
            string res = "|OK";
            string connect = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;
            string dateCreated = DateTime.Now.ToString("yyyy-MM-dd");
            StringBuilder sb = new StringBuilder();

            sb.Append("update [e_OnePLC].[dbo].[NEFT_TRANS] SET [Status]  = '" + resp + "', [processed_by] = '" + usrid + "', [date_processed] = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ");
            sb.Append("WHERE Log_Seq = '" + id + "'");
            string query = sb.ToString();

            try
            {
                SqlConnection myConn = new SqlConnection(connect);
                SqlCommand myCmd = new SqlCommand(query, myConn);
                myCmd.CommandType = CommandType.Text;

                if (myConn.State == ConnectionState.Closed)
                {
                    myConn.Open();
                }
                myCmd.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }

            return res;
        }

        public string UpdateUser(string FirstName, string LastName, string email, string user_role, string username, int id)
        {
            string res = "|OK";
            string connect = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;
            string dateCreated = DateTime.Now.ToString("yyyy-MM-dd");
            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE USERS SET ");
            sb.Append("FIRST_NAME = '" + FirstName + "', ");
            sb.Append("LAST_NAME = '" + LastName + "', ");
            sb.Append("EMAIL = '" + email + "', ");
            sb.Append("USER_ROLE = '" + user_role + "', ");
            sb.Append("USER_NAME = '" + username + "' ");
            sb.Append("WHERE LOG_SEQ = '" + id + "'");
            string query = sb.ToString();

            try
            {
                SqlConnection myConn = new SqlConnection(connect);
                SqlCommand myCmd = new SqlCommand(query, myConn);
                myCmd.CommandType = CommandType.Text;

                if (myConn.State == ConnectionState.Closed)
                {
                    myConn.Open();
                }
                myCmd.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }

            return res;
        }

        public DataTable getAllDates()
        {
            string connect = ConfigurationManager.ConnectionStrings["FTUPortalConnectionString"].ConnectionString;

            try
            {
                SqlConnection myConn = new SqlConnection(connect);
                SqlCommand myCmd = new SqlCommand("getAllDates", myConn);

                DataTable dt = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(myCmd);

                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        //
        //

        public DataSet getUssdUsersData()
        {
            string res = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string consString = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;

            string query = "SELECT LOG_SEQ ID,FIRST_NAME FirstName, LAST_NAME LastName, EMAIL email, USER_ROLE user_role, [USER_NAME] username, CREATED_BY created_by, DATE_CREATED date_created, LAST_LOGIN last_login FROM [DB_GTB_WEB].[dbo].[USERS]";

            //StringBuilder sb = new StringBuilder();
            //string queryStr = "SELECT ID, ConnectionName, DB_SCHEMA, HOST_ID, Port_Num, DB_Name, DBUSRName, DB_PWD, TBL_Name, Params FROM smsengine.sms_config";
            try
            {
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand(query.ToString(), Oraconn);

                if (Oraconn.State == ConnectionState.Closed)
                {
                    Oraconn.Open();
                }

                SqlDataAdapter oda = new SqlDataAdapter(oracmd);
                oda.Fill(ds);
                Oraconn.Close();
            }
            catch (Exception ex)
            {
            }

            return ds;
        }

        public string UpdateUserLogin(string ID)
        {
            string res = "|OK";
            string connect = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
            string datelogin = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE USERS SET LAST_LOGIN = '" + datelogin + "' WHERE LOG_SEQ = '" + ID + "'");
            string query = sb.ToString();

            try
            {
                SqlConnection myConn = new SqlConnection(connect);
                SqlCommand myCmd = new SqlCommand(query, myConn);
                myCmd.CommandType = CommandType.Text;

                if (myConn.State == ConnectionState.Closed)
                {
                    myConn.Open();
                }
                myCmd.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }

            return res;
        }

        public DataSet getUsers(string userName)
        {
            string res = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;

            //string query = "SELECT * FROM [ITAS_DB].[dbo].[USERS] WHERE USER_NAME = '" + userName + "'";

            try
            {
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand("getUserDetail2", Oraconn);
                oracmd.CommandType = CommandType.StoredProcedure;
                oracmd.Parameters.Add("@user_name", SqlDbType.VarChar).Value = userName;
                if (Oraconn.State == ConnectionState.Closed)
                {
                    Oraconn.Open();
                }
                
                SqlDataAdapter oda = new SqlDataAdapter(oracmd);
                oda.Fill(ds);
                Oraconn.Close();
            }
            catch (Exception ex)
            {
            }

            return ds;
        }

        public string counter(string val)
        {
            string consString = ConfigurationManager.ConnectionStrings["Datastringe_OnePLC"].ConnectionString;
            SqlConnection Oraconn = new SqlConnection(consString);
            SqlCommand oracmd = new SqlCommand("countEonePlc", Oraconn);
            oracmd.CommandType = CommandType.StoredProcedure;
            oracmd.Parameters.AddWithValue("@status", val);

            if (Oraconn.State == ConnectionState.Closed)
            {
                Oraconn.Open();
            }
            string count = oracmd.ExecuteScalar().ToString();
            Oraconn.Close();
            return count;
        }

        public DataSet getPendingFXTrans(string ddlpfsfilters = null, string ddldatefilters = null, string txtsearchText = null)
        {
            string res = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string consString = ConfigurationManager.ConnectionStrings["FTUPortalConnectionString2view"].ConnectionString;

            string query = ddldatefilters == null ? $"initFTPortal 'PENDING'" : $"searchFTPortal '{ddlpfsfilters}','{ddldatefilters}','{txtsearchText}'";

            try
            {
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand(query.ToString(), Oraconn);

                if (Oraconn.State == ConnectionState.Closed)
                {
                    Oraconn.Open();
                }

                SqlDataAdapter oda = new SqlDataAdapter(oracmd);
                oda.Fill(ds);
                Oraconn.Close();
            }
            catch (Exception ex)
            {
            }

            return ds;
        }

        public DataSet getOtherBankPendingTrans()
        {
            string res = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string consString = ConfigurationManager.ConnectionStrings["Datastringe_OnePLC"].ConnectionString;

            string query = "SELECT * FROM [e_OnePLC].[dbo].[NEFT_TRANS] WHERE [Status] = 'PENDING'";

            try
            {
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand(query.ToString(), Oraconn);

                if (Oraconn.State == ConnectionState.Closed)
                {
                    Oraconn.Open();
                }

                SqlDataAdapter oda = new SqlDataAdapter(oracmd);
                oda.Fill(ds);
                Oraconn.Close();
            }
            catch (Exception ex)
            {
            }

            return ds;
        }

        public DataSet getOtherBankPendingTrans(string id)
        {
            string res = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            string consString = String.Empty;
            string query = String.Empty;

            if (id.IndexOf("[FTUPortal].[dbo].[FXTransfer_Log]") > -1)
            {
                consString = ConfigurationManager.ConnectionStrings["FTUPortalConnectionString"].ConnectionString;
                query = id;
            }
            else
            {
                consString = ConfigurationManager.ConnectionStrings["Datastringe_OnePLC"].ConnectionString;
                query = "SELECT * FROM [e_OnePLC].[dbo].[NEFT_TRANS] WHERE Log_Seq = '" + id + "'";
            }

            try
            {
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand(query.ToString(), Oraconn);

                if (Oraconn.State == ConnectionState.Closed)
                {
                    Oraconn.Open();
                }

                SqlDataAdapter oda = new SqlDataAdapter(oracmd);
                oda.Fill(ds);
                Oraconn.Close();
            }
            catch (Exception ex)
            {
            }

            return ds;
        }

        public DataSet getUssdReportData()
        {
            string res = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string consString = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;

            string query = "SELECT Id, TransactionType AS TransType,	Beneficiary, 	BeneficiaryAccount AS BeneAcct, Payee, 	PayeeAccount, Amount,TransactionDate,  CASE  WHEN Status = '0' THEN \"Success\"   ELSE \"Failed\"   END AS Status FROM report.banktransactions LIMIT 0, 1000";

            //StringBuilder sb = new StringBuilder();
            //string queryStr = "SELECT ID, ConnectionName, DB_SCHEMA, HOST_ID, Port_Num, DB_Name, DBUSRName, DB_PWD, TBL_Name, Params FROM smsengine.sms_config";
            try
            {
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand(query.ToString(), Oraconn);

                if (Oraconn.State == ConnectionState.Closed)
                {
                    Oraconn.Open();
                }

                SqlDataAdapter oda = new SqlDataAdapter(oracmd);
                oda.Fill(ds);
                Oraconn.Close();
            }
            catch (Exception ex)
            {
            }

            return ds;
        }

        public DataSet getUssdReportData(string id)
        {
            string res = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string consString = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT  Id, TransactionType, Beneficiary, BeneficiaryAccount, Payee, PayeeAccount, ");

            sb.Append("Amount, TransactionDate, CASE WHEN Status = '0' THEN \"Success\" ELSE \"Failed\" END AS Status, ");
            sb.Append("TransactionMessage AS Description, CASE WHEN Currency = '2' THEN \"USD\" WHEN Currency = '1' THEN \"LRD\" ELSE \"\" END AS ");
            sb.Append("Currency, TransactionID	FROM report.banktransactions WHERE Id = '" + id + "'");
            //string query = "SELECT Id, TransactionType AS TransType,	Beneficiary, 	BeneficiaryAccount AS BeneAcct, Payee, 	PayeeAccount, Amount,TransactionDate,  CASE  WHEN Status = '0' THEN \"Success\"   ELSE \"Failed\"   END AS Status FROM report.banktransactions WHERE Id = "+ id;

            //StringBuilder sb = new StringBuilder();
            //string queryStr = "SELECT ID, ConnectionName, DB_SCHEMA, HOST_ID, Port_Num, DB_Name, DBUSRName, DB_PWD, TBL_Name, Params FROM smsengine.sms_config";
            try
            {
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand(sb.ToString(), Oraconn);

                if (Oraconn.State == ConnectionState.Closed)
                {
                    Oraconn.Open();
                }

                SqlDataAdapter oda = new SqlDataAdapter(oracmd);
                oda.Fill(ds);
                Oraconn.Close();
            }
            catch (Exception ex)
            {
            }

            return ds;
        }

        public string getTotalAirtimeSuccess()
        {
            string res = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string consString = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;

            string query = "SELECT 	COUNT(*) AS Airtime FROM report.banktransactions WHERE TransactionType = 'AIRTIME' AND Status = 0";

            //StringBuilder sb = new StringBuilder();
            //string queryStr = "SELECT ID, ConnectionName, DB_SCHEMA, HOST_ID, Port_Num, DB_Name, DBUSRName, DB_PWD, TBL_Name, Params FROM smsengine.sms_config";
            try
            {
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand(query.ToString(), Oraconn);

                if (Oraconn.State == ConnectionState.Closed)
                {
                    Oraconn.Open();
                }

                SqlDataAdapter oda = new SqlDataAdapter(oracmd);
                oda.Fill(ds);
                Oraconn.Close();

                DataTable dtt = ds.Tables[0];
                foreach (DataRow dr in dtt.Rows)
                {
                    res = dr["Airtime"].ToString();
                }
            }
            catch (Exception ex)
            {
            }

            return res;
        }

        public static bool saveBBanTOAccNumExcel(string uploader, string url)
        {
            string consString = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;
            try
            {
                SqlConnection Oraconn = new SqlConnection(consString);
                if (Oraconn.State == ConnectionState.Closed)
                {
                    Oraconn.Open();
                    SqlCommand oracmd = new SqlCommand("ExcelBBAN_TO_AccNum", Oraconn);
                    oracmd.CommandType = CommandType.StoredProcedure;
                    oracmd.Parameters.AddWithValue("@uploader", uploader);
                    oracmd.Parameters.AddWithValue("@url", url);
                    oracmd.ExecuteNonQuery();
                    Oraconn.Close();
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public string getTotalTransferSuccess()
        {
            string res = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string consString = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;

            string query = "SELECT 	COUNT(*) AS TRSF FROM report.banktransactions WHERE TransactionType = 'TRSF' AND Status = 0";

            //StringBuilder sb = new StringBuilder();
            //string queryStr = "SELECT ID, ConnectionName, DB_SCHEMA, HOST_ID, Port_Num, DB_Name, DBUSRName, DB_PWD, TBL_Name, Params FROM smsengine.sms_config";
            try
            {
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand(query.ToString(), Oraconn);

                if (Oraconn.State == ConnectionState.Closed)
                {
                    Oraconn.Open();
                }

                SqlDataAdapter oda = new SqlDataAdapter(oracmd);
                oda.Fill(ds);
                Oraconn.Close();

                DataTable dtt = ds.Tables[0];
                foreach (DataRow dr in dtt.Rows)
                {
                    res = dr["TRSF"].ToString();
                }
            }
            catch (Exception)
            {
            }

            return res;
        }

        public string getTotalTransferFailed()
        {
            string res = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string consString = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;

            string query = "SELECT 	COUNT(*) AS TRSF FROM report.banktransactions WHERE TransactionType = 'TRSF' AND Status != 0";

            //StringBuilder sb = new StringBuilder();
            //string queryStr = "SELECT ID, ConnectionName, DB_SCHEMA, HOST_ID, Port_Num, DB_Name, DBUSRName, DB_PWD, TBL_Name, Params FROM smsengine.sms_config";
            try
            {
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand(query.ToString(), Oraconn);

                if (Oraconn.State == ConnectionState.Closed)
                {
                    Oraconn.Open();
                }

                SqlDataAdapter oda = new SqlDataAdapter(oracmd);
                oda.Fill(ds);
                Oraconn.Close();

                DataTable dtt = ds.Tables[0];
                foreach (DataRow dr in dtt.Rows)
                {
                    res = dr["TRSF"].ToString();
                }
            }
            catch (Exception)
            {
            }

            return res;
        }

        public string getTotalAirtimeFailed()
        {
            string res = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string consString = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;

            string query = "SELECT 	COUNT(*) AS Airtime FROM report.banktransactions WHERE TransactionType = 'AIRTIME' AND Status != 0";

            //StringBuilder sb = new StringBuilder();
            //string queryStr = "SELECT ID, ConnectionName, DB_SCHEMA, HOST_ID, Port_Num, DB_Name, DBUSRName, DB_PWD, TBL_Name, Params FROM smsengine.sms_config";
            try
            {
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand(query.ToString(), Oraconn);

                if (Oraconn.State == ConnectionState.Closed)
                {
                    Oraconn.Open();
                }

                SqlDataAdapter oda = new SqlDataAdapter(oracmd);
                oda.Fill(ds);
                Oraconn.Close();

                DataTable dtt = ds.Tables[0];
                foreach (DataRow dr in dtt.Rows)
                {
                    res = dr["Airtime"].ToString();
                }
            }
            catch (Exception ex)
            {
            }

            return res;
        }

        //

        public static DataTable USSD(string num)
        {
            string consString = ConfigurationManager.ConnectionStrings["USSDConnectionString"].ConnectionString;
            SqlConnection Oraconn = new SqlConnection(consString);
            SqlCommand oracmd = new SqlCommand();
            oracmd.Connection = Oraconn;
            oracmd.CommandText = "ussd";
            oracmd.Parameters.AddWithValue("@num", num);
            oracmd.CommandType = CommandType.StoredProcedure;
            if (Oraconn.State == ConnectionState.Closed)
            {
                Oraconn.Open();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(oracmd);
            db.Fill(dt);
            Oraconn.Close();
            return dt;
        }

        //     exec
        //'<%$ ConnectionStrings: %>'

        public static DataTable initUSSD()
        {
            string consString = ConfigurationManager.ConnectionStrings["USSDConnectionString"].ConnectionString;
            SqlConnection Oraconn = new SqlConnection(consString);
            SqlCommand oracmd = new SqlCommand();
            oracmd.Connection = Oraconn;
            oracmd.CommandText = "initUSSD";
            //oracmd.Parameters.AddWithValue("@dates", date);
            //oracmd.Parameters.AddWithValue("@from", from);
            oracmd.CommandType = CommandType.StoredProcedure;
            if (Oraconn.State == ConnectionState.Closed)
            {
                Oraconn.Open();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(oracmd);
            db.Fill(dt);
            Oraconn.Close();
            return dt;
        }

        public static DataTable EBusinessBigPortaleExcelFile(string from, string startDate, string endDate)
        {
            string consString = ConfigurationManager.ConnectionStrings["Datastringe_OnePLC"].ConnectionString;
            SqlConnection Oraconn = new SqlConnection(consString);
            SqlCommand oracmd = new SqlCommand();
            oracmd.Connection = Oraconn;
            oracmd.CommandText = "EBusinessBigPortaleExcelFile";
            oracmd.Parameters.AddWithValue("@startDate", startDate);
            oracmd.Parameters.AddWithValue("@endDate", endDate);
            oracmd.Parameters.AddWithValue("@from", from);
            oracmd.CommandType = CommandType.StoredProcedure;
            if (Oraconn.State == ConnectionState.Closed)
            {
                Oraconn.Open();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(oracmd);
            db.Fill(dt);
            Oraconn.Close();
            return dt;
        }

        public static DataTable downloadExcel(string from, string startDate, string endDate)
        {
            string consString = ConfigurationManager.ConnectionStrings["Datastringe_OnePLC"].ConnectionString;

            SqlConnection Oraconn = new SqlConnection(consString);
            SqlCommand oracmd = new SqlCommand();
            oracmd.Connection = Oraconn;
            oracmd.CommandText = from;
            oracmd.Parameters.AddWithValue("@startDate", startDate);
            oracmd.Parameters.AddWithValue("@endDate", endDate);
            oracmd.Parameters.AddWithValue("@from", from);
            oracmd.CommandType = CommandType.StoredProcedure;
            if (Oraconn.State == ConnectionState.Closed)
            {
                Oraconn.Open();
            }
            DataTable dt = new DataTable(DateTime.Now.ToString("dd_MMM_yyyy"));
            SqlDataAdapter db = new SqlDataAdapter(oracmd);
            db.Fill(dt);
            Oraconn.Close();
            return dt;
        }

        public static SByte Clear(string num)
        {
            string consString = ConfigurationManager.ConnectionStrings["USSDConnectionString"].ConnectionString;
            SqlConnection Oraconn = new SqlConnection(consString);
            SqlCommand oracmd = new SqlCommand();
            oracmd.Connection = Oraconn;
            oracmd.CommandText = "clearUssd";
            oracmd.Parameters.AddWithValue("@num", num);
            oracmd.CommandType = CommandType.StoredProcedure;
            if (Oraconn.State == ConnectionState.Closed)
            {
                Oraconn.Open();
            }
            SByte res = (SByte)Convert.ToByte(oracmd.ExecuteNonQuery().ToString());
            Oraconn.Close();
            return res;
        }

        public DataSet getChartData(string query)
        {
            string res = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            string consString = ConfigurationManager.ConnectionStrings["Datastring"].ConnectionString;

            //StringBuilder sb = new StringBuilder();
            //string queryStr = "SELECT ID, ConnectionName, DB_SCHEMA, HOST_ID, Port_Num, DB_Name, DBUSRName, DB_PWD, TBL_Name, Params FROM smsengine.sms_config";
            try
            {
                SqlConnection Oraconn = new SqlConnection(consString);
                SqlCommand oracmd = new SqlCommand(query.ToString(), Oraconn);

                if (Oraconn.State == ConnectionState.Closed)
                {
                    Oraconn.Open();
                }

                SqlDataAdapter oda = new SqlDataAdapter(oracmd);
                oda.Fill(ds);
                Oraconn.Close();
            }
            catch (Exception ex)
            {
            }

            return ds;
        }

        internal static void deleteUser(string v, string v1)
        {
            //  as varchar(100),  as varchar(100)
            SqlConnection Oraconn = null;
            SqlCommand oracmd = new SqlCommand();
            string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
            Oraconn = new SqlConnection(consString);
            oracmd.CommandText = "delteUser";
            oracmd.Parameters.AddWithValue("@email", v);
            oracmd.Parameters.AddWithValue("@name", v1);
            oracmd.Connection = Oraconn;
            oracmd.CommandType = CommandType.StoredProcedure;
            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }
            oracmd.ExecuteScalar();
            Oraconn.Close();
        }

        internal static string getCount(string from,string role, string val)
        {
            //2021 - 07 - 16
            //string date = DateTime.Now.ToString("yyyy-MM-dd");
            string date = "2021-09-14";
            SqlConnection Oraconn = null;
            SqlCommand oracmd = new SqlCommand();
            string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
            Oraconn = new SqlConnection(consString);
            oracmd.CommandText = "getTotalfinal";
            oracmd.Parameters.AddWithValue("@date", date);
            oracmd.Parameters.AddWithValue("@branch", from);
            oracmd.Parameters.AddWithValue("@telBraaud", role);
            oracmd.Parameters.AddWithValue("@telBraID", val);
            oracmd.Connection = Oraconn;
            oracmd.CommandType = CommandType.StoredProcedure;
            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }
            string total = oracmd.ExecuteScalar().ToString();
            Oraconn.Close();
            return total;
        }
        internal static DataTable dateFilter(string text)
        {


            SqlConnection Oraconn = null;
            SqlCommand oracmd = new SqlCommand();
            string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
            Oraconn = new SqlConnection(consString);


            oracmd.CommandText = "getUser";
            oracmd.Parameters.AddWithValue("@name", text);


            oracmd.Connection = Oraconn;
            oracmd.CommandType = CommandType.StoredProcedure;

            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(oracmd);
            adp.Fill(dt);
            Oraconn.Close();

            return dt;
        }

        internal static DataTable getPendingApproval(string bra_code)
        {


            SqlConnection Oraconn = null;
            SqlCommand oracmd = new SqlCommand();
            string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
            Oraconn = new SqlConnection(consString);

           // bra_code = "001";
            oracmd.CommandText = "SP_GET_BRA_PENDING_APPROVAL";
            oracmd.Parameters.AddWithValue("@bra_code", bra_code);


            oracmd.Connection = Oraconn;
            oracmd.CommandType = CommandType.StoredProcedure;

            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(oracmd);
            adp.Fill(dt);
            Oraconn.Close();

            return dt;
        }


      
        internal static string location( string branch_name, string collection_act, string created_by,string bra_code)
        {
            string result = string.Empty;
            try
            {
                SqlConnection Oraconn = null;
                SqlCommand oracmd = new SqlCommand();
                string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
                Oraconn = new SqlConnection(consString);
                oracmd.CommandText = "location";
                oracmd.Parameters.AddWithValue("@branch_name", branch_name);
                oracmd.Parameters.AddWithValue("@collection_act", collection_act);
                oracmd.Parameters.AddWithValue("@created_by", created_by);


                //Random rd = new Random();
                //string bracode = rd.Next(1, 10).ToString();
                oracmd.Parameters.AddWithValue("@bra_code", bra_code);


                oracmd.Connection = Oraconn;
                oracmd.CommandType = CommandType.StoredProcedure;
                if (Oraconn.State != ConnectionState.Open)
                {
                    Oraconn.Open();
                }
                //DataTable dt = new DataTable();
                //SqlDataAdapter adp = new SqlDataAdapter(oracmd);
                //adp.Fill(dt);
                result = (string) oracmd.ExecuteScalar();
                Oraconn.Close();
                return result;
            }catch(Exception ex)
            {
                return result;
            }
        }




        internal static void createUser(string fName, string lname, string email, string username, string role, string createby, string tiltbox,string branch)
        {
            SqlConnection Oraconn = null;
            SqlCommand oracmd = new SqlCommand();
            string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
            Oraconn = new SqlConnection(consString);
            oracmd.CommandText = "createUser";
            oracmd.Parameters.AddWithValue("@fName", fName);
            oracmd.Parameters.AddWithValue("@lName", lname);
            oracmd.Parameters.AddWithValue("@email", email);
            oracmd.Parameters.AddWithValue("@username", username);
            oracmd.Parameters.AddWithValue("@role", role);
            oracmd.Parameters.AddWithValue("@tiltbox", tiltbox);
            oracmd.Parameters.AddWithValue("@creeatedby", createby);
            oracmd.Parameters.AddWithValue("@branch", branch);

            oracmd.Connection = Oraconn;
            oracmd.CommandType = CommandType.StoredProcedure;
            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(oracmd);
            adp.Fill(dt);
            Oraconn.Close();

        }
        public static DataTable getSelectedRowUser(string refs)
        {
            SqlConnection Oraconn = null;
            SqlCommand oracmd = new SqlCommand();
            string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
            Oraconn = new SqlConnection(consString);
            oracmd.CommandText = "getUserDetail";
            oracmd.Parameters.AddWithValue("@detail", refs);
            oracmd.Connection = Oraconn;
            oracmd.CommandType = CommandType.StoredProcedure;
            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }

            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(oracmd);
            adp.Fill(dt);
            Oraconn.Close();

            return dt;
        }





        public static DataTable getSelectedRowUserApproval(string refs)
        {
            SqlConnection Oraconn = null;
            SqlCommand oracmd = new SqlCommand();
            string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
            Oraconn = new SqlConnection(consString);
            oracmd.CommandText = "getTransDetailApproval";
            oracmd.Parameters.AddWithValue("@detail", refs);
            oracmd.Connection = Oraconn;
            oracmd.CommandType = CommandType.StoredProcedure;
            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }

            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(oracmd);
            adp.Fill(dt);
            Oraconn.Close();

            return dt;
        }











        public static DataTable getSelectedRow_r(string tin, string prn)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT [PaymentAmount] as allottedAmount,[Prn],[PaymentPurpose] as  documentType,[TaxPeriod] as taxPeriod,[TaxType] as taxType,[docRefNum]as documentReference ");
            sb.AppendLine("FROM [ITAS_DB].[dbo].[NRA_TRANSACTION] Where Prn = '"+ prn +"' AND Tin = '"+ tin +"' ");
            sb.AppendLine("Group By [PaymentAmount] ,[Prn],[PaymentPurpose] ,[TaxPeriod],[TaxType] ,[docRefNum]");
            //sb.AppendLine(",[BankName] as [Bank Name],[BankReferenceNumber] as [Bank Ref.Num.],[TransStatus] as [Trans.Status],[PaymentPurpose] as [Payment Purpose]");
            //sb.AppendLine(",[TaxPeriod] as [Tax Period],[TaxType] as [Tax Type],[TaxPayerName] as [Tax Payer Name],[DailyBatchID] as [Daily Batch ID] FROM[ITAS_DB].[dbo].[NRA_TRANSACTION] where [Log_seq] = " + refs);
            // Oraconn = null;

            string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
            SqlConnection Oraconn = new SqlConnection(consString);
            SqlCommand oracmd = new SqlCommand(sb.ToString(), Oraconn);
            //oracmd.CommandText = sb.ToString();
            oracmd.CommandType = CommandType.Text;
            //oracmd.Parameters.Add("@ref", SqlDbType.VarChar, 100).Value = refs;
            //oracmd.Connection = Oraconn;

            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(oracmd);
            adp.Fill(dt);
            Oraconn.Close();

            return dt;
        }

        public static DataTable getSelectedRow(string refs)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT [Tin],[DateOfPayment] as [Date Of Payment],[ModeOfPayment] as [Mode Ff Payment]");
            sb.AppendLine(",[PaymentAmount] as [Payment Amount],[Prn] as [PRN],[ReceiptNumber] as [Receipt Number]");
            sb.AppendLine(",[BankName] as [Bank Name],[BankReferenceNumber] as [Bank Ref.Num.],[TransStatus] as [Trans.Status],[PaymentPurpose] as [Payment Purpose]");
            sb.AppendLine(",[TaxPeriod] as [Tax Period],[TaxType] as [Tax Type],[TaxPayerName] as [Tax Payer Name],[DailyBatchID] as [Daily Batch ID] FROM[ITAS_DB].[dbo].[NRA_TRANSACTION] where [Log_seq] = "+ refs);
            // Oraconn = null;
           
            string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
            SqlConnection Oraconn = new SqlConnection(consString);
            SqlCommand oracmd = new SqlCommand(sb.ToString(), Oraconn);
            //oracmd.CommandText = sb.ToString();
            oracmd.CommandType = CommandType.Text;
            //oracmd.Parameters.Add("@ref", SqlDbType.VarChar, 100).Value = refs;
            //oracmd.Connection = Oraconn;
            
            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(oracmd);
            adp.Fill(dt);
            Oraconn.Close();

            return dt;
        }


        public static DataTable getSelectedRows(string refs)
        {
            SqlConnection Oraconn = null;
            SqlCommand oracmd = new SqlCommand();
            string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
            Oraconn = new SqlConnection(consString);
            oracmd.CommandText = "getSelectedRow";
            oracmd.Parameters.AddWithValue("@ref", refs);
            oracmd.Connection = Oraconn;
            oracmd.CommandType = CommandType.StoredProcedure;
            if (Oraconn.State != ConnectionState.Open)
            {
                Oraconn.Open();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(oracmd);
            adp.Fill(dt);
            Oraconn.Close();

            return dt;
        }

        //internal static void createUser(string fName, string lname, string email, string username, string role, string createby, string tiltbox)
        //{
        //    SqlConnection Oraconn = null;
        //    SqlCommand oracmd = new SqlCommand();
        //    string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
        //    Oraconn = new SqlConnection(consString);
        //    oracmd.CommandText = "createUser";
        //    oracmd.Parameters.AddWithValue("@fName", fName);
        //    oracmd.Parameters.AddWithValue("@lName", lname);
        //    oracmd.Parameters.AddWithValue("@email", email);
        //    oracmd.Parameters.AddWithValue("@username", username);
        //    oracmd.Parameters.AddWithValue("@role", role);
        //    oracmd.Parameters.AddWithValue("@tiltbox", tiltbox);
        //    oracmd.Parameters.AddWithValue("@creeatedby", createby);


        //    oracmd.Connection = Oraconn;
        //    oracmd.CommandType = CommandType.StoredProcedure;
        //    if (Oraconn.State != ConnectionState.Open)
        //    {
        //        Oraconn.Open();
        //    }
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter adp = new SqlDataAdapter(oracmd);
        //    adp.Fill(dt);
        //    Oraconn.Close();

        //}


        internal static DataTable report( string from, string begin, string end,string name)
        { 
            try
            {
                SqlConnection Oraconn = null;
                SqlCommand oracmd = new SqlCommand();
                string consString = ConfigurationManager.ConnectionStrings["ITAS_DBConnectionString"].ConnectionString;
                Oraconn = new SqlConnection(consString);
                oracmd.CommandText = "reports";
                 
                oracmd.Connection = Oraconn;
                oracmd.CommandType = CommandType.StoredProcedure; 
                oracmd.Parameters.AddWithValue("@from", from);
                oracmd.Parameters.AddWithValue("@begin", begin);
                oracmd.Parameters.AddWithValue("@end", end);
                oracmd.Parameters.AddWithValue("@name", name);
                if (Oraconn.State != ConnectionState.Open)
                {
                    Oraconn.Open();
                }
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(oracmd);
                adp.Fill(dt);
                Oraconn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
    }
}