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
    public partial class Training_Edit : System.Web.UI.Page
    {
        public DataTable dtTraining = null;
        Connection_SQLServer conSql = new Connection_SQLServer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!lblID.Text.Equals(Request.QueryString["id"]))
            {
                int id = int.Parse(Request.QueryString["id"]);
                string sql = "select * from tbTrainning where Trainning_id = " + id + ";";

                dtTraining = conSql.SqlQuery(sql);
                lblID.Text = Request.QueryString["id"];
                txtTitle.Text = dtTraining.Rows[0]["Trainning_name"].ToString();
                txtOwner.Text = dtTraining.Rows[0]["Trainning_owner"].ToString();
                txtAddress.Text = dtTraining.Rows[0]["Trainning_address"].ToString();
                DateTime dateStart = Convert.ToDateTime(dtTraining.Rows[0]["Trainning_startdate"].ToString());
                DateTime dateEnd = Convert.ToDateTime(dtTraining.Rows[0]["Trainning_enddate"].ToString());

                txtStartDate.Text = (dateStart.Year + "-" + dateStart.ToString("MM") + "-" + dateStart.ToString("dd")).ToString();
                txtEndDate.Text = (dateEnd.Year + "-" + dateEnd.ToString("MM") + "-" + dateEnd.ToString("dd")).ToString();

                txtParticipant.Text = dtTraining.Rows[0]["Trainning_amount"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
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
                string owner = txtOwner.Text;
                string address = txtAddress.Text;
                string startdate = txtStartDate.Text;
                string enddate = txtEndDate.Text;
                string participant = txtParticipant.Text;

                string sql = "UPDATE dbo.tbTrainning " +
                             "SET " +
                             "Trainning_owner ='"+ owner +"'," +
                             "Trainning_address = '"+address+"'," +
                             "Trainning_startdate = '"+startdate+"'," +
                             "Trainning_enddate = '"+enddate+"'," +
                             "Trainning_amount = "+participant+"," +
                             "Trainning_province = 1 " +
                             "WHERE Trainning_id = " + id;
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
                
                if (txtOwner.Text.Trim().Length == 0)
                {
                    _msgErr = "กรุณากรอกข้อมูลผู้จัดการอบรม";
                }
                else if (txtAddress.Text.Trim().Length == 0)
                {
                    _msgErr = "กรุณากรอกข้อมูลสถานที่การอบรม";
                }
                else if (txtStartDate.Text.Trim().Length == 0)
                {
                    _msgErr = "กรุณาเลือกวันที่เริ่มการอบรม";
                }
                else if (txtEndDate.Text.Trim().Length == 0)
                {
                    _msgErr = "กรุณาเลือกวันที่สิ้นสุดการอบรม";
                }

                DateTime dtStart = Convert.ToDateTime(txtStartDate.Text);
                DateTime dtEnd = Convert.ToDateTime(txtEndDate.Text);

                double totalDay = (dtEnd - dtStart).TotalDays;

                if (totalDay < 0)
                {
                    _msgErr = "กรุณาเลือก วันที่สิ้นสุดอบรม ให้มากกว่าหรือเท่ากับ วันที่เริ่มการอบรม";
                }
                
                if (txtParticipant.Text.Trim().Length == 0)
                {
                    _msgErr = "กรุณากรอกจำนวนผู้เข้าร่วมการอบรม";
                }

                return _msgErr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtAddress.Text = string.Empty;
                txtOwner.Text = string.Empty;
                txtParticipant.Text = string.Empty;
                txtStartDate.Text = string.Empty;
                txtEndDate.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }
    }
}