using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using UCHEBKA.Models;
using UCHEBKA.Services;

namespace UCHEBKA
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private string currentCaptcha;
        private readonly Random random = new Random();

        public AuthWindow()
        {
            InitializeComponent();
            GenerateNewCaptcha();
        }

        private void GenerateNewCaptcha()
        {
            // Генерация 4 случайных цифр
            currentCaptcha = random.Next(1000, 9999).ToString();
            CaptchaText.Text = currentCaptcha;

            // Очищаем предыдущие точки
            CaptchaBackgroundCanvas.Children.Clear();

            // Создаем фон из разноцветных точек
            int dotCount = 200;
            double canvasWidth = CaptchaBackgroundCanvas.ActualWidth;
            double canvasHeight = CaptchaBackgroundCanvas.ActualHeight;

            for (int i = 0; i < dotCount; i++)
            {
                Ellipse dot = new Ellipse
                {
                    Width = random.Next(1, 4),
                    Height = random.Next(1, 4),
                    Fill = new SolidColorBrush(Color.FromRgb(
                        (byte)random.Next(256),
                        (byte)random.Next(256),
                        (byte)random.Next(256)))
                };

                Canvas.SetLeft(dot, random.Next(0, (int)canvasWidth));
                Canvas.SetTop(dot, random.Next(0, (int)canvasHeight));

                CaptchaBackgroundCanvas.Children.Add(dot);
            }
        }

        private void RefreshCaptchaButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateNewCaptcha();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //// Проверка капчи
            //if (CaptchaInput.Text != currentCaptcha)
            //{
            //    MessageBox.Show("Неверная каптча! Попробуйте снова.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    GenerateNewCaptcha();
            //    return;
            //}

            //// Проверка ввода ID
            //if (!int.TryParse(UserIDTextBox.Text, out int userId))
            //{
            //    MessageBox.Show("Некорректный ID пользователя. Введите число.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return;
            //}

            //// Проверка ввода пароля
            //if (string.IsNullOrWhiteSpace(UserPasswordBox.Password))
            //{
            //    MessageBox.Show("Введите пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return;
            //}

            //try
            //{
            //    var userService = new UserService(_context);
            //    var user = userService.Auth(userId, UserPasswordBox.Password);

            //    if (user != null)
            //    {
            //        MessageBox.Show($"Добро пожаловать, {user.UserName} {user.UserSurname}!", "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);

                    
            //        Window mainWindow = new MainWindow(); 
            //        mainWindow.Show();
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Неверный ID пользователя или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //        GenerateNewCaptcha();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Ошибка при авторизации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                
            //}
        }
    }
}