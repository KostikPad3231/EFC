   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5          WpfApp1.RegistrationPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp1     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  Registration��5
       � 	Resources 5         HintRed �� 
TargetType % !MaterialDesignFloatingHintTextBox �� BasedOn �� Property �� Value  PasswordHintRed ) %MaterialDesignFloatingHintPasswordBox��%  &	        7  &	 u     7  �� 5   
   " ��6    8   .�5      ��  � ��
 �  ��6+   �� 5       � ��
 �  ��6,   5      �� 5   
   " G�6(   8   .�5      ��  � ��
 �  ��6+   �� 5       � ��
 �  ��6,   5      5      .��5      � ���#FF9500.+�5   
   �� $��400 pt��6   
�������$��Center=�63    �� Padding$ 50 30q�6N    �� CornerRadius$ 30��6^    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 60Q�6#   
   Color$
 Azure��63      ShadowDepth$ 0Q�6A   ._�5      �� .+�5      �� $��Registration��6   $��30(�60   $��Arial)�6>   $
��Bold"�6Q    �� TextAlignment$ Center=�6c   $��
0 0 0 10ptq�6z   � 5      $��
0 0 0 10ptq�6   .+�5      �� -   5        $��Sign in��5      $
��Left=�6/   $��16(�6J    # MaterialDesignRaisedLightButton#��[ 6X   6�   �� 5      $��Sign up��6   $��Right=�6/   $��16(�6K    " MaterialDesignRaisedDarkButton#��[ 6Y   5       �� 5!      -   5         ��Name$ usernameField��5!      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��61   #��[ 6[   $��
0 0 0 15ptq�6�   G� 5"      -   5         G�Name$ password1Field��5"      $ Password��66   #��[ 6`   $��
0 0 0 15ptq�6�   G� 5#      -   5        $ password2Field��5#      $ Repeat password��66   #��[ 6g   $��
0 0 0 15ptq�6�   �� 5$      -   5        $��Sign up��5$      6+   5%      5&      5'      5(      