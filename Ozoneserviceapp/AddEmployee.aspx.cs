using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ozoneserviceapp.BaseClass;
using System.Data;


namespace Ozoneserviceapp
{
    public partial class AddEmployee : System.Web.UI.Page
    {

        Connection_SQLServer conSql = new Connection_SQLServer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btnadd_Click(object sender, EventArgs e)
        {
            string Title = Ddtitle.SelectedItem.ToString();
            string Empname = Txtnname.Text;
            string role = Ddrole.SelectedValue;
            string dropin = Dddropin.SelectedValue;

            string sql = "INSERT INTO tbEmployee(Emp_id,Emp_title,Emp_name,Emp_position,Emp_province,Emp_status) values((select max(Emp_id) from tbEmployee)+1 ,' " + Title.ToString() + "','" + Empname.ToString() + "','" + role + "','" + dropin + "',1)";         
            conSql.ExcuteSql(sql);



            ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Complete');", true);

           

        }
    }
}