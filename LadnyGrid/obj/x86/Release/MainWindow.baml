   M S B A M L   `   `   `  ���� D  @LadnyGrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LadnyGrid	LadnyGrid      LadnyGrid.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:LadnyGrid       � WindowStartupLocation$  CenterScreen=� � Title$ 
MainWindow��$	��550��$	��850�� � 	Resources  �� 
TargetType   Personalizacja ��Name �� Padding �� CornerRadius ��Name �� Padding	 �� Triggers
 P� Property P� Value �� 
TargetName �� Property �� Value��%�  &	        �� " ��.R��� $ Bordeo�����	#FFE4A070$��2,2,2,0q�$ 6q�$��0,0,3,0q�$ 7,7,0,0��._��� $ TabItemHeaderText��$��SemiBold"�$��20(�$��
Sitka Text)�$ 2q��� $��Header��	 P� 
 �@J�IsMouseOver . . ��� $ TabItemHeaderText�� � �� �	#FFBFAF4C�� $ Bordeo�� � �� �	#FFEA6B22P� 
 �@��
IsSelected . . ��� $ TabItemHeaderText�� � �� �	#FF4192B0�� $ Bordeo�� � ��$ 4,4,4,0q���
� .���  � Color$ 	#FFF7F7F7�� � Offset$
 0.02Q�� $ 	#FFF9BE82��$ 0.996Q�.��� $��
0,4,-8,-53q�$	��850��$	��550��.+��� $��	0,0,10,79q�.@��� $��Tabela osób��#��[  .��   LadnyGrid.Tabela_Osob  �� $��	Kalendarz��#��[  .��� $��
0,-2,-3,-1q�.+�&   System.Windows.Controls.Calendar  -     Name$ Kalendarzyk��   SelectionMode$ 
SingleDate=�$��10,36,607,194q��� -    ��Name$
 mmbo��$��10,356,644,16q�&   System.Windows.Controls.DataGrid  -     Name$ 	DatyGrida��   FrozenColumnCount$ 1��   CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . $��253,10,10,15q�   AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Data��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$
 Data� �� StringFormat$ 
dd.MM.yyyy��  $
 Opis�� �� $
 Opis��� -    ��Name$ ButtonRezerwuj��$��Zarezerwuj date��$��50,265,678,121q��� $��A tu coś ekstra��#��[  .��� .+��� -   $��RichBox��$
��Left=�$	��379��$��
164,31,0,0q�$	��Top=�$	��660��  �� 
LineHeight$  6��. �/� .T�J� .*�.*��� -   ! ��Name$! ContentRichBoxa���� -   $ Otworz��$��Otwórz��$
��Left=�$��	43,66,0,0q�$	��Top=�$��75���� -   $ Zapisz��$��Zapisz��$
��Left=�$��
43,115,0,0q�$	��Top=�$��75���� 
�������$
��Left=�$��15��$��
164,16,0,0q�
���   �$	��Top=�$	��660���� $��0,471,24,50q�.@��� $	��849��.���� -	   " ��Name$" 	CzasLabel��
���   �$	��1,0q�$��23��$	��193��# �� ContentStringFormat$# HH:MM:ss dd/MM/yyyy��