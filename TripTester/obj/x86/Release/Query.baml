   M S B A M L   `   `   `  ���� E  ATripTester, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TripTester
TripTester      TripTester.Query   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     *localclr-namespace:TripTester       � Title$  Query��$	��600��$	��900�� � 	Resources  �� Source�� $ DictionaryCommon.xaml?�%    .���  � ColumnDefinitions �� $	��240 ��� $
��600* � � RowDefinitions �� $��40 ��� $	��500 ��� $	��10* �.+��� -   $��groupBoxQuery��$��18(�$��Query��$	��480��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��208��$��1��.��� .+��� -   $��stackPanel2��$��29��$
��Left=�$��	5,335,0,0q� �� Orientation$ 
Horizontal=�$	��Top=�$	��185��.+�(  "System.Windows.Controls.DatePicker  -   $��datePickerStart��   DisplayDate$ 2013-3-13 00:00:00��$��16(�$��25��   SelectedDateFormat$
 Long=�$	��120���� $
��--->���� -   $��stackPanel5��$��29��$��Right=�$��	0,375,5,0q�$ 
Horizontal=�$	��Top=�$	��120��.+�  -   $��datePickerEnd��$ 2013-3-13 00:00:00��$��16(�$��25��$	��120��$
 Long=��� -   $��	listBoxId��$	��160��$
��Left=�$��5,5,0,0q� �� SelectionMode$ Multiple=�$	��Top=�$	��185��.@��� $��1���� -   $��listBoxItems��$	��160��$
��Left=�$��	5,170,0,0q�$	��Top=�$	��185��$ Multiple=�.@��� .��1�� -   $��
buttonSave��$
��Save��$��30��$
��Left=�$��
15,410,0,0q�$	��Top=�$��75���� -	   $��buttonQuery��$
��Load��$��30��$
��Left=�$��105,410,0,0q�$	��Top=�$��75��&   System.Windows.Controls.DataGrid  -
   $��dataGridQuery��	   AutoGenerateColumns	 .  $��1��$��1��$	��480��$
��Left=�$��	15,10,0,0q�$	��Top=�$	��600��
   CanUserAddRows
 .     
IsReadOnly . $��16(�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ProductNumber+  $
 Item�� �� *Item+  $ Result�� �� *Result+   rConvert �� 	Converter# [    $
 Time�� �� *Time+  tConvert# [   $
 Type�� �� *Type+  $ Ir�� �� *Ir+  $ Tr�� �� *Tr+  $ I�� �� *I+  $ T�� �� *T+   RowStyle ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"  .���  �� Property � �� �� Value
 ����� �� Triggers ��  �� Binding �� *Result+ �� Mode$ OneWay=� �� Value 78.a���  � ��
 ����P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 ��·���  � ��
 �   �