   M S B A M L   `   `   `  ����>  :PR5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PR5PR5  5   	       	PR5.user2   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:PR5     5   	     � Title$  Snacks��5   	   $	��450��6   $	��800��6%   .��5	      � ���	#FFE9F1F3 � ColumnDefinitions 5
   
   �� 5      �� 5      $	��432 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$	 us2��5         AutoGenerateColumns .  ���	#FFBBCFD4���	#FF7292B1��6=   �� *a+ �� SelectedItem 5      �� *Snacks+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6&   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
ID_Snack+  5      $% Название закуски��6%    6?   �� *	SnackName+  5      $ Цена��6%    63   �� *
SnackPrice+  5      $ Категория��6%    68   �� *
Category+5      �� 5   
   -   5         ��Name$
 name��5      $��1��6    $
��Left=�60   $��
109,76,0,0q�6K   	 �� TextWrapping$
	 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��188��6�   $��19��6�   �� 5   
   -   5        $ price��5      $��1��6!   $
��Left=�61   $��109,100,0,0q�6L   $
	 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��188��6�   �� 5   
   -   5        $ category��5      $��1��6$   $
��Left=�64   $��109,123,0,0q�6O   $
	 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��188��6�   �� 5   
   $��1��6   $��Название:��6    $
��Left=�64   $��	35,73,0,0q�6O   $	��Top=�6b   �� 5   
   $��1��6   $��Цена��6    $
��Left=�6/   $��	35,96,0,0q�6J   $	��Top=�6]   �� 5   
   $��1��6   $��Категория:��6    $
��Left=�65   $��
35,119,0,0q�6P   $	��Top=�6d   �� 5   
   -   5        $��1��5      $��Добавить��6!   $��Center=�64   $��	0,279,0,0q�6Q   $	��Top=�6d   $��33��6|   $	��126��6�   ���	#FFD9E7ED���	#FF0C0C0C6�   �� 5   
   -   5        $��1��5      $��Изменить��6!   $��Center=�64   $��	0,312,0,0q�6Q   $	��Top=�6d   $��33��6|   $	��126��6�   ���	#FFD9E7ED���	#FF0C0C0C6�   �� 5    
   -   5        $��1��5       $��Удалить��6!   $��Center=�63   $��	0,345,0,0q�6P   $	��Top=�6c   $��33��6{   $	��126��6�   ���	#FFD9E7ED���	#FF0C0C0C6�   �� 5!   
   -   5        $��1��5!      $��
Назад��6!   $
��Left=�61   $��
22,300,0,0q�6L   $	��Top=�6`   $��26��6x   $��63��6�   ���	#FFD9E7ED���	#FF0C0C0C6�   �� 5"   
   $��1��6   $ ��Импортировать��6!   $��Center=�69   $��	0,383,0,0q�6V   $	��Top=�6i   $��22��6�   $	��244��6�   ���	#FFD9E7ED���	#FF0C0C0C6�   5$      5%      