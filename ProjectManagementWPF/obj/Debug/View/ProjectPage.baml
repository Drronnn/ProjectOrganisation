   M S B A M L   `   `   `  ����O  KProjectManagementWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ProjectManagementWPF.ViewProjectManagementWPF.View  5      Q-clr-namespace:ProjectManagementWPF.ComponentsProjectManagementWPF.Components  5      +    %ProjectManagementWPF.View.ProjectPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      3local'clr-namespace:ProjectManagementWPF.View  5      6uc-clr-namespace:ProjectManagementWPF.Components  5        N� Title$  ProjectPage��5       � 	Resources 5       �� 
TargetType   IteractButton �� Property �� Value �� AngleX �� 
TargetType � 	Resources  Key �� 
TargetName	 �� TargetProperty	
 �� To g� Duration g� FillBehavior ��Name
 � Tag �� Padding �� Color �� Orientation � ColumnDefinitions'  !MaterialDesignThemes.Wpf.PackIcon   Kind �� Self �� RelativeSource ��Name �� Triggers ]� 
Conditions �� Property �� Value N� EnterActions  MouseOverAnimation N� ExitActions  MouseOutAnimation P� Property P� Value  MouseDownAnimation��%�	  &	        7  7  7  7  �� 5   
   " ��6   .�5      ��  �@J�RenderTransformOrigin$ 0.5, 0.5&�66   �� 5       � z� 5      �� 5      $	 -20Q�6$   5      �� 5       � �� 5      �� 5      " ��6&    5      ���� 5      MouseOverAnimation .��5   "   �� $ ButtonBorderColor��61   $	 Color�6[   $
 #06e9d2X�6}   $ 0:0:0.1D�6�   �� 5   "   $ ContentPresenter��61   $"	 (TextBlock.Foreground).Color�6Z   $
 #085857X�6�   $ 0:0:0.1D�6�   �� 5   "   $
 Icon��61   $	 Foreground.Color�6N   $
 #085857X�6{   $ 0:0:0.2D�6�   5      �� 5      MouseOutAnimation $
 Stop=�6C   .��5    "   �� $ ButtonBorderColor��61   $	 Color�6[   $
 #06e9d2X�6}   $ 0:0:0.1D�6�   �� 5!   "   $ ContentPresenter��61   $"	 (TextBlock.Foreground).Color�6Z   $
 #085857X�6�   $ 0:0:0.1D�6�   �� 5"   "   $
 Icon��61   $	 Foreground.Color�6N   $
 #085857X�6{   $ 0:0:0.1D�6�   5$      �� 5%      MouseDownAnimation .��5&   "   �� $ ButtonBorderColor��61   $	 Color�6[   $
 #085857X�6}   $ 0:0:0.1D�6�   �� 5'   "   $ ContentPresenter��61   $"	 (TextBlock.Foreground).Color�6Z   $
 #e0e938X�6�   $ 0:0:0.1D�6�   �� 5(   "   $
 Icon��61   $	 Foreground.Color�6N   $
 #e0e938X�6{   $ 0:0:0.2D�6�   5*      5,      .R�5.      �� $ ButtonBorder��6!   # z 67   $
��Left=�6S   $��15, 0, 0, 0q�6n   $��50��6�   $	��200��6�   $ 0, 0, 15, 0q�6�   ��5/      �� 50   "   ButtonBorderColor��$ #e0e938��6M   6_   ._�52      �� $��LeftToRight=�6)   $ 
Horizontal=�6E   .+�53   "   �  54   &   �� 55   *   $��* �6;   6G   �� 56   *   $��3* �6;   6H   .+�58   &     $
��Icon��6N   $��0��6>   # z 6Z   ���#085857$��Center=�6�   $��35��6�   $��35��6�    6v   �� *Tag+# Z z�59   *   V� 5:   .   .~�5;   2   �� $ 20Q�6@   5<   /   5>   '   �� 5?   &   $ ContentPresenter��6�   $��1��67   $��25(�6G   $��Italic$�6_   $��DemiBold"�6|   ���#085857$��Center=�6�   $��Center=�6�   z�5@   *   V� 5A   .   .~�5B   2   �� $ 20Q�6@   5C   /   5E   '   5F   #   5G      5H       5J      ]� 5K       5L   "   �� 5M   &    �@J�IsMouseOver . 6G    5O   "   �� 5P   &   8��  66    5R   "   �� 5S   &   8�� 66   5U      P� 5W       � �� .  5X   "   �� 5Y   &   8�� 66    5[   "   �� 5\   &   8�� 66   5^      5a      5c      5d      5e      .��5g      �  � RowDefinitions 5h   
   �� 5i      $��* �6   6)   �� 5j      $��8* �6   6*   .+�5m   
   �� $��0��6q   #��[  6~   $	 Add��6�   $��Add Project��6�   $��10, 0, 0, 0q�6�   y�6   �� *IsAdministrator+   BooleanToVisibilityConverter  �� 	Converter#  [ ��6�   �� *AddProjectCommand+5o      �� 5p   
   $��0��6   $��Center=�6!   $��45(�5q      $��Italic$�6,   $��DemiBold"�6I   ���#e0e938$��Center=�6�   ПРОЕКТЫ6�   �� 5s   
   $��10q�6   $��1��6#   .��5t      �� -   5        ! ��Name$! items��5t      ��6*   �� *
Projects+��5u      �� 5v      .R�5w      6   0ProjectManagementWPF.Components.ProjectComponent  60   5x      5z      5{      5|      5}      