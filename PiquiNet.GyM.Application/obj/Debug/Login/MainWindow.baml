   M S B A M L   `   `   `  ����S  OPiquiNet.GyM.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:PiquiNet.GyM.ApplicationPiquiNet.GyM.Application  5   	   )    #PiquiNet.GyM.Application.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:PiquiNet.GyM.Application     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5	   	   $	��500��6   $	��350��6$    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	   $	��350��5   	   $	��500��5   	    � 
ResizeMode$ NoResize=�5   	   $��Segoe UI Emoji)�5   	   .��5      � -   5        ���	#FFEAEAEA.+�5   
   �� $	��280��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ #090000��6#   � 5      $ #C3C2C2��6#    � Offset$ 1Q�63   � 5      $ #504F4F��6#   $	 0.5Q�63   5      5      A� 5   
   $	��125��6   $	��125��6   $	��Top=�6+   $��Center=�6C   $��116,10,109,0q�6`   
���   ���5      �� 5      -   5        ImgBrushUser�� �� ImageSource$! ..\Resources\Assets\gym.jpg��5   3   	 j� Stretch$	 UniformToFill=�6]   5      �� 5    
   -   5        
 ��Name$
 	BtnLogOut��5        � ToolTip$ Cerrar��6$   $��30��65   $��30��6@   $��0q�6y   
�������$��310,10,10,460q�6�   ��6L   Z� ��6b   Z� .��5!      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ Power=�6&   5"      �� 5$   
   $	��280��6   $	��240��6    
�������$��Bottom=�6:   $��0,100q�6U    �� RadiusY$ 12.381��6d    �� RadiusX$ 12.381��6u    J� Opacity$	 0.5Q�6�    J� Effect 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&         Color$ 	#FFBBBBBB��6#      	Direction$ 0Q�65      
BlurRadius$ 15Q�6C      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6k   5(      � 5)   
   $��Bottom=�6   $��35,80q�6*   $	��240��69   .+�5*      �� $��Inicio de sesión��6   $��Center=�60   $	��Top=�6M   $��5q�6e   $��18(�6p   6�   �� 5+      $��Center=�6   $��15q�64   .+�5,      �� -   5         ��Name$ TxtUser��5,      $
��0,10q�6+   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Usuario��69    %  !MaterialDesignFloatingHintTextBox#��[  6b   $��Champagne & Limousines)�6�   $��18(�6�   6�   G� 5-      -   5         G�Name$ TxtPassword��5-      $
��0,10q�63   $ Contraseña��6A   $��Champagne & Limousines)�6m   $��18(�6�   6�   5.      5/      �� 50   
   -   5        $
 BtnLogin��50       " MaterialDesignRaisedDarkButton#��[ 6#   $	��150��6[   $��Center=�6g   $��Bottom=�6�   $
��0,85q�6�   $��Enviar��6�   ���	#FF101011$	 0.8Q�6�   $��0q�6�   �� 51   
   -   5         ��Name$ LblResultado��51      $��Center=�6*   $��Bottom=�6G   $��65q�6b   
���  ��$��13(�6   6�   �� 52   
   -   5         ��Name$ chkRecuerdaCred��52        MaterialDesignCheckBox#��[ 53      $��100, 395, 0, 0q�54      $��20��56      .��6   Recordar credenciales58      �� 59   
   $ ��Copyright © 2019 PiquiNet��6   $��Center=�65   $��Bottom=�6R   $��20q�6m   
�������$��12(�6�   �� 5:   
   $��Versión 1.0.0��6   $��Center=�6)   $��Bottom=�6F   $��5q�6a   
�������$��10(�6~   5<      5=      