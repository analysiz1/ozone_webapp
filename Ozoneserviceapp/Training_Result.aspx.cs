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
                    htmlView += "<td style='border: 1px solid #333; width: " + (80 / (Province.Count() * 2)).ToString() + "%;' align='center'>";
                    if (i % 2 == 0)
                    {
                        string[] strTitle = Regex.Split(ddlTitle.SelectedItem.ToString(), " ครั้งที่ ");

                        sql = @"select 
                                SUM(cast(q2.status as int)) as result
                                FROM
                                (
                                select 
                                (case  
                                when   count(q1.Emp_id)=1 then '1'
                                else '0'  
                                end ) as status
                                FROM
                                (
                                SELECT
                                a.Emp_id,
                                b.Trainning_id,
                                c.Trainning_no,
                                d.DropinID
                                FROM
                                dbo.tbEmployee a
                                inner join tbManageTrainning b on a.Emp_id = b.Emp_id
                                inner join tbTrainning c on b.Trainning_id = c.Trainning_id
                                inner join tbDropin d on a.Emp_province = d.DropinID
                                inner join tbProvince e on d.ProvinceID = e.ProvinceID
                                where c.Trainning_name= '" + strTitle[0] + @"'  and e.ProvinceID = " + j + @" and a.Emp_status=1 and c.Trainning_no <= '" + strTitle[1] + @"' and c.Trainning_status=1 and b.Status=1 ) as q1
                                GROUP BY q1.Emp_id
                                ) as q2
                                where q2.status = 1";

                        //sql = "select ProvinceID from tbProvince where ProvinceName = '" + Province[j - 1] + "'";

                        DataTable dtDataNew = conSql.SqlQuery(sql);

                        if (dtDataNew.Rows.Count == 0)
                        {
                            htmlView += "0";
                            lstDataNew.Add(0);
                        }
                        else
                        {
                            if (dtDataNew.Rows[0][0].ToString().Equals(""))
                            {
                                htmlView += "0";
                                lstDataNew.Add(0);
                            }
                            else
                            {
                                htmlView += dtDataNew.Rows[0][0];
                                lstDataNew.Add(int.Parse(dtDataNew.Rows[0][0].ToString()));
                            }
                        }


                    }
                    else
                    {
                        string[] strTitle = Regex.Split(ddlTitle.SelectedItem.ToString(), " ครั้งที่ ");

                        sql = @"select 
                                SUM(cast(q2.status as int)) as result
                                FROM
                                (
                                select 
                                (case  
                                when   count(q1.Emp_id)>1 then '1'
                                else '0'  
                                end ) as status
                                FROM
                                (
                                SELECT
                                a.Emp_id,
                                b.Trainning_id,
                                c.Trainning_no,
                                d.DropinID
                                FROM
                                dbo.tbEmployee a
                                inner join tbManageTrainning b on a.Emp_id = b.Emp_id
                                inner join tbTrainning c on b.Trainning_id = c.Trainning_id
                                inner join tbDropin d on a.Emp_province = d.DropinID
                                inner join tbProvince e on d.ProvinceID = e.ProvinceID
                                where c.Trainning_name= '" + strTitle[0] + @"'  and e.ProvinceID = " + j + @" and a.Emp_status=1 and c.Trainning_No <= '" + strTitle[1] + @"' and c.Trainning_status=1 and b.Status=1 ) as q1
                                GROUP BY q1.Emp_id
                                ) as q2
                                where q2.status = 1";

                        //sql = "select ProvinceID from tbProvince where ProvinceName = '" + Province[j - 1] + "'";

                        DataTable dtDataOld = conSql.SqlQuery(sql);

                        if (dtDataOld.Rows.Count == 0)
                        {
                            htmlView += "0";
                            lstDataOld.Add(0);
                        }
                        else
                        {
                            if (dtDataOld.Rows[0][0].ToString().Equals(""))
                            {
                                htmlView += "0";
                                lstDataOld.Add(0);
                            }
                            else
                            {
                                htmlView += dtDataOld.Rows[0][0];
                                lstDataOld.Add(int.Parse(dtDataOld.Rows[0][0].ToString()));
                            }
                        }



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

                string[] Department = { "ส่วนกลาง", "ผู้ประสานงานภาค", "ผู้จัดการศูนย์", "จนท.ธุรการ-การเงิน", "เจ้าหน้าที่ภาคสนาม", "แกนนำอาสาสมัคร", "อาสาสมัคร" };
                string[] DepAmount = { "1", "2", "3", "4", "5", "6", "7" };

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
                for (int i = 0; i < DepAmount.Count(); i++)
                {
                    htmlView += "<td style='border: 1px solid #333; width: " + (80 / DepAmount.Count()).ToString() + "%;' align='center'>";
                    htmlView += DepAmount[i];
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