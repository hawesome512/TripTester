   M S B A M L   `   `   `  ����E  ATripTester, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TripTester
TripTester  5          TripTester.TripDetail   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      *localclr-namespace:TripTester     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ���	#FF888888
�������$��3q�5   N   $	��665��6b   $
��1000��6o     � 	Resources  5       �� Source�� 5
   
   $ DictionaryCommon.xaml?�6   %    6>   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��1* �6   .+�5   
   � $��0��6   .+�5         TripTester.ImageButton  -   5          Name$ btn_back��5   ^      TripTester.ImageButton   Click$ button_Close_Click��6�   $��1q�6    $
��Left=�6+   $	��Top=�6F   $��48��6p   $��48��6{      ImgPath$ /Images/back.png��6�      ImageButtonTemplate#��[  6�   6�     5      -   5        $ 	btn_print��5   _   $ btn_print_Click_1��6�   $��1q�6    $��Right=�6+   $	��Top=�6G   $��48��6r   $��48��6}   $ /Images/print.png��6�   #��[  6�   6�   5      � 5   
   -   5        $��gridContent��5      $��2��6"   .+�5      �� $	��450��6   $��50��6!   $	��Top=�6-   
�������$��0,0,0,3q�6X   �� 5      $��50��6   $	��Top=�6%   $	��450��6=    �� Orientation$ 
Horizontal=�6I   .+�5      �� $��24(�6   $��Center=�6&   $��40��6H   .��6S   ID:6X   �� 5      $��24(�6   $��Center=�6&   $	��140��6A   ��5      �� 5       �� Path$ ProductNumber�6"   69   5      �� 5      $��24(�6   $��Center=�6&   $��40��6H   .��6S   In:6X   �� 5      $��24(�6   $��Center=�6&   $��70��6A   ��5       �� 5!      $ In�6"   6.   5#      �� 5$      $��24(�6   $��Center=�6&   $��50��6H   .��6S   A6V   �� 5%      $��24(�6   $��Center=�6&   $��70��6H   .��6S   Pole:6Z   �� 5&      $��24(�6   $��Center=�6&   $��40��6A   ��6L   �� *	BreakType+  pConvert �� 	Converter# [ 5'      &   System.Windows.Controls.DataGrid  5(      -   5        	  Name$	 dataGridDisplay��5(   3   
   AutoGenerateColumns
 .  
������    
IsReadOnly . 
������    CanUserAddRows .    SelectionUnit$ FullRow=�5)   \   $��3,50,3,0q�6t   $��1��6�   ��6D   ��    Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$	 No.��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   ��  �� RelativeSource ��  �� AncestorType$ DataGridRowL� $   TripTester.RowToIndexConverter    5,         Width5  /System.Windows.Controls.DataGridLengthConverter$ 2.65* 6)   $
 Time��67    6E   �� *Time+  tConvert# [  �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�  5-      $ Phase��6)    68   �� *Phase+$ OneWay=�$ PropertyChanged=�  5.      $
 1.2* 6*   $
 Type��67    6E   �� *Type+$ OneWay=�$ PropertyChanged=�  5/      $
 1.2* 6*   $ Iset(A)��67    6H   �� *Iset+$ OneWay=�$ PropertyChanged=�  50      $
 1.2* 6*   $ Tset(s)��67    6H   �� *Tset+$ OneWay=�$ PropertyChanged=�  51      $ 1* 6*   $
 I(A)��65    6C   �� *I+$ OneWay=�$ PropertyChanged=�  52      $
 0.8* 6*   $
 T(s)��67    6E   �� *T+$ OneWay=�$ PropertyChanged=�  53      $ 1* 6*   $ Ia(A)��65    6D   �� *Ia+$ OneWay=�$ PropertyChanged=�  54      $ 1* 6*   $ Ib(A)��65    6D   �� *Ib+$ OneWay=�$ PropertyChanged=�  55      $ 1* 6*   $ Ic(A)��65    6D   �� *Ic+$ OneWay=�$ PropertyChanged=�  56      $ 1* 6*   $ In(A)��66    6E   �� *In+$ OneWay=�$ PropertyChanged=�   RowStyle 58      �� 59       �� 
TargetType)	  #System.Windows.Controls.DataGridRow" 	 6   .�5:      ��  �� Property � �� �� Value
 ���� 67    �� Triggers 5;      �� 5<       �� Binding 6*   �� *	Results+$ OneWay=� �� Value 786S   .a�5=   "   ��  � �� �#FF56566?   5>      P� 5?       P� Property �@J�IsMouseOver P� Value . . �5A   "   ��  � �� �#2A71876?   �� 5B   "    � ��
 �����6?   5C      5E      5G      5H      5I      5J      