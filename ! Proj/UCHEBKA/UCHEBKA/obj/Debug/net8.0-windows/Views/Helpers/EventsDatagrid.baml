   M S B A M L   `   `   `  ����B  >UCHEBKA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UCHEBKA.ViewsUCHEBKA.Views  5   	   "    UCHEBKA.Views.EventsDatagrid   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:UCHEBKA.Views     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Мероприятия��5	   	   $	��600��6   $	��800��6*   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $
��Left=�5      $��Center=�5      $	��←��5      $	��100��5      $��5, 0, 0, 10q�5      $��20��5      6   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,0,0,10q�6W   .+�5      �� -   5        $��Обновить��5      $	��100��6(   $��5q�64   6?   �� 5      -   5        $��Добавить��5      $	��100��6(   $��5q�64   6?   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ EventsDataGrid��5      $��1��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5          SelectionMode$ Single=�5!         Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	EventId+6M     5%      $	 Название��6%      MinWidth$	 350Q�6W   $
 * 6f    68   �� *
EventTitle+6f     5&      $	 Дата начала��6%   $

 Auto 6�    6:   �� *EventStartTime+ �� StringFormat$ {0:dd.MM.yyyy HH:mm}��6�     5'      $	 Кол-во дней��6%   $

 Auto 6\    6:   �� *EventDuration+6\     5(      $	 Лого��6%   $

 Auto 6T    63   �� *EventLogoUrl+6T   5*      5+      5,      