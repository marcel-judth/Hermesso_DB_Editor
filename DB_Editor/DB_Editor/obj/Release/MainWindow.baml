   M S B A M L   `   `   `  ���� D  @DB_Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DB_Editor	DB_Editor      DB_Editor.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:DB_Editor       � Title$  Database Editor��$	��770��$
��1300��.���  � ColumnDefinitions ��  z� SharedSizeGroup$ A�� � RowDefinitions �� $
��0.3* ��� $��2* ��� $
��0.2* �.+�� $��Center=�$��Bottom=� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto �.+��� $��
0, 0, 5, 0q�.��	Server:�� -   $��	txtServer��$��1��$	��100��$��Center=��� $��2��$��15, 0, 5, 0q�.��	Database:�� -   $��txtDatabase��$��3��$	��100��$��Center=��� $��4��$��15, 0, 5, 0q�.��User:�� -   $��txtUser��$��5��$	��100��$��Center=��� $��6��$��15, 0, 5, 0q�.��	Password:�� -   $��txtPassword��$��7��$	��100��$��Center=��� $��8��$��15, 0, 5, 0q�.��
Company:�� -   $��txtCompanyNr��$��9��$	��100��$��Center=��� $��10��$��15, 0, 0, 0q�.��	Emp-Nr:�� -   $��txtEmpNr��$��11��$	��100��$��Center=��� -    ��Name$ btnGetTimes��$��	Get Times��$��12��$��20, 0, 0, 0q�$
��Left=�$��Center=�$��75��&   System.Windows.Controls.DataGrid  -   $��datagrid��$��1��   CanUserSortColumns . $��40,24,44,34q�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * �� $��2��.���� -	    ��Name$ 
lblMessage��$	��...��$��Center=�$��Center=�$
��Auto��$	��Top=�$
��Auto��