   M S B A M L   `   `   `  ���� D  @LadnyGrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LadnyGrid	LadnyGrid      LadnyGrid.Tabela_Osob   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:LadnyGrid       � 	Resources     ButtonTemplateSquare �� 
TargetType �� Property �� Value �� 
TargetType (� Stretch �� CornerRadius ��Name J� Effect3  -System.Windows.Media.Effects.DropShadowEffect	   Opacity
   
BlurRadius   Color �� RelativeSource �� Path J� Opacity � Color � Offset F�Name �� Stretch J� OpacityMask 
� Center 
� GradientOrigin 
� RadiusY 
� RadiusX �� Triggers P� Property P� Value �� ScaleX �� ScaleY N� EnterActions g� Duration	 W� To  �� TargetProperty! �� 
TargetName" N� ExitActions  ButtonTemplate# A�Name��%�	  &	        &	 �    �� " ��.���  � ��$ 60����  � ��$ 40����  � ��$ Segoe UI Black)���  � ��$ 20(���  � �� �� " ��.R�(� $
 Fill=�.���� #��z��#��z��$ 20,20,20,20��._�� $	��100��$	��100��.+��� $ 
Background��#��z��   SHEffect��$	 0Q�$
 20Q� ��  �� *TemplatedParent+$ BorderBrush.Color��� $ CentralBrightening��$	 0.2Q���
� .��� $ Black��$ 1Q�� $ White��F� $ 
GlassLayer��t�����J]@��ӀJ]��)��) Zb@�� Zb��k3 Zb��)@���    �k3�k3@��ӎ�)    �J]�k3�J]@��	$��5,5,5,40.117q�$
 Fill=��� $ 
FlashLayer��#��z��$��3q� 
� $ 
0.511,0.97&�$ 
0.511,0.97&�$ 0.362Q�.��� $ Black��$ 0Q�� $ 1Q��� $ 
FlashWhite��$��3q���
� $ 0.533,0.949&�$ 0.533,0.949&�$ 0.287Q�$ 0.415Q�.��� $ 1Q�� $ White���� $��Center=�$��Center=�#��z�� P�  � �� . . ���  � z� �� $
 0.95Q�$
 0.95Q���  �@J�RenderTransformOrigin$ 0.5,0.5&�P�  �@J�IsMouseOver .  �� .���� .��W� $ 0:0:0.25D�$ 1X�$  Opacity�$! SHEffect��" �� .���� .��W� $ 0:0:0.25D�$ 0X�$  Opacity�$! SHEffect���� " ��.���  � ��$ 60����  � ��$ 50����  � ��$ Segoe UI Black)���  � ��$ 20(���  � �� �� " ��.R�(� $
 Fill=�.��� $	��100��$	��100��.+�A� $# 
Background��#��z��   SHEffect��$	 0Q�$
 20Q� ��  �� *TemplatedParent+$ BorderBrush.Color�A� $# CentralBrightening��$	 0.2Q���
� .��� $ Black��$ 1Q�� $ White��F� $ 
GlassLayer��t�����J]@��ӀJ]��)��) Zb@�� Zb��k3 Zb��)@���    �k3�k3@��ӎ�)    �J]�k3�J]@��	$��5,5,5,40.117q�$
 Fill=���
� $ 	0.5,0.842&�$ 	0.5,0.842&�$ 0.828Q�.��� $ 0Q�$ 	#00FFFFFF��� $ 1Q�$ 	#F2FFFFFF��A� $# 
FlashLayer��#��z��$��3q� 
� $ 
0.511,0.97&�$ 
0.511,0.97&�$ 0.362Q�.��� $ Black��$ 0Q�� $ 1Q�A� $# 
FlashWhite��$��3q���
� $ 0.533,0.949&�$ 0.533,0.949&�$ 0.287Q�$ 0.415Q�.��� $ 1Q�� $ White���� $��Center=�$��Center=�#��z�� P�  � �� . . ���  � z� �� $
 0.95Q�$
 0.95Q���  �@J�RenderTransformOrigin$ 0.5,0.5&�P�  �@J�IsMouseOver .  �� .���� .��W� $ 0:0:0.25D�$ 1X�$  Opacity�$! SHEffect��" �� .���� .��W� $ 0:0:0.25D�$ 0X�$  Opacity�$! SHEffect��.��� $��0,23,-14,36q�$	��850��$	��400��.+�&   System.Windows.Controls.DataGrid  -   $  Name$$ Tabela��%   
IsReadOnly% . $��13(�&   FrozenColumnCount$& 1��$��134,0,44,10q�'   AutoGenerateColumns' .    AzureDataGrid#��[ 
�������(   RowStyle( �� )  #System.Windows.Controls.DataGridRow"  ) �� Triggers) P�  �@ 
IsSelected . . ���  � ��
 �i��P�  �@J�IsMouseOver . . ���  � �� �	#FFDE8240*   Columns* 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn+   Header$+ ID��1  +System.Windows.Controls.DataGridBoundColumn,   Binding, �� $ ID�-   	CellStyle- �� *  $System.Windows.Controls.DataGridCell"  .���  � ��$ 25����  � ��$ 13����  � ��$ Center=���  � ��$ Center=���  � �� �	#FFE48846  .   Width5  /System.Windows.Controls.DataGridLengthConverter$. 90 $
+ Imie��, �� $
 Name�  $	. 110 $+ Nazwisko��, �� $ Surname�  $
+ Wiek��, �� $	 Age�4	  .System.Windows.Controls.DataGridCheckBoxColumn	    MetroDataGridCheckBox/   EditingElementStyle#/ �  0   ElementStyle#0 �  $+ 
W związku��, �� $ Engaged�  $	. 160 $+ Email��, �� $ Email�- �� "  .���  � �� �� .R��� ����  �� 1 �� AncestorType$1 DataGridCellL�$ Content���  � ��
 ��  �) P�  �@ 
IsSelected . . ���  � ��
 �i��4
  .System.Windows.Controls.DataGridComboBoxColumn
  $. 55 -   KolumnaPlec��$+ Płeć��2 
  SelectedItemBinding2 �� $	 Sex��� -   3 ��Name$3 ButtonDodaj�����	#FFEA6B22���	#FFDCA511$��Dodaj��#��[ $��21,10,749,182q�4 ^� InitialShowDelay$
4 1000��5 ^� ShowDuration$
5 4000��6 ^� 	Placement$6 
MousePoint=�7 ^� HorizontalOffset$7 10��8 ^� VerticalOffset$8 10��
���   �9 � ToolTip9 �� .+��� $��Medium"�
�������.��(&Kliknij by dodać nową osobę do bazy�� �� $��Italic$�75Pamiętaj, że żadne pole nie może pozostać puste!�� -   $3 
ButtonUsun�����	#FFEA6B22���	#FFDCA511$��Usuń��#��[ $��21,74,749,118q�9 �� .+��� $��Medium"�
�������.��#!Kliknij by usunąć osobę z bazy�� �� $��Italic$�[YPrzy przytrzymaniu przycisku ALT lub SHIFT możesz usunąć wiele rekordów jednocześnie�� -   $3 ButtonEdytuj�����	#FFEA6B22���	#FFDCA511$��Edytuj��#��[ $��21,140,749,52q�9 �� .+��� $��Medium"�
�������.��Kliknij by edytować osobę�� �� $��Italic$�JHMożesz również edytować dany rekord klikając na wybranym podwójnie�� -   $3 CofnijButton��$
��Left=�$��406,313,0,0q�$	��Top=�$��30��$��32��  MetroCircleButtonStyle#���  ���� : �� ImageSource$: lewo.png��9 �� .+��� $��Medium"�
�������.��Cofnij�� �� $��Italic$�Kliknij by cofnąć strone�� -   $3 ButtonPrzod��$��30��#���  $
��Left=�$��515,313,0,0q�$	��Top=�$��31������ $: 	prawo.png��9 �� .+��� $��Medium"�
�������.��
Przeskok�� �� $��Italic$�)'Kliknij by przeskoczyć o jedną strone�� -   ; ��Name$; StronaTextBlock��$
��Left=�$
��Left=�$��443,313,0,0q�$	��Top=�$��25��$��26���� -	   < ��Name$< Wyszukaj��$
��Left=�$��195,313,0,0q�= �� TextWrapping$
= Wrap=�$	��Top=�$��25��$	��113��> J� RenderTransformOrigin$> 0.612,1.303&�.��9 �� .+��� $��Medium"�
�������.��Wyszukiwanie�� �� $��Italic$�53Wpisz imie bądź nazwisko by wyszukać dany rekord.���� -
   $; maxStronaLabel��$
��Left=�$��479,313,0,0q�$	��Top=�$
��Left=�$��25��$��25���� $��/��$
��Left=�$
��Left=�$��469,313,0,0q�$	��Top=�$��25��$��19���� -   $3 ButtonDwaPrzod��$��30��#���  $
��Left=�$��551,313,0,0q�$	��Top=�$��31��$> 2,0.56&����� $: dwaprawo.png��9 �� .+��� $��Medium"�
�������.��
Przeskok�� �� $��Italic$�$"Kliknij by przeskoczyć o 10 stron�� -   $3 ButtonDwaLewo��$��31��#���  $
��Left=�$��368,313,0,0q�$	��Top=�$��33��$> 2,0.56&����� $: dwalewo.png��9 �� .+��� $��Medium"�
�������.��Cofnij�� �� $��Italic$� Kliknij by cofnąć o 10 stron�� -   $3 lupka��$��35��$��35��#���  $> 
-11.75,6.7&�$��160,308,655,57q����� $: lupa.png���� -   $3 ButtonExportuj�����	#FFEA6B22���	#FFDCA511$��Eksportuj do pliku��#��[ $��31,284,759,66q�9 �� .+��� $��Medium"�
�������$%��Kliknij by eksportować tabelę���� �� $��Italic$��� $	�...���� -   $3 ButtonZapisz�����	#FFEA6B22���	#FFDCA511$��Zapisz��#��[ $��31,21,759,329q�$
4 1000��$
5 4000��$6 
MousePoint=�$7 10��$8 10��
���   �9 �� .+��� $��Medium"�
�������$,��&Kliknij by dodać nową osobę do bazy���� �� $��Italic$��� $;�5Pamiętaj, że żadne pole nie może pozostać puste!��