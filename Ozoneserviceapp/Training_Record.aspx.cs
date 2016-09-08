using Ozoneserviceapp.BaseClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ozoneservice.UI.Training
{
    public partial class Training_Record : System.Web.UI.Page
    {
        public DataTable dtTitleTraining = null;
        Connection_SQLServer conSql = new Connection_SQLServer();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select Trainning_name from tbTrainning group by Trainning_name";

            dtTitleTraining = conSql.SqlQuery(sql);

            foreach (DataRow dr in dtTitleTraining.Rows)
            {
                ddlTitle.Items.Add(dr["Trainning_name"].ToString());
            }
        }

        private string CheckDataBeforeRun()
        {
            try
            {
                string _msgErr = null;

                if (txtTitle.Text.Trim().Length == 0)
                {
                    _msgErr = "กรุณากรอกข้อมูลหัวข้อการอบรม";
                }
                else if (txtOwner.Text.Trim().Length == 0)
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
                txtTitle.Text = string.Empty;
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

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string _msgErr = CheckDataBeforeRun();

                if (_msgErr != null)
                {
                    RegisterClientScriptBlock("OnLoad", "<script>alert('" + _msgErr + "!')</script>");
                    return;
                }
                string title = txtTitle.Text;
                string owner = txtOwner.Text;
                string address = txtAddress.Text;
                string startdate = "1/1/2559";
                string enddate = "2/1/2559";
                string participant = txtParticipant.Text;

                string sql = "insert into tbTrainning (Trainning_name,Trainning_address,Trainning_startdate,Trainning_enddate,Trainning_owner,Trainning_no,Trainning_province)" +
                             " values ('"+title+"','"+address+"','"+startdate+"','"+enddate+"','"+owner+"','1','1')";

                Connection_SQLServer conSql = new Connection_SQLServer();

                bool chk = conSql.UpdateData(sql);

                
                //Response.Write("Title : " + txtTitle.Text + "\n");
                //Response.Write("Owner : " + txtOwner.Text + "\n");
                //Response.Write("Address : " + txtAddress.Text + "\n");
                //Response.Write("Start Date : " + dateStart.Value + "\n");
                //Response.Write("End Date : " + dateEnd.Value + "\n");
                //Response.Write("Participant : " + txtParticipant.Text + "\n");
                if (chk)
                {
                    RegisterClientScriptBlock("OnLoad", "<script>alert('Complete!')</script>");
                }
                else
                {
                    RegisterClientScriptBlock("OnLoad", "<script>alert('Save Fail!')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message.ToString()) + "')</script>");
            }
        }
    }
}