using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Microsoft.Win32;
using UCHEBKA.Models;
using UCHEBKA.Repos;

namespace UCHEBKA.Views
{
    public partial class RegistrattionWindow : Window
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;
        private readonly SexRepository _sexRepository;
        private readonly EventRepository _eventRepository;

        public RegistrattionWindow()
        {
            InitializeComponent();

            var db = new UchebnayaLeto2025Context();
            _userRepository = new UserRepository(db);
            _roleRepository = new RoleRepository(db);
            _sexRepository = new SexRepository(db);
            _eventRepository = new EventRepository(db);

            LoadData();
        }

        private void LoadData()
        {
            // Set next available ID
            txtIdNumber.Text = _userRepository.GetNextUserId().ToString();

            // Load genders
            cmbGender.ItemsSource = _sexRepository.GetAllSexes();
            cmbGender.DisplayMemberPath = "SexName";
            cmbGender.SelectedValuePath = "SexId";

            // Load roles
            cmbRole.ItemsSource = _roleRepository.GetAllRoles();
            cmbRole.DisplayMemberPath = "RoleName";
            cmbRole.SelectedValuePath = "RoleId";

            // Load events
            cmbEvent.ItemsSource = _eventRepository.GetAllEvents();
            cmbEvent.DisplayMemberPath = "EventName";
            cmbEvent.SelectedValuePath = "EventId";
        }

        private void BrowsePhoto_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (openFileDialog.ShowDialog() == true)
            {
                txtPhotoPath.Text = openFileDialog.FileName;
            }
        }

        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            txtPasswordVisible.Text = pwdPassword.Password;
            txtRepeatPasswordVisible.Text = pwdRepeatPassword.Password;

            txtPasswordVisible.Visibility = Visibility.Visible;
            txtRepeatPasswordVisible.Visibility = Visibility.Visible;

            pwdPassword.Visibility = Visibility.Collapsed;
            pwdRepeatPassword.Visibility = Visibility.Collapsed;
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            pwdPassword.Password = txtPasswordVisible.Text;
            pwdRepeatPassword.Password = txtRepeatPasswordVisible.Text;

            pwdPassword.Visibility = Visibility.Visible;
            pwdRepeatPassword.Visibility = Visibility.Visible;

            txtPasswordVisible.Visibility = Visibility.Collapsed;
            txtRepeatPasswordVisible.Visibility = Visibility.Collapsed;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                var newUser = new User
                {
                    UserId = long.Parse(txtIdNumber.Text),
                    UserName = txtName.Text,
                    UserSurname = txtSurname.Text,
                    UserLastname = txtLastname.Text,
                    UserEmail = txtEmail.Text,
                    UserBirthDay = dpBirthDate.SelectedDate,
                    UserPhone = txtPhone.Text,
                    UserPassword = pwdPassword.Password,
                    UserPhoto = Path.GetFileName(txtPhotoPath.Text)
                };

                // Copy photo to application directory
                //if (!string.IsNullOrEmpty(txtPhotoPath.Text))
                //{
                //    var destPath = Path.Combine(_userRepository.BaseImagePath, Path.GetFileName(txtPhotoPath.Text));
                //    File.Copy(txtPhotoPath.Text, destPath, true);
                //}

                // Add user to database
                _userRepository.AddUser(newUser);

                // Set user sex
                if (cmbGender.SelectedValue != null)
                {
                    _userRepository.UpdateUserSex(newUser.UserId, (long)cmbGender.SelectedValue);
                }

                // Set user role
                if (cmbRole.SelectedValue != null)
                {
                    _userRepository.AddUserRole(newUser.UserId, (long)cmbRole.SelectedValue);
                }

                // Attach to event if needed
                if (chkAttachToEvent.IsChecked == true && cmbEvent.SelectedValue != null)
                {
                    _userRepository.AddUserEvent(newUser.UserId, (long)cmbEvent.SelectedValue);
                }

                MessageBox.Show("Пользователь успешно зарегистрирован!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя и фамилию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите пол", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите роль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Пожалуйста, введите корректный email", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            //if (string.IsNullOrWhiteSpace(pwdPassword.Password) || pwdPassword.Password.Length < 6)
            //{
            //    MessageBox.Show("Пароль должен содержать минимум 6 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return false;
            //}

            //if (pwdPassword.Password != pwdRepeatPassword.Password)
            //{
            //    MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return false;
            //}

            return true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}