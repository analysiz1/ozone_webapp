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
            string Empname = Txtnname.ToString();
            string role = Ddrole.SelectedValue;
            string dropin = Dddropin.SelectedValue;

            string sql = "insert into tbEmployee(Emp_title,Emp_name,Emp_position,Emp_province) values(' "+Title.ToString()+"','"+Empname.ToString()+"','"+role+"','"+dropin+"')";

            conSql.ExcuteSql(sql);

            Console.Write("Add Complete");



        }
    }
}