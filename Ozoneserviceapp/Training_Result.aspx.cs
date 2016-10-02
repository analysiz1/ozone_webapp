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
    public partial class Training_Result : System.Web.UI.Page
    {
        public DataTable dtTitleTraining = null;
        Connection_SQLServer conSql = new Connection_SQLServer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddlTitle.Items.Count == 0)
            {
                string sql = "SELECT dbo.tbTrainning.Trainning_name,dbo.tbTrainning.Trainning_no,dbo.tbTrainning.Trainning_id FROM dbo.tbTrainning where dbo.tbTrainning.Trainning_status = 1 order by dbo.tbTrainning.Trainning_name";

                dtTitleTraining = conSql.SqlQuery(sql);

                ddlTitle.Items.Add("");
                foreach (DataRow dr in dtTitleTraining.Rows)
                {
                    ddlTitle.Items.Add(new ListItem(dr["Trainning_name"].ToString() + " ครั้งที่ " + dr["Trainning_no"].ToString(), dr["Trainning_id"].ToString()));
                }
            }
        }

        //protected void btn1_Click(object sender, EventArgs e)
        //{
        //    if (ddlTitle.Items.FindByText("การป้องกันเอชไอวี/เอสด์ ครั้งที่ 1") != null)
        //    {

        //        RegisterClientScriptBlock("OnLoad", "<script>alert('TRUE!')</script>");
        //    }
        //    else
        //    {
        //        RegisterClientScriptBlock("OnLoad", "<script>alert('FALSE!')</script>");
        //    }

        //}

        protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from tbTrainning where Trainning_id = " + ddlTitle.SelectedValue.ToString() + ";";
                DataTable dtTitle = conSql.SqlQuery(sql);

                DateTime dateStart = Convert.ToDateTime(dtTitle.Rows[0]["Trainning_startdate"].ToString());
                DateTime dateEnd = Convert.ToDateTime(dtTitle.Rows[0]["Trainning_enddate"].ToString());

                txtdateStart.Text = (dateStart.ToString("dd") + "-" + dateStart.ToString("MM") + "-" + dateEnd.Year).ToString();
                txtdateEnd.Text = (dateEnd.ToString("dd") + "-" + dateEnd.ToString("MM") + "-" + dateEnd.Year).ToString();
                txtAddress.Text = dtTitle.Rows[0]["Trainning_address"].ToString();
                txtOwner.Text = dtTitle.Rows[0]["Trainning_owner"].ToString();
                txtParticipant.Text = dtTitle.Rows[0]["Trainning_amount"].ToString();

                string[] Province = { "กรุงเทพฯ", "เชียงใหม่", "เชียงราย", "ตาก", "ยะลา", "ปัตตานี", "นราธิวาส", "สงขลา" };
                //string[] DataNew = { "1", "2", "3", "4", "5", "6", "7", "8" }; 
                //string[] DataOld = { "1", "2", "3", "4", "5", "6", "7", "8" }; 
                string htmlView = string.Empty;

                htmlView += "<p align='center'>รายละเอียดผู้เข้าร่วม </p>";

                htmlView += "<table style='border: 1px solid #000; width: 80%;' align='center' class='table-condensed'>";
                htmlView += "<tr>";
                foreach (string _province in Province)
                {
                    htmlView += "<td style='border: 1px solid #333; width: " + (80 / Province.Count()).ToString() + "%;' align='center'>";
                    htmlView += _province;
                    htmlView += "</td>";
                }
                htmlView += "</tr>";
                htmlView += "</table>";

                htmlView += "<table style='border: 1px solid #000; width: 80%;' align='center' class='table-condensed'>";
                htmlView += "<tr>";
                for (int i = 0; i < (Province.Count() * 2); i++)
                {
                    htmlView += "<td style='border: 1px solid #333; width: " + (80 / (Province.Count() * 2)).ToString() + "%;' align='center'>";

                    if (i % 2 == 0)
                    {
                        htmlView += "รายใหม่";
                    }
                    else
                    {
                        htmlView += "รายเก่า";
                    }
                    htmlView += "</td>";
                }
                htmlView += "</tr>";
                htmlView += "</table>";

                htmlView += "<table style='border: 1px solid #000; width: 80%;' align='center'>";
                htmlView += "<tr>";
                int j = 1;

                sql = string.Empty;
                List<int> lstDataNew = new List<int>();
                List<int> lstDataOld = new List<int>();

                for (int i = 0; i < (Province.Count() * 2); i++)
                {
                    string[] strTitle = Regex.Split(ddlTitle.SelectedItem.ToString(), " ครั้งที่ ");
                    int countOld = 0;
                    int countNew = 0;

                    sql = @"SELECT
                            a.Emp_id
                            FROM
                            dbo.tbManageTrainning a
                            INNER JOIN tbTrainning  b on  a.Trainning_id = b.Trainning_id
                            where b.Trainning_name = '" + strTitle[0] + @"' and b.Trainning_no < " + strTitle[1] + @" and b.Trainning_status=1 and a.Status=1
                            GROUP BY a.Emp_id ";

                    DataTable dtDataOld = conSql.SqlQuery(sql);

                    sql = @"SELECT
                            a.Emp_id
                            FROM
                            dbo.tbManageTrainning a
                            INNER JOIN tbTrainning  b on  a.Trainning_id = b.Trainning_id
                            INNER JOIN tbEmployee c on a.Emp_id = c.Emp_id
                            INNER JOIN tbDropin d on c.Emp_province = d.DropinID
                            INNER JOIN tbProvince e on e.ProvinceID = d.ProvinceID
                            where a.Trainning_id = " + ddlTitle.SelectedValue.ToString() + @" and b.Trainning_status=1 and a.Status=1and e.ProvinceID = "+j;

                    DataTable dtDataNew = conSql.SqlQuery(sql);

                    if (dtDataOld != null)
                    {
                        foreach (DataRow dr in dtDataNew.Rows)
                        {
                            DataRow[] drArr = null;
                            drArr = dtDataOld.Select("Emp_id = " + dr["Emp_id"]);

                            if(drArr.Count() == 0)
                            {
                                countNew++;
                            }
                            else
                            {
                                countOld++;
                            }
                        }
                    }

                    htmlView += "<td style='border: 1px solid #333; width: " + (80 / (Province.Count() * 2)).ToString() + "%;' align='center'>";
                    if (i % 2 == 0)
                    {
                        htmlView += countNew.ToString();
                        lstDataNew.Add(countNew);
                    }
                    else
                    {
                        htmlView += countOld.ToString();
                        lstDataOld.Add(countOld);

                        j++;
                    }
                    htmlView += "</td>";
                }
                htmlView += "</tr>";
                htmlView += "</table>";

                htmlView += "<table style='border: 1px solid #000; width: 80%;' align='center'>";
                htmlView += "<tr>";
                for (int i = 0; i < Province.Count(); i++)
                {
                    htmlView += "<td style='border: 1px solid #333; width: " + (80 / Province.Count()).ToString() + "%;' align='center'>";
                    htmlView += lstDataNew[i] + lstDataOld[i];
                    htmlView += "</td>";
                }
                htmlView += "</tr>";
                htmlView += "</table>";

                lblTraining_Result1.Text = htmlView;

                htmlView = string.Empty;

                string[] Department = { "ส่วนกลาง", "ผู้ประสานงานภาค", "ผู้จัดการศูนย์บริการ", "จนท.ธุรการ-การเงิน", "เจ้าหน้าที่ภาคสนาม", "แกนนำอาสาสมัคร", "อาสาสมัคร" };
                //string[] DepAmount = { "1", "2", "3", "4", "5", "6", "7" };

                htmlView += "<p align='center'> ตำแหน่งงาน </p>";

                htmlView += "<table style='border: 1px solid #000; width: 80%;' align='center'>";
                htmlView += "<tr>";
                for (int i = 0; i < Department.Count(); i++)
                {
                    htmlView += "<td style='border: 1px solid #333; width: " + (80 / Department.Count()).ToString() + "%;' align='center'>";
                    htmlView += Department[i];
                    htmlView += "</td>";
                }
                htmlView += "</tr>";

                

                htmlView += "<tr>";
                for (int i = 0; i < Department.Count(); i++)
                {
                    sql = @"select 
                        COUNT(a.Emp_id) as Qty,
                        c.Rolename
                        from tbManageTrainning a
                        inner join tbEmployee b on a.Emp_id = b.Emp_id
                        inner join tbEmployeeRole c on b.Emp_position = c.RoleId
                        where a.Trainning_id = " + ddlTitle.SelectedValue.ToString() + @" and c.Rolename = '" + Department[i] + @"'
                        GROUP BY c.Rolename";

                    DataTable dtDepartment = conSql.SqlQuery(sql);
                    int countDepartment = 0; 

                    if(dtDepartment.Rows.Count != 0)
                    {
                        countDepartment = int.Parse(dtDepartment.Rows[0][0].ToString());
                    }

                    htmlView += "<td style='border: 1px solid #333; width: " + (80 / Department.Count()).ToString() + "%;' align='center'>";
                    htmlView += countDepartment;
                    htmlView += "</td>";
                }
                htmlView += "</tr>";
                htmlView += "</table>";

                lblTraining_Result2.Text = htmlView;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + Server.HtmlEncode(ex.Message.ToString()) + "')</script>");
            }
        }


    }
}