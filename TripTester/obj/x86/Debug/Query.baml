   M S B A M L   `   `   `  ����E  ATripTester, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TripTester
TripTester  5   	       TripTester.Query   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *localclr-namespace:TripTester     5   	     � Title$  Query��5   	   $	��600��6   $	��900��6$    � 	Resources 5       �� Source�� 5   
   $ DictionaryCommon.xaml?�6   %    6>   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��240 �6   �� 5      $
��600* �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $	��500 �6   �� 5      $	��10* �6   .+�5   
   �� -   5        $��groupBoxQuery��5   k   $��18(�6   $��Query��6!   $	��480��60   $
��Left=�6=   $��	10,10,0,0q�6X   $	��Top=�6�   $	��208��6�   $��1��6�   .��5      � .+�5      �� -   5        $��stackPanel2��5   W   $��29��6   $
��Left=�6)   $��	5,335,0,0q�6D    �� Orientation$ 
Horizontal=�6j   $	��Top=�6�   $	��185��6�   .+�5      (  "System.Windows.Controls.DatePicker  -   5        $��datePickerStart��5   \      DisplayDate$ 2013-3-13 00:00:00��6!   $��16(�6B   $��25��6P      SelectedDateFormat$
 Long=�6s   $	��120��6�   �� 5      $
��--->��6   5      �� 5      -   5        $��stackPanel5��5   X   $��29��6   $��Right=�6)   $��	0,375,5,0q�6E   $ 
Horizontal=�6k   $	��Top=�6�   $	��120��6�   .+�5        -   5        $��datePickerEnd��5   \   $ 2013-3-13 00:00:00��6!   $��16(�6B   $��25��6P   $	��120��6q   $
 Long=�6}   5      �� 5      -   5        $��	listBoxId��5   S   $	��160��6   $
��Left=�6'   $��5,5,0,0q�6B    �� SelectionMode$ Multiple=�6d   $	��Top=�6}   $	��185��6�   .@�5      �� $��1��6"   5      �� 5       -   5        $��listBoxItems��5    U   $	��160��6   $
��Left=�6'   $��	5,170,0,0q�6B   $	��Top=�6i   $	��185��6�   $ Multiple=�6�   .@�5!      �� .��6"   16%   5"      �� 5#      -   5        $��
buttonSave��5#   c   $
��Save��6   $��30��6(   $
��Left=�64   $��
15,410,0,0q�6O   $	��Top=�6u   $��75��6�   6�   �� 5$      -	   5        $��buttonQuery��5$   ~   $
��Load��63   $��30��6B   $
��Left=�6N   $��105,410,0,0q�6i   $	��Top=�6�   $��75��6�   5%      5&      &   System.Windows.Controls.DataGrid  5'   
   -
   5        $��dataGridQuery��5'   �   	   AutoGenerateColumns	 .  $��1��6/   $��1��6?   $	��480��6L   $
��Left=�6Y   $��	15,10,0,0q�6t   $	��Top=�6�   $	��600��6�   
   CanUserAddRows
 .     
IsReadOnly . $��16(�5(   <      Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ProductNumber+6U     5+      $
 Item��6%    63   �� *Item+6O     5,      $ Result��6%    65   �� *Result+   rConvert �� 	Converter# [  6w     5-      $
 Time��6%    63   �� *Time+  tConvert# [ 6s     5.      $
 Type��6%    63   �� *Type+6N     5/      $ Ir��6%    61   �� *Ir+6J     50      $ Tr��6%    61   �� *Tr+6K     51      $ I��6%    60   �� *I+6H     52      $ T��6%    60   �� *T+6H      RowStyle 54      �� 55       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�56      ��  �� Property � �� �� Value
 �����63    �� Triggers 57      �� 58       �� Binding 6&   �� *Result+ �� Mode$ OneWay=� �� Value 786M   .a�59      ��  � ��
 ����6;   5:      P� 5;       P� Property �@J�IsMouseOver P� Value . . �5=      ��  � ��
 ��·�6;   �� 5>       � ��
 �   �6;   5?      5A      5C      5D      5E      