   M S B A M L   `   `   `  ����Q  MMediAssist_Desktop_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:MediAssist_Desktop_App.Views.Doctor#MediAssist_Desktop_App.Views.Doctor  5   	   4    .MediAssist_Desktop_App.Views.Doctor.DoctorDash   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:MediAssist_Desktop_App.Views.Doctor     5   	     � Title$!  MediAssist/Doctor/Dashboard��5      $	��750��6,   $
��1400��69    � WindowStartupLocation$ CenterScreen=�5	   	    � 
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
   -   5        $ AppointmentBtn��5,      $��Appointment��6)   $
��Left=�6?   $��
67,347,0,0q�6Z   $	��Top=�6n   $	��148��6�   $��50��6�   $��22(�6�   $��MV Boli)�6�   
���������6�   Z� ��6�   Z� 6  �� 5-   
   $�� ��6   $
��Left=�6   $��	0,347,0,0q�66   $	��Top=�6I   $��50��6a   $��67��6m   ��5.      �� 5/      $ AppointmentIcon.png��6   $ Uniform=�6?   51      �� 52   
   -   5        $ 	ReportBtn��52      $��Reports��6$   $
��Left=�66   $��
67,402,0,0q�6Q   $	��Top=�6e   $	��148��6}   $��50��6�   $��22(�6�   $��MV Boli)�6�   
���������6�   Z� ��6�   Z� 6�   �� 53   
   $�� ��6   $
��Left=�6   $��	0,402,0,0q�66   $	��Top=�6I   $��50��6a   $��67��6m   ��54      �� 55      $ ReportIcon.png��6   $ Uniform=�6:   57      59      5:      