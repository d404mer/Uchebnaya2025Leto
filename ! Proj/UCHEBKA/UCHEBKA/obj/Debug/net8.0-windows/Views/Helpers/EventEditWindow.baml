   M S B A M L   `   `   `  ����B  >UCHEBKA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:UCHEBKA.Views.HelpersUCHEBKA.Views.Helpers  5   	   +    %UCHEBKA.Views.Helpers.EventEditWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:UCHEBKA.Views.Helpers     5   	   $	��400��5   	   $	��400��5	   	   $	��450��5
   	   $	��450��5   	     � Title$9  3Редактирование мероприятия��5   	   $	��400��6,   $	��400��69    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $.��(Название мероприятия:��6   �� 5   
   -   5         ��Name$ EventTitleTextBox��5        �� TextWrapping$
 Wrap=�5      $��1��5      $��0,0,0,10q�5!      �� 5#   
   $��2��6   $*��$Дата и время начала:��6   (  "System.Windows.Controls.DatePicker  5$   
   -   5          Name$ EventStartTimePicker��5$   "   $��3��6   $��0,0,0,10q�6@   �� 5&   
   $��4��6   $%��Количество дней: ��6   �� 5'   
   -   5        $ EventDurationTextBox��5'      $��5��6   $��0,0,0,10q�6=   �� 5)   
   $��6��6   $,��&Логотип мероприятия:��6   �� 5*   
   $��7��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5+      �� -   5        $ EventLogoUrlTextBox��5-      $
 Wrap=�5,      $	��250��5.       �� 
IsReadOnly$
 True��5/      �� 50      -   5         ��Name$ SelectImageButton��52      $��Выбрать...��51      $��5,0,0,0q�53      $��80��54      55      56      �� 58   
   -   5        $ DeleteButton��5<      $��9��59      $
��Left=�5:      $��Удалить��5;      $��20��5=      $��80��5>      $��5q�5?      6   �� 5A   
   $��Center=�5B      $��9��5C      $ 
Horizontal=�5D      $��Right=�5E      .+�5G      �� -   5        $ 
SaveButton��5I      $��Сохранить��5H      $��80��5K      $��5q�6   �� 5L      -   5        $ CancelButton��5N      $��Отмена��5M      $��80��5P      $��5q�5Q      5R      5S      5T      