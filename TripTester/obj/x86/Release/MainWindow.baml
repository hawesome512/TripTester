   M S B A M L   `   `   `  ���� E  ATripTester, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TripTester
TripTester      TripTester.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     *localclr-namespace:TripTester     -     � Title$  
TripTester��$	��700��$
��1000��
������� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�$��18(� � 
ResizeMode$ NoResize=�$��Microsoft JhengHei)� � 	Resources  �� Source�� $ DictionaryCommon.xaml?�%    .���  � RowDefinitions �� $��35 ��� $��40 ��� $��1* ��� $��60 �.+�� $��1�����#2A7187.+���  �� Orientation$ 
Horizontal=�$��Center=�.+�	� -   $��rb_trip��.��Trip	� -   $��rb_test��.��Test�� ���#888888$��3q�$��4��� $��0������  �� ImageSource$, &/TripTester;component/Images/title.png��.+��� $��Shihlin ACB TripTester��
�������$��35��$��Center=�$��Center=�$��18(�$
��Bold"��� -   	 ��Name$	 Title��$ 
Horizontal=�$��RightToLeft=�$	��7,4q�.+�   TripTester.ImageButton  -   
  Name$
 	btn_close��   TripTester.ImageButton   Click$ btn_close_Click_1��$��26��$��26��$	��Top=�   ImgPath$ /Images/关闭.png��   ImageButtonTemplate#��[    -   $
 btn_size��$ btn_size_Click_1��$��26��$��26��$	��Top=�$ /Images/最大化.png��#���     -   $
 btn_min��$ btn_min_Click_1��$��26��$��26��$	��Top=�$ /Images/最小化.png��#��[  &   System.Windows.Controls.DataGrid  -   $��dataGridDisplay��   AutoGenerateColumns .  $��2��$	��3,0q�
������    
IsReadOnly . 
������    CanUserAddRows .    SelectionUnit$ FullRow=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 No.��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� RelativeSource ��  �� AncestorType$ DataGridRowL� �� 	Converter $   TripTester.RowToIndexConverter    $ Result�� �� *	Results+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�     Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* $ Model�� �� *
DeviceCode+$ OneWay=�$ PropertyChanged=�  $ 1* $	 ETR�� �� *	BreakType+$ OneWay=�$ PropertyChanged=�  $ 1* $ ID�� �� *ProductNumber+$ OneWay=�$ PropertyChanged=�  $ 1* $ In(A)�� �� *In+$ OneWay=�$ PropertyChanged=�  $ 1* $ Fn(Hz)�� �� *Fn+$ OneWay=�$ PropertyChanged=�  $ 2* $ Update Time�� �� *
SaveTime+$ OneWay=�$ PropertyChanged=�  tConvert# [ 4	  .System.Windows.Controls.DataGridTemplateColumn	  $ 60 $ Delete�� 	  CellTemplate �� .R��� -	   $��Images/delete.png��$��20��$��20��
 � Tag �� *ProductNumber+   RowStyle ��  �� 
TargetType)
  #System.Windows.Controls.DataGridRow" 
 .���  �� Property � �� �� Value
 ����   �� Triggers  �� ! �� Binding! �� *	Results+$ OneWay=�" �� Value" NG.a���  � �� �#FF5656P� # P� Property# �@J�IsMouseOver$ P� Value$ . . ���  � �� �#2A7187��  � ��
 ������� -
   $��label1��$��Center=�$��Bottom=�$��3�����	#FF4B4A4A$
��Bold"����� " ��.���  � ��$' !Copyright ©2018 Shihlin Electirc��  �� ! �� *IsMouseOver+% �� ElementName$% 
btn_import��" True.a���  � ��$$ Import records from ACB-TESTER���� ! �� *IsMouseOver+$% 	btn_excel��" True.a���  � ��$ Save as excel��  -   $
 
btn_import��$ btn_import_Click_1��$��3��$��5q�$
��Left=�$��48��$��48��$ /Images/bluetooth.png��#��[    -   $
 	btn_excel��$ btn_excel_Click_1��$��3��$��5q�$��Right=�$��48��$��48��$ /Images/excel.png��#��[     TripTester.TestDetail  -   &  Name$& 
testDetail��$��1��$��3��$y�Hidden=�   TripTester.TripDetail  -   '  Name$' 
tripDetail��$��1��$��3��$y�Hidden=�   TripTester.ComPage  -   (  Name$( comPage��$��1��$��3��$y�Hidden=�