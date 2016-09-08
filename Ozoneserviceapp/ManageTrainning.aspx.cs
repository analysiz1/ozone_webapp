using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ozoneserviceapp.BaseClass;
using System.Data;

namespace Ozoneservice
{
    public partial class ManageTrainning : System.Web.UI.Page
    {
        /*08/09/2559*/
         Connection_SQLServer conSql = new Connection_SQLServer();
         public DataTable dtTraining = null;
         string TrainningID=null;
         string st = "1";
         string innerHTML;
         string dropinID ;

         protected void Page_Load(object sender, EventArgs e)
         {

             string querystring;
             TrainningID = Request.QueryString["id"];
             

             if (TrainningID == null)
             {
                 Response.Redirect("/Training_Manage.aspx");
             }
             else
             {
                 if (Session["dropin"].ToString() != null)
                 {
                     dropinID = Session["dropin"].ToString();
                 }
                 else { dropinID = "1"; }
                 if (dropinID != null)
                 {
                     TrainningName.Text = TrainningID.ToString();
                     querystring = @"SELECT 
                            a.Emp_id ,
                            a.Emp_name,                           
                            a.Emp_status,
                            d.RoleName,
                            e.DropinName ,    
                            e.DropinCode ,                      
                            '" + TrainningID + @"' as tID,
                            b.Trainning_id,
                            ('" + TrainningID + @"' + ':' + CAST(ISNULL(b.Status,0) as varchar)) as tStatus                                 
                            FROM
                            dbo.tbEmployee a
                            LEFT join tbManageTrainning  b on a.Emp_id = b.Emp_id  and b.Trainning_id= " + TrainningID + @"
                            LEFT join tbTrainning c on b.Trainning_id = c.Trainning_id  
                            INNER JOIN tbEmployeeRole d on a.Emp_position = d.RoleId  
                            inner join tbDropin e on a.Emp_province = e.DropinID where a.Emp_status = 1 and  e.DropinID = " + dropinID + "";
                 }
                 else
                 {
                    
                     querystring = @"SELECT 
                            a.Emp_id ,
                            a.Emp_name,                           
                            a.Emp_status,
                            d.RoleName,
                            e.DropinName ,          
                            e.DropinCode      ,          
                            '" + TrainningID + @"' as tID,
                            b.Trainning_id,
                            ('" + TrainningID + @"' + ':' + CAST(ISNULL(b.Status,0) as varchar)) as tStatus                                 
                            FROM
                            dbo.tbEmployee a
                            LEFT join tbManageTrainning  b on a.Emp_id = b.Emp_id  and b.Trainning_id= " + TrainningID + @"
                            LEFT join tbTrainning c on b.Trainning_id = c.Trainning_id  
                            INNER JOIN tbEmployeeRole d on a.Emp_position = d.RoleId  
                            inner join tbDropin e on a.Emp_province = e.DropinID where a.Emp_status = 1";

                 }
                 binddataEmp(querystring);
             }
             TrainningID = Request.QueryString["id"];
             if (TrainningID == null)
             {
                 Response.Redirect("/Training_Manage.aspx");
             }
             else
             {
                 TrainningName.Text = TrainningID.ToString();
                 //binddataEmp();
             }
             
         }

        protected void Btncreate_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Training_Record.aspx");
        }


        public void binddataEmp(string sql)
        {
            int no = 1;
            string dropin = ddl2.Text;
            DataTable dt = new DataTable();         
            dtTraining = conSql.SqlQuery(sql);
            innerHTML = "";
            innerHTML =  headtable(); // headtable

            foreach (System.Data.DataRow dr in dtTraining.Rows)
            {
                //if (dr["tID"].ToString() == TrainningID) // check TrainID
                //{
                /*Content Emp*/
                innerHTML += "<tr>";
                innerHTML += "<td>" + no++ + "</td>";
                innerHTML += "<td>" + dr["DropinCode"].ToString() + dr["Emp_id"].ToString() + "</td>";
                innerHTML += "<td>"+"</td>";
                innerHTML += "<td>" + dr["Emp_id"].ToString() + "</td>";
                innerHTML += "<td>" + dr["Emp_name"].ToString()  + "</td>";
                innerHTML += "<td>" + dr["DropinName"].ToString() + "</td>";
                innerHTML += "<td>" + dr["DropinName"].ToString() + "</td>";
                innerHTML += "<td>" + dr["RoleName"].ToString() + "</td>";
                innerHTML += "<td> </td>";
                innerHTML += "<td>";
                string tstatus = dr["tStatus"].ToString();
                if (tstatus.Equals(TrainningID.ToString() + ":0"))
                {
                    innerHTML += "<input type='Button' id='btnAdd' name='" + dr["Emp_id"].ToString() + "' onclick='addtraining(" + dr["Emp_id"] + ",1," + TrainningID + "); chkstatus();' runat='server' value='เข้ารับการอบรม' Class='btn btn-primary' />";
                }                
                else
                {                    
                    innerHTML += "<input type='Button' id='btnAdd' name='" + dr["Emp_id"].ToString() + "' onclick='addtraining(" + dr["Emp_id"] + ",0," + TrainningID + "); chkstatus();' runat='server' value='ยกเลิกการอบรม' Class='btn btn-danger' />";
                }
                innerHTML += "</td>";
                innerHTML += "</tr>";
              
            }
                    innerHTML += "</table>     </div>";
                    lblEmp.Text = innerHTML; // output to fontend
        }


        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            string Empname = txtEmpname.Text;          
            string sql = @"SELECT 
                            a.Emp_id ,
                            a.Emp_name,                           
                            a.Emp_status,
                            d.RoleName,
                            e.DropinName ,          
                            e.DropinCode      ,          
                            '" + TrainningID + @"' as tID,
                            b.Trainning_id,
                            ('" + TrainningID + @"' + ':' + CAST(ISNULL(b.Status,0) as varchar)) as tStatus                                 
                            FROM
                            dbo.tbEmployee a
                            LEFT join tbManageTrainning  b on a.Emp_id = b.Emp_id  and b.Trainning_id= " + TrainningID + @"
                            LEFT join tbTrainning c on b.Trainning_id = c.Trainning_id  
                            INNER JOIN tbEmployeeRole d on a.Emp_position = d.RoleId  
                            inner join tbDropin e on a.Emp_province = e.DropinID where a.Emp_status = 1 and  Emp_name like '%" + Empname + "'";
                                        
            binddataEmp(sql);
        
              }
         
        public string  headtable()
        {
            string thead = @"<div class=''>
            <table  class='table table-hover '  style='margin-left:30px;'  >
            <tr class='headtable'><!-- Headtable -->
            <td>ลำดับ</td>
            <td>รหัสพนักงาน</td>         
            <td>ชื่อ-นามสกุล</td>            
            <td>สำนักงาน/พื้นที่</td>            
            <td>ตำแหน่ง</td>
            <td> </td>
            </tr>";
            return thead;
        }

        protected void ddl2_SelectedIndexChanged(object sender, EventArgs e)
        {
                      
            string sql = @"SELECT 
                            a.Emp_id ,
                            a.Emp_name,                           
                            a.Emp_status,
                            d.RoleName,
                            e.DropinName ,          
                            e.DropinCode      ,          
                            '" + TrainningID + @"' as tID,
                            b.Trainning_id,
                            ('" + TrainningID + @"' + ':' + CAST(ISNULL(b.Status,0) as varchar)) as tStatus                                 
                            FROM
                            dbo.tbEmployee a
                            LEFT join tbManageTrainning  b on a.Emp_id = b.Emp_id  and b.Trainning_id= " + TrainningID + @"
                            LEFT join tbTrainning c on b.Trainning_id = c.Trainning_id  
                            INNER JOIN tbEmployeeRole d on a.Emp_position = d.RoleId  
                            inner join tbDropin e on a.Emp_province = e.DropinID where a.Emp_status = 1 and  e.DropinID = " + dropinID + "";
            binddataEmp(sql);
        }
       
    }
}