using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Wordle_hw
{
    public partial class Form1 : Form
    {
        private enum PageState
        {
            Description,
            Login,
            Register,
            Game
        }

        private PageState _currentPage = PageState.Description;
        private User _currentUser = null; // Placeholder for user authentication

        public Form1()
        {
            InitializeComponent(); // **Crucially, this must run first to create all the UI controls**
            ShowDescriptionPage(); // Now it's safe to use the initialized controls
        }

        private void ShowDescriptionPage()
        {
            _currentPage = PageState.Description;
            pnlDescription.Visible = true;
            pnlLogin.Visible = false;
            pnlRegister.Visible = false;

            // **Double-check that these controls (btnLogout, lblWelcomeUser, btnLoginRegister) are correctly initialized in Form1.Designer.cs**
            if (_currentUser == null)
            {
                btnLogout.Visible = false;
                lblWelcomeUser.Visible = false;
                btnLoginRegister.Visible = false;
            }
            else
            {
                btnLogout.Visible = true;
                lblWelcomeUser.Visible = true;
                lblWelcomeUser.Text = $"Welcome, {_currentUser.UserName}!";
                btnLoginRegister.Visible = false;
            }

            // Call the method to create example tiles
            CreateExampleTiles();
        }


        private void ShowLoginPage()
        {
            _currentPage = PageState.Login;
            pnlDescription.Visible = false;
            pnlLogin.Visible = true;
            pnlRegister.Visible = false;
            lblLoginError.Visible = false; // Reset error message
            txtLoginEmail.Text = "";
            txtLoginPassword.Text = "";
        }

        private void ShowRegisterPage()
        {
            _currentPage = PageState.Register;
            pnlDescription.Visible = false;
            pnlLogin.Visible = false;
            pnlRegister.Visible = true;
            lblRegisterError.Visible = false; // Reset error message
            txtRegisterUsername.Text = "";
            txtRegisterEmail.Text = "";
            txtRegisterPassword.Text = "";
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }


        private void btnLoginRegister_Click(object sender, EventArgs e)
        {
            ShowLoginPage();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShowDescriptionPage();
        }

        private void lnkCreateAccount_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowRegisterPage();
        }

        private void lnkBackToLogin_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLoginPage();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblLoginError.Visible = false;

            string email = txtLoginEmail.Text.Trim();
            string password = txtLoginPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                lblLoginError.Text = "Email and password are required.";
                lblLoginError.Visible = true;
                return;
            }

            if (!IsValidEmail(email))
            {
                lblLoginError.Text = "Invalid email format.";
                lblLoginError.Visible = true;
                return;
            }

            try
            {
                using (var context = new EF.DataModelContainer())
                {
                    var user = context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

                    if (user != null)
                    {
                        _currentUser = new User { UserName = user.UserName, Email = user.Email };
                        ShowDescriptionPage();
                    }
                    else
                    {
                        lblLoginError.Text = "Invalid email or password.";
                        lblLoginError.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblLoginError.Text = "Login error: " + ex.Message;
                lblLoginError.Visible = true;
            }
        }



        private void btnRegister_Click(object sender, EventArgs e)
        {
            lblRegisterError.Visible = false;

            string username = txtRegisterUsername.Text.Trim();
            string email = txtRegisterEmail.Text.Trim();
            string password = txtRegisterPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                lblRegisterError.Text = "All fields are required.";
                lblRegisterError.Visible = true;
                return;
            }

            if (!IsValidEmail(email))
            {
                lblRegisterError.Text = "Invalid email format.";
                lblRegisterError.Visible = true;
                return;
            }

            try
            {
                using (var context = new EF.DataModelContainer())
                {
                    // Check for existing username or email
                    bool emailExists = context.Users.Any(u => u.Email == email);
                    bool usernameExists = context.Users.Any(u => u.UserName == username);

                    if (emailExists)
                    {
                        lblRegisterError.Text = "This email is already registered.";
                        lblRegisterError.Visible = true;
                        return;
                    }

                    if (usernameExists)
                    {
                        lblRegisterError.Text = "This username is already taken.";
                        lblRegisterError.Visible = true;
                        return;
                    }

                    var newUser = new EF.Users
                    {
                        UserName = username,
                        Email = email,
                        Password = password, // Note: Use hashed passwords in production
                        Created_at = DateTime.Now
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();

                    _currentUser = new User { UserName = newUser.UserName, Email = newUser.Email };
                }

                MessageBox.Show("Account created successfully!");
                ShowDescriptionPage();
            }
            catch (Exception ex)
            {
                lblRegisterError.Text = "Error creating account: " + ex.Message;
                lblRegisterError.Visible = true;
            }
        }



        private void btnLogout_Click(object sender, EventArgs e)
        {
            _currentUser = null;
            ShowDescriptionPage();
        }

        private void CreateExampleTiles()
        {
            // Remove any existing example tiles to avoid duplicates
            foreach (Control control in pnlDescription.Controls)
            {
                if (control.Tag != null && control.Tag.ToString() == "exampleTile")
                {
                    pnlDescription.Controls.Remove(control);
                }
            }

            int startX = 23;
            int startY = lblExamples.Location.Y + lblExamples.Height + 20;
            int tileSpacing = 45;
            int descriptionOffset = 45;

            // Example 1: WORDY
            CreateTile(startX, startY, "W", Color.FromArgb(120, 177, 89)); // Green
            CreateTile(startX + tileSpacing, startY, "O", Color.White);
            CreateTile(startX + 2 * tileSpacing, startY, "R", Color.White);
            CreateTile(startX + 3 * tileSpacing, startY, "D", Color.White);
            CreateTile(startX + 4 * tileSpacing, startY, "Y", Color.White);
            CreateExampleDescription(startX, startY + descriptionOffset, "W is in the word and in the correct spot.");
            startY += 80;

            // Example 2: LIGHT
            CreateTile(startX, startY, "L", Color.White);
            CreateTile(startX + tileSpacing, startY, "I", Color.FromArgb(201, 180, 88)); // Yellow
            CreateTile(startX + 2 * tileSpacing, startY, "G", Color.White);
            CreateTile(startX + 3 * tileSpacing, startY, "H", Color.White);
            CreateTile(startX + 4 * tileSpacing, startY, "T", Color.White);
            CreateExampleDescription(startX, startY + descriptionOffset, "I is in the word but in the wrong spot.");
            startY += 80;

            // Example 3: ROGUE
            CreateTile(startX, startY, "R", Color.White);
            CreateTile(startX + tileSpacing, startY, "O", Color.White);
            CreateTile(startX + 2 * tileSpacing, startY, "G", Color.White);
            CreateTile(startX + 3 * tileSpacing, startY, "U", Color.FromArgb(129, 131, 132)); // Gray
            CreateTile(startX + 4 * tileSpacing, startY, "E", Color.White);
            CreateExampleDescription(startX, startY + descriptionOffset, "U is not in the word in any spot.");
        }

        private void CreateTile(int x, int y, string letter, Color bgColor)
        {
            Panel tile = new Panel();
            tile.Size = new Size(35, 35);
            tile.Location = new Point(x, y);
            tile.BorderStyle = BorderStyle.FixedSingle;
            tile.BackColor = bgColor;
            tile.Tag = "exampleTile"; // Tag to identify example tiles

            Label lblLetter = new Label();
            lblLetter.Text = letter;
            lblLetter.Font = new Font("Arial", 16, FontStyle.Bold);
            lblLetter.AutoSize = false;
            lblLetter.Size = new Size(35, 35);
            lblLetter.TextAlign = ContentAlignment.MiddleCenter;
            lblLetter.BackColor = Color.Transparent;

            tile.Controls.Add(lblLetter);
            pnlDescription.Controls.Add(tile);
        }

        private void CreateExampleDescription(int x, int y, string text)
        {
            Label description = new Label();
            description.AutoSize = true;
            description.Location = new Point(x, y);
            description.Text = text;
            description.Font = new Font("Arial", 12);
            description.Tag = "exampleTile"; // Tag to identify example tiles
            pnlDescription.Controls.Add(description);
        }

        private void lnkAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLoginPage();
        }

        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowRegisterPage();
        }
    }

    // Placeholder for User class
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        // Add other user properties as needed
    }
}