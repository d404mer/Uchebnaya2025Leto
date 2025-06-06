using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using UCHEBKA.Repos;
using UCHEBKA.Models;

namespace UCHEBKA
{
    public partial class AuthWindow : Window
    {
        private string currentCaptcha;
        private readonly Random random = new Random();
        private readonly UserRepository _usRepo;
        private User _currUser;

        public AuthWindow()
        {
            var db = new UchebnayaLeto2025Context();
            _usRepo = new UserRepository(db);

            InitializeComponent();
            CaptchaInput.Foreground = Brushes.Gray;
            GenerateNewCaptcha();
            this.Loaded += (s, e) => GenerateNewCaptcha();

            //TryAutoLog();
            
        }

        private void GenerateNewCaptcha()
        {
            currentCaptcha = "";
            for (int i = 0; i < 4; i++)
            {
                currentCaptcha += random.Next(0, 10).ToString();
            }

            CaptchaCanvas.Children.Clear();

            AddNoiseToCanvas();

            DrawCaptchaText();

            AddInterferenceLines();


        }

        private void AddNoiseToCanvas()
        {
            int dotCount = 100;
            double canvasWidth = CaptchaCanvas.ActualWidth;
            double canvasHeight = CaptchaCanvas.ActualHeight;

            for (int i = 0; i < dotCount; i++)
            {
                Ellipse dot = new Ellipse
                {
                    Width = random.Next(1, 3),
                    Height = random.Next(1, 3),
                    Fill = new SolidColorBrush(Color.FromRgb(
                        (byte)random.Next(150, 220),
                        (byte)random.Next(150, 220),
                        (byte)random.Next(150, 220)))
                };

                Canvas.SetLeft(dot, random.Next(0, (int)canvasWidth));
                Canvas.SetTop(dot, random.Next(0, (int)canvasHeight));
                CaptchaCanvas.Children.Add(dot);
            }
        }

        private void DrawCaptchaText()
        {
            double xPos = 10;
            double yPos = CaptchaCanvas.ActualHeight / 3;
            double fontSize = 24;

            for (int i = 0; i < currentCaptcha.Length; i++)
            {
                TextBlock charBlock = new TextBlock
                {
                    Text = currentCaptcha[i].ToString(),
                    FontSize = fontSize,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.DarkBlue,
                    RenderTransform = new TransformGroup
                    {
                        Children = new TransformCollection
                        {
                            new RotateTransform(random.Next(-10, 11)),
                            new TranslateTransform(random.Next(-2, 3), random.Next(-2, 3))
                        }
                    }
                };

                Canvas.SetLeft(charBlock, xPos);
                Canvas.SetTop(charBlock, yPos + random.Next(-5, 6));
                CaptchaCanvas.Children.Add(charBlock);

                xPos += fontSize - 5;
            }
        }

        private void AddInterferenceLines()
        {
            for (int i = 0; i < 2; i++)
            {
                Line line = new Line
                {
                    X1 = random.Next(0, (int)CaptchaCanvas.ActualWidth / 2),
                    Y1 = random.Next(0, (int)CaptchaCanvas.ActualHeight),
                    X2 = random.Next((int)CaptchaCanvas.ActualWidth / 2, (int)CaptchaCanvas.ActualWidth),
                    Y2 = random.Next(0, (int)CaptchaCanvas.ActualHeight),
                    Stroke = Brushes.Gray,
                    StrokeThickness = 1,
                    Opacity = 0.5
                };
                CaptchaCanvas.Children.Add(line);
            }
        }

        private void RefreshCaptchaButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateNewCaptcha();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // CAPTCHA
            if (CaptchaInput.Text != currentCaptcha)
            {
                MessageBox.Show("Неверная CAPTCHA! Введите показанные цифры.",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                GenerateNewCaptcha();
                CaptchaInput.Clear();
                return;
            }

            // ID
            if (!int.TryParse(UserIDTextBox.Text, out int userId))
            {
                MessageBox.Show("Некорректный ID пользователя. Введите число.",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // пароль
            if (string.IsNullOrWhiteSpace(UserPasswordBox.Password))
            {
                MessageBox.Show("Введите пароль.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                _currUser = _usRepo.Auth(userId, UserPasswordBox.Password);
                if (_currUser == null)
                {
                    MessageBox.Show("Неверные учетные данные");
                    return;
                }

                _usRepo.SaveCurrentUser(userId, UserPasswordBox.Password);
                OpenRoleBasedWindow();
            }
            catch
            {
                MessageBox.Show("Нffffff");
                return;
            }

        }

        private void TryAutoLog()
        {
            var cred = _usRepo.GetCurrentUser();
            if (cred != null)
            {
                var (userId, password) = cred.Value;
                _currUser = _usRepo.Auth(userId, password);

                if (_currUser != null)
                {
                    OpenRoleBasedWindow();
                }
            }
        }

        private void OpenRoleBasedWindow()
        {
            var role = _usRepo.GetUserRole(_currUser.UserId);

            Window window = role switch
            {
                "модератор" => new AdminWindow(),
                "жюри" => new JuryWindow(),
                "организатор" => new OrgWindow(),
                _ => new ParticipantWindow()
            };

            window.Show();
        }

        private void CaptchaInput_GotFocus(object sender, RoutedEventArgs e)
        {
            CaptchaInput.Foreground = Brushes.Black;
            if (CaptchaInput.Text == "Введите каптчу")
            {
                CaptchaInput.Text = "";
            }
        }

        private void CaptchaInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CaptchaInput.Text))
            {
                CaptchaInput.Text = "Введите каптчу";
                CaptchaInput.Foreground = Brushes.Gray;
            }
        }
    }
}