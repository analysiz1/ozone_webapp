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
            int id = int.Parse(Request.QueryString["id"]);
            string sql = "select * from tbTrainning where Trainning_id = " + id + ";";
            
            dtTraining = conSql.SqlQuery(sql);

            txtTitle.Text = dtTraining.Rows[0]["Trainning_name"].ToString();
            txtOwner.Text = dtTraining.Rows[0]["Trainning_owner"].ToString();
            txtAddress.Text = dtTraining.Rows[0]["Trainning_address"].ToString();
            txtStartDate.Text = dtTraining.Rows[0]["Trainning_startdate"].ToString();
            txtEndDate.Text = dtTraining.Rows[0]["Trainning_enddate"].ToString();
            txtParticipant.Text = dtTraining.Rows[0]["Trainning_amount"].ToString();
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

                string owner = txtOwner.Text;
                string address = txtAddress.Text;
                string startdate = "1/1/2559";
                string enddate = "2/1/2559";
                string participant = txtParticipant.Text;
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
                else if (txtParticipant.Text.Trim().Length == 0)
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