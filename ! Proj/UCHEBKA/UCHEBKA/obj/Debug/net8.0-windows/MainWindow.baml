   M S B A M L   `   `   `  ����B  >UCHEBKA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UCHEBKAUCHEBKA  5   	       UCHEBKA.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:UCHEBKA     5   	     � WindowStartupLocation$  CenterScreen=�5   	   $	��450��5	   	   $	��850��6    � Title$ Мероприятия��5
   	   $	��450��6   $	��850��6*   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� -   5         ��Name$ 
MyComboBox��5      $	��200��6+   $��0,0,10,0q�67    �� DisplayMemberPath$ SecName��5       �� SelectedValuePath$ SecId��5      5      �� 5      -   5         ��Name$ DatePickerButton��5      $��Выбрать дату��6/   $��0,0,10,0q�6F   6X   �� 5      -   5        $%��Сбросить фильтры��5      $��0,0,10,0q�60   6B   �� 5      -   5        $��Авторизация��5      $��0,0,10,0q�6+   5      5      �� 5    
   -   5         ��Name$ SelectedDateText��5       $��1��6.   $
��10,0q�6;   $
��Bold"�6I   �� 5#   
   $��Center=�6   $��2��64   $
��Auto=�6A   .��5$      � -   5        	 �Name$	 EventsWrapPanel��5$      $��10q�61   5%      &   System.Windows.Controls.Calendar  5(   
   -   5        
  Name$
 
MyCalendar��5(      $��0��6'   $��3��64   $y�	Collapsed=�5)       K� ZIndex$	 100��5*      $
��Left=�5+      $	��Top=�5,      $��
100,50,0,0q�5-      
�������5/      50      51      