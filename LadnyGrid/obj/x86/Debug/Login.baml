   M S B A M L   `   `   `  ����D  @LadnyGrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LadnyGrid	LadnyGrid  5   	   H DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	       LadnyGrid.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:LadnyGrid     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5          �Name$  login��5   	    � WindowStyle$ 
ToolWindow=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Login��5   	   $	��300��6   $	��300��6$   ��5      
� 5   
   .��5      �  � Color$ 	#FFF7F4EE��6   � 5      $ 	#FFD6D056��6    � Offset$ 0.919Q�6-   � 5      $ 	#FFEDFF9E��6   $ 0.142Q�6-   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��57* �6   �� 5      $
��235* �6   .+�5   
   )  #MahApps.Metro.Controls.ProgressRing  -   5          Name$ 	FirstRing��5          IsActive .  $��Center=�6D   $��Center=�6h   ���	#FF82C78B$��26��6�   $��128,204,58,28q�6�   $��26��6�   $��38��6�   $��49��6�   $��1��6�   G� 5   
   -   5        	 G�Name$	 	HasloText��5   �   $��Center=�6^   
 G� PasswordChar$
 *��6�   $
��Left=�6�   $��23��6�   $��26.466,138,0,0q�6�   $	��Top=�6  $	��120��6  $��1��6(  �� 5   
   -   5         ��Name$ 	LoginText��5   +   $
��Left=�5   }   $��23��6�   $��26.466,94,0,0q�5      $	��Top=�6>   $	��120��6V   $��1��6b    �� DisplayMemberPath$ Login��6r    �� IsTextSearchEnabled .  �� StaysOpenOnEdit .  �� 
IsEditable . ��5      �� *Login+5       �� 5!   
   -   5         ��Name$ kk��5!      $��Button��6   $
��Left=�6.   $��48.466,215,0,0q�6I   $	��Top=�6a   $��75��6y   $��1��6�   �� 5"   
   -   5         ��Name$ InvalidPassword��5"      $y�Hidden=�6)   $��invalid.png��6=    J� RenderTransformOrigin$ 6.976,0.862&�6R   $��151,140,55,106q�6v   $��1��6�   �� 5#   
   $��	Logowanie��6   $��Center=�6%   $��1��6I   $
��Left=�6Y   $��	19,40,0,0q�6t   $	��Top=�6�   $��28��6�   $	��134��6�   $��Showcard Gothic)�6�   $��14(�6�   �� 5$   
   -   5         ��Name$ 
HasloLabel��5$       J� Opacity$	 0.5Q�6%   $��	Hasło...��63   $��1��6F   $
��Left=�6V   $��
26,138,0,0q�6q   $	��Top=�6�   �� 5%   
   -   5        $ keyinfo��5%      $��48,140,214,106q�6!   $��if_key_info_66816.png��69   $
��Fill=�6X   $��2��6g    � ToolTip 5&      �� 5'      .+�5(      �� 
������.��64   Haslo6;   �� 5)      $��Italic$�6   .��6/   *(Wpisz poprawne hasło by się zalogować6V   5*      5,      5-      5.      