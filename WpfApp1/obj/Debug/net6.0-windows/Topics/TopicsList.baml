   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5          WpfApp1.TopicsList   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp1     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  Topics��5
      .��5      � ���#FF9500 � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $
��0.8* �6   �� 5      $
��0.1* �6   .+�5   
   �� -   5         ��Name$ searchField��5   C   $��0��6   $��3��6   $��2��6/   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search��6X    %  !MaterialDesignFloatingHintTextBox#��[  6�   $��0 0 0 0q�6�   �� 5   
   -   5        $��0��5      $��5��6   $��10pt 0q�6.   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�6&   $
��20pt��65   $
��20pt��6C   5       �� 5!   
   -   5         ��Name$ UserNameLabel��5!   B   $��0��6   $��7��6   $��2��6.   $��20(�6Y   $��10pt 0q�6g   6w   �� 5"   
   -   5        $��0��5"      $��0��6   $��2��6.   $��	New topic��6B   6V   �� 5#   
   -   5         ��Name$ 
topicsList��5#   D   $��1��6   $��0��6    $��9��60    �� View 5$      �� 5%      .P�5&      �� 	 �� Width$	 100pt��6%   ��5'      �� 5(      -   5        
 � Cursor$

 Hand��5(   V   .��5)   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5*   &   �� $��Topic ��60     5+   &   -   5          Name$ SortIcon��5+   >   $
 Sort=�6P   $��0,0,5,0q�6\   $��Center=�6m   5,   #   5-       �� CellTemplate 5/      �� 50      .R�51   "   �� -   5        
����  �$

 Hand��53   $   ��51   ,   �� *Name+
 � Tag 55   ,   �� *Id+56      58      �� 59      $��Starter��6%   $	 100pt��6d    �� DisplayMemberBinding 66   �� *UserUsername+6d   �� 5:      $��
Created at��6%   $	 115pt��6d    69   �� *	CreatedAt+6d   �� 5;      $��Posts count��6%   $	 100pt��6f    6:   �� *
PostsCount+6f   �� 5<      $��Actions��6%   $
	 85pt��66    5=      �� 5>      .R�5?   "   �� -	   5        $��Update��5?   )    6V   �� *Id+5@      5B      �� 5C      $��Actions��6%   $
	 85pt��66    5D      �� 5E      .R�5F   "   �� -
   5        $��Delete��5F   )    6V   �� *Id+5G      5I      5J      5L      �� 5M   
   -   5        $��2��5M   -   $��2��6:   $��<<��6J   $��10pt 0q�6]   �� 5N   
   -   5        $��2��5N   +   $��3��68   $��<��6H   $��10pt 0q�6W   �� 5O   
   -   5         ��Name$ curPageField��5O   1   $��2��6   $��4��6!   $��20(�6G   $��Center=�6U   $��Center=�6p   
�������6�   �� 5P   
   -   5        $��2��5P   +   $��5��68   $��>��6H   $��10pt 0q�6W   �� 5Q   
   -   5        $��2��5Q   +   $��6��68   $��>>��6H   $��10pt 0q�6[   5R      5S      