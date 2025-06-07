using System;
using Microsoft.EntityFrameworkCore;
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

namespace UCHEBKA.Views.Helpers
{
    /// <summary>
    /// Логика взаимодействия для JuryDaragrid.xaml
    /// </summary>
    public partial class JuryDaragrid : Window
    {
        public JuryDaragrid()
        {
            InitializeComponent();
            LoadUsersWithRole4();
        }

        private void LoadUsersWithRole4()
        {
            try
            {
                using (var context = new UchebnayaLeto2025Context())
                {
                    var usersWithRole1 = context.UserRoles
                        .Include(ur => ur.FkUser)
                        .Include(ur => ur.FkRole)
                        .Where(ur => ur.FkRoleId == 4)
                        .ToList();

                    UsersWithRole4DataGrid.ItemsSource = usersWithRole1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке пользователей: {ex.Message}",
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadUsersWithRole4();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
