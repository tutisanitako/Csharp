using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Homework3.EF;
using Microsoft.EntityFrameworkCore;

namespace Homework3
{
    public partial class Form1 : Form
    {
        private enum PageState
        {
            Description,
            Login,
            Register,
            Statistics,
            Game
        }

        private PageState _currentPage = PageState.Description;
        private User _currentUser = null;
        private string _targetWord;
        private int _currentAttempt = 0;
        private const int MaxAttempts = 6;
        private const int WordLength = 5;
        private List<Label> _gridLabels = new List<Label>();
        private Dictionary<char, Button> _keyboardButtons = new Dictionary<char, Button>();
        private Random _random = new Random();

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();

            // Enable key events for physical keyboard support
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            ShowDescriptionPage();
        }

        private void InitializeDatabase()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WordleModel>();
            optionsBuilder.UseSqlServer("Data Source=PHOENIX\\MSSQLSERVER01;Initial Catalog=WordleDbcs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            using (var context = new WordleModel(optionsBuilder.Options))
            {
                // Ensure database is created
                context.Database.EnsureCreated();

                // Check if there are any selectable words
                if (!context.Words.Any(w => w.IsSelectable))
                {
                    var defaultWords = new List<Word>
                    {
                        new Word { WordText = "BLACK", IsSelectable = true },
                        new Word { WordText = "FLOAT", IsSelectable = true },
                        new Word { WordText = "AISLE", IsSelectable = true },
                        new Word { WordText = "HATCH", IsSelectable = true },
                        new Word { WordText = "MELTS", IsSelectable = true },
                        new Word { WordText = "CRANE", IsSelectable = true },
                        new Word { WordText = "SLATE", IsSelectable = true },
                        new Word { WordText = "HOUSE", IsSelectable = true },
                        new Word { WordText = "FLAME", IsSelectable = true },
                        new Word { WordText = "STORM", IsSelectable = true }
                    };

                    context.Words.AddRange(defaultWords);
                    context.SaveChanges();
                }
            }
        }

        private WordleModel GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WordleModel>();
            optionsBuilder.UseSqlServer("Data Source=PHOENIX\\MSSQLSERVER01;Initial Catalog=WordleDbcs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return new WordleModel(optionsBuilder.Options);
        }

        private void ShowDescriptionPage()
        {
            _currentPage = PageState.Description;
            pnlDescription.Visible = true;
            pnlLogin.Visible = false;
            pnlRegister.Visible = false;
            pnlStatistics.Visible = false;
            pnlGame.Visible = false;

            if (_currentUser == null)
            {
                btnLogout.Visible = false;
                lblWelcomeUser.Visible = false;
                btnLoginRegister.Visible = true;
                btnLoginRegister.Text = "Login / Register";
            }
            else
            {
                btnLogout.Visible = true;
                lblWelcomeUser.Visible = true;
                lblWelcomeUser.Text = $"Welcome, {_currentUser.Email}!";
                btnLoginRegister.Visible = true;
                btnLoginRegister.Text = "Statistics";
            }

            CreateExampleTiles();
        }

        private void ShowLoginPage()
        {
            _currentPage = PageState.Login;
            pnlDescription.Visible = false;
            pnlLogin.Visible = true;
            pnlRegister.Visible = false;
            pnlStatistics.Visible = false;
            pnlGame.Visible = false;
            lblLoginError.Visible = false;
            txtLoginEmail.Text = "";
            txtLoginPassword.Text = "";
        }

        private void ShowRegisterPage()
        {
            _currentPage = PageState.Register;
            pnlDescription.Visible = false;
            pnlLogin.Visible = false;
            pnlRegister.Visible = true;
            pnlStatistics.Visible = false;
            pnlGame.Visible = false;
            lblRegisterError.Visible = false;
            txtRegisterUsername.Text = "";
            txtRegisterEmail.Text = "";
            txtRegisterPassword.Text = "";
        }

        private void ShowStatisticsPage()
        {
            _currentPage = PageState.Statistics;
            pnlDescription.Visible = false;
            pnlLogin.Visible = false;
            pnlRegister.Visible = false;
            pnlStatistics.Visible = true;
            pnlGame.Visible = false;

            using (var context = GetContext())
            {
                var stats = context.UserStatistics.FirstOrDefault(s => s.UserId == _currentUser.Id);
                if (stats != null)
                {
                    lblPlayed.Text = stats.GamesPlayed.ToString();
                    // Calculate win percentage manually since it's not a computed column in Code First
                    double winPercentage = stats.GamesPlayed > 0 ? (double)stats.Wins / stats.GamesPlayed * 100 : 0;
                    lblWinPercent.Text = winPercentage.ToString("F0") + "%";
                    lblCurrentStreak.Text = stats.CurrentStreak.ToString();
                    lblMaxStreak.Text = stats.MaxStreak.ToString();
                }
                else
                {
                    lblPlayed.Text = "0";
                    lblWinPercent.Text = "0%";
                    lblCurrentStreak.Text = "0";
                    lblMaxStreak.Text = "0";
                }
            }
        }

        private void ShowGamePage()
        {
            _currentPage = PageState.Game;
            pnlDescription.Visible = false;
            pnlLogin.Visible = false;
            pnlRegister.Visible = false;
            pnlStatistics.Visible = false;
            pnlGame.Visible = true;

            InitializeGameControls();
            StartNewGame();
        }

        private void InitializeGameControls()
        {
            // Clear existing controls if any
            _gridLabels.Clear();
            _keyboardButtons.Clear();

            // Clear only dynamically created controls, preserve static ones
            var controlsToRemove = pnlGame.Controls.Cast<Control>()
                .Where(c => c is Panel || (c is Button && c.Name != "btnGameBack"))
                .ToList();

            foreach (Control control in controlsToRemove)
            {
                pnlGame.Controls.Remove(control);
            }

            // Game Grid - centered and properly spaced
            int tileSize = 50;
            int spacing = 5;
            int gridWidth = 5 * tileSize + 4 * spacing; // Total width of the grid
            int startX = (pnlGame.Width - gridWidth) / 2; // Center horizontally
            int startY = 50; // Start from top with some margin

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Panel tile = new Panel();
                    tile.Size = new Size(tileSize, tileSize);
                    tile.Location = new Point(startX + col * (tileSize + spacing), startY + row * (tileSize + spacing));
                    tile.BorderStyle = BorderStyle.FixedSingle;
                    tile.BackColor = Color.White;

                    Label lblLetter = new Label();
                    lblLetter.Font = new Font("Arial", 18, FontStyle.Bold);
                    lblLetter.AutoSize = false;
                    lblLetter.Size = new Size(tileSize, tileSize);
                    lblLetter.TextAlign = ContentAlignment.MiddleCenter;
                    lblLetter.BackColor = Color.Transparent;
                    lblLetter.ForeColor = Color.Black;

                    tile.Controls.Add(lblLetter);
                    pnlGame.Controls.Add(tile);
                    _gridLabels.Add(lblLetter);
                }
            }

            // Keyboard - positioned below the grid
            string[] keyboardRows = new string[] { "QWERTYUIOP", "ASDFGHJKL", "ZXCVBNM" };
            int keyboardStartY = startY + 6 * (tileSize + spacing) + 30; // Position below grid
            int keySize = 35;
            int keySpacing = 3;

            for (int row = 0; row < keyboardRows.Length; row++)
            {
                string currentRow = keyboardRows[row];
                int rowWidth = currentRow.Length * keySize + (currentRow.Length - 1) * keySpacing;
                int rowStartX = (pnlGame.Width - rowWidth) / 2; // Center each row

                for (int col = 0; col < currentRow.Length; col++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(keySize, keySize);
                    btn.Location = new Point(rowStartX + col * (keySize + keySpacing), keyboardStartY + row * (keySize + keySpacing));
                    btn.Text = currentRow[col].ToString();
                    btn.Font = new Font("Arial", 12, FontStyle.Bold);
                    btn.Click += new EventHandler(this.KeyboardButton_Click);
                    btn.BackColor = SystemColors.Control;
                    btn.ForeColor = Color.Black;

                    pnlGame.Controls.Add(btn);
                    _keyboardButtons.Add(currentRow[col], btn);
                }
            }

            // Enter and Backspace Buttons - positioned on the bottom row
            int bottomRowY = keyboardStartY + 2 * (keySize + keySpacing);

            Button btnEnter = new Button();
            btnEnter.Size = new Size(70, keySize);
            btnEnter.Location = new System.Drawing.Point(18, 495);
            btnEnter.Text = "ENTER";
            btnEnter.Font = new Font("Arial", 9, FontStyle.Bold);
            btnEnter.Click += new EventHandler(this.KeyboardButton_Click);
            btnEnter.BackColor = SystemColors.Control;
            btnEnter.ForeColor = Color.Black;
            btnEnter.Name = "btnEnter"; // Add name for identification
            pnlGame.Controls.Add(btnEnter);

            Button btnBackspace = new Button();
            btnBackspace.Size = new Size(70, keySize);
            btnBackspace.Location = new System.Drawing.Point(558, 495);
            btnBackspace.Text = "⌫";
            btnBackspace.Font = new Font("Arial", 14, FontStyle.Bold);
            btnBackspace.Click += new EventHandler(this.KeyboardButton_Click);
            btnBackspace.BackColor = SystemColors.Control;
            btnBackspace.ForeColor = Color.Black;
            btnBackspace.Name = "btnBackspace"; // Add name for identification
            pnlGame.Controls.Add(btnBackspace);
        }

        private void StartNewGame()
        {
            _currentAttempt = 0;
            using (var context = GetContext())
            {
                // Ensure there are selectable words in the database
                var selectableWords = context.Words.Where(w => w.IsSelectable).ToList();

                // If no selectable words exist, add some default ones
                if (!selectableWords.Any())
                {
                    var defaultWords = new List<Word>
                    {
                        new Word { WordText = "BLACK", IsSelectable = true },
                        new Word { WordText = "FLOAT", IsSelectable = true },
                        new Word { WordText = "AISLE", IsSelectable = true },
                        new Word { WordText = "HATCH", IsSelectable = true },
                        new Word { WordText = "MELTS", IsSelectable = true }
                    };

                    context.Words.AddRange(defaultWords);
                    context.SaveChanges();
                    selectableWords = defaultWords;
                }

                // Now select a random word
                _targetWord = selectableWords[_random.Next(selectableWords.Count)].WordText.ToUpper();

                // Reset the grid
                foreach (var label in _gridLabels)
                {
                    label.Text = "";
                    label.BackColor = Color.White;
                }

                // Reset the keyboard
                foreach (var kvp in _keyboardButtons)
                {
                    kvp.Value.BackColor = SystemColors.Control;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Only handle keyboard input when on the game page
            if (_currentPage != PageState.Game)
                return;

            // Prevent default handling to avoid conflicts
            e.Handled = true;

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                SubmitGuess();
            }
            else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                RemoveLastLetter();
            }
            else if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                // Convert key to character and add letter
                char letter = (char)e.KeyCode;
                AddLetter(letter);
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 8;
        }

        private bool IsValidWord(string word)
        {
            // Check if the word is exactly 5 letters and contains only alphabetic characters
            if (string.IsNullOrWhiteSpace(word) || word.Length != WordLength)
                return false;

            return word.All(char.IsLetter);
        }

        private void btnLoginRegister_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                ShowLoginPage();
            }
            else
            {
                ShowStatisticsPage();
            }
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
                using (var context = GetContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
                    if (user != null)
                    {
                        _currentUser = user;
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

            string email = txtRegisterEmail.Text.Trim();
            string password = txtRegisterPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
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

            if (!IsValidPassword(password))
            {
                lblRegisterError.Text = "Password must be at least 8 characters long.";
                lblRegisterError.Visible = true;
                return;
            }

            try
            {
                using (var context = GetContext())
                {
                    if (context.Users.Any(u => u.Email == email))
                    {
                        lblRegisterError.Text = "This email is already registered.";
                        lblRegisterError.Visible = true;
                        return;
                    }

                    var newUser = new User
                    {
                        Email = email,
                        PasswordHash = password,
                        CreatedAt = DateTime.Now
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();

                    var userStats = new UserStatistic
                    {
                        UserId = newUser.Id,
                        GamesPlayed = 0,
                        Wins = 0,
                        MaxStreak = 0,
                        CurrentStreak = 0
                    };

                    context.UserStatistics.Add(userStats);
                    context.SaveChanges();

                    _currentUser = newUser;
                    MessageBox.Show("Account created successfully!");
                    ShowDescriptionPage();
                }
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

            CreateTile(startX, startY, "W", Color.FromArgb(120, 177, 89));
            CreateTile(startX + tileSpacing, startY, "O", Color.White);
            CreateTile(startX + 2 * tileSpacing, startY, "R", Color.White);
            CreateTile(startX + 3 * tileSpacing, startY, "D", Color.White);
            CreateTile(startX + 4 * tileSpacing, startY, "Y", Color.White);
            CreateExampleDescription(startX, startY + descriptionOffset, "W is in the word and in the correct spot.");
            startY += 80;

            CreateTile(startX, startY, "L", Color.White);
            CreateTile(startX + tileSpacing, startY, "I", Color.FromArgb(201, 180, 88));
            CreateTile(startX + 2 * tileSpacing, startY, "G", Color.White);
            CreateTile(startX + 3 * tileSpacing, startY, "H", Color.White);
            CreateTile(startX + 4 * tileSpacing, startY, "T", Color.White);
            CreateExampleDescription(startX, startY + descriptionOffset, "I is in the word but in the wrong spot.");
            startY += 80;

            CreateTile(startX, startY, "R", Color.White);
            CreateTile(startX + tileSpacing, startY, "O", Color.White);
            CreateTile(startX + 2 * tileSpacing, startY, "G", Color.White);
            CreateTile(startX + 3 * tileSpacing, startY, "U", Color.FromArgb(129, 131, 132));
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
            tile.Tag = "exampleTile";

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
            description.Tag = "exampleTile";
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

        private void btnStatsBack_Click(object sender, EventArgs e)
        {
            ShowDescriptionPage();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            ShowGamePage();
        }

        private void btnGameBack_Click(object sender, EventArgs e)
        {
            ShowStatisticsPage();
        }

        private void KeyboardButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Text == "ENTER")
            {
                SubmitGuess();
            }
            else if (btn.Text == "⌫")
            {
                RemoveLastLetter();
            }
            else if (btn.Text.Length == 1 && char.IsLetter(btn.Text[0]))
            {
                AddLetter(btn.Text[0]);
            }
        }

        private void AddLetter(char letter)
        {
            // Find the current row and count filled letters in that row
            int rowStart = _currentAttempt * WordLength;
            int filledInCurrentRow = 0;

            for (int i = 0; i < WordLength; i++)
            {
                if (!string.IsNullOrEmpty(_gridLabels[rowStart + i].Text))
                {
                    filledInCurrentRow++;
                }
                else
                {
                    break; // Stop at first empty cell
                }
            }

            // Add letter only if there's space in current row
            if (filledInCurrentRow < WordLength)
            {
                _gridLabels[rowStart + filledInCurrentRow].Text = letter.ToString().ToUpper();
            }
        }

        private void RemoveLastLetter()
        {
            // Find the current row and remove the last filled letter
            int rowStart = _currentAttempt * WordLength;

            // Find the last filled position in current row
            for (int i = WordLength - 1; i >= 0; i--)
            {
                if (!string.IsNullOrEmpty(_gridLabels[rowStart + i].Text))
                {
                    _gridLabels[rowStart + i].Text = "";
                    break;
                }
            }
        }

        private void SubmitGuess()
        {
            int startIndex = _currentAttempt * WordLength;
            string guess = "";
            for (int i = 0; i < WordLength; i++)
            {
                guess += _gridLabels[startIndex + i].Text;
            }

            if (guess.Length != WordLength)
            {
                MessageBox.Show("Please enter a 5-letter word.");
                return;
            }

            // Validate that the guess is a valid word format (5 letters, alphabetic characters only)
            if (!IsValidWord(guess))
            {
                MessageBox.Show("Please enter a valid 5-letter word with only alphabetic characters.");
                return;
            }

            using (var context = GetContext())
            {
                // Check if the guessed word exists in the database, if not, add it
                var wordEntity = context.Words.FirstOrDefault(w => w.WordText.ToUpper() == guess.ToUpper());
                if (wordEntity == null)
                {
                    // Add the new word to the database (but not as selectable for target words)
                    wordEntity = new Word
                    {
                        WordText = guess.ToUpper(),
                        IsSelectable = false // User-entered words are not selectable as target words
                    };
                    context.Words.Add(wordEntity);
                    context.SaveChanges();
                }

                // Create the game record first
                var game = new Game
                {
                    UserId = _currentUser.Id,
                    WordId = context.Words.First(w => w.WordText.ToUpper() == _targetWord).Id,
                    AttemptsUsed = _currentAttempt + 1,
                    CreatedAt = DateTime.Now,
                    Score = 0 // Will be updated based on game outcome
                };

                // Process the guess and update colors
                string result = "";
                for (int i = 0; i < WordLength; i++)
                {
                    if (guess[i] == _targetWord[i])
                    {
                        _gridLabels[startIndex + i].BackColor = Color.FromArgb(120, 177, 89);
                        _keyboardButtons[guess[i]].BackColor = Color.FromArgb(120, 177, 89);
                        result += "G";
                    }
                    else if (_targetWord.Contains(guess[i]))
                    {
                        _gridLabels[startIndex + i].BackColor = Color.FromArgb(201, 180, 88);
                        if (_keyboardButtons[guess[i]].BackColor != Color.FromArgb(120, 177, 89))
                            _keyboardButtons[guess[i]].BackColor = Color.FromArgb(201, 180, 88);
                        result += "Y";
                    }
                    else
                    {
                        _gridLabels[startIndex + i].BackColor = Color.FromArgb(129, 131, 132);
                        if (_keyboardButtons[guess[i]].BackColor != Color.FromArgb(120, 177, 89) && _keyboardButtons[guess[i]].BackColor != Color.FromArgb(201, 180, 88))
                            _keyboardButtons[guess[i]].BackColor = Color.FromArgb(129, 131, 132);
                        result += "B";
                    }
                }

                // Add the game attempt
                context.Games.Add(game);
                context.SaveChanges(); // Save to get the GameId

                context.GameAttempts.Add(new GameAttempt
                {
                    GameId = game.Id,
                    AttemptNumber = _currentAttempt + 1,
                    GuessedWord = guess,
                    Result = result
                });

                // Get user statistics
                var stats = context.UserStatistics.First(s => s.UserId == _currentUser.Id);

                // Check if the game is won or lost
                if (guess == _targetWord)
                {
                    // User guessed correctly!
                    // Scoring: 6 points for 1st attempt, 5 for 2nd, 4 for 3rd, 3 for 4th, 2 for 5th, 1 for 6th
                    game.Score = Math.Max(1, 7 - (_currentAttempt + 1)); // Ensures minimum 1 point for correct guess

                    stats.GamesPlayed++;
                    stats.Wins++;
                    stats.CurrentStreak++;
                    stats.MaxStreak = Math.Max(stats.MaxStreak, stats.CurrentStreak);

                    MessageBox.Show($"You won! Score: {game.Score} points!");
                    context.SaveChanges();
                    ShowStatisticsPage();
                }
                else if (_currentAttempt == MaxAttempts - 1)
                {
                    // Game over - user failed to guess the word
                    game.Score = 0; // Only 0 points when they don't guess the word at all

                    stats.GamesPlayed++;
                    // stats.Wins stays the same (no win to add)
                    stats.CurrentStreak = 0; // Reset streak on loss

                    MessageBox.Show($"Game over! The word was: {_targetWord}. Score: 0 points.");
                    context.SaveChanges();
                    ShowStatisticsPage();
                }
                else
                {
                    // Continue to next attempt
                    _currentAttempt++;
                    context.SaveChanges(); // Save the attempt but don't update game stats yet
                }

                context.SaveChanges();
            }
        }
    }
}