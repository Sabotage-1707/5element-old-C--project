   M S B A M L   `   `   `  ����F  BLAB33_KPIAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LAB33_KPIAP.PagesLAB33_KPIAP.Pages  5          LAB33_KPIAP.Pages.Korzina   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:LAB33_KPIAP.Pages     5      -   5          N� Title$  Korzina��5	       � 	Resources 5         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray ! RadioButton.Static.Background �� Color  RadioButton.Static.Border  OptionMarkFocusVisual $  RadioButton.MouseOver.Background   RadioButton.MouseOver.Border  RadioButton.MouseOver.Glyph # RadioButton.Disabled.Background  RadioButton.Disabled.Border 	 RadioButton.Disabled.Glyph "
 RadioButton.Pressed.Background  RadioButton.Pressed.Border  RadioButton.Pressed.Glyph  RadioButton.Static.Glyph  RadioButtonStyle1 �� 
TargetType �� 
TargetType	 �Name
 � ColumnDefinitions ��Name �� CornerRadius A�Name J� Opacity ��Name �� Triggers P� Property P� Value �� 
TargetName  Button.Static.Background  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground��%�  &	        &	 �     &	 �     &	 �     &	 �    &	 �    &	 �    &	 
    &	 -    &		 P    &	
 s    &	 �    &	 �    &	 �    &	 �    7   7  7  7  7  7  7  7  7  7  7 	 7 
 7  7  &	 m
    &	 �
    &	 �
    &	 �
    &	 �
    &	     &	 ?    &	 b    &	 �    �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $ 	#FFFFFFFF��6@   �� 5   
   $ 	#FF707070��6<   �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��14,0,0,0q�6$    . #��� ��6Q   $��1��6�   $	 1 2R�6�   5      5      5      �� 5    
   $ 	#FFF3F9FF��6C   �� 5!   
   $ 	#FF5593FF��6?   �� 5"   
   $ 	#FF212121��6>   �� 5#   
   $ 	#FFE6E6E6��6B   �� 5$   
   $ 	#FFBCBCBC��6>   �� 5%   
   $ 	#FF707070��6=   �� 5&   
   $ 	#FFD9ECFF��6A   �� 5'   
   $ 	#FF3C77DD��6=   �� 5(   
   $ 	#FF212121��6<   �� 5)   
   $ 	#FF212121��6;   �� 5*   
   " 	�6*   .�5+      ��  �@�FocusVisualStyle8   61   �� 5,       � ��8  6+   �� 5-       � ��8  6,   �� 5.       � ��# � ��6+   �� 5/       � ��$ 1q�60   �� 50       � �� 51      �� 52      " 	�6&   .R�53      � $	 templateRoot��6   
������  . 
 54      �� 55   "   $
��Auto �63   �� 56   "   $��* �63   .+�58      �� $ radioButtonBorder��6%   #��z��6@   #��z��6l   #��z��6�   $	 100��6�   #��z��6�   $��0,6,0,0q�6   #��z��61  ._�59   "   � $	 markGrid��6'   $��2q�69   .+�5:   &   A� $ 
optionMark��6.   8�� $��30��6s   $��30��6�   $ 0Q�6�   5;   #   5<      �� 5=      $ contentPresenter��6/   $��1��6I   |�.  #��z��6k   #��z��6�   ��. # z 6�   #��z��6(  5>       5?      P� 5@       � �� . . �5A   "   �� 8   �@�FocusVisualStyle6E   �� 5B   "    � ��$ 4,-1,0,0q�6<   5C      P� 5D       �@J�IsMouseOver . . �5E   "   �� $ radioButtonBorder��6?   8   � ��6^   �� 5F   "   $ radioButtonBorder��6@   8   � ��6_   �� 5G   "   $ 
optionMark��69   8   � ��6Q   5H      P� 5I       � {� .  . �5J   "   �� $ radioButtonBorder��6?   8   � ��6^   �� 5K   "   $ radioButtonBorder��6@   8 	  � ��6_   �� 5L   "   $ 
optionMark��69   8 
  � ��6Q   5M      P� 5N       � �� . . �5O   "   �� $ radioButtonBorder��6?   8   � ��6^   �� 5P   "   $ radioButtonBorder��6@   8   � ��6_   �� 5Q   "   $ 
optionMark��69   8   � ��6Q   5R      P� 5S       �@d�	IsChecked$
 trueY�6;   . �5T   "   �� $ 
optionMark��6<    �@J�Opacity$ 1Q�6T   5U      P� 5V       6;   Z�  �@d�	IsChecked. �5W   "   �� $ 
optionMark��6<    �@J�Opacity$
 0.56Q�6T   5X      5Z      5\      5]      �� 5^   
   $ 	#FFDDDDDD��6;   �� 5_   
   $ 	#FF707070��67   �� 5`   
   $ 	#FFBEE6FD��6>   �� 5a   
   $ 	#FF3C7FB1��6:   �� 5b   
   $ 	#FFC4E5F6��6<   �� 5c   
   $ 	#FF2C628B��68   �� 5d   
   $ 	#FFF4F4F4��6=   �� 5e   
   $ 	#FFADB2B5��69   �� 5f   
   $ 	#FF838383��6=   5h      .��5j      � 
�������.+�5n   
   �� $��61��6   $F��@Выберите способ оформления заказа:��6   $��657,36,28,353q�6I   $��34(�6`   �� 5o   
   $��657,102,28,42q�6   .+�5p      	� -   5        $��34(�5p      $(��"Сообщение на почту��6)    	� 	GroupName$ BorderBrush��6F   
 � Tag$ Email��6^   #���  6�   	� 5q      -   5        $��34(�5q      $&�� Звонок на телефон��6(   $ BorderBrush��6D   $ Phone��6\   #���  6�   �� 5r      -   5         ��Name$ Change��5r      $��62��6(   $��34(�64   6D   �� 5s      -   5         ��Name$
 box1��5s   "   $��62��6   $��34(�60   6@   �� 5t      -   5         ��Name$ Confirm��5t      $��Подтвердить��6&   $��34(�6<   $��60��6J   
�������
�������$��101,0,113,0q�6�   5u      �� 5v   
   -   5        $ Zakaz��5v      $��127,363,812,26q�6!   
����������	#FFD37E7E$!��Оформить Заказ��6c   $��34(�6|    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5w      V� 5x      .~�5y      �� �� 5z      �� 5{       �� Angle$ -2Q�6&   T� 5|      5}      5      ,� 5�   
   $��10,10,705,92q�6#   .��5�      /� .T�5�      J� .*�6   .*�5�      �� -   5         ��Name$ MyPanel��5�   "   $
��Auto��63   $	��638��6A   5�      5�      5�      5�      5�      5�      