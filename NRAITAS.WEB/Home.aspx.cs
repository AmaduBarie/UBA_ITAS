using System;
using System.Data;

namespace NRA_ITAS
{
    public partial class Home : System.Web.UI.Page
    {
      public  int suc=0;
      public int fai =0;
      public int che =0;
      public int cas =0;

        public int sucp = 0;
        public int faip = 0;
        public int chep = 0;
        public int casp = 0;

        string username = string.Empty;
        string usr_role = string.Empty;
        string bra_code = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = (string)Session["username"];
            usr_role = (string)Session["user_role"];
            bra_code =(string)Session["bra_code"];
             

            if (!IsPostBack)
            {
               // usr_role = (string)Session["user_role"]
                //if (usr_role == "Teller")
                //{
                //    Panel1.Visible = true;
                //    Panel2.Visible = false;
                //    Panel3.Visible = false;
                //    initializeService("Teller", username);
                //}
                //else
                if(!string.IsNullOrEmpty(usr_role))
                {
                    //Panel1.Visible = false;
                    //Panel2.Visible = true;
                    //Panel3.Visible = false;
                    initializeService(usr_role,username);
                }
                else 
                {  
                    Response.Redirect("login.aspx");
                }
                
            }

            

        }




        public void initializeService(string role,string val)
        {


            try
            {


                Session["series"] = string.Empty;
                Session["drilldown"] = string.Empty;

               
                string usr = (string)Session["username"];
                string roles = Session["user_role"].ToString(); 
                if(roles == "Teller")
                {
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    chart(usr);
                }
                else if (roles == "Auditor")
                {
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Panel3.Visible = false;
                    chart(roles);
                }
                else
                {
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                    chart(usr);

                }

                int tot = (int)Int64.Parse(dataconnect.getCount("tot", role, val));

                Session["tot"] = tot;

                suc = (int)Int64.Parse(dataconnect.getCount("suc", role, val));
                fai = (int)Int64.Parse(dataconnect.getCount("fai", role, val));
                che = (int)Int64.Parse(dataconnect.getCount("che", role, val));
                cas = (int)Int64.Parse(dataconnect.getCount("cas", role, val));

                nratranss.DataSource = init();
                nratranss.DataBind();



                if (suc > 0)
                {
                    sucp = (suc * 100) / tot;
                }
                else
                {
                    sucp = 0;
                }

                if (fai > 0)
                {
                    faip = (fai * 100) / tot;
                }
                else
                {
                    faip = 0;
                }

                if (che > 0)
                {
                    chep = (che * 100) / tot;
                }
                else
                {
                    chep = 0;
                }


                if (cas > 0)
                {
                    casp = (cas * 100) / tot;
                }
                else
                {
                    casp = 0;
                }

            }catch(Exception ee)
            {

            }
        }

        protected DataTable init()
        {
            string usr = (string)Session["username"];
            string role = Session["user_role"].ToString();
            DataTable tb = new DataTable();
            if (role == "Auditor")
            {
                tb = dataconnect.report("init", "init", "init", "Auditor");
            }
            else
            {

                tb = dataconnect.report("init", "init", "init", usr);
            }
            return tb;

        }
        protected string convertDate(string date, string from)
        {

            if (date != "1 End Date" && date != "1 Start Date")
            {
                DateTime da = DateTime.ParseExact(date, @"d MMM yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (from == "yes")
                {
                    da = da.AddMonths(1);
                }

                return da.ToString("yyyy-MM-dd");
            }
            else if (from == "no")
            {
                DateTime da = DateTime.Now;

                da = da.AddMonths(-1);

                return da.ToString("yyyy-MM-dd");
            }
            return DateTime.Now.ToString("yyyy-MM-dd");
            //2011 - 10 - 14 17:47:28.370
        }

        protected void chart(string from)
        {

            string series = "";
            string drilldown = "";
            //try
            //{
            
                DataTable dt = dataconnect.GraphAndCount(from);
                string cat = "";

                Boolean firstTime = false;
                foreach (DataRow dr in dt.Rows)
                {
                    string dd = dr["pd"].ToString();

                    if (cat != dr["dd"].ToString())
                    {
                        string cur = dr["dd"].ToString();
                        int yearToal = 0;
                        //drilldown = "";
                        foreach (DataRow drin in dt.Rows)
                        {
                            string crrne = drin["dd"].ToString();
                            if (cur == drin["dd"].ToString())
                            {
                                yearToal = (int)(yearToal + Convert.ToInt64(drin["counts"].ToString()));
                            }
                        }

                        series += $"{{ name:'{cur}',y:{yearToal},drilldown:'{cur}'}},";
                        if (drilldown != "")
                        {
                            drilldown += "]},";
                        }
                        drilldown += $"{{name:'{cur}',id:'{cur}',data:[";
                        if (firstTime == false)
                        {
                            int count = (int)Int64.Parse(dr["counts"].ToString());
                            drilldown += $"['{dr["pd"].ToString()}', {count}],";
                            firstTime = true;
                        }
                    }
                    else
                    {
                        int count = (int)Int64.Parse(dr["counts"].ToString());
                        drilldown += $"['{dr["pd"].ToString()}', {count}],";
                    }
                    cat = dr["dd"].ToString();

                }

                drilldown += "]}";


                Session["series"] = series;
                Session["drilldown"] = drilldown;
                string ss = Session["series"].ToString();
                string drf = Session["drilldown"].ToString();
            }
            //catch (Exception ce)
            //{

            //}
        //}


    }
}