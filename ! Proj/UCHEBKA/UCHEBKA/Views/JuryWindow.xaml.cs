﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UCHEBKA.Models;
using UCHEBKA.Repos;
using UCHEBKA.Views;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore;

namespace UCHEBKA
{
    public partial class JuryWindow : Window
    {
        private readonly UserRepository _usRepo;
        private readonly ActivityRepository _activityRepo;
        private readonly UchebnayaLeto2025Context _db;
        private User _currentUser;
        private ObservableCollection<ActivityRatingViewModel> _activitiesToRate;

        public JuryWindow()
        {
            InitializeComponent();
            _db = new UchebnayaLeto2025Context();
            _usRepo = new UserRepository(_db);
            _activityRepo = new ActivityRepository(_db);

            LoadUserData();
            LoadActivities();
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
                DataContext = this;
            }
        }

        private void LoadActivities()
        {
            if (_currentUser == null) return;

            var activities = _activityRepo.GetActivitiesForJury(_currentUser.UserId)
                .Select(ae => new ActivityRatingViewModel
                {
                    ActivityEventId = ae.ActivityEventId,
                    Event = ae.FkEvent,
                    Activity = ae.FkActivity,
                    Day = ae.Day,
                    StartTime = ae.StartTime,
                    // Инициализируем рейтинг из базы данных или 0, если его нет
                }).ToList();

            _activitiesToRate = new ObservableCollection<ActivityRatingViewModel>(activities);
            ActivitiesListView.ItemsSource = _activitiesToRate;
        }

        private void RatingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox?.SelectedItem == null) return;

            var selectedActivity = comboBox.DataContext as ActivityRatingViewModel;
            if (selectedActivity == null || selectedActivity.Activity == null) return;

            try
            {
                // Находим активность в базе данных
                var activity = _db.Activities
                    .FirstOrDefault(a => a.ActivityId == selectedActivity.Activity.ActivityId);

                if (activity != null)
                {
                    // Обновляем оценку активности
                    activity.ActivityScore = selectedActivity.Rating;

                    // Сохраняем изменения
                    _db.SaveChanges();

                    MessageBox.Show("Оценка сохранена успешно!", "Успех",
                                  MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Активность не найдена в базе данных", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении оценки: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class ActivityRatingViewModel
    {
        public long ActivityEventId { get; set; }
        public Event Event { get; set; }
        public Activity Activity { get; set; }
        public int? Day { get; set; }
        public DateTime? StartTime { get; set; }
        public int Rating { get; set; }
    }
}