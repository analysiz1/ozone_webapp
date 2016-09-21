using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ozoneserviceapp
{
    public partial class testpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            Response.Write(id);

            int a = 5;
            int b = 4;
            int c = 2;

            a = a + b + c;
            Response.Write("a:"+ a);
            b++;
            c = a + c;
            b = ++b + c++;
            Response.Write("b:" + b);


            Response.Write("result a:" + a);
            Response.Write("result b:" + b);
            Response.Write("result c:" + c);




        }
    }
}