   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5          WpfApp1.UserDetails   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp1     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  UserDetails��5
       � 	Resources 5         HintRed �� 
TargetType % !MaterialDesignFloatingHintTextBox �� BasedOn �� Property �� Value��%�   &	        7  �� 5   
   " ��6    8   .�5      ��  � ��
 �  ��6+   �� 5       � ��
 �  ��6,   5      5      .��5      � ���#FF9500 � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $
��0.9* �6   .+�5   
   �� -   5        $��0��5      $��0��6   $��10pt 0q�6.   $
��Back��6>   6M   �� 5   
   $��1��6   $��0��6   $��4��6.   $��400 pt��6B   
�������$��Center=�6d    �� Padding$ 50 30q�6   	 �� CornerRadius$	 30��6�   
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5          
BlurRadius$ 60Q�6#      Color$ Azure��63      ShadowDepth$ 0Q�6A   ._�5"      �� .+�5#      �� $��Profile��6   $��30(�6+   $��Arial)�69   $
��Bold"�6L    �� TextAlignment$ Center=�6^   $��
0 0 0 10ptq�6u   �� 5$      -   5         ��Name$ usernameField��5$      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��61   #��[ 6[   $��
0 0 0 15ptq�6�   �� 5%      -   5        $
��Save��5%      6(   5&      5'      �� 5(   
   -   5        $��0��5(      $��3��6   
���  ��$��Log out��6?   $��10pt 0q�6Q   6a   5)      5*      