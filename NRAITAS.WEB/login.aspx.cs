using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web;

namespace NRA_ITAS
{
    public partial class login : System.Web.UI.Page
    {
        private dataconnect dc = new dataconnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //Session["username"] = null;
               // Session["firstlastname"] = null;
                //Session["user_role"] = null;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUserName.Text.Trim();
                string password = txtPassword.Text.Trim();
                string ID = string.Empty;

                DataSet ds = dc.getUsers(username);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                       Session["username"] = dr["USER_NAME"].ToString();
                       Session["firstlastname"] = dr["FIRST_NAME"].ToString() + " " + dr["LAST_NAME"].ToString();
                       Session["user_role"] = dr["USER_ROLE"].ToString();
                       Session["TILTBOX"] = dr["TILTBOX"].ToString();
                       Session["bra_code"] = dr["BRA_CODE"].ToString();
                       Session["from_acct"] = dr["COLLECTION_ACT"].ToString();
                        ID = dr["LOG_SEQ"].ToString();
                    }
                    bool auth = AuthenticateUserViaAD(username, password);
                    if (auth == true)
                    {
                        dc.UpdateUserLogin(ID);
                        Response.Redirect("Home.aspx");
                        //if ((string)Session["user_role"] == "Teller")
                        //{
                        //    Response.Redirect("Home.aspx");
                        //}
                        //else
                        //{
                        //    Response.Redirect("users.aspx");
                        //}
                    }
                    else
                    {
                        // Response.Redirect("Login.aspx");
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('Invalid Username or Password, Please Contact AccessBank IT-Team.');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('Invalid Username or Password, Please Contact AccessBank IT-Team.');", true);
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script2", "alert('"+ ex.Message +"');", true);
            }
        }

        public Boolean AuthenticateUserViaAD(String UserID, String Password)
        {
            bool res = false;
            try
            {
                UserAuthentication _Auth = new UserAuthentication();
                String _Domain = ConfigurationManager.AppSettings["Domain"].ToString();
                String _LdapPath = ConfigurationManager.AppSettings["LDAP"].ToString();
                res = _Auth.AuthenticeViaAD(
                UserID,
                Password,
                _Domain,
                _LdapPath);

                return res;
            }
            catch (Exception ex)
            {
                return res;
            }
        }
    }
}