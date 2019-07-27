using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors_Database_V1._0._1
{
     class DoctorsClass
     {
          public int DoctorID { get; set; }
          public string FullName { get; set; }
          public string Speciality { get; set; }
          public string Phone { get; set; }
          public string Address { get; set; }
          public string Email { get; set; }

          public static SqlConnection GetConnection()
          {
               string myconnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Docs.mdf;Integrated Security=True";
               SqlConnection conn = new SqlConnection(myconnstr);
               return conn;
          }

          public DataTable Select()
          {
               SqlConnection conn = GetConnection();
               DataTable dt = new DataTable();
               try
               {
                    string sql = "SELECT * FROM Doctors ";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    conn.Open();
                    adapt.Fill(dt);
               }
               catch (Exception ex)
               {

               }
               finally
               {
                    conn.Close();
               }
               return dt;
          }

          public bool Insert(DoctorsClass d)
          {
               bool Success = false;
               SqlConnection conn = GetConnection();
               try
               {
                    string sql = "INSERT INTO Doctors (FullName, Speciality, Phone, Address, Email) VALUES (@FullName, @Speciality, @Phone, @Address, @Email)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@FullName", d.FullName);
                    cmd.Parameters.AddWithValue("@Speciality", d.Speciality);
                    cmd.Parameters.AddWithValue("@Phone", d.Phone);
                    cmd.Parameters.AddWithValue("@Address", d.Address);
                    cmd.Parameters.AddWithValue("@Email", d.Email);
                    
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows>0)
                    {
                         Success = true;
                    }
                    else
                    {
                         Success = false;
                    }
               }
               catch (Exception ex)
               {

               }
               finally
               {
                    conn.Close();
               }
               return Success;
          }

          public bool Delete(DoctorsClass d)
          {
               bool Success = false;
               SqlConnection conn = GetConnection();
               try
               {
                    string sql = "DELETE FROM Doctors WHERE DoctorID=@DoctorID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@DoctorID", d.DoctorID);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                         Success = true;
                    }
                    else
                    {
                         Success = false;
                    }
               }
               catch (Exception ex)
               {

               }
               finally
               {
                    conn.Close();
               }
               return Success;

          }
     }
}
