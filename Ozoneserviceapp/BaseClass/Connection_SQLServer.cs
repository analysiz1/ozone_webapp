﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Ozoneserviceapp.BaseClass
{
    public class Connection_SQLServer
    {
        SqlConnection sqlCon = new SqlConnection();
       
        public Connection_SQLServer()
        {
            sqlCon.ConnectionString = ConfigurationManager.ConnectionStrings["Ozoneservice_dbConnectionString"].ConnectionString;
        }

        public DataTable GetUser(string user , string pass)
        {
            try
            {
                
                DataTable dt = new DataTable();
                sqlCon.Open();
                string command = "select * from tbUser where Username='" + user + "' and Password='"+pass+"'";
                SqlDataAdapter da = new SqlDataAdapter(command, sqlCon);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw(new Exception("DBConnect error : '" + ex.Message + "'"));
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public DataTable SqlQuery(string sql)
        {

            try
            {

                DataTable dt = new DataTable();
                sqlCon.Open();
                string command = sql.ToString();
                SqlDataAdapter da = new SqlDataAdapter(command, sqlCon);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw (new Exception("DBConnect error : '" + ex.Message + "'"));
            }
            finally
            {
                sqlCon.Close();
            }



        }

        public DataTable GetTitleTraining()
        {
            try
            {
                DataTable dt = new DataTable();
                sqlCon.Open();
                string command = "select Trainning_id,Trainning_name,Trainning_no from tbTrainning where Trainning_status = 1";
                SqlDataAdapter da = new SqlDataAdapter(command, sqlCon);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw (new Exception("DBConnect error : '" + ex.Message + "'"));
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public bool UpdateData(string sql)
        {
            try
            {
                sqlCon.Open();
                SqlCommand sqlcomm = new SqlCommand(sql, sqlCon);

                int _row = sqlcomm.ExecuteNonQuery();

                if(_row > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw(new Exception("DBConnect error : " + ex.Message ));
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}