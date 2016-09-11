using Ozoneserviceapp.BaseClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ozoneserviceapp
{
    public partial class Training_Manage : System.Web.UI.Page
    {
        public DataTable dtTitleTraining = null;
        Connection_SQLServer conSql = new Connection_SQLServer();

        protected void Page_Load(object sender, EventArgs e)
        {
            dtTitleTraining = conSql.GetTitleTraining();

            string outputHTML;
            
            /*head table*/

            outputHTML = @"<table style='border: 1px solid #000; width: 80%;' align='center' class='table-condensed'>
            <tr>
                <td style='border: 1px solid #333; width: 60% ; align='center'>
                    <p align ='center'>ชื่อหัวข้อ</p>
                </td>
                <td style='border: 1px solid #333; width: 10% ; align='center'>
                </td>
                <td style='border: 1px solid #333; width: 10% ; align='center'>
                </td>
                <td  style='border: 1px solid #333; width: 10% ; align='center'>
                </td>
            </tr>";             

            foreach(System.Data.DataRow dr in dtTitleTraining.Rows)
              {
             outputHTML += @"<tr>
                    <td style='border: 1px solid #333; width: 50% ; align='center'>
                    <p align ='center'>"+ dr["Trainning_Name"].ToString() + " ครั้งที่ " + dr["Trainning_no"].ToString()+"</p></td>";

             /*<asp:Button ID='btnEdit'  runat='server' CssClass='btn btn-primary'  Text='แก้ไข' align ='center' />*/
             /*<asp:Button ID='btnDelete' runat='server' CssClass='btn btn-primary'  Text='ลบ' align ='center' OnClientClick='return confirm('คุณต้องการบหัวข้อการอบรมนี้ ใช่หรือไม่ ?');' OnClick='btnDelete_Click'/>*/
               /* <asp:Button ID='BtnManage2' CommandName=" + dr["Trainning_id"].ToString()+ " runat='server' Text='จัดการอบรม' CssClass='btn btn-primary' OnClick='BtnManage2_Click' /></td>";*/
             outputHTML += @"<td style='border: 1px solid #333; width: auto ; align='center'>                       
                         <input type ='button' id='btnEdit'  onclick='btnedit(" + dr["Trainning_id"].ToString() + ");' value='แก้ไข' runat='server' Class='btn btn-primary'align ='center' /></td>";
                    outputHTML += @"<td style='border: 1px solid #333; width: auto ; align='center'>";                        
                      outputHTML += @"<input type ='button'  runat='server' onclick='btndelete("+dr["Trainning_id"].ToString() +");' id='btnDelete' runat='server' value='ลบข้อมูล' Class='btn btn-primary'align ='center' /></td><td> ";                             
                       outputHTML+= @"<input type ='button' id='BtnManage2' value='จัดการคน' runat='server' onclick='btnmanage(" + dr["Trainning_id"].ToString() + ");' Class='btn btn-primary'align ='center' />";                               
               
               outputHTML +=   @"</tr>";
          } 
          outputHTML +=   "</table>";



            lblTrainning.Text = outputHTML;



        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Training_Record.aspx");
            }
            catch (Exception ex)
            {
                RegisterClientScriptBlock("OnLoad", "<script>alert('" + ex.Message.ToString() + "')</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
            try
            {

            }
            catch (Exception ex)
            {
                RegisterClientScriptBlock("OnLoad", "<script>alert('" + ex.Message.ToString() + "')</script>");
            }
        }

    }

}
