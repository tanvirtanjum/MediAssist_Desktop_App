   M S B A M L   `   `   `  ����Q  MMediAssist_Desktop_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:MediAssist_Desktop_App.Views.Manager$MediAssist_Desktop_App.Views.Manager  5   	   8    2MediAssist_Desktop_App.Views.Manager.ShipmentsView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:MediAssist_Desktop_App.Views.Manager     5   	     � Title$"  MediAssist/Manager/Shipments��5   	   $	��750��6.   $
��1400��6;    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ CanMinimize=�5
   	   .��5      � .+�5   
   �� $
��Left=�6   $	��721��62   $	��Top=�6?   $	��215��6W   $��
0,0,0,-0.2q�6c   ���	#FF1158896w   �� 5   
   $�� ��6   $
��Left=�6   $	��Top=�66   $	��147��6N   $	��175��6[    J� RenderTransformOrigin$ 0.434,0.531&�6g   $��16,0,0,0q�6�   ��5      �� 5       �� ImageSource$ MediAssistProjectLogo.png��6   5      �� 5   
   $
��Left=�6   $��79��62   $��210,-1,-1.4,0q�6>   $	��Top=�6U   $
��1185��6m   ���	#FF1158896z   �� 5   
   -   5         ��Name$ 	logoutBtn��5      $
��Left=�6$   $��1307,14,0,0q�6?   $	��Top=�6T   $��67��6l   $��50��6w   ��6�   Z� ��6�   Z� ��6�   Z� .��5      �� $�� ��6   $��45��6   $��57��6+   ��5      �� 5      $ LogoutIcon.png��6!    j� Stretch$ Uniform=�6>   5      5      �� 5   
   -   5        $ HomeBtn��5      $
��Home��6"   $
��Left=�61   $��
67,182,0,0q�6L   $	��Top=�6`   $	��148��6x   $��50��6�   $��22(�6�   $��MV Boli)�6�   
���������6�   Z� ��6�   Z� 6�   �� 5   
   $�� ��6   $
��Left=�6   $��	0,182,0,0q�66   $	��Top=�6I   $��50��6a   $��67��6m   ��5      �� 5      $@ :/MediAssist_Desktop_App;component/Views/Admin/HomeIcon.png��6   $ Uniform=�6f   5      �� 5    
   -   5        $ 
ProfileBtn��5       $��Profile��6%   $
��Left=�67   $��
67,237,0,0q�6R   $	��Top=�6f   $	��148��6~   $��50��6�   $��22(�6�   $��MV Boli)�6�   
���������6�   Z� ��6�   Z� 6�   �� 5!   
   $�� ��6   $
��Left=�6   $��	0,237,0,0q�66   $	��Top=�6I   $��50��6a   $��67��6m   ��5"      �� 5#      $G A/MediAssist_Desktop_App;component/Views/Admin/UserProfileIcon.png��6   $ Uniform=�6m   5%      �� 5&   
   -   5        $ NoteBtn��5&      $��Notes��6"   $
��Left=�62   $��
67,292,0,0q�6M   $	��Top=�6a   $	��148��6y   $��50��6�   $��22(�6�   $��MV Boli)�6�   
���������6�   Z� ��6�   Z� 6�   �� 5'   
   $�� ��6   $
��Left=�6   $��	0,292,0,0q�66   $	��Top=�6I   $��50��6a   $��67��6m   ��5(      �� 5)      $G A/MediAssist_Desktop_App;component/Views/DeliveryMan/NotesIcon.png��6   $ Uniform=�6m   5+      �� 5,   
   -   5        $ MedicinesBtn��5,      $��Medicine��6'   $��67,347,1178.6,0q�6:   $	��Top=�6S   $��50��6k   $��22(�6�   $��MV Boli)�6�   
���������6w   Z� ��6�   Z� 6�   �� 5-   
   $�� ��6   $
��Left=�6   $��	0,347,0,0q�66   $	��Top=�6I   $��50��6a   $��67��6m   ��5.      �� 5/      $G A/MediAssist_Desktop_App;component/Views/Consumer/MedicineIcon.png��6   $ Uniform=�6m   51      �� 52   
   -   5        $ PendingOrdersBtn��52      $��Orders��6+   $��67,402,1178.6,0q�6<   $	��Top=�6U   $��50��6m   $��22(�6�   $��MV Boli)�6�   
���������6y   Z� ��6�   Z� 6�   �� 53   
   $�� ��6   $
��Left=�6   $��	0,402,0,0q�66   $	��Top=�6I   $��50��6a   $��67��6m   ��54      �� 55      $E ?/MediAssist_Desktop_App;component/Views/Consumer/OrdersIcon.png��6   $ Uniform=�6k   57      �� 58   
   -   5        $ 
HistoryBtn��58      $��	Shipments��6%   $��67,457,1178.6,0q�69   $	��Top=�6R   $��50��6j   $��22(�6�   $��MV Boli)�6�   
���������6v   Z� ��6�   Z� 6�   �� 59   
   $�� ��6   $
��Left=�6   $��	0,457,0,0q�66   $	��Top=�6I   $��50��6a   $��67��6m   ��5:      �� 5;      $N H/MediAssist_Desktop_App;component/Views/Consumer/ShipmentHistoryIcon.png��6   $ Uniform=�6t   5=      �� 5>   
   $
��Left=�6   $	��643��62   $��215,78,0,-0.2q�6?   $	��Top=�6V   $	��572��6n   &   System.Windows.Controls.DataGrid  5?   
   -   5          Name$ orderDG��5?         
IsReadOnly . $
��Left=�66   $	��643��6Q   $��792,78,-0.4,-0.2q�6^   $	��Top=�6x   $	��602��6�   $��14(�6�   	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6�   
���   ����	#FF9C9C9C
 � 	Resources
 5@      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5A      "  6   .�5B      ��  � �� �	#FF1E7C0063   �� 5C       � ��$ SemiBold"�63   �� 5D       � ��$ 0,0,1,2q�68   �� 5E       � ��
 �   �64   �� 5F       � ��$ Center=�6C   5G      5H      5I      �� 5J   
   -	   5         ��Name$ 	detailsTB��5J      $
��Left=�6%    �� AcceptsReturn . $	��556��6U   $��
215,78,0,0q�6b    �� TextWrapping$
 Wrap=�6v   $	��Top=�6�   $	��577��6�   $��MV Boli)�6�   $��18(�6�    �� 
IsReadOnly . 6�   �� 5K   
   -
   5        $ 
refreshBtn��5K      $��Refresh��6%   $
��Left=�67   $��215,634,0,-0.2q�6R   $	��Top=�6j   $	��577��6�   $��87��6�   $��MV Boli)�6�   $��36(�6�   ���	#FF2FCAD3���	#FF2FCAD3 J� OpacityMask �	#FF2FCAD36  5M      5N      