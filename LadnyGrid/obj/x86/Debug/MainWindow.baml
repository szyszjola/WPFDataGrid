   M S B A M L   `   `   `  ����D  @LadnyGrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LadnyGrid	LadnyGrid  5   	   N JMenulab.RichTextBox, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null>2clr-namespace:Menulab;assembly=Menulab.RichTextBoxMenulab 5   	       LadnyGrid.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:LadnyGrid     5   	   Aml2clr-namespace:Menulab;assembly=Menulab.RichTextBox     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ 
MainWindow��5
   	   $	��550��6   $	��850��6)    � 	Resources 5       �� 
TargetType   Personalizacja ��Name �� Padding �� CornerRadius ��Name �� Padding	 �� Triggers
 P� Property P� Value �� 
TargetName �� Property �� Value �� 
TargetType  DatePickerTextBoxStyle:  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name �� Path �� StringFormat �� RelativeSource �� AncestorType(  "System.Windows.Controls.DatePicker��%n  &	        &	 �    '  J    7  �� 5   
   " ��6   .R�5      �� $ Bordeo��6   ���	#FFE4A070$��2,2,2,0q�6=   $ 6q�6W   $��0,0,3,0q�6c   $ 7,7,0,0��6t   ._�5      �� $ TabItemHeaderText��6   $��SemiBold"�68   $��20(�6N   $��
Sitka Text)�6\   $ 2q�6t   �� 5      $��Header��6(   5      5      	 5      P� 5      
 �@J�IsMouseOver . . �5      �� $ TabItemHeaderText��6E    � �� �	#FFBFAF4C�� 5      $ Bordeo��6F    � �� �	#FFEA6B225      P� 5      
 �@��
IsSelected . . �5      �� $ TabItemHeaderText��6E    � �� �	#FF4192B0�� 5      $ Bordeo��6H    � ��$ 4,4,4,0q�68   6H   5      5      �� 5   
   " ��6   .�5      ��  � ��$ 0q�60   �� 5        � ��$ Center=�62   �� 5!       � �� 6+   Z� 5"      �� 5#   
   "  6   .�5$      ��  � �� 5%      �� 5&      .R�5'      �� $ DatePickerTextBoxy��6"   
����  �$��2,2,2,0q�6U   8��  ��5(   !   �� $ SelectedDate�$ 
yyyy-MM-dd�� �� "  6�   5)      5+      5,      5-      ��5.      
� 5/   
   .��50      �  � Color$ 	#FFF7F7F7��6    � Offset$
 0.02Q�6-   � 51      $ 	#FFF9BE82��6   $ 0.996Q�6-   52      .��5<      � $��
0,4,-8,-53q�6   $	��850��6   $	��550��6+   .+�5=   
   �� -   5        $��	0,0,10,79q�5=      .@�5>      �� $��Tabela osób��6   #��[  6,   .��5?         LadnyGrid.Tabela_Osob  5@      �� 5A      $��	Kalendarz��6   #��[  6)   .��5B      � $��
0,-2,-3,-1q�6   .+�5C      &   System.Windows.Controls.Calendar  -   5          Name$ Kalendarzyk��5C   j      SelectionMode$ 
SingleDate=�6O   $��10,36,607,194q�6   5D        5E      -   5          Name$ DatePickerStart��5E   !   $��50,324,665,67q�6;      Text 6R   ��  �� Source# [ $ 
yyyy-MM-dd��  5F      -   5        $ DatePickerEnd��5F   !   $��50,361,665,30q�68   �� 5G      -   5         ��Name$ ButtonPokazDaty��5G      $��Pokaz��66   $��192,334,589,54q�6F   6^   &   System.Windows.Controls.DataGrid  5I      -   5          Name$ 	DatyGrida��5I   x      FrozenColumnCount$ 1��6      CanUserAddRows .      CanUserDeleteRows  .  !   
IsReadOnly! . $��253,10,10,15q�6�   "   AutoGenerateColumns" .  #   Columns# 5J      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn$   Header$
$ Data��61   1  +System.Windows.Controls.DataGridBoundColumn%   Binding% 6?   �� $
 Data�$ 
dd.MM.yyyy��  5M      $
$ Opis��61   % 6?   �� $
 Opis�5O      �� 5P      -   5        $ ButtonRezerwuj��5P      $��Zarezerwuj date��65   $��50,265,678,121q�6O   6g   5Q      5R      �� 5S      $��A tu coś ekstra��6   #��[  60   .��5T      � .+�5U      �� -   5        $��RichBox��5U   #   $
��Left=�62   $	��379��6M   $��
164,31,0,0q�6Z   $	��Top=�6n   $	��660��6�   & �� 
LineHeight$& 6��6�   . �5V      /� .T�5W      J� .*�6(   .*�5X   "   �� -	   5        ' ��Name$' ContentRichBoxa��5X   &   5Y      5Z      5[      �� 5\      -
   5        $ Otworz��5\      $��Otwórz��6-   $
��Left=�6>   $��	43,66,0,0q�6Y   $	��Top=�6l   $��75��6�   6�   �� 5]      -   5        $ Zapisz��5]      $��Zapisz��6-   $
��Left=�6>   $��
43,115,0,0q�6Y   $	��Top=�6m   $��75��6�   6�   �� 5^      
�������$
��Left=�6,   $��15��6G   $��
164,16,0,0q�6S   
���   �$	��Top=�6v   $	��660��6�   5_      5`      �� 5a      -   5        ( ��Name$( TestTabItem��5a      $!��Stwórz nowego użytkownika��6+   #��[  6N   .��5b      � -   5        ) �Name$) Rodzic��5b      5c      5d      �� 5e   
   $��0,471,24,50q�6   .@�5f      �� $	��849��6   .��5g      �� -   5        * ��Name$* 	CzasLabel��5g      
���   �$	��1,0q�6>   $��23��6K   $	��193��6W   + �� ContentStringFormat$+ HH:MM:ss dd/MM/yyyy��6c   5h      5i      5j      5k      