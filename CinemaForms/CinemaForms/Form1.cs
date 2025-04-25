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
        private DataSet cinemaDataSet;
        private DataTable displayBookingsTable;

        public Form1()
        {
            InitializeComponent();
            cinemaDataSet = new DataSet("CinemaData");
            displayBookingsTable = new DataTable("DisplayBookings");

            InitializeDataSet();

            IDTextBox.ReadOnly = true;
            MovieTextBox.ReadOnly = true;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView3.CellDoubleClick += dataGridView3_CellDoubleClick;
            ShowtimeComboBox.SelectedIndexChanged += ShowtimeComboBox_SelectedIndexChanged;
        }

        private async void InitializeDataSet()
        {
            await LoadUsers();
            await LoadShowtimes();
            await LoadBookings();
            await LoadMovies();
        }

        private async Task LoadUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT UserID, UserName FROM Users";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    DataTable usersTable = new DataTable("Users");
                    await Task.Run(() => adapter.Fill(usersTable));

                    if (!cinemaDataSet.Tables.Contains("Users"))
                    {
                        cinemaDataSet.Tables.Add(usersTable);
                    }
                    else
                    {
                        cinemaDataSet.Tables["Users"].Clear();
                        adapter.Fill(cinemaDataSet.Tables["Users"]);
                    }

                    DataTable comboTable = usersTable.Copy();
                    DataRow emptyRow = comboTable.NewRow();
                    emptyRow["UserID"] = DBNull.Value;
                    emptyRow["UserName"] = "-- Select User --";
                    comboTable.Rows.InsertAt(emptyRow, 0);

                    UserComboBox.DisplayMember = "UserName";
                    UserComboBox.ValueMember = "UserID";
                    UserComboBox.DataSource = comboTable;
                    UserComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private async Task LoadMovies()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT m.MovieID, m.Title, g.GenreName, m.Duration, m.ReleaseDate, m.Language
                                     FROM Movies m
                                     JOIN Genres g ON m.Genre = g.GenreID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    DataTable moviesTable = new DataTable("Movies");

                    DataColumn idColumn = new DataColumn("MovieID", typeof(int));
                    idColumn.AllowDBNull = false;
                    idColumn.Unique = true;
                    idColumn.AutoIncrement = false;
                    idColumn.Caption = "Movie ID";
                    moviesTable.Columns.Add(idColumn);

                    moviesTable.Columns.Add(new DataColumn("Title", typeof(string)));
                    moviesTable.Columns.Add(new DataColumn("GenreName", typeof(string)));
                    moviesTable.Columns.Add(new DataColumn("Duration", typeof(int)));
                    moviesTable.Columns.Add(new DataColumn("ReleaseDate", typeof(DateTime)));
                    moviesTable.Columns.Add(new DataColumn("Language", typeof(string)));

                    moviesTable.PrimaryKey = new DataColumn[] { idColumn };

                    await Task.Run(() => adapter.Fill(moviesTable));

                    if (!cinemaDataSet.Tables.Contains("Movies"))
                    {
                        cinemaDataSet.Tables.Add(moviesTable);
                    }
                    else
                    {
                        cinemaDataSet.Tables["Movies"].Clear();
                        adapter.Fill(cinemaDataSet.Tables["Movies"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading movies: " + ex.Message);
            }
        }

        private async Task LoadBookings()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string baseQuery = "SELECT BookingID, UserID, ShowtimeID, NumberOfTickets FROM Bookings";
                    SqlDataAdapter adapter = new SqlDataAdapter(baseQuery, conn);

                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                    DataTable bookingsTable = new DataTable("Bookings");
                    await Task.Run(() => adapter.Fill(bookingsTable));

                    if (!cinemaDataSet.Tables.Contains("Bookings"))
                    {
                        cinemaDataSet.Tables.Add(bookingsTable);
                    }
                    else
                    {
                        cinemaDataSet.Tables["Bookings"].Clear();
                        adapter.Fill(cinemaDataSet.Tables["Bookings"]);
                    }

                    if (cinemaDataSet.Tables.Contains("Users") && cinemaDataSet.Tables.Contains("Bookings"))
                    {
                        if (!cinemaDataSet.Relations.Contains("UserBookings"))
                        {
                            DataRelation relation = new DataRelation(
                                "UserBookings",
                                cinemaDataSet.Tables["Users"].Columns["UserID"],
                                cinemaDataSet.Tables["Bookings"].Columns["UserID"],
                                false
                            );
                            cinemaDataSet.Relations.Add(relation);
                        }
                    }

                    if (cinemaDataSet.Tables.Contains("Showtimes") && cinemaDataSet.Tables.Contains("Bookings"))
                    {
                        if (!cinemaDataSet.Relations.Contains("ShowtimeBookings"))
                        {
                            DataRelation relation = new DataRelation(
                                "ShowtimeBookings",
                                cinemaDataSet.Tables["Showtimes"].Columns["ShowtimeID"],
                                cinemaDataSet.Tables["Bookings"].Columns["ShowtimeID"],
                                false
                            );
                            cinemaDataSet.Relations.Add(relation);
                        }
                    }
                }

                await LoadDisplayBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings: " + ex.Message);
            }
        }

        private async Task LoadDisplayBookings()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string displayQuery = @"SELECT b.BookingID, b.UserID, b.ShowtimeID, b.NumberOfTickets, s.Showtime
                                            FROM Bookings b
                                            JOIN Showtimes s ON b.ShowtimeID = s.ShowtimeID";

                    SqlDataAdapter displayAdapter = new SqlDataAdapter(displayQuery, conn);

                    displayBookingsTable.Clear();
                    if (displayBookingsTable.Columns.Count == 0)
                    {
                        displayBookingsTable.Columns.Add("BookingID", typeof(int));
                        displayBookingsTable.Columns.Add("UserID", typeof(int));
                        displayBookingsTable.Columns.Add("ShowtimeID", typeof(int));
                        displayBookingsTable.Columns.Add("NumberOfTickets", typeof(int));
                        displayBookingsTable.Columns.Add("Showtime", typeof(DateTime));
                    }

                    await Task.Run(() => displayAdapter.Fill(displayBookingsTable));

                    DataTable allBookingsTable = displayBookingsTable.Copy();
                    dataGridView3.DataSource = allBookingsTable;

                    var filteredBookings = displayBookingsTable.AsEnumerable()
                        .Where(row => row.Field<DateTime>("Showtime") > DateTime.Now)
                        .OrderBy(row => row.Field<int>("BookingID"))
                        .ToList();

                    if (filteredBookings.Any())
                    {
                        dataGridView1.DataSource = filteredBookings.CopyToDataTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = new DataTable();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading display bookings: " + ex.Message);
            }
        }

        private async Task LoadShowtimes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string showtimeQuery = "SELECT ShowtimeID, MovieID, Showtime FROM Showtimes";
                    SqlDataAdapter showtimeAdapter = new SqlDataAdapter(showtimeQuery, conn);

                    DataTable showtimesTable = new DataTable("Showtimes");
                    await Task.Run(() => showtimeAdapter.Fill(showtimesTable));

                    if (!cinemaDataSet.Tables.Contains("Showtimes"))
                    {
                        cinemaDataSet.Tables.Add(showtimesTable);
                    }
                    else
                    {
                        cinemaDataSet.Tables["Showtimes"].Clear();
                        showtimeAdapter.Fill(cinemaDataSet.Tables["Showtimes"]);
                    }

                    if (cinemaDataSet.Tables.Contains("Movies") && cinemaDataSet.Tables.Contains("Showtimes"))
                    {
                        if (!cinemaDataSet.Relations.Contains("MovieShowtimes"))
                        {
                            DataRelation relation = new DataRelation(
                                "MovieShowtimes",
                                cinemaDataSet.Tables["Movies"].Columns["MovieID"],
                                cinemaDataSet.Tables["Showtimes"].Columns["MovieID"],
                                false
                            );
                            cinemaDataSet.Relations.Add(relation);
                        }
                    }

                    string displayQuery = @"SELECT s.ShowtimeID, s.MovieID, s.Showtime, m.Title AS MovieTitle
                                           FROM Showtimes s
                                           JOIN Movies m ON s.MovieID = m.MovieID";

                    SqlDataAdapter displayAdapter = new SqlDataAdapter(displayQuery, conn);
                    DataTable displayTable = new DataTable("ShowtimesDisplay");
                    await Task.Run(() => displayAdapter.Fill(displayTable));

                    DataTable comboTable = displayTable.Copy();
                    DataRow emptyRow = comboTable.NewRow();
                    emptyRow["ShowtimeID"] = DBNull.Value;
                    emptyRow["Showtime"] = DBNull.Value;
                    emptyRow["MovieTitle"] = "-- Select Showtime --";
                    comboTable.Rows.InsertAt(emptyRow, 0);

                    ShowtimeComboBox.DisplayMember = "Showtime";
                    ShowtimeComboBox.ValueMember = "ShowtimeID";
                    ShowtimeComboBox.DataSource = comboTable;
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
            if (ShowtimeComboBox.SelectedIndex > 0 && ShowtimeComboBox.SelectedValue != null)
            {
                int selectedShowtimeID = Convert.ToInt32(ShowtimeComboBox.SelectedValue);
                await LoadMovieDetails(selectedShowtimeID);
            }
            else
            {
                MovieTextBox.Text = "";
                dataGridView2.DataSource = null;
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

                if (cinemaDataSet.Tables.Contains("Bookings"))
                {
                    DataTable bookingsTable = cinemaDataSet.Tables["Bookings"];
                    DataRow newRow = bookingsTable.NewRow();

                    newRow["UserID"] = UserComboBox.SelectedValue;
                    newRow["ShowtimeID"] = ShowtimeComboBox.SelectedValue;
                    newRow["NumberOfTickets"] = numberOfTickets;

                    bookingsTable.Rows.Add(newRow);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT BookingID, UserID, ShowtimeID, NumberOfTickets FROM Bookings", conn);
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                        adapter.Update(bookingsTable.GetChanges());
                        bookingsTable.AcceptChanges();

                        MessageBox.Show("Booking created successfully!");

                        await LoadDisplayBookings();
                        ResetForm();
                    }
                }
                else
                {
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
                        await LoadDisplayBookings();
                        ResetForm();
                    }
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
            try
            {
                if (string.IsNullOrEmpty(IDTextBox.Text) || UserComboBox.SelectedIndex == 0 ||
                    ShowtimeComboBox.SelectedIndex == 0 || string.IsNullOrEmpty(TicketsTextBox.Text))
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

                int bookingID = int.Parse(IDTextBox.Text);

                if (cinemaDataSet.Tables.Contains("Bookings"))
                {
                    DataTable bookingsTable = cinemaDataSet.Tables["Bookings"];
                    DataRow[] bookingRows = bookingsTable.Select($"BookingID = {bookingID}");

                    if (bookingRows.Length > 0)
                    {
                        bookingRows[0]["UserID"] = UserComboBox.SelectedValue;
                        bookingRows[0]["ShowtimeID"] = ShowtimeComboBox.SelectedValue;
                        bookingRows[0]["NumberOfTickets"] = numberOfTickets;

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(
                                "SELECT BookingID, UserID, ShowtimeID, NumberOfTickets FROM Bookings", conn);

                            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                            DataTable changesTable = bookingsTable.GetChanges();
                            if (changesTable != null)
                            {
                                adapter.Update(changesTable);
                                bookingsTable.AcceptChanges();
                            }

                            MessageBox.Show("Booking updated successfully!");

                            await LoadDisplayBookings();
                            ResetForm();
                        }

                        return;
                    }
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        SqlCommand cmd = new SqlCommand(
                            "UPDATE Bookings SET UserID = @UserID, ShowtimeID = @ShowtimeID, NumberOfTickets = @NumberOfTickets WHERE BookingID = @BookingID",
                            conn, transaction);

                        cmd.Parameters.Add(new SqlParameter("@BookingID", SqlDbType.Int)).Value = bookingID;
                        cmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int)).Value = UserComboBox.SelectedValue;
                        cmd.Parameters.Add(new SqlParameter("@ShowtimeID", SqlDbType.Int)).Value = ShowtimeComboBox.SelectedValue;
                        cmd.Parameters.Add(new SqlParameter("@NumberOfTickets", SqlDbType.Int)).Value = numberOfTickets;

                        await cmd.ExecuteNonQueryAsync();

                        transaction.Commit();
                        MessageBox.Show("Booking updated successfully!");

                        await LoadDisplayBookings();
                        ResetForm();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
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

                int bookingID = int.Parse(IDTextBox.Text);

                if (cinemaDataSet.Tables.Contains("Bookings"))
                {
                    DataTable bookingsTable = cinemaDataSet.Tables["Bookings"];
                    DataRow[] bookingRows = bookingsTable.Select($"BookingID = {bookingID}");

                    if (bookingRows.Length > 0)
                    {
                        bookingRows[0].Delete();

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(
                                "SELECT BookingID, UserID, ShowtimeID, NumberOfTickets FROM Bookings", conn);

                            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                            adapter.Update(bookingsTable);
                            bookingsTable.AcceptChanges();

                            MessageBox.Show("Booking deleted successfully!");

                            await LoadDisplayBookings();
                            ResetForm();
                        }

                        return;
                    }
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteBooking", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@BookingID", SqlDbType.Int)).Value = bookingID;

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    MessageBox.Show("Booking deleted successfully!");
                    await LoadDisplayBookings();
                    ResetForm();
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

        private async void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["BookingID"].Value != null)
                {
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
        }

        private async void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView3.Rows.Count)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                if (row.Cells["BookingID"].Value != null)
                {
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
            ResetForm();
        }

        private void ExportDataSetSchema()
        {
            try
            {
                cinemaDataSet.WriteXmlSchema("CinemaSchema.xsd");
                MessageBox.Show("Schema exported successfully to CinemaSchema.xsd");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting schema: {ex.Message}");
            }
        }

        private void SaveDataSet()
        {
            try
            {
                cinemaDataSet.WriteXml("CinemaData.xml");
                MessageBox.Show("Data exported successfully to CinemaData.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}");
            }
        }
    }
}