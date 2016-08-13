using Ozoneserviceapp.BaseClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ozoneservice
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Connection_SQLServer sqlCon = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            sqlCon = new Connection_SQLServer(); 
        }

        protected void Btnlogin_Click(object sender, EventArgs e)
        {
            try
            {

                string username = inputUsername.Value;
                string password = inputPassword.Value;

                DataTable dt = sqlCon.GetUser(username, password);

                if (dt.Rows.Count < 1)
                {
                    RegisterClientScriptBlock("OnLoad", "<script>alert('Username or Password Invalid!!')</script>");
                    return;
                }

                Response.Redirect("Mainpage.aspx");

            }
            catch (Exception ex)
            {
                RegisterClientScriptBlock("OnLoad", "<script>alert('"+ex.Message.ToString()+"')</script>");
            }
        }

    }
}