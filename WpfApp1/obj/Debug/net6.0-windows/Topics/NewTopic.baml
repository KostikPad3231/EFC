   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5          WpfApp1.NewTopic   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp1     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  NewTopic��5
       � 	Resources 5         SubjectHintRed �� 
TargetType % !MaterialDesignFloatingHintTextBox �� BasedOn �� Property �� Value  MessageHintRed ! MaterialDesignOutlinedTextBox��%  &	        7  &	 u     7  �� 5   
   " ��6'   8   .�5      ��  � ��
 �  ��6+   �� 5       � ��
 �  ��6,   5      �� 5   
   " ��6'   8   .�5      ��  � ��
 �  ��6+   �� 5       � ��
 �  ��6,   5      5      .��5      � ���#FF9500.+�5   
   �� $��400 pt��6   
�������$��Center=�63    �� Padding$ 50 30q�6N    �� CornerRadius$ 30��6^    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 60Q�6#   
   Color$
 Azure��63      ShadowDepth$ 0Q�6A   ._�5      �� .+�5      �� $��	New topic��6   $��30(�6-   $��Arial)�6;   $
��Bold"�6N    �� TextAlignment$ Center=�6`   $��
0 0 0 10ptq�6w   �� 5      -   5         ��Name$ subjectField��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Subject��60   #��[ 6Y   $��
0 0 0 15ptq�6�   �� 5      -   5        $ messageField��5      $ Message��60   #��[ 6Y    �� TextWrapping$
 Wrap=�6�   $	��100��6�   $��
0 0 0 15ptq�6�   �� 5      -   5        $
��Post��5      6(   5       5!      5"      5#      