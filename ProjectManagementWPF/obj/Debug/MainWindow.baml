   M S B A M L   `   `   `  ����O  KProjectManagementWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ProjectManagementWPFProjectManagementWPF  5   	   Q-clr-namespace:ProjectManagementWPF.ComponentsProjectManagementWPF.Components  5   	   %    ProjectManagementWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:ProjectManagementWPF     5   	   <uc-clr-namespace:ProjectManagementWPF.Components     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5
   	   $	��650��6   $
��1050��6)    � WindowStyle$
 None=�5   	   
������  � AllowsTransparency .  � 	Resources 5      +   %ProjectManagementWPF.BoolToVisibility   BoolToVisibilityConverter �� 
TargetType  SideMenuButton �� Property �� Value �� AngleX �� 
TargetType	 � 	Resources  Key
 �� 
TargetName �� TargetProperty	 �� To g� Duration g� FillBehavior ��Name
 � Tag �� Color �� Orientation ��Name �� Triggers ]� 
Conditions �� Property �� Value N� EnterActions  MouseOverAnimation N� ExitActions  MouseOutAnimation P� Property P� Value  MouseUpAnimation  IteractButton �� CornerRadius � ColumnDefinitions'  !MaterialDesignThemes.Wpf.PackIcon   Kind �� Self  �� RelativeSource  SlantedButton! �� 
TargetName��%�  &	        &	      7  7  7  7  &	 �    7  7  &	 |      5   
   6!   �� 5   
   " 	�6   .�5      ��  �@J�RenderTransformOrigin$ 0.5, 0.5&�66   �� 5       � z� 5      �� 5      $	 -20Q�6$   5      �� 5       � �� 5      �� 5      " 	�6&   	 5      ���� 5      MouseOverAnimation .��5   "   �� $
 ButtonBorderColor��61   $ Color�6[   $ #06e9d2X�6}   $ 0:0:0.1D�6�   5       �� 5!      MouseOutAnimation $
 Stop=�6C   .��5"   "   �� $
 ButtonBorderColor��61   $ Color�6[   $ TransparentX�6}   $ 0:0:0.1D�6�   5#      �� 5$      MouseDownAnimation .��5%   "   �� $
 ButtonBorderColor��61   $ Color�6[   $ #dfd828X�6}   $ 0:0:0.1D�6�   5'      �� 5(      MouseUpAnimation .��5)   "   �� $
 ButtonBorderColor��61   $ Color�6[   $ #e0e938X�6}   $ 0:0:0.1D�6�   5+      5,      .R�5/      �� $ ButtonBorder��6!   # z 67   
������ $��1q�6n   ��50      �� 51   "   ButtonBorderColor��$ Transparent��6M   6c   ._�53      �� $��LeftToRight=�6)   $ 
Horizontal=�6E   .+�54   "   � .+�55   &   �� $ ContentPresenter��6�   $��20(�67   ���#085857$��DemiBold"�6n   $��Italic$�6�   $��Center=�6�   $��Center=�6�   $��10, 0, 25, 0q�6�   z�56   *   V� 57   .   .~�58   2   �� $ 20Q�6@   59   /   5;   '   5<   #   5=      5>       5@      ]� 5A       5B   "   �� 5C   &    �@J�IsMouseOver . 6G   �� 5D   &    �@d�	IsChecked$ FalseY�6E    5F   "   �� 5G   &   8��  66    5I   "   �� 5J   &   8�� 66   5L      P� 5N       �@d�	IsChecked$
 TrueY�6;    5O   "   �� 5P   &   8�� 66    5R   "   �� 5S   &   8�� 66   5U      5W      5Y      5Z      �� 5\   
   " ��6   .�5]      ��  � �� 5^      �� 5_      " ��6&   	 5`      ���� 5a      MouseOverAnimation .��5b   "   �� $
 ButtonBorderColor��61   $ Color�6[   $ #bb9fd6X�6}   $ 0:0:0.2D�6�   �� 5c   "   $
 ContentPresenter��61   $" (TextBlock.Foreground).Color�6Z   $ WhiteX�6�   $ 0:0:0.2D�6�   �� 5d   "   $

 Icon��61   $ (Foreground).Color�6N   $ WhiteX�6}   $ 0:0:0.2D�6�   5e      �� 5f      MouseOutAnimation $
 Stop=�6C   .��5g   "   �� $
 ButtonBorderColor��61   $ Color�6[   $ TransparentX�6}   $ 0:0:0.2D�6�   �� 5h   "   $
 ContentPresenter��61   $" (TextBlock.Foreground).Color�6Z   $ BlackX�6�   $ 0:0:0.2D�6�   �� 5i   "   $

 Icon��61   $ (Foreground).Color�6N   $ BlackX�6}   $ 0:0:0.2D�6�   5j      �� 5k      MouseDownAnimation .��5l   "   �� $
 ButtonBorderColor��61   $ Color�6[   $ VioletX�6}   $ 0:0:0.2D�6�   �� 5m   "   $
 ContentPresenter��61   $" (TextBlock.Foreground).Color�6Z   $ WhiteX�6�   $ 0:0:0.2D�6�   �� 5n   "   $

 Icon��61   $ (Foreground).Color�6N   $ WhiteX�6}   $ 0:0:0.2D�6�   5o      �� 5p      MouseUpAnimation .��5q   "   �� $
 ButtonBorderColor��61   $ Color�6[   $ 
DarkVioletX�6}   $ 0:0:0.2D�6�   �� 5r   "   $
 ContentPresenter��61   $" (TextBlock.Foreground).Color�6Z   $ WhiteX�6�   $ 0:0:0.2D�6�   �� 5s   "   $

 Icon��61   $ (Foreground).Color�6N   $ WhiteX�6}   $ 0:0:0.2D�6�   5t      5u      .R�5x      �� $ ButtonBorder��6!   # z 67   $ 5��6T   
������ $��1q�6   $��10q�6�   $��40��6�   ��5z      �� 5{   "   ButtonBorderColor��$ Transparent��6M   6c   ._�5}      �� $��LeftToRight=�6)   $ 
Horizontal=�6E   .+�5~   "   �  5   &   �� 5�   *   $��* �6;   6G   �� 5�   *   $��3* �6;   6H   .+�5�   &     $
��Icon��6N   $��0��6>   # z 6Z   ���#085857$��Center=�6�   $��10, 0, 10, 0q�6�   $��30��6  $��25��6   6v   �� *Tag+#  Z 6  �� 5�   &   $ ContentPresenter��6   $��1��67   $��18(�6G   $��DemiBold"�6_   $��Center=�6�   $��Center=�6�   5�   '   5�   #   5�      5�       5�      ]� 5�       5�   "   �� 5�   &    �@J�IsMouseOver . 6G    5�   "   �� 5�   &   8��  66    5�   "   �� 5�   &   8�� 66   5�      5�      5�      5�      �� 5�   
   " ��6&   .�5�      ��  � ��$ 0q�60   �� 5�       � ��$
 10,5q�6(   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      � .+�5�      �� $ border��6%   #��z��65   #��z��6_   #��z��6�   ._�5�   "   �� $��Center=�63   $��Center=�6P   z�5�   &   V� 5�   *   .~�5�   .   �� $ 20Q�6<   5�   +   5�   #   5�      5�       5�      P� 5�       �@J�IsMouseOver . . �5�   "   �� $! border��6)    � �� �#e0e9386S   5�      P� 5�       � �� . . �5�   "   �� $! border��6)    � �� �#06e9d26S   5�      5�      5�      �� 5�       �@J�RenderTransformOrigin$ 0.5, 0.5&�66   �� 5�       � z� 5�      �� 5�      $	 -20Q�6$   5�      5�      5�      .��5�      �� -   5        $ 
MainBorder��5�      ���#111810._�5�   
   � " � RowDefinitions" 5�      �� 5�      $��* �6    6-   �� 5�      $��9* �6    6.   .+�5�      �� $��0��6   # K� ZIndex$# 2��6"   ._�5�      �� -   5        $ ��Name$$ DragRecranhle��5�      
������ $��Center=�6k   $��55��6�   $��	735,0,0,0q�6�   5�      �� 5�      $# 2��6   
������ $ 
Horizontal=�6C   $	��Top=�6\   $��Right=�6t   $
��auto��6�   $��0��6�   $��0, 0, -11, 0q�6�   .+�5�      �� #��[ 6n   $��40��6�   $��0q�6�   
������ $��50��6�   y�6   �� *	IsLogin+% �� 	Converter#% [  ��6�   �� *LogOutCommand+.��5�        $ Logout=�6.   $��Center=�6<   ���#085857$	��-10q�6n   $��20��6{   $��20��6�   5�      �� 5�      #��[ 6   $��40��6@   $��0q�6L   
������ $��50��6y   .��5�        $ ColorHelper=�6.   $��Center=�6A   ���#085857$	��-10q�6s   $��20��6�   $��20��6�   5�      �� 5�      #��[ 6   $��40��6@   $��0q�6L   $��50��6`   
������ & � Cursor$
& Hand��5�   .   ��5�      �� *MaxMinCommand+.��5�        $ VectorArrangeBelow=�6.   $��Center=�6H   $	��-10q�6e   $��20��6r   $��20��6~   ���#0858576�   5�      �� 5�      -   5        ' ��Name$' CloseButton��5�      #��[ 6.   
������ $��40��5�      $��65��6!   +  %MaterialDesignThemes.Wpf.ButtonAssist(   CornerRadius$( 0,0,0,0��5�      $��0q�5�      $
& Hand��5�      ��5�      �� *CloseCommand+.��5�        $ Close=�6.   $	��-10q�6;   $��20��6H   $��20��6T   ���#0858576_   5�      5�      �� 5�      -   5        $ 
Horizontal=�5�      $��0��63   .+�5�      �� $ 
Horizontal=�6   $��10q�66   .+�5�      �� $8��2/ProjectManagementWPF;component/Source/boarPng.png��6   $��40��6X   $��40��6c   $��Center=�6o   $��Center=�5�      �� 5�      ) �� Padding$) 10, 10,60, 10q�5�      $��Center=�5�      $��Center=�5�      $��Bahnschrift)�5�      $��35(�5      $
��Bold"�5     $��Italic$�5     ���#e0e938KABAN5     5     	� 5	     -   5        * 	�Name$* AgileButton��5
     + 	� 	GroupName$+ SideMenu��5     $��Agile��5     #��[ 5     $
& Hand��5     ��5     �� *NavigateCommand+.��5  '   AGILE5     	� 5     -   5        $* EmployeesButton��5     $+ SideMenu��5     $��Employee��5     #��[ 5     $
& Hand��5     ��5     �� *NavigateCommand+.��5  '   	EMPLOYEES5     	� 5     -   5        $* ProjectsButton��5     $+ SideMenu��5     $��Project��5!     #��[ 5"     $
& Hand��5#     ��5      �� *NavigateCommand+.��5#  '   
PROJECTS5%     	� 5&     -   5        $* ContractsButton��5'     $+ SideMenu��5(     $��Contract��5*     #��[ 5+     $
& Hand��5,     ��5)     �� *NavigateCommand+.��5,  '   	CONTRACTS5.     5/     �� 5@     $��2��6   $# 1��6&   ._�5A      � -	   5        ,  �Name$, 	authFrame��5A     -  � NavigationUIVisibility$- Hidden=�6+   5D     �� 5G     $��1��6   $ 0, 20, 20, 0��6"   ._�5H      � -
   5        $, 	mainFrame��5H     $- Hidden=�6+   5I     5K     5M     5O     