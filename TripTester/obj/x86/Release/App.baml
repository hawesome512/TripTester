   M S B A M L   `   `   `  ���� E  ATripTester, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TripTester
TripTester      TripTester.App   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     *localclr-namespace:TripTester       �� 	Resources     
Foreground �� Color    TripTester.ResultConverter  
rConverter  BackgroundHighlighted  BorderBrushHighlighted  BackgroundSelected  BorderBrushSelected  BackgroundNormal  BorderBrushNormal  ImageButtonTemplate �� 
TargetType   TripTester.ImageButton ��Name j� Stretch j� Viewbox �� ImageSource �� RelativeSource �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value 	 	ItemLable �� 
TargetType �� Path �� 	Converter �� Triggers �� Binding �� Value�� %�  &	        &	      &	      &	 +     &	 >     &	 Q     &	 d     &	 w     &	 �     &		 A    7  '	� .    �� $ #FFFFFF��  �� $ #54545C���� $ #6A6A75���� $ #007ACC���� $ #1C97EA���� $ #3F3F46���� $ #54545C���� "  .R�� .+��� $ bgrect������ $ UniformToFill=�$ 
0,0,0.25,1� �� *	ImgPath+ �� *TemplatedParent+�� $��Center=�$��Center=�$��24(�
����������� *	Content+ �� *TemplatedParent+ P� 	 �@J�IsMouseOver
 . . ��� $ bgrect�� � �� �� $ UniformToFill=�$ 0.25,0,0.25,1� �� *	ImgPath+ �� *TemplatedParent+P� 	 � ��
 . . ��� $ bgrect�� � �� �� $ UniformToFill=�$ 0.5,0,0.25,1� �� *	ImgPath+ �� *TemplatedParent+P� 	 � {�
 .  . ��� $ bgrect�� � �� �� $ UniformToFill=�$ 0.75,0,0.25,1� �� *	ImgPath+ �� *TemplatedParent+�� " ��.���  � �� �	#FF99996A��  � ��
 �������  � �� �� $ Result�8    ��  �� *Result+ OK.a���  � �� �#2A7187��  �� *Result+ NG.a���  � �� �#FF5656�� " 	� P� 	 �@d�	IsChecked$

 TrueY�. ���  � �� �#FF5656P� 	 �@d�	IsChecked$
 FalseY�. ���  � �� �#2A7187��  � ��$ 40��P� 	 �@J�IsMouseOver
 . . ���  � �� �#dc2b2b.���  � ��$	 105����  � ��$ 40����  � ��$
 Left=���  � �� �� .R�� .+��� ���� *
Background+ �� *TemplatedParent+�� $��Center=�$��Center=�
����������� *	Content+ �� *TemplatedParent+