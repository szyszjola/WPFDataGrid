   M S B A M L   `   `   `  ����D  @LadnyGrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LadnyGrid	LadnyGrid  5   	       LadnyGrid.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:LadnyGrid     5   	     � Title$  
MainWindow��5   	   $	��550��6   $	��850��6)    � 	Resources 5	       �� 
TargetType   Personalizacja �� Padding �� CornerRadius ��Name �� Padding �� Triggers P� Property	 P� Value
 �� 
TargetName �� Property �� Value��%*  &	        �� 5
   
   " ��6   .R�5      �� 
�������$��2,2,2,0q�6*   $ 6q�6D   $��0q�6P   $ 7,7,0,0��6[   ._�5      �� $ TabItemHeaderText��6   $��SemiBold"�67   $��20(�6M   $��
Sitka Text)�6[   $ 2q�6s   �� 5      $��Header��6   5      5       5      P� 5       �@J�IsMouseOver	 . . �5      �� $
 TabItemHeaderText��6E    � �� �	#FFBFAF4C5      P� 5       �@��
IsSelected	 . . �5      �� $
 TabItemHeaderText��6E    � �� �	#FF4192B05      5      5      ��5      
� 5   
   .��5      �  � Color$ 	#FFFCF5FF��6    � Offset$ 0.996Q�6-   � 5      $ 	#FFEDECFB��6   $ 0.004Q�6-   5      .��5"      � $��
0,4,-8,-53q�6   $	��850��6   $	��550��6+   .+�5#   
   �� $��	0,0,10,79q�6   .@�5$      �� $��Tabela osób��6   #��[  6,   .��5%         LadnyGrid.Tabela_Osob  $��	0,0,0,-15q�6$   5&      �� 5'      $��	Kalendarz��6   #��[  6)   .��5(      � $��
0,-2,-3,-1q�6   .+�5)      &   System.Windows.Controls.Calendar  -   5          Name$ Kalendarzyk��5)   n      SelectionMode$ 
SingleDate=�6S   $��10,36,607,194q�6�      SelectedDate 6   ��  �� Path$ KolekcjaSelectedDates�5*      �� 5+      -   5         ��Name$
 mmbo��5+       $��10,356,644,16q�6.   &   System.Windows.Controls.DataGrid  5,      -   5          Name$ 	DatyGrida��5,   x      FrozenColumnCount$ 1��6      CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . $��253,10,10,15q�6�      AutoGenerateColumns .     Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� $ ID�  5/      $
 Data��61    6?   �� $
 Data� �� StringFormat$ 
dd.MM.yyyy��  50      $
 Opis��61    6?   �� $
 Opis�52      �� 53      -   5         ��Name$ ButtonRezerwuj��53      $��Zarezerwuj date��65   $��50,265,678,121q�6O     AccentedSquareButtonStyle#��[ 6g   6�   54      55      �� 56      $��A tu coś ekstra��6   #��[  60   .��6[   fff58      59      �� 5:   
   $��0,471,24,50q�6   .@�5;      �� $	��849��6   .��5<      �� -   5         ��Name$ 	CzasLabel��5<      
���   �$	��1,0q�6>   $��23��6K   $	��193��6W     �� ContentStringFormat$  HH:MM:ss dd/MM/yyyy��6c   5=      5>      5?      5@      