   M S B A M L   `   `   `  ����B  >UCHEBKA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:UCHEBKA.Views.HelpersUCHEBKA.Views.Helpers  5   	   0    *UCHEBKA.Views.Helpers.ParticipantsDatagrid   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:UCHEBKA.Views.Helpers     5   	     � Title$  ParticipantsDatagrid��5   	   $	��450��6&   $	��800��63   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $
��Left=�5      $��Center=�5      $	��←��5      $	��100��5      $��5, 0, 0, 10q�5      $��20��5      6   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,0,0,10q�6W   .+�5      �� -   5        $��Обновить��5      $	��100��6(   $��5q�64   6?   �� 5      -   5        $��Добавить��5      $	��100��6(   $��5q�64   6?   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ UsersWithRole1DataGrid��5         AutoGenerateColumns$ False��5      $��1��5         
IsReadOnly$
 True��5          SelectionMode$ Single=�5!         CanUserAddRows$ False��5"         Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn	   Header$	 User ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 5)      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5(      �� *FkUser.UserId+5)        5,      $	 Отчество��6%   $

 Auto 5.       5-      �� *FkUser.UserName+5.        51      $	 Имя��6%   $

 Auto 53       52      �� *FkUser.UserSurname+53        56      $	 Фамилия��6%   $

 Auto 58       57      �� *FkUser.UserLastname+58        5;      $	 Роль��6%   $

 Auto 5=       5<      �� *FkRole.RoleName+5=        5?      $	 
Почта��6%   $

 Auto 5A       5@      �� *FkUser.UserEmail+5A        5C      $	 Дата рождения��6%   $

 Auto 5E       5D      �� *FkUser.UserBirthDay+5E        5H      $	 
Номер��6%   $

 Auto 5J       5I      �� *FkUser.UserPhone+5J        5L      $	 Пароль��6%   $

 Auto 5N       5M      �� *FkUser.UserPassword+5N        5P      $	 Фото��6%   $
 * 5R       5Q      �� *FkUser.UserPhoto+5R        5U      $	 Role ID��6%   $

 Auto 5W         
Visibility$ Hidden=�5X       5V      �� *
FkRoleId+5X      5Z      5[      5\      