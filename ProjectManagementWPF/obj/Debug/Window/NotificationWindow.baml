   M S B A M L   `   `   `  ����O  KProjectManagementWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ProjectManagementWPF.WindowProjectManagementWPF.Window  5   	   4    .ProjectManagementWPF.Window.NotificationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ProjectManagementWPF.Window     5   	     � Title$  NotificationWindow��5   	   $	��200��6$   $	��350��61    � WindowStyle$
 None=�5	   	   
������  � AllowsTransparency . $��Center=�5   	   $��Center=�5   	    � 	Resources 5       �� 
TargetType   IteractButton �� Property �� Value �� AngleX �� 
TargetType	 � 	Resources  Key
 �� 
TargetName �� TargetProperty	 �� To g� Duration g� FillBehavior ��Name
 � Tag �� Color ��Name �� Triggers ]� 
Conditions �� Property �� Value N� EnterActions  MouseOverAnimation N� ExitActions  MouseOutAnimation P� Property P� Value  MouseDownAnimation  MouseUpAnimation��%  &	        7  7  7  7  �� 5   
   " ��6   .�5      ��  �@J�RenderTransformOrigin$ 0.5, 0.5&�66   �� 5       � z� 5      �� 5      $	 -20Q�6$   5      �� 5       � �� 5      �� 5      " ��6&   	 5      ���� 5      MouseOverAnimation .��5   "   �� $
 ButtonBorderColor��61   $ Color�6[   $ #e0e938X�6}   $ 0:0:0.2D�6�   �� 5   "   $
 ContentPresenter��61   $" (TextBlock.Foreground).Color�6Z   $ BlackX�6�   $ 0:0:0.1D�6�   5      �� 5       MouseOutAnimation $
 Stop=�6C   .��5!   "   �� $
 ButtonBorderColor��61   $ Color�6[   $ #06e9d2X�6}   $ 0:0:0.2D�6�   �� 5"   "   $
 ContentPresenter��61   $" (TextBlock.Foreground).Color�6Z   $ BlackX�6�   $ 0:0:0.1D�6�   5$      �� 5%      MouseDownAnimation .��5&   "   �� $
 ButtonBorderColor��61   $ Color�6[   $ #dfd828X�6}   $ 0:0:0.1D�6�   �� 5'   "   $
 ContentPresenter��61   $" (TextBlock.Foreground).Color�6Z   $ WhiteX�6�   $ 0:0:0.1D�6�   5)      �� 5*      MouseUpAnimation .��5+   "   �� $
 ButtonBorderColor��61   $ Color�6[   $ #085857X�6}   $ 0:0:0.2D�6�   �� 5,   "   $
 ContentPresenter��61   $" (TextBlock.Foreground).Color�6Z   $ WhiteX�6�   $ 0:0:0.1D�6�   5.      5/      .R�51      �� $ ButtonBorder��6>   $��Center=�6!   # z 6T   
������ $��1q�6�   $��40q�6�   ��52      �� 53   "   ButtonBorderColor��$ #06e9d2��6M   6_   ._�55      �� $ ContentPresenter��6�   $��20q�60   $��20(�6<   $��DemiBold"�6T   
���   �$��Center=�6�   $��Center=�6�   z�56   "   V� 57   &   .~�58   *   �� $ 20Q�68   59   '   5;      5<       5=      ]� 5>       5?   "   �� 5@   &    �@J�IsMouseOver . 6G    5B   "   �� 5C   &   8��  66    5E   "   �� 5F   &   8�� 66   5H      P� 5J       � �� .  5K   "   �� 5L   &   8�� 66    5N   "   �� 5O   &   8�� 66   5Q      5T      5V      5W      5X      .��5Z      � $��Center=�6   
������ .+�5[   
   �� -   5         ��Name$	 But��5[   U   $��Center=�6   #��[  6.   6y   5\      5]      