using Ozoneserviceapp.BaseClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ozoneservice
{
    public partial class Report1 : System.Web.UI.Page
    {
        Connection_SQLServer conSql = new Connection_SQLServer();
        public DataTable dtTraining = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = @"SELECT
                            a.Trainning_name + 'ครั้งที่ ' + cast(a.Trainning_no as varchar) as Trainning_name,
                            CONVERT(varchar(20),a.Trainning_startdate,103) as Trainning_startdate ,
                            CONVERT(varchar(20),a.Trainning_enddate,103) as Trainning_enddate,
                            count(a.Trainning_id) as Trainning_qty
                            FROM
							tbManageTrainning b                            
							INNER JOIN dbo.tbTrainning a on a.Trainning_id = b.Trainning_id 
                            where a.Trainning_status = 1                         
                            GROUP BY Trainning_name , a.Trainning_startdate , a.Trainning_enddate ,a.Trainning_no ,a.Trainning_id
                            order by a.Trainning_id ASC";

            Binddata(sql);
        }

        public void Binddata(string sql)
        {
            int no = 1;
            DataTable dt = new DataTable();
            dtTraining = conSql.SqlQuery(sql);
            string innerHTML = "";
            innerHTML = @"<div class='table-responsive'>
            <table  class='table table-hover '  style='margin-left:30px;'  >
            <tr class='headtable'>
            <td>ลำดับ</td>
            <td>เรื่องหัวข้อ</td>
            <td>วันที่เริ่มอบรม</td>
            <td>วันที่สิ้นสุด</td>
            <td>จำนวนผู้เข้าร่วม</td>            
            </tr>";


            foreach (System.Data.DataRow dr in dtTraining.Rows)
            {
                innerHTML += @" <tr class='headtable'>
            <td>"+no++ +@"</td>
            <td>" + dr["Trainning_name"].ToString() + @"</td>
            <td>" + dr["Trainning_startdate"] + @"</td>
            <td>" + dr["Trainning_enddate"] + @"</td>
            <td>" + dr["Trainning_qty"].ToString() + @"</td>            
            </tr>";
            }
 
            innerHTML += " </table></div>";
            lbltrainning.Text = innerHTML;
        }
    }
}