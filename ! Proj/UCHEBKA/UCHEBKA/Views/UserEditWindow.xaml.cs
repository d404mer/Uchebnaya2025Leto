using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using UCHEBKA.Models;
using UCHEBKA.Repos;
using System.Collections.Generic;

namespace UCHEBKA.Views
{
    public partial class UserEditWindow : Window
    {
        private readonly UserRepository _userRepo;
        private readonly EventRepository _eventRepo;
        private readonly UchebnayaLeto2025Context _db;
        private User _user;
        private int _roleId;
        private string _photoFileName;
        private bool _isEditMode;
        private readonly SectionRepository _sectionRepo;

        public UserEditWindow(User user, int roleId)
        {
            InitializeComponent();
            _db = new UchebnayaLeto2025Context();
            _userRepo = new UserRepository(_db);
            _eventRepo = new EventRepository(_db);
            _sectionRepo = new SectionRepository(_db);
            _roleId = roleId;
            _isEditMode = user != null;
            _user = user ?? new User();
            LoadData();
        }

        private void LoadData()
        {
            // Пол
            SexComboBox.ItemsSource = _userRepo.GetAllSexes();
            SexComboBox.DisplayMemberPath = "SexName";
            SexComboBox.SelectedValuePath = "SexId";

            // Роль
            //RoleComboBox.ItemsSource = _userRepo.GetAllRoles();
            RoleComboBox.DisplayMemberPath = "RoleName";
            RoleComboBox.SelectedValuePath = "RoleId";
            RoleComboBox.SelectedValue = _roleId;

            // Мероприятия
            EventComboBox.ItemsSource = _eventRepo.GetAllEvents();
            EventComboBox.DisplayMemberPath = "EventTitle";
            EventComboBox.SelectedValuePath = "EventId";

            // Направления
            DirectionComboBox.ItemsSource = _sectionRepo.GetAllSections();
            DirectionComboBox.DisplayMemberPath = "SecName";
            DirectionComboBox.SelectedValuePath = "SecId";

            if (_isEditMode)
            {
                IdTextBox.Text = _user.UserId.ToString();
                FioTextBox.Text = $"{_user.UserSurname} {_user.UserName} {_user.UserLastname}";
                EmailTextBox.Text = _user.UserEmail;
                PhoneTextBox.Text = _user.UserPhone;
                _photoFileName = _user.UserPhoto;
                if (!string.IsNullOrEmpty(_photoFileName))
                {
                    var path = _userRepo.GetFullImagePath(_photoFileName);
                    PhotoImage.Source = new BitmapImage(new Uri(path));
                }
                // Пол
                if (_user.UserSexes.Any())
                    SexComboBox.SelectedValue = _user.UserSexes.First().FkSexId;
                // Email, телефон, др. поля
                // Роль
                RoleComboBox.SelectedValue = _roleId;
                // Пароль
                PasswordTextBox.Text = _user.UserPassword;
                RepeatPasswordTextBox.Text = _user.UserPassword;
                // Направление
                if (_user.UserSecs.Any())
                    DirectionComboBox.SelectedValue = _user.UserSecs.First().FkSecId;
            }
            else
            {
                IdTextBox.Text = "(авто)";
            }
        }

        private void UploadPhoto_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png",
                Title = "Выберите фото профиля"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                _photoFileName = System.IO.Path.GetFileName(openFileDialog.FileName);
                PhotoImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            //// Валидация
            //if (string.IsNullOrWhiteSpace(FioTextBox.Text) ||
            //    SexComboBox.SelectedValue == null ||
            //    RoleComboBox.SelectedValue == null ||
            //    string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
            //    string.IsNullOrWhiteSpace(PhoneTextBox.Text))
            //{
            //    MessageBox.Show("Заполните все обязательные поля");
            //    return;
            //}
            //if (!_isEditMode && (PasswordTextBox.Text != RepeatPasswordTextBox.Text || string.IsNullOrWhiteSpace(PasswordTextBox.Text)))
            //{
            //    MessageBox.Show("Пароли не совпадают или не заполнены");
            //    return;
            //}

            //// ФИО разбор
            //var fio = FioTextBox.Text.Split(' ');
            //_user.UserSurname = fio.Length > 0 ? fio[0] : "";
            //_user.UserName = fio.Length > 1 ? fio[1] : "";
            //_user.UserLastname = fio.Length > 2 ? fio[2] : "";
            //_user.UserEmail = EmailTextBox.Text;
            //_user.UserPhone = PhoneTextBox.Text;
            //_user.UserPhoto = _photoFileName;
            //// Пол
            //_userRepo.UpdateUserSex(_user.UserId, Convert.ToInt64(SexComboBox.SelectedValue));
            //// Роль
            //var roleId = Convert.ToInt32(RoleComboBox.SelectedValue);
            //// Мероприятие (если нужно)
            //// ...
            //if (!_isEditMode)
            //{
            //    _user.UserPassword = PasswordTextBox.Text;
            //    _userRepo.AddUser(_user, roleId);
            //}
            //else
            //{
            //    _userRepo.UpdateUser(_user);
            //    _userRepo.UpdateUserRole(_user.UserId, roleId);
            //}
            //// Сохраняем направление
            //if (DirectionComboBox.SelectedValue != null)
            //{
            //    long secId = Convert.ToInt64(DirectionComboBox.SelectedValue);
            //    var userSec = _db.UserSecs.FirstOrDefault(us => us.FkUserId == _user.UserId);
            //    if (userSec != null)
            //    {
            //        userSec.FkSecId = secId;
            //    }
            //    else
            //    {
            //        _db.UserSecs.Add(new UserSec { FkUserId = _user.UserId, FkSecId = secId });
            //    }
            //    _db.SaveChanges();
            //}
            //DialogResult = true;
            //Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ShowPasswordCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Можно реализовать показ пароля через TextBox, если нужно
        }
        private void ShowPasswordCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Можно реализовать скрытие пароля
        }
    }
} 