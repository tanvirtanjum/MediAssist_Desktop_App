   M S B A M L   `   `   `  ����Q  MMediAssist_Desktop_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MediAssist_Desktop_AppMediAssist_Desktop_App  5   	   &     MediAssist_Desktop_App.LoginView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:MediAssist_Desktop_App     5   	     � Title$  MediAssist/Login��5   	   $	��450��6"   $	��350��6/    � 
ResizeMode$ CanMinimize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      �  J� Opacity$	 0.8Q�6   ��5   
   �� 5       �� ImageSource$ Login Background.png��6   .+�5   
   �� $�� ��6   $��Center=�6   $��	82,2,92,0q�68   $	��Top=�6K   $	��120��6c   $	��170��6p    J� RenderTransformOrigin$ 	1.157,0.5&�6|   ��5      �� 5      $ MediAssistProjectLogo.png��6   5      �� 5   
   -   5         ��Name$ 
usernameTB��5      $��40��6&   $��23,158,26,0q�62    �� TextWrapping$
 Wrap=�6G   $	��Top=�6[   $	��295��6s   
�������$��Center=�6�   $��18(�6�   $
��Bold"�6�    �� TextAlignment$ Center=�6�   $	 0.7Q�6�   ��6�   Z� 6�   �� 5   
   $��Username��6   $
��Left=�6#   $��
23,124,0,0q�6>   $	��Top=�6R   $	��110��6j   $��18(�6v   $��Comic Sans MS)�6�   $
��Bold"�6�   �� 5   
   $��Password��6   $
��Left=�6#   $��
23,202,0,0q�6>   $	��Top=�6R   $��94��6j   $��36��6u   $��Comic Sans MS)�6�   $
��Bold"�6�   $��18(�6�   G� 5   
   -   5        	 G�Name$	 
passwordTB��5      $��Center=�6*   $��23,238,26,0q�6G   $	��Top=�6\   $��40��6t   $	��295��6�   $��18(�6�   $��Consolas)�6�   $	 0.7Q�6�   ��6�   Z� �� 5   
   -   5        
 ��Name$
 loginBTN��5      $��LOGIN��6#   $��Center=�63   $��127,314,137,0q�6P   $	��Top=�6g   $��80��6   $��35��6�   ���	#FF24036C$��Consolas)�6�   $��18(�6�   $
��Bold"�6�   
���������6�   Z� 6  �� 5   
   -   5        $
 registerBTN��5      $��REGISTER��6&   $��Center=�69   $��82,356,92,0q�6V   $	��Top=�6k   $	��170��6�   $��35��6�   ���	#FF93108F$��Consolas)�6�   $��18(�6�   $
��Bold"�6�   
���������6�   Z� 6  �� 5   
   -   5         ��Name$ loginErrLbl��5      $��Invalid Username/Password��6%   $
��Left=�6I   $��
23,283,0,0q�6d   $	��Top=�6x   $	��295��6�   $��15(�6�   $��Comic Sans MS)�6�   $
��Bold"�6�   ���	#FFF00C0C$y�Hidden=�6�   5      5      