using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PS_ServiceCharge
{
    public class GsysSQL
    {
        #region //Execute Data
        public static DataTable fncGetQueryData(string lvSQL, DataTable dt)
        {
            string query = lvSQL;
            DataTable DTReturn = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(query, System.Configuration.ConfigurationManager.ConnectionStrings["DBPSConnectionString"].ToString());
            DA.Fill(DTReturn);

            return DTReturn;
        }
        public static string fncExecuteQueryData(string lvSQL)
        {
            string lvReturn = "";
            try
            {
                string query = lvSQL;
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBPSConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                con.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                con.Close();
                con.Dispose();

                lvReturn = "Success";
                return lvReturn;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        //#region //Check Data
        public static string fncCheck()
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBPSConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "Select COUNT(ID_ID) as COUNTID from Cane_ServiceCharge ";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn =(Gstr.fncToInt(dr["COUNTID"].ToString())+1).ToString();                    
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckID(string N ,string S,string D)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBPSConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "Select  SC_ID from Cane_ServiceCharge WHERE  NO_Name='"+ N + "' and SC_ID = '"+ S + "' and NO_Date='"+ D + "'";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["SC_ID"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }

        public static string fncCheckPrice(string Name)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBPSConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "Select NO_Price from Cane_ServiceCharge WHERE NO_Name='"+ Name + "'";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["NO_Price"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }
        public static string fncCheckDate(string Name)
        {
            #region //Connect Database 
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBPSConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            #endregion  

            string lvReturn = "";
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "Select NO_Date from Cane_ServiceCharge WHERE NO_Name='" + Name + "'";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lvReturn = dr["NO_Date"].ToString();
                }
            }
            dr.Close();
            con.Close();

            return lvReturn;
        }
        //public static string fncCheckUser(string lvUser)
        //{
        //    #region //Connect Database 
        //    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
        //    MySqlCommand cmd = new MySqlCommand();
        //    MySqlDataReader dr;
        //    #endregion  

        //    string lvReturn = "";

        //    cmd.Connection = con;
        //    con.Open();
        //    cmd.CommandText = "SELECT us_UserID FROM SysUser WHERE us_UserID = '" + lvUser + "' ";
        //    dr = cmd.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            lvReturn = dr["us_UserID"].ToString();
        //        }
        //    }
        //    dr.Close();
        //    con.Close();

        //    return lvReturn;
        //}
        //public static string fncCheckPass(string lvUser)
        //{
        //    #region //Connect Database 
        //    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
        //    MySqlCommand cmd = new MySqlCommand();
        //    MySqlDataReader dr;
        //    #endregion  

        //    string lvReturn = "";

        //    cmd.Connection = con;
        //    con.Open();
        //    cmd.CommandText = "SELECT us_Password FROM SysUser WHERE us_UserID = '" + lvUser + "' ";
        //    dr = cmd.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            lvReturn = dr["us_Password"].ToString();
        //        }
        //    }
        //    dr.Close();
        //    con.Close();

        //    return lvReturn;
        //}
        //public static string fncCheckEmail(string lvUser)
        //{
        //    #region //Connect Database 
        //    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
        //    MySqlCommand cmd = new MySqlCommand();
        //    MySqlDataReader dr;
        //    #endregion  

        //    string lvReturn = "";

        //    cmd.Connection = con;
        //    con.Open();
        //    cmd.CommandText = "SELECT us_Email FROM SysUser WHERE us_UserID = '" + lvUser + "' ";
        //    dr = cmd.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            lvReturn = dr["us_Email"].ToString();
        //        }
        //    }
        //    dr.Close();
        //    con.Close();

        //    return lvReturn;
        //}
        //#endregion
    }
}