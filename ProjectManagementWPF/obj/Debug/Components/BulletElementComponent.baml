   M S B A M L   `   `   `  ����O  KProjectManagementWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ProjectManagementWPF.ComponentsProjectManagementWPF.Components  5      <    6ProjectManagementWPF.Components.BulletElementComponent   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:ProjectManagementWPF.Components     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � 	Resources  5
       �� 
TargetType   IteractButton �� Property �� Value �� AngleX �� 
TargetType � 	Resources  Key �� 
TargetName �� TargetProperty		 �� To
 g� Duration g� FillBehavior ��Name
 � Tag �� Padding �� Color �� Orientation � ColumnDefinitions'  !MaterialDesignThemes.Wpf.PackIcon   Kind �� Self �� RelativeSource ��Name �� Triggers ]� 
Conditions �� Property �� Value N� EnterActions  MouseOverAnimation N� ExitActions  MouseOutAnimation P� Property P� Value  MouseDownAnimation��%�	  &	        7  7  7  7  �� 5   
   " ��6   .�5      ��  �@J�RenderTransformOrigin$ 0.5, 0.5&�66   �� 5       � z� 5      �� 5      $	 -20Q�6$   5      �� 5       � �� 5      �� 5      " ��6&    5      ���� 5      MouseOverAnimation .��5   "   �� $ ButtonBorderColor��61   $ Color�6[   $	 #06e9d2X�6}   $
 0:0:0.1D�6�   �� 5   "   $ ContentPresenter��61   $" (TextBlock.Foreground).Color�6Z   $	 #085857X�6�   $
 0:0:0.1D�6�   �� 5   "   $
 Icon��61   $ Foreground.Color�6N   $	 #085857X�6{   $
 0:0:0.1D�6�   5      �� 5      MouseOutAnimation $
 Stop=�6C   .��5   "   �� $ ButtonBorderColor��61   $ Color�6[   $	 TransparentX�6}   $
 0:0:0.1D�6�   �� 5   "   $ ContentPresenter��61   $" (TextBlock.Foreground).Color�6Z   $	 BlackX�6�   $
 0:0:0.1D�6�   �� 5   "   $
 Icon��61   $ Foreground.Color�6N   $	 #e0e938X�6{   $
 0:0:0.1D�6�   5!      �� 5"      MouseDownAnimation .��5#   "   �� $ ButtonBorderColor��61   $ Color�6[   $	 #06e9d2X�6}   $
 0:0:0.1D�6�   �� 5$   "   $ ContentPresenter��61   $" (TextBlock.Foreground).Color�6Z   $	 #085857X�6�   $
 0:0:0.1D�6�   �� 5%   "   $
 Icon��61   $ Foreground.Color�6N   $	 #085857X�6{   $
 0:0:0.1D�6�   5'      5)      .R�5+      �� $ ButtonBorder��6!   # z 67   $
��Left=�6S   $��15, 0, 0, 0q�6n   $��40��6�   $ 0, 0, 15, 0q�6�   ��5,      �� 5-   "   ButtonBorderColor��$ Transparent��6M   6c   ._�5/      �� $��LeftToRight=�6)   $ 
Horizontal=�6E   .+�50   "   �  51   &   �� 52   *   $��* �6;   6G   �� 53   *   $��3* �6;   6H   .+�55   &     $
��Icon��6N   $��0��6>   # z 6Z   ���#e0e938$��Center=�6�   $��0, 0, 10, 0q�6�   $��30��6   $��25��6   6v   �� *Tag+# Z z�56   *   V� 57   .   .~�58   2   �� $ 20Q�6@   59   /   5;   '   �� 5<   &   $ ContentPresenter��6   $��1��67   $��18(�6G   $��DemiBold"�6_   ���#06e9d2$��Center=�6�   $��Center=�6�   z�5=   *   V� 5>   .   .~�5?   2   �� $ 20Q�6@   5@   /   5B   '   5C   #   5D      5E       5G      ]� 5H       5I   "   �� 5J   &    �@J�IsMouseOver . 6G    5L   "   �� 5M   &   8��  66    5O   "   �� 5P   &   8�� 66   5R      P� 5T       � �� .  5U   "   �� 5V   &   8�� 66    5X   "   �� 5Y   &   8�� 66   5[      5^      5`      5a      5b      .��5d      � .+�5e   
   �� $ 
Horizontal=�6   .+�5f      �� $y�	Collapsed=�6   $��Id��6/   �� 5g      #��[  6   $ RhombusOutline��6<   ��6Q   �� *Title+��6k   ��  �� *FindAncestor+ �� AncestorType" N� �� Path$) #DataContext.OpenTaskSideMenuCommand���5h      �� *Id+5i      5j      5k      5l      