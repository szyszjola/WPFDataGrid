   M S B A M L   `   `   `  ����D  @LadnyGrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LadnyGrid	LadnyGrid  5   	        LadnyGrid.DodajOsobeWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:LadnyGrid     5   	     � Title$"  Dodaj nową osobę do tabeli��5   	   $	��350��6,   $	��300��69   ��5	      
� 5
   
   .��5      �  � Color$ 	#FFFCF5FF��6    � Offset$ 0.996Q�6-   � 5      $ 	#FFEDECFB��6   $ 0.004Q�6-   5      .��5      � .+�5   
   �� -   5         ��Name$ ImieText��5   4   $��Center=�6   $
��Left=�6F   $��30��6a   $��
119,40,0,0q�6m    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��123��6�   �� 5   
   $��DemiBold"�6   $��Center=�6)   $��Imie:��6K   $
��Left=�6[   $��	19,40,0,0q�6v   $	��Top=�6�   $��30��6�   $��95��6�   �� 5   
   -   5        $ NazwiskoText��5   4   $��Center=�6   $
��Left=�6J   $��30��6e   $��
119,75,0,0q�6q   $
 Wrap=�6�   $	��Top=�6�   $	��123��6�   �� 5   
   $��DemiBold"�6   $��Center=�6'   $��	Nazwisko:��6I   $
��Left=�6]   $��	19,75,0,0q�6x   $	��Top=�6�   $��30��6�   $��95��6�   �� 5   
   -   5         ��Name$ WiekComboBox��5      $
��Left=�6*   $��119,110,0,0q�6E   $	��Top=�6Z   $	��123��6r   $��30��6~   �� 5   
   $��DemiBold"�6   $��Center=�6'   $��Wiek:��6I   $
��Left=�6Y   $��
19,110,0,0q�6t   $	��Top=�6�   $��30��6�   $��95��6�   �� 5   
   -   5         ��Name$ wZwiazkuCheckBox��5      $
��Left=�6.   $��119,180,0,0q�6I   $	��Top=�6^   $��30��6v   $��51��6�   �� 5   
   -   5        $ 	EmailText��5   4   $��Center=�6   $
��Left=�6G   $��30��6b   $��119,145,0,0q�6n   $
 Wrap=�6�   $	��Top=�6�   $	��123��6�   �� 5   
   $��DemiBold"�6   $��Center=�6)   $��Email:��6K   $
��Left=�6\   $��
19,145,0,0q�6w   $	��Top=�6�   $��30��6�   $��95��6�   �� 5   
   $��DemiBold"�6   $��Center=�6)   $��W związku:��6K   $
��Left=�6`   $��
19,180,0,0q�6{   $	��Top=�6�   $��30��6�   $��95��6�   �� 5   
   $��DemiBold"�6   $��Center=�6)   $��Płeć:��6K   $
��Left=�6[   $��
19,215,0,0q�6v   $	��Top=�6�   $��30��6�   $��95��6�   	� 5   
   -   5         	�Name$ KobietaRadioButton��5       d� 	IsChecked$
 TrueY�62   $��Kobieta��6C   $
��Left=�6U   $��
19,250,0,0q�6p   $	��Top=�6�   	� 5   
   -   5        $ MezycznaRadioButton��5      $��Mężczyzna��63   $
��Left=�6G   $��
19,273,0,0q�6b   $	��Top=�6v   �� 5   
   -   5        	 ��Name$	 DodajButton��5      $��Dodaj ��6&   $
��Left=�67   $��150,241,0,0q�6R   $	��Top=�6g   $��92��6   $��38��6�   6�   5      5       