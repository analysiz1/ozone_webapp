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
            string sql = "";
            Binddata(sql);
        }

        public void Binddata(string sql)
        {
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



            innerHTML += @" <tr class='headtable'>
            <td>1</td>
            <td>ต่อต้านยาเสพติด</td>
            <td>30/07/2559</td>
            <td>2/08/2559</td>
            <td>258 คน</td>            
            </tr>     ";

 
            innerHTML += " </table></div>";
            lbltrainning.Text = innerHTML;
        }
    }
}