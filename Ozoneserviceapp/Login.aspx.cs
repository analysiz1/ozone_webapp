using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ozoneservice
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Btnlogin_Click(object sender, EventArgs e)
        {
            string username = inputUsername.Value;
            string password = inputPassword.Value;
            if(username=="admin"&&password=="password@1")
            {               
                Response.Redirect("Mainpage.aspx");
            }
        }

        

        

      
    }
}