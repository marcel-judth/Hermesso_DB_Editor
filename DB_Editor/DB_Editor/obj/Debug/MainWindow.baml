   M S B A M L   `   `   `  ����D  @DB_Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DB_Editor	DB_Editor  5   	       DB_Editor.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:DB_Editor     5   	     � Title$  Database Editor��5   	   $	��770��6!   $
��1300��6.   .��5	      �  � ColumnDefinitions 5
   
   �� 5       z� SharedSizeGroup$ A��6    � RowDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $��2* �6   �� 5      $
��0.2* �6   .+�5   
   � $��Center=�6   $��Bottom=�6,    5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5       $
��Auto �6#   �� 5!      $
��Auto �6#   �� 5"      $
��Auto �6#    5$      �� 5%      $
��Auto �6    .+�5)      �� $��
0, 0, 5, 0q�6   .��6(   	Server:61   �� 5*      -   5        $��	txtServer��5*   &   $��1��6   $	��100��68   $��Center=�6D   �� 5+      $��2��6   $��15, 0, 5, 0q�6%   .��6:   	Database:6E   �� 5,      -   5        $��txtDatabase��5,   &   $��3��6   $	��100��69   $��Center=�6E   �� 5-      $��4��6   $��15, 0, 5, 0q�6$   .��69   User:6@   �� 5.      -   5        $��txtUser��5.   &   $��5��6   $	��100��65   $��Center=�6A   �� 5/      $��6��6   $��15, 0, 5, 0q�6$   .��69   	Password:6D   �� 50      -   5        $��txtPassword��50   &   $��7��6   $	��100��69   $��Center=�6E   �� 51      $��8��6   $��15, 0, 5, 0q�6$   .��69   Company-Nr:6F   �� 52      -   5        $��txtCompanyNr��52   &   $��9��6   $	��100��6;   $��Center=�6G   �� 53      $��10��6   $��15, 0, 0, 0q�6%   .��6:   	Emp-Nr:6C   �� 54      -   5        $��txtEmpNr��54   '   $��11��6   $	��100��68   $��Center=�6D   �� 55      -   5         ��Name$ btnGetTimes��55      $��	Get Times��6*   $��12��6>   $��20, 0, 0, 0q�6O   $
��Left=�6d   $��Center=�6   $��75��6�   6�   �� 56      -   5        $ btnCreateDB��56      $��	Create DB��6*   $��13��6>   $��20, 0, 0, 0q�6O   $
��Left=�6d   $��Center=�6   $��75��6�   6�   57      &   System.Windows.Controls.DataGrid  59   
   -	   5        $��datagrid��59       $��1��6      CanUserSortColumns . $��40,24,44,34q�6K      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6`   6�   �� 5;   
   $��2��6   .��5<      �� -
   5         ��Name$ 
lblMessage��5<      $	��...��6)   $��Center=�67   $��Center=�6T   $
��Auto��6x   $	��Top=�6�   $
��Auto��6�   5=      5>      5@      