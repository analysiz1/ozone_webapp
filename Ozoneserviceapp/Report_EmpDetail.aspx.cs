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
    public partial class Report2_1 : System.Web.UI.Page
    {
        string innerHTML;
        Connection_SQLServer conSql = new Connection_SQLServer();
        public DataTable dtTraining = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string empid = Request.QueryString["empid"];
            if(empid!=null)
            {
                string sql = @"SELECT
                                c.DropinCode + '-' +a.Emp_id as Empid,
                                a.Emp_name,
                                a.Emp_status,
                                c.DropinName,
                                b.RoleName
                                FROM
                                dbo.tbEmployee a
                                INNER JOIN tbEmployeeRole b on a.Emp_position = b.RoleId
                                INNER JOIN tbDropin c on a.Emp_province = c.DropinID
                                where Emp_id = " + empid+"";
                BindEmpdata(sql);

                string sqlt = @"SELECT
                                b.Trainning_name,
                                COUNT(Trainning_name) as Qty
                                FROM
                                dbo.tbManageTrainning a
                                inner join tbTrainning b on  a.Trainning_id = b.Trainning_id
                                where a.Emp_id = "+empid+@" and a.Status = 1
                                GROUP BY b.Trainning_name";
                BinddataTrainning(sqlt);
            }
            else
            {
                Response.Redirect("/Report_Person.aspx");

            }
            
        }

        public void BindEmpdata(string sql)
        {
            dtTraining = conSql.SqlQuery(sql);
            innerHTML = "";
            foreach (System.Data.DataRow dr in dtTraining.Rows)
            {
                innerHTML = @"  <table  class='table table-bordered '  style='margin-left:30px;'  >
       <tr class='headtable'>
            <td>รหัสผู้เข้าร่วม</td>
            <td>" + dr["Empid"].ToString() + @"</td>                                
        </tr>                      
         <tr class='headtable'>
            <td>ชื่อ-นามสกุล</td>
            <td>" +dr["Emp_name"].ToString()+@"</td>                                
        </tr>
        <tr class='headtable'>
            <td>สถานะ</td>";
                if(dr["Emp_status"].ToString()=="1"){
            innerHTML +="<td>ปฏิบัติงาน</td>";     
            }
                    else
            { innerHTML +="<td>ลาออก</td>";  }
        innerHTML +=@"</tr>
        <tr class='headtable'>
            <td>ตำแหน่ง</td>
            <td>" + dr["RoleName"].ToString() + @"</td>                                
        </tr>
        <tr class='headtable'>
            <td>จังหวัด</td>
            <td>" + dr["DropinName"].ToString() + @"</td>                                
        </tr>       

        </table>  ";
            }
            EmpDetail.Text = innerHTML;

        }

        public void BinddataTrainning(string sqlt)
        {
            int no = 1;
            dtTraining = conSql.SqlQuery(sqlt);
            string innerHTML = "";
             innerHTML = @"<table  class='table table-hover '  style='margin-left:30px;'  >
        <tr class='headtable'>
            <td>ลำดับ</td>
            <td>เรื่อง/หัวข้อ</td>
            <td>จำนวนครั้งที่เข้าร่วมการอบรม</td>                        
        </tr>";
            foreach (System.Data.DataRow dr in dtTraining.Rows)
            {
     innerHTML +=@"<tr class='headtable'>
                    <td>"+ no++ +@"</td>
                    <td>" + dr["Trainning_name"].ToString() + @"</td>
                    <td>" + dr["Qty"].ToString()  + " ครั้ง" + @"</td>                        
                 </tr>";
    }
        

   innerHTML+=  "</table>";

            EmpTrain.Text = innerHTML;

        }
    }
}