   M S B A M L   `   `   `  ����Q  MMediAssist_Desktop_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:MediAssist_Desktop_App.Views.Manager$MediAssist_Desktop_App.Views.Manager  5   	   =    7MediAssist_Desktop_App.Views.Manager.MedicineManagement   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:MediAssist_Desktop_App.Views.Manager     5   	     � Title$+  %MediAssist/Manager/MedicineManagement��5   	   $	��750��67   $
��1400��6D    � WindowStartupLocation$ CenterScreen=�5	   	    � 
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
   -   5         ��Name$ split��5>      $
��Left=�6&   $	��643��6A   $��215,78,0,-0.2q�6N   $	��Top=�6e   $	��622��6}   �� 5?   
   $��Name:��6   $
��Left=�6    $��220,113,0,0q�6;   $	��Top=�6P   $��34��6h   $	��139��6t   $��MV Boli)�6�   $��18(�6�   �� 5@   
   $��Distributor:��6   $
��Left=�6'   $��220,157,0,0q�6B   $	��Top=�6W   $��34��6o   $	��139��6{   $��MV Boli)�6�   $��18(�6�   �� 5A   
   $��Type:��6   $
��Left=�6    $��220,198,0,0q�6;   $	��Top=�6P   $��34��6h   $	��139��6t   $��MV Boli)�6�   $��18(�6�   �� 5B   
   $��Price:��6   $
��Left=�6!   $��220,244,0,0q�6<   $	��Top=�6Q   $��34��6i   $	��139��6u   $��MV Boli)�6�   $��18(�6�   �� 5C   
   $��	Quantity:��6   $
��Left=�6$   $��220,283,0,0q�6?   $	��Top=�6T   $��34��6l   $	��139��6x   $��MV Boli)�6�   $��18(�6�   �� 5D   
   $��Availability:��6   $
��Left=�6(   $��220,322,0,0q�6C   $	��Top=�6X   $��34��6p   $	��139��6|   $��MV Boli)�6�   $��18(�6�   �� 5E   
   -	   5         ��Name$ nameTB��5E      $
��Left=�6"   $��34��6=   $��359,113,0,0q�6I   	 �� TextWrapping$
	 Wrap=�6^   $	��Top=�6r   $	��384��6�   $��MV Boli)�6�   $��18(�6�   �� 5F   
   -
   5        $ disTB��5F      $
��Left=�6!   $��34��6<   $��359,159,0,0q�6H   $
	 Wrap=�6]   $	��Top=�6q   $	��384��6�   $��MV Boli)�6�   $��18(�6�   �� 5G   
   -   5        $ priceTB��5G      $
��Left=�6#   $��34��6>   $��359,244,0,0q�6J   $
	 Wrap=�6_   $	��Top=�6s   $	��384��6�   $��MV Boli)�6�   $��18(�6�   �� 5H   
   -   5        $ quanTB��5H      $
��Left=�6"   $��34��6=   $��359,286,0,0q�6I   $
	 Wrap=�6^   $	��Top=�6r   $	��384��6�   $��MV Boli)�6�   $��18(�6�   �� 5I   
   -   5        
 ��Name$
 typeCB��5I      $
��Left=�6#   $��359,201,0,0q�6>   $	��Top=�6S   $	��384��6k   $��34��6w   $��MV Boli)�6�   $��18(�6�   �� 5J   
   -   5        $
 availCB��5J      $
��Left=�6$   $��359,328,0,0q�6?   $	��Top=�6T   $	��384��6l   $��34��6x   $��MV Boli)�6�   $��18(�6�   �� 5K   
   -   5        $
 sortCB��5K      $
��Left=�6#   $��
837,78,0,0q�6>   $	��Top=�6R   $	��550��6j   $��34��6v   $��MV Boli)�6�   $��18(�6�   6�   &   System.Windows.Controls.DataGrid  5L   
   -   5          Name$ medicinesDG��5L         
IsReadOnly . $
��Left=�6:   $	��609��6U   $��837,112,-0.4,-0.2q�6b   $	��Top=�6}   $	��557��6�   $��14(�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�   
���   ����	#FF9C9C9C � 	Resources 5M      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5N      "  6   .�5O      ��  � �� �	#FF1E7C0063   �� 5P       � ��$ SemiBold"�63   �� 5Q       � ��$ 0,0,1,2q�68   �� 5R       � ��
 �   �64   �� 5S       � ��$ Center=�6C   5T      5U      5V      �� 5W   
   -   5        $ addBtn��5W      $	��Add��6!   $
��Left=�6/   $��428,405,0,0q�6J   $	��Top=�6_   $	��145��6w   $��50��6�   $��MV Boli)�6�   $��18(�6�   ���	#FF1B8ABA��6�   Z� 6�   �� 5X   
   -   5        $ 	updateBtn��5X      $��Update��6$   $
��Left=�65   $��278,405,0,0q�6P   $	��Top=�6e   $	��145��6}   $��50��6�   $��MV Boli)�6�   $��18(�6�   ���	#FF1BBA34$y�Hidden=�6�   ��6�   Z� 6�   �� 5Y   
   -   5        $ 
refreshBtn��5Y      $��Refresh��6%   $
��Left=�67   $��578,405,0,0q�6R   $	��Top=�6g   $	��145��6   $��50��6�   $��MV Boli)�6�   $��18(�6�   ���	#FFBA6B1B$y�Hidden=�6�   ��6�   Z� 6�   5[      5\      