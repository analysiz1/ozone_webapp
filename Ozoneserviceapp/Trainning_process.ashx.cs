using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ozoneserviceapp.BaseClass;
using System.Web.Script.Serialization;
namespace Ozoneserviceapp
{
    /// <summary>
    /// Summary description for Trainning_process
    /// </summary>
    public class Trainning_process : IHttpHandler
    {

        Connection_SQLServer conSql = new Connection_SQLServer();
        public void ProcessRequest(HttpContext context)
        {

            string Empid = context.Request.QueryString["Empid"];
            string Tid = context.Request.QueryString["Tid"];       
            string Status = context.Request.QueryString["Status"];
            string postback = "";

           
           
                       
           
            if(Status=="1") // add person 
            {
                AddEmpTrainning(Empid, Tid);
                postback = Empid+":0"; /*return 0 for red btn*/
                context.Response.ContentType = "text/plain";
                context.Response.Write(Empid);

            }
            else if (Status == "11") // delete Trainning 11/09/2559
            {
                UpdatestatusTrainning(Tid);
                context.Response.ContentType = "text/plain";
                context.Response.Write(Tid);
            }
            else // delete person
            {
                DeleteEmpTrainning(Empid, Tid);
                postback = Empid+":1"; /* return 1 for Blue btn*/ 
                context.Response.ContentType = "text/plain";
                context.Response.Write(Empid);
            }
                       
            
           
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        
        public void AddEmpTrainning(string Emp_id,string Train_id)
        {            
            string AddSql = "INSERT INTO tbManageTrainning(Trainning_id,Emp_id,Status) VALUES("+Train_id+"," + Emp_id + ",1)";
            conSql.ExcuteSql(AddSql);
            
        }
        public void DeleteEmpTrainning(string Emp_id, string Train_id)
        {
            string DelSql = @"DELETE FROM tbManageTrainning  
WHERE Emp_id ='"+Emp_id.ToString()+"' and Trainning_id ="+Train_id.ToString()+" ";
            conSql.ExcuteSql(DelSql);
            
        }
        public void UpdatestatusTrainning(string Train_id)
        {
            string updatesql = @"
                                        UPDATE dbo.tbTrainning 
                                        SET  Trainning_status = 0
                                        WHERE Trainning_id = '"+Train_id.ToString()+"' ";
            conSql.ExcuteSql(updatesql);
        }
    }
}