using Ozoneserviceapp.BaseClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ozoneserviceapp
{
    public partial class Training_Manage : System.Web.UI.Page
    {
        public DataTable dtTitleTraining = null;
        Connection_SQLServer conSql = new Connection_SQLServer();

        protected void Page_Load(object sender, EventArgs e)
        {
            dtTitleTraining = conSql.GetTitleTraining();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Training_Record.aspx");
            }
            catch (Exception ex)
            {
                RegisterClientScriptBlock("OnLoad", "<script>alert('" + ex.Message.ToString() + "')</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {

            }
            catch (Exception ex)
            {
                RegisterClientScriptBlock("OnLoad", "<script>alert('" + ex.Message.ToString() + "')</script>");
            }
        }




    }
}