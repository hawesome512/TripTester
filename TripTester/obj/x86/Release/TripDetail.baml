   M S B A M L   `   `   `  ���� E  ATripTester, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TripTester
TripTester      TripTester.TripDetail   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     *localclr-namespace:TripTester     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ���	#FF888888
�������$��3q�$	��665��$
��1000��  � 	Resources   �� Source�� $ DictionaryCommon.xaml?�%    .���  � RowDefinitions �� $��50 ��� $��1* �.+�� $��0��.+�   TripTester.ImageButton  -     Name$ btn_back��   TripTester.ImageButton   Click$ button_Close_Click��$��1q�$
��Left=�$	��Top=�$��48��$��48��   ImgPath$ /Images/back.png��   ImageButtonTemplate#��[    -   $ 	btn_print��$ btn_print_Click_1��$��1q�$��Right=�$	��Top=�$��48��$��48��$ /Images/print.png��#��[  � -   $��gridContent��$��2��.+��� $	��450��$��50��$	��Top=�
�������$��0,0,0,3q��� $��50��$	��Top=�$	��450�� �� Orientation$ 
Horizontal=�.+��� $��24(�$��Center=�$��40��.��ID:�� $��24(�$��Center=�$	��140������  �� Path$ ProductNumber��� $��24(�$��Center=�$��40��.��In:�� $��24(�$��Center=�$��70������ $ In��� $��24(�$��Center=�$��50��.��A�� $��24(�$��Center=�$��70��.��Pole:�� $��24(�$��Center=�$��40������ *	BreakType+  pConvert �� 	Converter# [ &   System.Windows.Controls.DataGrid  -   	  Name$	 dataGridDisplay��
   AutoGenerateColumns
 .  
������    
IsReadOnly . 
������    CanUserAddRows .    SelectionUnit$ FullRow=�$��3,50,3,0q�$��1������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 No.��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� RelativeSource ��  �� AncestorType$ DataGridRowL� $   TripTester.RowToIndexConverter       Width5  /System.Windows.Controls.DataGridLengthConverter$ 2.65* $
 Time�� �� *Time+  tConvert# [  �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�  $ Phase�� �� *Phase+$ OneWay=�$ PropertyChanged=�  $
 1.2* $
 Type�� �� *Type+$ OneWay=�$ PropertyChanged=�  $
 1.2* $ Iset(A)�� �� *Iset+$ OneWay=�$ PropertyChanged=�  $
 1.2* $ Tset(s)�� �� *Tset+$ OneWay=�$ PropertyChanged=�  $ 1* $
 I(A)�� �� *I+$ OneWay=�$ PropertyChanged=�  $
 0.8* $
 T(s)�� �� *T+$ OneWay=�$ PropertyChanged=�  $ 1* $ Ia(A)�� �� *Ia+$ OneWay=�$ PropertyChanged=�  $ 1* $ Ib(A)�� �� *Ib+$ OneWay=�$ PropertyChanged=�  $ 1* $ Ic(A)�� �� *Ic+$ OneWay=�$ PropertyChanged=�  $ 1* $ In(A)�� �� *In+$ OneWay=�$ PropertyChanged=�   RowStyle ��  �� 
TargetType)	  #System.Windows.Controls.DataGridRow" 	 .���  �� Property � �� �� Value
 ����  �� Triggers ��  �� Binding �� *	Results+$ OneWay=� �� Value 78.a���  � �� �#FF5656P�  P� Property �@J�IsMouseOver P� Value . . ���  � �� �#2A7187��  � ��
 �����