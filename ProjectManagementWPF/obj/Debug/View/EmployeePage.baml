   M S B A M L   `   `   `  ����O  KProjectManagementWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ProjectManagementWPF.ViewProjectManagementWPF.View  5      Q-clr-namespace:ProjectManagementWPF.ComponentsProjectManagementWPF.Components  5
      ,    &ProjectManagementWPF.View.EmployeePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5      3local'clr-namespace:ProjectManagementWPF.View  5      6uc-clr-namespace:ProjectManagementWPF.Components  5
        N� Title$  EmployeePage��5       � 	Resources 5       �� 
TargetType   IteractButton �� Property �� Value �� AngleX �� 
TargetType � 	Resources  Key �� 
TargetName	 �� TargetProperty	
 �� To g� Duration g� FillBehavior ��Name
 � Tag �� Padding �� Color �� Orientation � ColumnDefinitions'  !MaterialDesignThemes.Wpf.PackIcon   Kind �� Self �� RelativeSource ��Name �� Triggers ]� 
Conditions �� Property �� Value N� EnterActions  MouseOverAnimation N� ExitActions  MouseOutAnimation P� Property P� Value  MouseDownAnimation��%�	  &	        7  7  7  7  �� 5   
   " ��6   .�5      ��  �@J�RenderTransformOrigin$ 0.5, 0.5&�66   �� 5       � z� 5      �� 5      $	 -20Q�6$   5      �� 5       � �� 5      �� 5      " ��6&    5      ���� 5      MouseOverAnimation .��5   "   �� $ ButtonBorderColor��61   $	 Color�6[   $
 #06e9d2X�6}   $ 0:0:0.1D�6�   �� 5   "   $ ContentPresenter��61   $"	 (TextBlock.Foreground).Color�6Z   $
 #085857X�6�   $ 0:0:0.1D�6�   �� 5   "   $
 Icon��61   $	 Foreground.Color�6N   $
 #085857X�6{   $ 0:0:0.2D�6�   5      �� 5      MouseOutAnimation $
 Stop=�6C   .��5   "   �� $ ButtonBorderColor��61   $	 Color�6[   $
 #06e9d2X�6}   $ 0:0:0.1D�6�   �� 5    "   $ ContentPresenter��61   $"	 (TextBlock.Foreground).Color�6Z   $
 #085857X�6�   $ 0:0:0.1D�6�   �� 5!   "   $
 Icon��61   $	 Foreground.Color�6N   $
 #085857X�6{   $ 0:0:0.1D�6�   5#      �� 5$      MouseDownAnimation .��5%   "   �� $ ButtonBorderColor��61   $	 Color�6[   $
 #085857X�6}   $ 0:0:0.1D�6�   �� 5&   "   $ ContentPresenter��61   $"	 (TextBlock.Foreground).Color�6Z   $
 #e0e938X�6�   $ 0:0:0.1D�6�   �� 5'   "   $
 Icon��61   $	 Foreground.Color�6N   $
 #e0e938X�6{   $ 0:0:0.2D�6�   5)      5+      .R�5-      �� $ ButtonBorder��6!   # z 67   $
��Left=�6S   $��15, 0, 0, 0q�6n   $��50��6�   $	��220��6�   $ 0, 0, 15, 0q�6�   ��5.      �� 5/   "   ButtonBorderColor��$ #e0e938��6M   6_   ._�51      �� $��LeftToRight=�6)   $ 
Horizontal=�6E   .+�52   "   �  53   &   �� 54   *   $��* �6;   6G   �� 55   *   $��3* �6;   6H   .+�57   &     $
��Icon��6N   $��0��6>   # z 6Z   ���#085857$��Center=�6�   $��35��6�   $��35��6�    6v   �� *Tag+# Z z�58   *   V� 59   .   .~�5:   2   �� $ 20Q�6@   5;   /   5=   '   �� 5>   &   $ ContentPresenter��6�   $��1��67   $��25(�6G   $��Italic$�6_   $��DemiBold"�6|   ���#085857$��Center=�6�   $��Center=�6�   z�5?   *   V� 5@   .   .~�5A   2   �� $ 20Q�6@   5B   /   5D   '   5E   #   5F      5G       5I      ]� 5J       5K   "   �� 5L   &    �@J�IsMouseOver . 6G    5N   "   �� 5O   &   8��  66    5Q   "   �� 5R   &   8�� 66   5T      P� 5V       � �� .  5W   "   �� 5X   &   8�� 66    5Z   "   �� 5[   &   8�� 66   5]      5`      5b      5c      5d      .��5f      �  � RowDefinitions 5g   
   �� 5h      $��* �6   6)   �� 5i      $��8* �6   6*   .+�5l   
   �� $��0��6q   #��[  6~   $	 Add��6�   $��Add Employee��6�   $��10, 0, 0, 0q�6�   y�6   �� *IsAdministrator+   BooleanToVisibilityConverter  �� 	Converter#  [ ��6�   �� *AddEmployeeCommand+5n      �� 5o   
   $��0��6   $��Center=�6!   $��45(�5p      $��Italic$�6*   $��DemiBold"�6G   ���#e0e938$��Center=�6�   СОТРУДНИКИ6�   �� 5r   
   $��10q�6   $��1��6#   .��5s      �� -   5        ! ��Name$! items��5s      ��6*   �� *	Employees+��5t      �� 5u      .R�5v      7   1ProjectManagementWPF.Components.EmployeeComponent  61   5w      5y      5z      5{      5|      