   M S B A M L   `   `   `  ����D  @TicTacToe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TicTacToe	TicTacToe  5   	       TicTacToe.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   )localclr-namespace:TicTacToe     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   o� $��0��6    o� 
IsMainMenu . .@�5      m� $��Players��6   .@�5      m� $��Player vs Player��6    m� CommandParameter$ PP��6w    m� 	IsChecked 65   �� *PP+ m� Command 6N   �� *PlayerChangedCommand+6w   m� 5      $��Player vs CPU��6   $ PC��6t    62   �� *PC+ 6K   �� *PlayerChangedCommand+6t   m� 5      $��
CPU vs CPU��6   $ CC��6q    6/   �� *CC+ 6H   �� *PlayerChangedCommand+6q   5      m� 5      $��
Difficulty��6   .@�5      m� $
��Easy��6   $
 Easy��6q    6)   �� *Easy+ 6D   �� *DifficultyChangedCommand+6q   m� 5      $��Medium��6   $ Medium��6u    6+   �� *Medium+ 6H   �� *DifficultyChangedCommand+6u   m� 5      $
��Hard��6   $
 Hard��6q    6)   �� *Hard+ 6D   �� *DifficultyChangedCommand+6q   5      m� 5      $
��View��6   .@�5      m� $��View evaluation��6    64   �� *ShowEvaluate+ 6W   �� *EvaluationCommand+5      5      �� 5   
   -   5         ��Name$ 	scrollbar��5   $   $��1��6   $��Visible=�67   $��Visible=�6]   .��5      �� ��6   �� *
Elements+��5      �� 5      .R�5       A�  A� Rows 6&   �� *Size+ A� Columns 6<   �� *Size+5!      ��5#      �� 5$      .R�5%      �� |�.  $��30��6�   $��30��6�   $��30��6�   $��30��6�   $
��Bold"�6�   $��19(�6�   ��6!   �� *StepCommand+��6A   �� *Id+��6a   �� *Text+��5&      �� 5(   "   	 �� 
TargetType"	 ��6(   
 �� Triggers
 5)   &   �� 5+   *    �� Binding 66   �� *	IsEnabled+ �� Value True6T   .a�5,   .   ��  �� Property � �� �� Value
 �����6K   5-   +   �� 5.   *    66   �� *	IsEnabled+	 False6T   .a�5/   .   ��  � �� 6K   �� *Color+50   +   52   #   54      55      ��57      �� 58      .�59      ��  � �� 65   �� *X+�� 5:       � �� 68   �� *Y+5;      5=      5>      ]� 5?   
   $��2��6   .+�5@      �� $��Bottom=�6   .@�5A      �� .��5B      �� ��6    �� *
InfoText+5C      5D      5E      5F      5G      