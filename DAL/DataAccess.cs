using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoronaManagment.Models;

namespace CoronaManagment.DAL
{
    public class DataAccess
    {
        //------------------------------------------------------
        public static DataTable GetInsurees()
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.
                ConnectionStrings["ConnectionString1"].ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("dbo.GetInsureds", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable resultTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            dataAdapter.Fill(resultTable);
            conn.Close();
            return resultTable;
        }

        //------------------------------------
        public static void Delete(string Id)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.
                     ConnectionStrings["ConnectionString1"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.DeleteInsured", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", Id);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public static DataTable getInsuredInformByID(string Id)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.
                     ConnectionStrings["ConnectionString1"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.GetInsuredInfoByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InsuredID", Id);
            DataTable resultTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            dataAdapter.Fill(resultTable);
            conn.Close();
            return resultTable;
        }

        public static DataTable getInsuredInform(string Id)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.
                     ConnectionStrings["ConnectionString1"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.GetInsuredInfo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@InsuredID", Id);
            DataTable resultTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            dataAdapter.Fill(resultTable);
            conn.Close();
            return resultTable;
        }
        public static void Add(Insured insured)
        {
            try
            {
                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.
                     ConnectionStrings["ConnectionString1"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.InsertNew", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", insured.FirstName);
                cmd.Parameters.AddWithValue("@Famely", insured.LastName);
                cmd.Parameters.AddWithValue("@id", insured.InsuredID);
                cmd.Parameters.AddWithValue("@addres", insured.Addres);
                cmd.Parameters.AddWithValue("@birth", insured.BirthDate);
                cmd.Parameters.AddWithValue("@tel", insured.Tel);
                cmd.Parameters.AddWithValue("@phone", insured.Phone);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch(Exception e) 
            { string error = e.Message; }
        }

        public static void UpdateInsured(Insured insured)
        {
            try
            {
                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.
                     ConnectionStrings["ConnectionString1"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.UpdateInsured", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", insured.Id);
                cmd.Parameters.AddWithValue("@Name", insured.FirstName);
                cmd.Parameters.AddWithValue("@Famely", insured.LastName);
                cmd.Parameters.AddWithValue("@TZ", insured.InsuredID);
                cmd.Parameters.AddWithValue("@addres", insured.Addres);
                cmd.Parameters.AddWithValue("@birth", insured.BirthDate);
                cmd.Parameters.AddWithValue("@tel", insured.Tel);
                cmd.Parameters.AddWithValue("@phone", insured.Phone);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            { string error = e.Message; }
        }

        public static void AddVacine(Vacine vacine)
        {
            try
            {
                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.
                     ConnectionStrings["ConnectionString1"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.InsertNewVacine", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InsuredID", vacine.InsuredID);
                cmd.Parameters.AddWithValue("@Number", vacine.Number);
                cmd.Parameters.AddWithValue("@Company", vacine.Company);
                cmd.Parameters.AddWithValue("@ReceivingDate", vacine.ReceivingDate);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            { string error = e.Message; }
        }
    }
}
