﻿using System;
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
                AddTrainning(Empid,Tid);
                postback = Empid+":0"; /*return 0 for red btn*/
                context.Response.ContentType = "text/plain";
                context.Response.Write(Empid);

            }
            else if (Status == "11") // delete Trainning
            {
                UpdatestatusTrainning(Tid);
                context.Response.ContentType = "text/plain";
                context.Response.Write(Tid);
            }
            else // delete person
            {
                DeleteTrainning(Empid,Tid);
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
        
        public void AddTrainning(string Emp_id,string Train_id)
        {            
            string AddSql = "INSERT INTO tbManageTrainning(Trainning_id,Emp_id,Status) VALUES("+Train_id+"," + Emp_id + ",1)";
            conSql.ExcuteSql(AddSql);
            
        }
        public void DeleteTrainning(string Emp_id, string Train_id)
        {
            string DelSql = "UPDATE dbo.tbTrainning SET Trainning_status='0' WHERE Trainning_id = " + Emp_id.ToString();
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