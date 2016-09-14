using Ozoneserviceapp.BaseClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ozoneservice.Train
{
    public partial class Report2 : System.Web.UI.Page
    {

        Connection_SQLServer conSql = new Connection_SQLServer();
        public DataTable dtTraining = null;
        string TrainningID = null;
        string innerHTML;
        string dropinID;

        protected void Page_Load(object sender, EventArgs e)
        {

            string sql = @"SELECT 
                            a.Emp_id ,
                            e.DropinCode+'-'+a.Emp_id  as Empid,                                                      
                            a.Emp_title,
                            a.Emp_name,
                            e.DropinName,          
                            e.DropinCode as Province,
							e.DropinCode as Dropin,         
                            d.RoleName                                                
                            FROM
                            dbo.tbEmployee a                         
                            INNER JOIN tbEmployeeRole d on a.Emp_position = d.RoleId  
                            inner join tbDropin e on a.Emp_province = e.DropinID 
                            where a.Emp_status = 1 ";
            binddataEmp(sql);

        }

    
       

        private void redirec()
        {
            Response.Redirect("~/Report2-1.aspx");
        }

        protected void btnEmp_Click(object sender, EventArgs e)
        {
            redirec();
        }




        public void binddataEmp(string sql)
        {
            int no = 1;
            string dropin = ddl2.Text;
            DataTable dt = new DataTable();
            dtTraining = conSql.SqlQuery(sql);
            innerHTML = "";
            innerHTML = headtable(); // headtable

            foreach (System.Data.DataRow dr in dtTraining.Rows)
            {                
                /*Content Emp*/
                innerHTML += "<tr>";
                innerHTML += "<td>" + no++ + "</td>";
                innerHTML += "<td>" + dr["Empid"].ToString() + "</td>";                
                innerHTML += "<td>" + dr["Emp_title"].ToString() + "</td>";
                innerHTML += "<td>" + dr["Emp_name"].ToString() + "</td>";
                innerHTML += "<td>" + dr["Province"].ToString() + "</td>";
                innerHTML += "<td>" + dr["Dropin"].ToString() + "</td>";
                innerHTML += "<td>" + dr["RoleName"].ToString() + "</td>";                
                innerHTML += "<td>";
                innerHTML += "<input type='Button' id='btnAdd' name='" + dr["Empid"].ToString() + "' onclick='redirect("+dr["Emp_id"].ToString()+")' runat='server' value='ดูรายละเอียดการอบรม' Class='btn btn-primary' />";                               
                innerHTML += "</td>";
                innerHTML += "</tr>";

            }
            innerHTML += "</table>     </div>";
            lblEmp.Text = innerHTML; // output to fontend
        }

        public string headtable()
        {
            string thead = @"<div class=''>
            <table  class='table table-hover '  style='margin-left:30px;'>
            <tr class='headtable'><!-- Headtable -->
            <td>ลำดับ</td>
            <td>รหัสพนักงาน</td>            
            <td>คำนำหน้า</td>
            <td>ชื่อ-นามสกุล</td>
            <td>จังหวัด</td>
            <td>สำนักงาน/พื้นที่</td>            
            <td>ตำแหน่ง</td>
            <td></td>
            </tr>";
            return thead;
        }

        protected void ddl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = @"SELECT 
                            a.Emp_id ,
                            e.DropinCode+'-'+a.Emp_id  as Empid,                                                      
                            a.Emp_title,
                            a.Emp_name,
                            e.DropinName,          
                            e.DropinCode as Province,
							e.DropinCode as Dropin,         
                            d.RoleName                                                
                            FROM
                            dbo.tbEmployee a                         
                            INNER JOIN tbEmployeeRole d on a.Emp_position = d.RoleId  
                            inner join tbDropin e on a.Emp_province = e.DropinID 
                            where a.Emp_status = 1 and e.DropinID = " + ddl2.SelectedValue+" ";
            binddataEmp(sql);
        }



    }
}