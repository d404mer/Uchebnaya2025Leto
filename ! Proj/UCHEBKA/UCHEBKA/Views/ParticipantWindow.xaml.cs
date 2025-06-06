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

namespace UCHEBKA
{
    /// <summary>
    /// Логика взаимодействия для ParticipantWindow.xaml
    /// </summary>
    public partial class ParticipantWindow : Window
    {
        private readonly UserRepository _usRepo;

        public ParticipantWindow()
        {
            var db = new UchebnayaLeto2025Context();
            _usRepo = new UserRepository(db);
            InitializeComponent();
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            _usRepo.Logout();
            this.Close();
            mainWindow.Show();
        }
    }
}
