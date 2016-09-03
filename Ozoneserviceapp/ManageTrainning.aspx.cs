﻿using System;
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

         Connection_SQLServer conSql = new Connection_SQLServer();
         public DataTable dtTraining = null;
         string TrainningID=null;
         string st = "1";
         string innerHTML;
         string dropID;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            TrainningID = Request.QueryString["id"];
            dropID = Request.QueryString["drop"];
            Session["drop"] =  "1";
            if (TrainningID == null)
            {
                Response.Redirect("/Training_Manage.aspx");
            }
            else
            {
                TrainningName.Text = TrainningID.ToString();
                binddataEmp();
            }
           
           
           
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void Btncreate_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Training_Record.aspx");
        }


        public void binddataEmp()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT 
                            a.Emp_id,
                            a.Emp_name,                           
                            a.Emp_status,
                            d.RoleName,
                            e.DropinName ,                          
                            '" + TrainningID + @"' as tID,
                            b.Trainning_id,
                            ('" + TrainningID + @"' + ':' + CAST(ISNULL(b.Status,0) as varchar)) as tStatus                                 
                            FROM
                            dbo.tbEmployee a
                            LEFT join tbManageTrainning  b on a.Emp_id = b.Emp_id  and b.Trainning_id= "+TrainningID+@"
                            LEFT join tbTrainning c on b.Trainning_id = c.Trainning_id  
                            INNER JOIN tbEmployeeRole d on a.Emp_position = d.RoleId  
                            inner join tbDropin e on a.Emp_province = e.DropinID where a.Emp_status = 1";                       
            
            dtTraining = conSql.SqlQuery(sql);
            innerHTML = "";
            innerHTML =  headtable(); // headtable

            foreach (System.Data.DataRow dr in dtTraining.Rows)
            {
                //if (dr["tID"].ToString() == TrainningID) // check TrainID
                //{
                /*Content Emp*/
                innerHTML += "<tr>";
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
                    //innerHTML += "<input type='Button'  id='btnAdd' onclick='addtraining(" + dr["Emp_id"].ToString() + ",'2'," + TrainningID + ");' runat='server' value='ยกเลิกการอบรม' Class='btn btn-danger' />";
                    innerHTML += "<input type='Button' id='btnAdd' name='" + dr["Emp_id"].ToString() + "' onclick='addtraining(" + dr["Emp_id"] + ",2," + TrainningID + "); chkstatus();' runat='server' value='ยกเลิกการอบรม' Class='btn btn-danger' />";
                }
                innerHTML += "</td>";
                innerHTML += "</tr>";
               // }
            }
            innerHTML += "</table>     </div>";
            lblEmp.Text = innerHTML; // output to fontend
        }


        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            string Empname = txtEmpname.Text;
            DataTable dt = new DataTable();
            string sql = @"SELECT *                         
                            FROM
                            dbo.tbEmployee where Emp_name like '%"+Empname.ToString()+"' where = "+TrainningID+" ";
            dtTraining =  conSql.SqlQuery(sql);


            innerHTML = "";

            innerHTML  = headtable();// headtable
            
           foreach (System.Data.DataRow dr in dtTraining.Rows)
            {
               /*Content Emp*/
             innerHTML+= "<tr>";           
             innerHTML += "<td>" + dr["Emp_id"].ToString() + "</td>";
             innerHTML += "<td>" + dr["Emp_title"].ToString() + "</td>";
             innerHTML += "<td>" + dr["Emp_name"].ToString() + "</td>";
             innerHTML += "<td>" + dr["Emp_province"].ToString() + "</td>";
             innerHTML += "<td>" + dr["Emp_position"].ToString() + "</td>";
             innerHTML += "<td></td>";
             innerHTML += "<td></td>";
             innerHTML += "<td>";            

            // if (dr["Status"] == "1")
             if (st == "1")
              {
                  innerHTML += "<input type='Button' id='btnAdd' name='" + dr["Emp_id"].ToString() + "' onclick='addtraining(" + dr["Emp_id"].ToString() + ",1," + TrainningID + ");' runat='server' value='เข้ารับการอบรม' Class='btn btn-primary' />";
                 
              }
              else
              {
                  innerHTML += "<input type='Button'  id='btnAdd' onclick='addtraining(" + dr["Emp_id"].ToString() + ",'2'," + TrainningID + ");' runat='server' value='ยกเลิกการอบรม' Class='btn btn-danger' />";
              }
             innerHTML += "</td>";   
             innerHTML+="</tr>";
                  
       //innerHTML+= "</tr>";
              }    
                  innerHTML +="</table>     </div>";
                  lblEmp.Text = innerHTML; // output to fontend
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
       
    }
}