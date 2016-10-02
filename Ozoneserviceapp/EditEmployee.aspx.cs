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
    public partial class EditEmployee : System.Web.UI.Page
    {
        public DataTable dtEmployee = null;
        Connection_SQLServer conSql = new Connection_SQLServer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!lblID.Text.Equals(Request.QueryString["id"]))
            {
                int id = int.Parse(Request.QueryString["id"]);
                string sql = "select * from tbEmployee where Emp_id = " + id + ";";

                dtEmployee = conSql.SqlQuery(sql);

                if (dtEmployee != null && dtEmployee.Rows.Count != 0)
                {
                    lblID.Text = Request.QueryString["id"];
                    ddlTitle.SelectedItem.Text = dtEmployee.Rows[0]["Emp_title"].ToString();
                    txtName.Text = dtEmployee.Rows[0]["Emp_name"].ToString();
                    ddlRole.SelectedValue = dtEmployee.Rows[0]["Emp_position"].ToString();
                    ddlDropin.SelectedValue = dtEmployee.Rows[0]["Emp_province"].ToString();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string _msgErr = CheckDataBeforeRun();

                if (_msgErr != null)
                {
                    RegisterClientScriptBlock("OnLoad", "<script>alert('" + _msgErr + "!')</script>");
                    return;
                }

                int id = int.Parse(Request.QueryString["id"]);
                string title = ddlTitle.SelectedItem.ToString();
                string name = txtName.Text;
                string position = ddlRole.SelectedValue.ToString();
                string province = ddlDropin.SelectedValue.ToString();

                string sql = "";

                bool chk = conSql.UpdateData(sql);

                if (chk)
                {
                    //Response.Write("<script>alert('Complete!')</script>");
                    RegisterClientScriptBlock("OnLoad", "<script>alert('Edit Complete!')</script>");
                    //Response.Redirect("Training_Record.aspx");

                }
                else
                {
                    //Response.Write("<script>alert('Save Fail!')</script>");
                    RegisterClientScriptBlock("OnLoad", "<script>alert('Edit Fail!')</script>");
                    //Response.Redirect("Training_Record.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message.ToString()) + "')</script>");
            }
        }

        private string CheckDataBeforeRun()
        {
            try
            {
                string _msgErr = null;

                if(ddlTitle.SelectedIndex == -1)
                {
                    _msgErr = "กรุณาเลือกคำนำหน้า";
                }
                else if(txtName.Text.Trim().Length == 0)
                {
                    _msgErr = "กรุณากรอกชื่อและนามสกุล";
                }
                else if(ddlRole.SelectedIndex == -1)
                {
                    _msgErr = "กรุณาเลือกตำแหน่ง";
                }
                else if(ddlDropin.SelectedIndex == -1)
                {
                    _msgErr = "กรุณาเลือก Dropin";
                }

                return _msgErr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}