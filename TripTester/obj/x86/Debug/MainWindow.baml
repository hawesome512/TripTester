   M S B A M L   `   `   `  ����E  ATripTester, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TripTester
TripTester  5   	       TripTester.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *localclr-namespace:TripTester     5   	   -   5          � Title$  
TripTester��5   	   $	��700��6   $
��1000��6)   
������� � WindowStartupLocation$ CenterScreen=�6M    � WindowStyle$
 None=�6r   $��18(�6�    � 
ResizeMode$ NoResize=�6�   $��Microsoft JhengHei)�6�    � 	Resources 5       �� Source�� 5   
   $ DictionaryCommon.xaml?�6   %    6>   .��5
      �  � RowDefinitions 5   
   �� 5      $��35 �6   6*   �� 5      $��40 �6   6*   �� 5      $��1* �6   6*   �� 5      $��60 �6   .+�5   
   � $��1��6   ���#2A7187.+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      	� -   5        $��rb_trip��5      .��6D   Trip6J   	� 5      -   5        $��rb_test��5      .��6D   Test6J   5      5      �� 5   
   ���#888888$��3q�6'   $��4��6;   6N   � 5   
   $��0��6   ��5      �� 5       �� ImageSource$, &/TripTester;component/Images/title.png��6   .+�5      �� $��Shihlin ACB TripTester��6   
�������$��35��6H   $��Center=�6T   $��Center=�6v   $��18(�6�   $
��Bold"�6�   �� 5      -   5        	 ��Name$	 Title��5      $ 
Horizontal=�6(   $��RightToLeft=�6A   $	��7,4q�6]   .+�5         TripTester.ImageButton  -   5        
  Name$
 	btn_close��5   $      TripTester.ImageButton   Click$ btn_close_Click_1��6�   $��26��67   $��26��6B   $	��Top=�6N      ImgPath$ /Images/关闭.png��6g      ImageButtonTemplate#��[  6�   6�     5      -   5        $
 btn_size��5   $   $ btn_size_Click_1��6�   $��26��66   $��26��6A   $	��Top=�6M   $ /Images/最大化.png��6f   #���   6�   6�     5       -   5        $
 btn_min��5    $   $ btn_min_Click_1��6�   $��26��65   $��26��6@   $	��Top=�6L   $ /Images/最小化.png��6e   #��[  6   6�   5!      5"      &   System.Windows.Controls.DataGrid  5#   
   -   5        $��dataGridDisplay��5#   J      AutoGenerateColumns .  $��2��6/   $	��3,0q�6=   
������    
IsReadOnly . 
������    CanUserAddRows .    SelectionUnit$ FullRow=�5$   �   ��6w   ��    Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$	 No.��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   ��  �� RelativeSource ��  �� AncestorType$ DataGridRowL� �� 	Converter $   TripTester.RowToIndexConverter    5'      $ Result��6%    65   �� *	Results+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�     5(         Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6%   $ Model��60    6?   �� *
DeviceCode+$ OneWay=�$ PropertyChanged=�6�     5)      $ 1* 6%   $	 ETR��60    6=   �� *	BreakType+$ OneWay=�$ PropertyChanged=�6�     5*      $ 1* 6%   $ ID��60    6<   �� *ProductNumber+$ OneWay=�$ PropertyChanged=�6�     5,      $ 1* 6%   $ In(A)��60    6?   �� *In+$ OneWay=�$ PropertyChanged=�6�     5-      $ 1* 6%   $ Fn(Hz)��60    6@   �� *Fn+$ OneWay=�$ PropertyChanged=�6�     50      $ 2* 6%   $ Update Time��60    6E   �� *
SaveTime+$ OneWay=�$ PropertyChanged=�  tConvert# [ 6�   4	  .System.Windows.Controls.DataGridTemplateColumn	  52      $ 60 6)   $ Delete��64    	  CellTemplate 53      �� 54      .R�55      �� -	   5        $��Images/delete.png��55   %   $��20��6@   $��20��6K   
 � Tag 6W   �� *ProductNumber+6u   56      58         RowStyle 5:      �� 5;       �� 
TargetType)
  #System.Windows.Controls.DataGridRow" 
 6   .�5<      ��  �� Property � �� �� Value
 ���� 63     �� Triggers  5=      �� 5>      ! �� Binding! 6&   �� *	Results+$ OneWay=�" �� Value" NG6N   .a�5?      ��  � �� �#FF56566;   5@      P� 5A      # P� Property# �@J�IsMouseOver$ P� Value$ . . �5C      ��  � �� �#2A71876;   �� 5D       � ��
 �����6;   5E      5G      5I      �� 5J   
   -
   5        $��label1��5J   e   $��Center=�6   $��Bottom=�65   $��3��6W   ���	#FF4B4A4A$
��Bold"�6�   ��5K      �� 5L      " ��6   .�5M      ��  � ��$' !Copyright ©2018 Shihlin Electirc��60     5N      �� 5O      ! 6&   �� *IsMouseOver+% �� ElementName$% 
btn_import��" True6]   .a�5P      ��  � ��$$ Import records from ACB-TESTER��68   5Q      �� 5R      ! 6&   �� *IsMouseOver+$% 	btn_excel��" True6\   .a�5S      ��  � ��$ Save as excel��68   5T      5V      5X        5Y   
   -   5        $
 
btn_import��5Y   O   $ btn_import_Click_1��6�   $��3��6   $��5q�6)   $
��Left=�64   $��48��6c   $��48��6n   $ /Images/bluetooth.png��6z   #��[  6�   6�     5Z   
   -   5        $
 	btn_excel��5Z   P   $ btn_excel_Click_1��6�   $��3��6   $��5q�6)   $��Right=�64   $��48��6c   $��48��6n   $ /Images/excel.png��6z   #��[  6�   6�      TripTester.TestDetail  5[   
   -   5        &  Name$& 
testDetail��5[   M   $��1��6   $��3��6(   $y�Hidden=�69   6M      TripTester.TripDetail  5\   
   -   5        '  Name$' 
tripDetail��5\   M   $��1��6   $��3��6(   $y�Hidden=�69   6M      TripTester.ComPage  5]   
   -   5        (  Name$( comPage��5]   J   $��1��6   $��3��6%   $y�Hidden=�66   6J   5^      5_      