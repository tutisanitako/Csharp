using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace classwork1
{
    public partial class Form1 : Form
    {
        private readonly string _connectionString = "Server=PHOENIX\\MSSQLSERVER01;Database=OnlineCinemacs;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
            LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    await con.OpenAsync();
                    string query = "SELECT UserID, FirstName, LastName FROM Users";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataSet ds = new DataSet();
                        await Task.Run(() => da.Fill(ds, "Users"));
                        dataGridView1.DataSource = ds.Tables["Users"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    await con.OpenAsync();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("InsertUser", con, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@FirstName", textBox1.Text));
                                cmd.Parameters.Add(new SqlParameter("@LastName", textBox2.Text));

                                await cmd.ExecuteNonQueryAsync();
                            }
                            transaction.Commit();
                            MessageBox.Show("User added successfully!");
                            await LoadUsersAsync();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("DeleteUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@UserID", textBox3.Text));

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                MessageBox.Show("User deleted successfully!");
                await LoadUsersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private async void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    await con.OpenAsync();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("UpdateUser", con, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@UserID", textBox3.Text));
                                cmd.Parameters.Add(new SqlParameter("@FirstName", textBox1.Text));
                                cmd.Parameters.Add(new SqlParameter("@LastName", textBox2.Text));

                                await cmd.ExecuteNonQueryAsync();
                            }
                            transaction.Commit();
                            MessageBox.Show("User updated successfully!");
                            await LoadUsersAsync();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
            }
        }

    }
}


