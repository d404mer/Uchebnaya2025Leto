﻿using System;
using System.Windows;
using UCHEBKA.Repos;
using UCHEBKA.Models;
using UCHEBKA.Views;

namespace UCHEBKA
{
    public partial class OrgWindow : Window
    {
        private readonly UchebnayaLeto2025Context _db;
        private readonly UserRepository _userRepo;
        private User _currentUser;

        public OrgWindow()
        {
            InitializeComponent();
            
            _db = new UchebnayaLeto2025Context();
            _userRepo = new UserRepository(_db);
            
            LoadUserData();
        }

        private void LoadUserData()
        {
            var currentUser = _userRepo.GetCurrentUser();
            
            if (currentUser != null)
            {
                _currentUser = _userRepo.Auth(currentUser.Value.userId, currentUser.Value.password);
                
                if (_currentUser != null)
                {
                    SetGreeting();
                    MrMrsText.Text = GetUserTitle(_currentUser.UserId) + " " + _currentUser.UserLastname;
                }
            }
        }

        private string GetUserTitle(long userId)
        {
            var userSex = _userRepo.GetUserSex(userId);

            return userSex switch
            {
                "мужской" => "Mr",
                "женский" => "Ms",
                _ => string.Empty    // если пол не указан или не распознан
            };
        }

        private void SetGreeting()
        {
            var currentHour = DateTime.Now.Hour;
            
            if (currentHour >= 9 && currentHour < 11)
            {
                GoodText.Text = "Доброе утро";
            }
            else if (currentHour >= 11 && currentHour < 18)
            {
                GoodText.Text = "Добрый день";
            }
            else
            {
                GoodText.Text = "Добрый вечер";
            }
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = _userRepo.GetCurrentUserData();
            if (currentUser != null)
            {
                var profileWindow = new ProfileWindow(_userRepo);
                profileWindow.Owner = this;
                profileWindow.ShowDialog();

                // Обновляем приветствие после закрытия окна профиля
                LoadUserData();
            }
            else
            {
                MessageBox.Show("Не удалось загрузить данные пользователя", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EventsBtn_Click(object sender, RoutedEventArgs e)
        {
            // Логика для кнопки мероприятий
        }

        private void PartiBtn_Click(object sender, RoutedEventArgs e)
        {
            // Логика для кнопки участников
        }

        private void JuryBtn_Click(object sender, RoutedEventArgs e)
        {
            // Логика для кнопки жюри
        }
    }
}