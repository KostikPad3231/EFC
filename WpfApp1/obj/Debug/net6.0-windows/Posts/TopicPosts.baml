   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp1.PostsWpfApp1.Posts  5          WpfApp1.Posts.TopicPosts   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp1.Posts     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  
TopicPosts��5
       � 	Resources 5         MessageHintRed �� 
TargetType ! MaterialDesignOutlinedTextBox �� BasedOn �� Property �� Value��%�   &	        7  �� 5   
   " ��6'   8   .�5      ��  � ��
 �  ��6+   �� 5       � ��
 �  ��6,   5      5      .��5      � ���#FF9500 � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��0.25* �6   �� 5      $��0.85* �6   .+�5    
   �� -   5        $��0��5       $��0��6   $
��Back��6.   $
��10 0q�6W   �� 5!   
   -   5         ��Name$ messageField��5!   C   $��0��6   $��1��6   $��4��6/   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Message��6Y   #��[ 6�   
 �� TextWrapping$

 Wrap=�6�   $
��10ptq�6�   6�   �� 5"   
   -   5        $��0��5"      $��5��6   $��Reply��6.   $
��10 0q�6Y   �� 5#   
   -   5         ��Name$ 	postsList��5#   D   $��1��6   $��0��6    $��7��60    �� View 5$      �� 5%      .P�5&      �� $��Username��6%    �� Width$ 100pt��6e    �� DisplayMemberBinding 67   �� *UserUsername+6e   �� 5'      $
��Post��6%   $ 200pt��63    �� CellTemplate 5(      �� 5)      .R�5*   "   �� $
��Wrap=�6X   ��6,   �� *	Message+
 � Tag 6E   �� *Id+6X   5+      5-      �� 5.      $��
Created at��6%   $ 100pt��6d    69   �� *	UpdatedAt+6d   �� 5/      $��Actions��6%   $ 100pt��66    50      �� 51      .R�52   "   �� -   5        $
��Edit��52   )    6R   �� *Id+53      55      �� 56      $��Actions��6%   $ 100pt��66    57      �� 58      .R�59   "   �� -   5        $��Delete��59   )    6V   �� *Id+5:      5<      5=      5?      5@      5A      