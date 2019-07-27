using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctors_Database_V1._0._1
{
     public partial class Doctors : Form
     {
          DoctorsClass d = new DoctorsClass();
          public Doctors()
          {
               InitializeComponent();
          }

          
          private void BtnAdd_Click(object sender, EventArgs e)
          {
               d.FullName = txtFN.Text;
               d.Speciality = txtSP.Text;
               d.Phone = txtPH.Text;
               d.Address = txtAD.Text;
               d.Email = txtEM.Text;
               bool S = d.Insert(d);
               if (S == true)
               {
                    MessageBox.Show("New Doctor Successfully Added");
                    Clear();
               }
               else
               {
                    MessageBox.Show("Failed to Add Doctor");
               }
               DataTable dt = d.Select();
               DG.DataSource = dt;

          }

          private void Doctors_Load(object sender, EventArgs e)
          {
               DataTable dt = d.Select();
               DG.DataSource = dt;
          }

          public void Clear()
          {
               txtID.Text = "";
               txtFN.Text = "";
               txtSP.Text = "";
               txtPH.Text = "";
               txtAD.Text = "";
               txtEM.Text = "";
          }

          private void About_Click(object sender, EventArgs e)
          {
               MessageBox.Show("This Software is Designed as a project in Software Engineering by: \n\n Mark Joseph \n Youssif Kamil \n Mina Laban \n Romario Samir");
          }

          private void DG_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
          {
               int rowIndex = e.RowIndex;
               txtID.Text = DG.Rows[rowIndex].Cells[0].Value.ToString();
               txtFN.Text = DG.Rows[rowIndex].Cells[1].Value.ToString();
               txtSP.Text = DG.Rows[rowIndex].Cells[2].Value.ToString();
               txtPH.Text = DG.Rows[rowIndex].Cells[3].Value.ToString();
               txtAD.Text = DG.Rows[rowIndex].Cells[4].Value.ToString();
               txtEM.Text = DG.Rows[rowIndex].Cells[5].Value.ToString();
          }

          private void BtnClear_Click(object sender, EventArgs e)
          {
               Clear();
          }

          private void BtnRemove_Click(object sender, EventArgs e)
          {
               d.DoctorID = Convert.ToInt32(txtID.Text);
               bool S = d.Delete(d);
               if(S==true)
               {
                    MessageBox.Show("Doctor Successfully Removed");
                    Clear();
               }
               else
               {
                    MessageBox.Show("Failed to Remove Doctor");
               }
               DataTable dt = d.Select();
               DG.DataSource = dt;
          }

          public static SqlConnection GetConnection()
          {
               string myconnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Docs.mdf;Integrated Security=True";
               SqlConnection conn = new SqlConnection(myconnstr);
               return conn;
          }

          private void txtSE_TextChanged(object sender, EventArgs e)
          {
               string key = txtSE.Text;
               SqlConnection conn = GetConnection();
               SqlDataAdapter sAdapt = new SqlDataAdapter("SELECT * FROM Doctors WHERE FullName LIKE '%"+key+ "%' OR Speciality LIKE '%" + key + "%' OR Phone LIKE '%" + key + "%' OR Address LIKE '%" + key + "%' OR Email LIKE '%" + key + "%'", GetConnection());
               DataTable dt = new DataTable();
               sAdapt.Fill(dt);
               DG.DataSource = dt;
          }

        private void MapsBtn_Click(object sender, EventArgs e)
        {
            string location = txtAD.Text;
            try
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("http://maps.google.com/maps?q=Egypt ");
                if(location!=string.Empty)
                {
                    builder.Append(location);

                }
                MapsBrowser.Navigate(builder.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error Searching Google Maps");
            }
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
