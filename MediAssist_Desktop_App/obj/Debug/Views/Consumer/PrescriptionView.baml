   M S B A M L   `   `   `  ����Q  MMediAssist_Desktop_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:MediAssist_Desktop_App.Views.Consumer%MediAssist_Desktop_App.Views.Consumer  5   	   <    6MediAssist_Desktop_App.Views.Consumer.PrescriptionView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Elocal3clr-namespace:MediAssist_Desktop_App.Views.Consumer     5   	     � Title$'  !MediAssist/Consumer/Prescriptions��5   	   $	��750��63   $
��1400��6@    � WindowStartupLocation$ CenterScreen=�5	   	    � 
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
   -   5        $ NoteBtn��5&      $��Notes��6"   $��Right=�62   $��0,292,1178.6,0q�6N   $	��Top=�6f   $	��148��6~   $��50��6�   $��22(�6�   $��MV Boli)�6�   
���������6�   Z� ��6�   Z� 6�   �� 5'   
   $�� ��6   $
��Left=�6   $��	0,292,0,0q�66   $	��Top=�6I   $��50��6a   $��67��6m   ��5(      �� 5)      $G A/MediAssist_Desktop_App;component/Views/DeliveryMan/NotesIcon.png��6   $ Uniform=�6m   5+      �� 5,   
   -   5        $ shopBtn��5,      $
��Shop��6"   $��Right=�61   $��0,347,1178.6,0q�6M   $	��Top=�6e   $	��148��6}   $��50��6�   $��22(�6�   $��MV Boli)�6�   
���������6�   Z� ��6�   Z� 6�   �� 5-   
   $�� ��6   $
��Left=�6   $��	0,347,0,0q�66   $	��Top=�6I   $��50��6a   $��67��6m   ��5.      �� 5/      $ ShopCartIcon.png��6   $ Uniform=�6<   51      �� 52   
   -   5        $ puchaseHistoryBtn��52      $��	Purchases��6,   $��Right=�6@   $��0,402,1178.6,0q�6\   $	��Top=�6t   $	��148��6�   $��50��6�   $��22(�6�   $��MV Boli)�6�   
���������6�   Z� ��6�   Z� 6  �� 53   
   $�� ��6   $
��Left=�6   $��	0,402,0,0q�66   $	��Top=�6I   $��50��6a   $��67��6m   ��54      �� 55      $ PuchaseHisoryIcon.png��6   $ Uniform=�6A   57      �� 58   
   -   5        $ 	reportBtn��58      $��Prescriptions ��6$   $��Right=�6=   $��0,457,1178.6,0q�6Y   $	��Top=�6q   $	��148��6�   $��50��6�   $��22(�6�   $��MV Boli)�6�   
���������6�   Z� ��6�   Z� 6  �� 59   
   $�� ��6   $
��Left=�6   $��	0,457,0,0q�66   $	��Top=�6I   $��50��6a   $��67��6m   ��5:      �� 5;      $ ConsumerReportIcon.png��6   $ Uniform=�6B   5=      �� 5>   
   -   5        $ appontmentBtn��5>      $��Appointment��6(   $��Right=�6>   $��0,512,1178.6,0q�6Z   $	��Top=�6r   $	��148��6�   $��50��6�   $��22(�6�   $��MV Boli)�6�   
���������6�   Z� ��6�   Z� 6  �� 5?   
   $�� ��6   $
��Left=�6   $��	0,512,0,0q�66   $	��Top=�6I   $��50��6a   $��67��6m   ��5@      �� 5A      $! ConsumerAppointmentIcon.png��6   $ Uniform=�6G   5C      �� 5D   
   $��Subject:��6   $
��Left=�6#   $��215,125,0,0q�6>   $	��Top=�6S   $��42��6k   $	��139��6w   $��MV Boli)�6�   $��18(�6�   �� 5E   
   -	   5         ��Name$ 	subjectTB��5E      $
��Left=�6%   $��42��6@   $��359,125,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��536��6�   $��MV Boli)�6�   $��18(�6�   	 �� 
IsReadOnly	 .  6�   �� 5F   
   $��Report:��6   $
��Left=�6"   $��215,172,0,0q�6=   $	��Top=�6R   $��42��6j   $	��139��6v   $��MV Boli)�6�   $��18(�6�   �� 5G   
   -
   5        $ reportTB��5G      $
��Left=�6$   
 �� AcceptsReturn
 . $	��502��6T   $��220,219,0,-0.2q�6a   $
 Wrap=�6y   $	��Top=�6�   $	��680��6�   $��MV Boli)�6�   $��18(�6�   &   System.Windows.Controls.DataGrid  5H   
   -   5          Name$ reportDG��5H         
IsReadOnly .  $
��Left=�68   $	��601��6S   $��900,120,-0.4,-0.2q�6`   $	��Top=�6{   $	��494��6�   $��14(�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6�   
���   ����	#FF9C9C9C � 	Resources 5I      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5J      "  6   .�5K      ��  � �� �	#FF1E7C0063   �� 5L       � ��$ SemiBold"�63   �� 5M       � ��$ 0,0,1,2q�68   �� 5N       � ��
 �   �64   �� 5O       � ��$ Center=�6C   5P      5Q      5R      �� 5S   
   $)��#                      Given Reports��6   $
��Left=�6>   $��900,78,-1.4,0q�6Y   $	��Top=�6p   $��42��6�   $	��495��6�   ���	#FF2276A2$��MV Boli)�6�   $��18(�6�   �� 5T   
   -   5        $ 
refreshBtn��5T      $��Refresh��6%   $
��Left=�67   $��
220,78,0,0q�6R   $	��Top=�6f   $	��675��6~   $��42��6�   $��MV Boli)�6�   $��18(�6�   ���	#FF08ACC36�   5U      5V      