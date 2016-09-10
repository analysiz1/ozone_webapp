using Ozoneserviceapp.BaseClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
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
            if(ChkTitle.Checked)
            {
                ddlTitle.Enabled = true;
                txtTitle.Enabled = false;   
            }
            else
            {
                ddlTitle.Enabled = false;
                txtTitle.Enabled = true;    
            }


            if (ddlTitle.Items.Count == 0)
            {
                string sql = "SELECT dbo.tbTrainning.Trainning_id,dbo.tbTrainning.Trainning_name," +
                             "dbo.tbTrainning.Trainning_no + 1 as Trainning_no FROM dbo.tbTrainning";

                dtTitleTraining = conSql.SqlQuery(sql);

                ddlTitle.Items.Add("");
                foreach (DataRow dr in dtTitleTraining.Rows)
                {
                    ddlTitle.Items.Add(dr["Trainning_name"].ToString() + " ครั้งที่ " + dr["Trainning_no"]);
                }
            }
        }

        private string CheckDataBeforeRun()
        {
            try
            {
                string _msgErr = null;

                if (txtTitle.Text.Trim().Length == 0)
                {
                    if (!ChkTitle.Checked)
                    {
                        _msgErr = "กรุณากรอกข้อมูลหัวข้อการอบรม";
                    }
                    else if(ChkTitle.Checked && ddlTitle.SelectedItem.ToString().Trim().Length == 0)
                    {
                        _msgErr = "กรุณาเลือกหัวข้อการอบรม";
                    }
                }
                
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

                if(totalDay < 0)
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
                    Response.Write("<script>alert('" + _msgErr + "!')</script>");
                    //RegisterClientScriptBlock("OnLoad", "<script>alert('" + _msgErr + "!')</script>");
                    return;
                }

                string title = string.Empty;
                string no = string.Empty;
                string sql = string.Empty;
                Connection_SQLServer conSql = new Connection_SQLServer();

                if (ChkTitle.Checked == false)
                {
                    // *** ขาดกรณีชื่อซ้ำ Query ซ้ำ ให้แจ้งว่าซ้ำแล้วให้เลือก จากใน Combo แทน
                    title = txtTitle.Text;
                    no = "1";

                    sql = "Select Trainning_id from tbTrainning where Trainning_name = '" + title + "'";

                    DataTable dt = conSql.SqlQuery(sql);

                    if (dt.Rows.Count > 0)
                    {
                        txtTitle.Text = string.Empty;
                        Response.Write("<script>alert('ชื่อหัวข้อซ้ำกรุณาเลือกจากหัวข้อเดิมหรือเปลีย่นชื่อการอบรมใหม่!')</script>");
                        return;
                    }
                }
                else
                {
                    string[] _strArr = Regex.Split(ddlTitle.SelectedItem.ToString(), " ครั้งที่ ");
                    title = _strArr[0];
                    no = _strArr[1];
                }

                string owner = txtOwner.Text;
                string address = txtAddress.Text;
                string startdate = txtStartDate.Text;
                string enddate = txtEndDate.Text;
                string participant = txtParticipant.Text;

                sql = "insert into tbTrainning(Trainning_name,Trainning_address,Trainning_startdate,Trainning_enddate," +
                      "Trainning_owner,Trainning_no,Trainning_province,Trainning_amount,Trainning_status) Values("+
                      "'" + title + "','" + address + "','" + startdate + "','" + enddate + "','" + owner + "'," +
                      "'" + no + "','0','" + participant + "','1')"; 

                

                bool chk = conSql.UpdateData(sql);

                if (chk)
                {
                    //Response.Write("<script>alert('Complete!')</script>");
                    RegisterClientScriptBlock("OnLoad", "<script>alert('Record Complete!')</script>");
                    //Response.Redirect("Training_Record.aspx");
                    
                }
                else
                {
                    //Response.Write("<script>alert('Save Fail!')</script>");
                    RegisterClientScriptBlock("OnLoad", "<script>alert('Record Fail!')</script>");
                    //Response.Redirect("Training_Record.aspx");
                }
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message.ToString()) + "')</script>");
            }
        }

        


    }
}