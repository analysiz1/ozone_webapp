using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ozoneservice.UI.Training
{
    public partial class Training_Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            /*ddlTitle.Items.Add("การป้องกันเอชไอวี/เอดส์ ครั้งที่ 2");
            ddlTitle.Items.Add("การศึกษา");
            ddlTitle.Items.Add("การป้องกันเอชไอวี/เอดส์ ครั้งที่ 1");*/
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            if (ddlTitle.Items.FindByText("การป้องกันเอชไอวี/เอสด์ ครั้งที่ 1") != null)
            {

                RegisterClientScriptBlock("OnLoad", "<script>alert('TRUE!')</script>");
            }
            else
            {
                RegisterClientScriptBlock("OnLoad", "<script>alert('FALSE!')</script>");
            }

        }


    }
}