   M S B A M L   `   `   `  ����>  :PR5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PR5PR5  5   	       	PR5.user3   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:PR5     5   	     � Title$  Status Ticket��5   	   $	��450��6   $	��800��6,   .��5	      � ���	#FFE9F1F3 � ColumnDefinitions 5
   
   �� 5      �� 5      $	��424 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$	 us3��5         AutoGenerateColumns .  
���   ����	#FFBBCFD4���	#FF7292B1��6<   �� *a+ �� SelectedItem 5      �� *StatusTicket+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6&   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *ID_StatusTicket+  5      $ Статус��6%    65   �� *Status+  5      $ 
Билет��6%    64   �� *TicketOrdersID+5      �� 5   
   -   5         ��Name$ status��5      $��1��6"   $
��Left=�62   $��
142,75,0,0q�6M   	 �� TextWrapping$
	 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��213��6�   $��21��6�   �� 5   
   -   5        
 ��Name$
 orders��5      $��1��6#   $
��Left=�63   $��142,116,0,0q�6N   $	��Top=�6c   $	��213��6{   $��21��6�   �� 5   
   $��1��6   $��Статус:��6    $
��Left=�62   $��	39,70,0,0q�6M   $	��Top=�6`   $��26��6x   $��84��6�   $��14(�6�   �� 5   
   $��1��6   $��Билет:��6    $
��Left=�61   $��
39,112,0,0q�6L   $	��Top=�6`   $��32��6x   $��69��6�   $��14(�6�   �� 5   
   -   5        $��1��5      $��Добавить��6!   $��Center=�64   $��	0,279,0,0q�6Q   $	��Top=�6d   $��32��6|   $	��164��6�   ���	#FFD9E7ED���	#FF0C0C0C6�   �� 5   
   -   5        $��1��5      $��Изменить��6!   $��Center=�64   $��	0,311,0,0q�6Q   $	��Top=�6d   $��32��6|   $	��164��6�   ���	#FFD9E7ED���	#FF0C0C0C6�   �� 5   
   -   5        $��1��5      $��Удалить��6!   $��Center=�63   $��	0,343,0,0q�6P   $	��Top=�6c   $��32��6{   $	��164��6�   ���	#FFD9E7ED���	#FF0C0C0C6�   �� 5   
   -   5        $��1��5      $��
Назад��6!   $
��Left=�61   $��
39,279,0,0q�6L   $	��Top=�6`   $��32��6x   $��69��6�   ���	#FFD9E7ED���	#FF0C0C0C6�   5       5!      