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

         Connection_SQLServer conSql = new Connection_SQLServer();
         public DataTable dtTraining = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string getID = Request.QueryString["id"];
           
           
        }

        protected void Btncreate_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Training_Record.aspx");
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            string Empname = txtEmpname.Text;
            DataTable dt = new DataTable();
            string sql = @"SELECT *                         
                            FROM
                            dbo.tbEmployee
                            ";
           dtTraining =  conSql.SqlQuery(sql);

            string innerHTML;


           innerHTML =@"<div class=''>
    <table  class='table table-hover '  style='margin-left:30px;'  >
        <tr class='headtable'><!-- Headtable -->
            <td>ลำดับ</td>
            <td>รหัสพนักงาน</td>            
            <td>คำนำหน้า</td>
            <td>ชื่อ-นามสกุล</td>
            <td>จังหวัด</td>
            <td>สำนักงาน/พื้นที่</td>            
            <td>ตำแหน่ง</td>
            <td> </td>
        </tr>";
            
           foreach (System.Data.DataRow dr in dtTraining.Rows)
            {
               /*Content Emp*/
         innerHTML+= "<tr>";           
             innerHTML += "<td>" + dr["Emp_id"].ToString() + "</td>";
             innerHTML += "<td>" + dr["Emp_title"].ToString() + "</td>";
             innerHTML += "<td>" + dr["Emp_name"].ToString() + " " + dr["Emp_lastname"].ToString() + "</td>";
             innerHTML += "<td>" + dr["Emp_province"].ToString() + "</td>";
             innerHTML += "<td>" + dr["Emp_position"].ToString() + "</td>";
             innerHTML += "<td></td>";
             innerHTML += "<td></td>";
             innerHTML += "<td>";
             // <asp:Button ID="Button3" runat="server" Text="ยกเลิกการเข้าอบรม" CssClass="btn btn-danger"  />
             innerHTML += "<input type='Button' id='btnAdd' runat='server' value='เข้ารับการอบรม' Class='btn btn-danger' />";
             innerHTML += "</td>";   
         innerHTML+="</tr>";
                  
       //innerHTML+= "</tr>";
        }    
    innerHTML +="</table>     </div>";


    lblEmp.Text = innerHTML; // output to fontend
        }
         
       
    }
}