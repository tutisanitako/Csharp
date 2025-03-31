using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CinemaForms
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=PHOENIX\\MSSQLSERVER01;Database=OnlineCinemacsDB;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
            LoadUsers();
            LoadShowtimes();
            LoadBookings(); 

            IDTextBox.ReadOnly = true;
            MovieTextBox.ReadOnly = true;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView3.CellDoubleClick += dataGridView3_CellDoubleClick;
            ShowtimeComboBox.SelectedIndexChanged += ShowtimeComboBox_SelectedIndexChanged;
        }

        private async void LoadUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT UserID, UserName FROM Users";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    await Task.Run(() => adapter.Fill(table)); // table-s asinqronuli shevseba

                    DataRow emptyRow = table.NewRow();
                    emptyRow["UserID"] = DBNull.Value;
                    emptyRow["UserName"] = "-- Select User --";
                    table.Rows.InsertAt(emptyRow, 0);

                    UserComboBox.DisplayMember = "UserName";
                    UserComboBox.ValueMember = "UserID";
                    UserComboBox.DataSource = table;
                    UserComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private async void LoadBookings()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT b.BookingID, b.UserID, b.ShowtimeID, b.NumberOfTickets, s.Showtime
                                 FROM Bookings b
                                 JOIN Showtimes s ON b.ShowtimeID = s.ShowtimeID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    await Task.Run(() => adapter.Fill(table));

                    // Linq
                    var filteredBookings = table.AsEnumerable()
                        .Where(row => row.Field<DateTime>("Showtime") > DateTime.Now)
                        .OrderBy(row => row.Field<int>("BookingID"))
                        .ToList();

                    if (filteredBookings.Any())
                    {
                        dataGridView1.DataSource = filteredBookings.CopyToDataTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                    }

                    dataGridView3.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings: " + ex.Message);
            }
        }

        private async void LoadShowtimes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT s.ShowtimeID, s.Showtime, m.Title AS MovieTitle
                                       FROM Showtimes s
                                       JOIN Movies m ON s.MovieID = m.MovieID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    await Task.Run(() => adapter.Fill(table));

                    DataRow emptyRow = table.NewRow();
                    emptyRow["ShowtimeID"] = DBNull.Value;
                    emptyRow["Showtime"] = DBNull.Value;
                    emptyRow["MovieTitle"] = DBNull.Value;
                    table.Rows.InsertAt(emptyRow, 0);

                    ShowtimeComboBox.DisplayMember = "Showtime";
                    ShowtimeComboBox.ValueMember = "ShowtimeID";
                    ShowtimeComboBox.DataSource = table;
                    ShowtimeComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading showtimes: " + ex.Message);
            }
        }

        private async Task LoadMovieDetails(int showtimeID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT m.Title, g.GenreName, m.Duration, m.ReleaseDate, m.Language
                                       FROM Showtimes s
                                       JOIN Movies m ON s.MovieID = m.MovieID
                                       JOIN Genres g ON m.Genre = g.GenreID
                                       WHERE s.ShowtimeID = @ShowtimeID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ShowtimeID", showtimeID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    await Task.Run(() => adapter.Fill(table));

                    var movieDetails = table.AsEnumerable()
                        .Select(row => new
                        {
                            Title = row.Field<string>("Title"),
                            Genre = row.Field<string>("GenreName"),
                            Duration = row.Field<int>("Duration"),
                            ReleaseDate = row.Field<DateTime>("ReleaseDate"),
                            Language = row.Field<string>("Language")
                        }).ToList();

                    dataGridView2.DataSource = movieDetails;

                    if (movieDetails.Any())
                    {
                        MovieTextBox.Text = movieDetails.First().Title;
                        MovieTextBox.ReadOnly = true;
                        MovieTextBox.BackColor = SystemColors.Control;
                    }
                    else
                    {
                        MovieTextBox.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading movie details: " + ex.Message);
            }
        }

        private async void ShowtimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ShowtimeComboBox.SelectedIndex > 0)
            {
                int selectedShowtimeID = Convert.ToInt32(ShowtimeComboBox.SelectedValue);
                await LoadMovieDetails(selectedShowtimeID);
            }
        }

        private async void createButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserComboBox.SelectedIndex == 0 || ShowtimeComboBox.SelectedIndex == 0 || string.IsNullOrEmpty(TicketsTextBox.Text))
                {
                    MessageBox.Show("Please fill all the fields before creating a booking.");
                    return;
                }

                if (!int.TryParse(TicketsTextBox.Text, out int numberOfTickets) || numberOfTickets <= 0)
                {
                    MessageBox.Show("Please enter a valid number of tickets.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("InsertBooking", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int)).Value = UserComboBox.SelectedValue;
                    cmd.Parameters.Add(new SqlParameter("@ShowtimeID", SqlDbType.Int)).Value = ShowtimeComboBox.SelectedValue;
                    cmd.Parameters.Add(new SqlParameter("@NumberOfTickets", SqlDbType.Int)).Value = numberOfTickets;

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    MessageBox.Show("Booking created successfully!");
                    LoadBookings();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlTransaction transaction = null;

            try
            {
                if (string.IsNullOrEmpty(IDTextBox.Text) || UserComboBox.SelectedIndex == 0 || ShowtimeComboBox.SelectedIndex == 0 || string.IsNullOrEmpty(TicketsTextBox.Text))
                {
                    MessageBox.Show("Please fill all the fields before updating a booking.");
                    return;
                }

                if (!int.TryParse(TicketsTextBox.Text, out int numberOfTickets) || numberOfTickets <= 0)
                {
                    MessageBox.Show("Please enter a valid number of tickets.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to modify this booking?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return;
                }

                await conn.OpenAsync();
                transaction = conn.BeginTransaction();

                SqlCommand cmd = new SqlCommand(
                    "UPDATE Bookings SET UserID = @UserID, ShowtimeID = @ShowtimeID, NumberOfTickets = @NumberOfTickets WHERE BookingID = @BookingID", conn, transaction);

                cmd.Parameters.Add(new SqlParameter("@BookingID", SqlDbType.Int)).Value = int.Parse(IDTextBox.Text);
                cmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int)).Value = UserComboBox.SelectedValue;
                cmd.Parameters.Add(new SqlParameter("@ShowtimeID", SqlDbType.Int)).Value = ShowtimeComboBox.SelectedValue;
                cmd.Parameters.Add(new SqlParameter("@NumberOfTickets", SqlDbType.Int)).Value = numberOfTickets;

                await cmd.ExecuteNonQueryAsync();

                transaction.Commit();
                MessageBox.Show("Booking updated successfully!");

                LoadBookings();
                ResetForm();
            }
            catch (SqlException sqlEx)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show($"SQL Error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(IDTextBox.Text))
                {
                    MessageBox.Show("Please select a booking to delete.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this booking?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteBooking", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@BookingID", SqlDbType.Int)).Value = int.Parse(IDTextBox.Text);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    MessageBox.Show("Booking deleted successfully!");
                    LoadBookings();
                }

                ResetForm();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                IDTextBox.Text = row.Cells["BookingID"].Value?.ToString();
                UserComboBox.SelectedValue = row.Cells["UserID"].Value;
                ShowtimeComboBox.SelectedValue = row.Cells["ShowtimeID"].Value;
                TicketsTextBox.Text = row.Cells["NumberOfTickets"].Value?.ToString();

                createButton.Enabled = false;
                createButton.BackColor = Color.Gray;
                int showtimeID = Convert.ToInt32(row.Cells["ShowtimeID"].Value);
                await LoadMovieDetails(showtimeID);
            }
        }

        private async void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];

                IDTextBox.Text = row.Cells["BookingID"].Value?.ToString();
                UserComboBox.SelectedValue = row.Cells["UserID"].Value;
                ShowtimeComboBox.SelectedValue = row.Cells["ShowtimeID"].Value;
                TicketsTextBox.Text = row.Cells["NumberOfTickets"].Value?.ToString();

                createButton.Enabled = false;
                createButton.BackColor = Color.Gray;
                int showtimeID = Convert.ToInt32(row.Cells["ShowtimeID"].Value);
                await LoadMovieDetails(showtimeID);
            }
        }

        private void ResetForm()
        {
            IDTextBox.Clear();
            UserComboBox.SelectedIndex = 0;
            ShowtimeComboBox.SelectedIndex = 0;
            MovieTextBox.Clear();
            TicketsTextBox.Clear();

            createButton.Enabled = true;
            createButton.BackColor = Color.FromArgb(89, 108, 187);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            IDTextBox.Clear();
            MovieTextBox.Clear();
            TicketsTextBox.Clear();

            UserComboBox.SelectedIndex = 0;
            ShowtimeComboBox.SelectedIndex = 0;

            createButton.Enabled = true;
            createButton.BackColor = Color.FromArgb(89, 108, 187);
        }

    }
}