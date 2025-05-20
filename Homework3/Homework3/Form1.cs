using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using DataEntity;

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
        private Users _currentUser = null;
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
            InitializeDatabase(); // Add this line
            ShowDescriptionPage();
        }

        private void InitializeDatabase()
        {
            using (var context = new DataModel())
            {
                // Check if there are any selectable words
                if (!context.Words.Any(w => w.IsSelectable))
                {
                    var defaultWords = new List<Words>
            {
                new Words { Word = "BLACK", IsSelectable = true },
                new Words { Word = "FLOAT", IsSelectable = true },
                new Words { Word = "AISLE", IsSelectable = true },
                new Words { Word = "HATCH", IsSelectable = true },
                new Words { Word = "MELTS", IsSelectable = true },
                new Words { Word = "CRANE", IsSelectable = true },
                new Words { Word = "SLATE", IsSelectable = true },
                new Words { Word = "HOUSE", IsSelectable = true },
                new Words { Word = "FLAME", IsSelectable = true },
                new Words { Word = "STORM", IsSelectable = true }
            };

                    context.Words.AddRange(defaultWords);
                    context.SaveChanges();
                }
            }
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

            using (var context = new DataModel())
            {
                var stats = context.UserStatistics.FirstOrDefault(s => s.UserId == _currentUser.Id);
                if (stats != null)
                {
                    lblPlayed.Text = stats.GamesPlayed.ToString();
                    lblWinPercent.Text = stats.WinningPercentage?.ToString("F0") + "%" ?? "0%";
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

            StartNewGame();
        }

        private void StartNewGame()
        {
            _currentAttempt = 0;
            using (var context = new DataModel())
            {
                // Ensure there are selectable words in the database
                var selectableWords = context.Words.Where(w => w.IsSelectable).ToList();

                // If no selectable words exist, add some default ones
                if (!selectableWords.Any())
                {
                    var defaultWords = new List<Words>
            {
                new Words { Word = "BLACK", IsSelectable = true },
                new Words { Word = "FLOAT", IsSelectable = true },
                new Words { Word = "AISLE", IsSelectable = true },
                new Words { Word = "HATCH", IsSelectable = true },
                new Words { Word = "MELTS", IsSelectable = true }
            };

                    context.Words.AddRange(defaultWords);
                    context.SaveChanges();
                    selectableWords = defaultWords;
                }

                // Now select a random word
                _targetWord = selectableWords[_random.Next(selectableWords.Count)].Word.ToUpper();

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

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
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
                using (var context = new DataModel())
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

            try
            {
                using (var context = new DataModel())
                {
                    if (context.Users.Any(u => u.Email == email))
                    {
                        lblRegisterError.Text = "This email is already registered.";
                        lblRegisterError.Visible = true;
                        return;
                    }

                    var newUser = new Users
                    {
                        Email = email,
                        PasswordHash = password,
                        CreatedAt = DateTime.Now
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();

                    var userStats = new UserStatistics
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
            else
            {
                AddLetter(btn.Text[0]);
            }
        }

        private void AddLetter(char letter)
        {
            int index = _currentAttempt * WordLength + _gridLabels.Count(l => l.Text != "" && _gridLabels.IndexOf(l) / WordLength == _currentAttempt);
            if (index < (_currentAttempt + 1) * WordLength)
            {
                _gridLabels[index].Text = letter.ToString();
            }
        }

        private void RemoveLastLetter()
        {
            int index = _currentAttempt * WordLength + _gridLabels.Count(l => l.Text != "" && _gridLabels.IndexOf(l) / WordLength == _currentAttempt) - 1;
            if (index >= _currentAttempt * WordLength)
            {
                _gridLabels[index].Text = "";
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

            using (var context = new DataModel())
            {
                if (!context.Words.Any(w => w.Word.ToUpper() == guess))
                {
                    MessageBox.Show("Not a valid word.");
                    return;
                }

                var game = new Games
                {
                    UserId = _currentUser.Id,
                    WordId = context.Words.First(w => w.Word.ToUpper() == _targetWord).Id,
                    AttemptsUsed = _currentAttempt + 1,
                    CreatedAt = DateTime.Now
                };

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

                context.GameAttempts.Add(new GameAttempts
                {
                    GameId = game.Id,
                    AttemptNumber = _currentAttempt + 1,
                    GuessedWord = guess,
                    Result = result
                });

                context.Games.Add(game);
                context.SaveChanges();

                var stats = context.UserStatistics.First(s => s.UserId == _currentUser.Id);
                stats.GamesPlayed++;
                if (guess == _targetWord)
                {
                    stats.Wins++;
                    stats.CurrentStreak++;
                    stats.MaxStreak = Math.Max(stats.MaxStreak, stats.CurrentStreak);
                    game.Score = 10 - _currentAttempt * 2;
                    MessageBox.Show($"You won! Score: {game.Score}");
                    context.SaveChanges();
                    ShowStatisticsPage();
                }
                else if (_currentAttempt == MaxAttempts - 1)
                {
                    stats.CurrentStreak = 0;
                    game.Score = 0;
                    MessageBox.Show($"Game over! The word was: {_targetWord}");
                    context.SaveChanges();
                    ShowStatisticsPage();
                }
                else
                {
                    _currentAttempt++;
                }

                stats.WinningPercentage = stats.GamesPlayed > 0 ? (double)stats.Wins / stats.GamesPlayed * 100 : 0;
                context.SaveChanges();
            }
        }
    }
}