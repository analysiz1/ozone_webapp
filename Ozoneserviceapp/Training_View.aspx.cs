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
    public partial class Training_View : System.Web.UI.Page
    {
        public DataTable dtTitleTraining = null;
        Connection_SQLServer conSql = new Connection_SQLServer();
        public DataTable dtData = new System.Data.DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (ddlTitle.Items.Count == 0 )
            {
                string sql = "SELECT dbo.tbTrainning.Trainning_name,dbo.tbTrainning.Trainning_no,dbo.tbTrainning.Trainning_id FROM dbo.tbTrainning where dbo.tbTrainning.Trainning_status = 1 order by dbo.tbTrainning.Trainning_name";

                dtTitleTraining = conSql.SqlQuery(sql);

                ddlTitle.Items.Add("");
                foreach (DataRow dr in dtTitleTraining.Rows)
                {
                    ddlTitle.Items.Add(new ListItem(dr["Trainning_name"].ToString() + " ครั้งที่ " + dr["Trainning_no"].ToString(), dr["Trainning_id"].ToString()));
                }
            }

            if (Request.QueryString["id"] != null)
            {
                ddlTitle.SelectedValue = Request.QueryString["id"];
                btnSearch_Click(null, null);
                /*new 01/10/2559*/
            }
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlTitle.SelectedItem.ToString().Trim().Length == 0)
                {
                    return;
                }

                Connection_SQLServer conSql = new Connection_SQLServer();

                string sql = "select * from tbTrainning where Trainning_id = " + ddlTitle.SelectedValue.ToString() + ";";
                DataTable dtTitle = conSql.SqlQuery(sql);

                DateTime dateStart = Convert.ToDateTime(dtTitle.Rows[0]["Trainning_startdate"].ToString());
                DateTime dateEnd = Convert.ToDateTime(dtTitle.Rows[0]["Trainning_enddate"].ToString());

                txtdateStart.Text = (dateStart.ToString("dd") + "-" + dateStart.ToString("MM") + "-" + dateEnd.Year).ToString();
                txtdateEnd.Text = (dateEnd.ToString("dd") + "-" + dateEnd.ToString("MM") + "-" + dateEnd.Year).ToString();
                txtAddress.Text = dtTitle.Rows[0]["Trainning_address"].ToString();
                txtOwner.Text = dtTitle.Rows[0]["Trainning_owner"].ToString();
                txtParticipant.Text = dtTitle.Rows[0]["Trainning_amount"].ToString();

                //sql = "SELECT c.DropinCode + '-' +a.Emp_id as Emp_id,a.Emp_title,a.Emp_name,c.DropinName as Dropin,c.DropinName as Province,d.RoleName " +
                //"FROM tbEmployee a inner join tbManageTrainning b on  a.Emp_id = a.Emp_id inner join tbDropin c on a.Emp_province = c.DropinID " +
                //"inner join tbEmployeeRole d on a.Emp_position = d.RoleId where b.Trainning_id = " + ddlTitle.SelectedValue.ToString();

                sql = "SELECT c.DropinCode + '-' +a.Emp_id as Emp_id,a.Emp_title,a.Emp_name,c.DropinName as Dropin,c.DropinName as Province,d.RoleName " +
                      "FROM tbManageTrainning b left join tbEmployee a on  a.Emp_id = b.Emp_id inner join tbDropin c on a.Emp_province = c.DropinID " +
                      "inner join tbEmployeeRole d on a.Emp_position = d.RoleId where a.Emp_status = 1 and Trainning_id = " + ddlTitle.SelectedValue.ToString();

                dtData.Clear();

                dtData = conSql.SqlQuery(sql);

                //dtData.Columns.Add("id");
                //dtData.Columns.Add("prefixName");
                //dtData.Columns.Add("nameSurname");
                //dtData.Columns.Add("province");
                //dtData.Columns.Add("area");
                //dtData.Columns.Add("position");

                //System.Data.DataRow dr = dtData.NewRow();

                //dr["id"] = "OSO-42";
                //dr["prefixName"] = "นางสาว";
                //dr["nameSurname"] = "แก่นแก้ว  ชุมชาติ";
                //dr["province"] = "สงขลา";
                //dr["area"] = "อำเภอจะนะ";
                //dr["position"] = "เจ้าหน้าที่ภาคสนาม";

                //dtData.Rows.Add(dr);

                //dr = dtData.NewRow();

                //dr["id"] = "OYA-60";
                //dr["prefixName"] = "นาย";
                //dr["nameSurname"] = "อับดุลรอฮมาน ยามา";
                //dr["province"] = "ยะลา";
                //dr["area"] = "อำเภอยะลา";
                //dr["position"] = "เจ้าหน้าที่ภาคสนาม";

                //dtData.Rows.Add(dr);

                //dr = dtData.NewRow();

                //dr["id"] = "OPA-12";
                //dr["prefixName"] = "นาย";
                //dr["nameSurname"] = "มูตะผา เหลาะหม๊ะ";
                //dr["province"] = "ปัตตานี";
                //dr["area"] = "อำเภอเมือง";
                //dr["position"] = "เจ้าหน้าที่ภาคสนาม";

                //dtData.Rows.Add(dr);

                DataTable dt = new System.Data.DataTable();

                dt = dtData;

                string[] Column = { "ลำดับ", "รหัสผู้เข้าอบรม", "คำนำหน้า", "ชื่อ-นามสกุล", "จังหวัด", "สำนักงาน/พื้นที่", "ตำแหน่ง", "" };

                string htmlView = string.Empty;

                htmlView += "<br />";
                htmlView += "<table  class='table table-hover' >";
                htmlView += "<tr>";
                for (int i = 0; i < Column.Count(); i++)
                {
                    htmlView += "<td style=' width:" + (80 / Column.Count()).ToString() + ";' align='center'>";
                    htmlView += Column[i].ToString();
                    htmlView += "</td>";
                }
                htmlView += "</tr>";


                int j = 0;

                foreach (System.Data.DataRow drTemp in dt.Rows)
                {
                    j++;

                    htmlView += "<tr>";

                    for (int i = -1; i < (drTemp.Table.Columns.Count + 1); i++)
                    {
                        if (i == -1)
                        {
                            htmlView += "<td style=' width:" + (80 / drTemp.Table.Columns.Count + 1).ToString() + ";' align='center'>";
                            htmlView += j.ToString();
                            htmlView += "</td>";

                        }
                        else if (i == drTemp.Table.Columns.Count)
                        {
                            string empID = drTemp["Emp_id"].ToString().Substring(drTemp["Emp_id"].ToString().IndexOf('-') + 1);

                            htmlView += "<td style='width:" + (80 / drTemp.Table.Columns.Count + 1).ToString() + ";' align='center'>";
                            htmlView += "<input type='Button' id='btnAdd' name='" + empID + "' onclick='addtraining(" + empID + ",0," + ddlTitle.SelectedValue.ToString() + ");' runat='server' value='ยกเลิกการอบรม' Class='btn btn-danger' />";
                            htmlView += "</td>";
                        }
                        else
                        {
                            htmlView += "<td style=' width: " + (80 / drTemp.Table.Columns.Count + 1).ToString() + ";' align='center'>";
                            htmlView += drTemp[i].ToString();
                            htmlView += "</td>";

                        }
                    }

                    htmlView += "</tr>";

                }

                htmlView += "</table>";

                htmlView += "<p> ยอดรวมจำนวนผู้เข้าร่วมการอบรม/พัฒนาศักยภาพ </p>";
                htmlView += "<p> (" + dt.Rows.Count + ")</p>";

                lblTraining_View.Text = htmlView;

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message.ToString()) + "')</script>");
            }
        }




    }
}