using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UCHEBKA.Models;
using UCHEBKA.Repos;
using UCHEBKA.Views;

namespace UCHEBKA
{
    /// <summary>
    /// Логика взаимодействия для JuryWindow.xaml
    /// </summary>
    public partial class JuryWindow : Window
    {
        private readonly UserRepository _usRepo;
        private readonly UchebnayaLeto2025Context _db;
        private User _currentUser;

        public JuryWindow()
        {
            InitializeComponent();

            _db = new UchebnayaLeto2025Context();
            _usRepo = new UserRepository(_db);

            LoadUserData();
        }


        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = _usRepo.GetCurrentUserData();
            if (currentUser != null)
            {
                var profileWindow = new ProfileWindow(_usRepo);
                profileWindow.Owner = this;
                profileWindow.ShowDialog();

                LoadUserData();
            }
            else
            {
                MessageBox.Show("Не удалось загрузить данные пользователя", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

                 private void LoadUserData()
        {
            var currentUser = _usRepo.GetCurrentUser();

            if (currentUser != null)
            {
                _currentUser = _usRepo.Auth(currentUser.Value.userId, currentUser.Value.password);

                string imageName = _currentUser.UserPhoto;
                var ProfileImagePath = _usRepo.GetFullImagePath(imageName);

                ProfileImage.Source = new BitmapImage(new Uri(ProfileImagePath));
            }
        }
    }
}
