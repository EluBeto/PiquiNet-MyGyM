   M S B A M L   `   `   `  ����S  OPiquiNet.GyM.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:PiquiNet.GyM.Application.RegisterView%PiquiNet.GyM.Application.RegisterView  5   	   <    6PiquiNet.GyM.Application.RegisterView.RegisterActivity   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Elocal3clr-namespace:PiquiNet.GyM.Application.RegisterView     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  RegisterActivity��5	   	   $	��650��6"   $
��1100��6/    � WindowStyle$
 None=�6<    J� Opacity$	 100Q�6O    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6w    � WindowState$ Normal=�6�   .��5
      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TransitioningContentSlide��5
   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6M   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.8X�.��5   
   � -   5        	 �Name$	 gridReg��5      ��5      �� 5      -   5        ImgBrushBackground��
 �� Opacity$

 0.50Q�5   9   .+�5      �� -   5         ��Name$ 	stakBarra��5      $��0,0,0,0q�6,   ���	#FF4F4D4D$��40��6T   $	��Top=�6`   .+�5      �� $��Registro��6   $��22(�6,   $��Center=�6:   $��0 5 0 0q�6W   
�������$
��Bold"�6�   ��6{   �� *propTextBlock.FontFamily+6�   5      �� 5      $��	0,45,0,20q�6   
������ $��45��6E   $	��Top=�6Q   $��Center=�6i    �� Orientation$ Vertical=�6�   .+�5      �� -   5         ��Name$ fechaRegistro��5      $��30(�6c   $��Center=�6q   $��0,0,0,0q�6�   
���   �$
��Bold"�6�   ��63   �� *propTextBlock.FontFamily+6�   5      �� 5      $��	0,90,0,20q�6   
������ $��45��6E   $	��Top=�6Q   $��Center=�6i   $ Vertical=�6�   .+�5      �� -   5        $ horaRegistro��5      $��40(�6b   $��Center=�6p   $��0,0,0,0q�6�   
���   �$
��Bold"�6�   ��62   �� *propTextBlock.FontFamily+6�   5      � 5      $��	0,120,0,0q�6   $��Center=�6&   $��Center=�6C   $
��auto��6^   $
��auto��6k    � RowDefinitions 5      �� 5      $	��230 �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5       $
��auto �6$    � ColumnDefinitions 5"      �� 5#      $
��auto �6'   �� 5$      $
��auto �6'   �� 5%      $
��auto �6'   �� 5&      $
��auto �6'   .+�5)      � $��0,0,0,0q�6   $��0��6(   $��1��65   $��2��6E   $��2��6Y   $	��240��6j   $	��Top=�6w   $��Center=�6�   .+�5*      �� $	��Top=�6!   $��Center=�69   .+�5+      �� -   5         ��Name$ 	btnHuella��5+   !   $	��200��64   $	��210��6@   $��	10,0,10,0q�5,   %    &  "MaterialDesignFloatingActionButton#��[  5-   '   3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IsIndicatorVisible .    Value$ -1Q�5/   '      IsIndeterminate . .��51      A� $	��170��6&   $	��180��62   $	��Top=�6?   $��Center=�6W   $��0,0,0,0q�6t   ��52   "   �� 53   &   -   5        ImgBrushUserHuella�� j� Stretch$ UniformToFill=�53   M   55      56      57      58      � 5:      $��0,0,0,0q�6   $��1��6(   $��1��65   $��2��6E   $��Center=�6Y   $��Center=�6v   .+�5;      �� -	   5        $ titleH��5;       $	��Top=�5<       $��Center=�5=       $��5,0,5,0q�5>       $��36(�5?       
�������$
��Bold"�5A       ��5B       �� *propTextBlock.FontFamily+6R   5C      � 5E      -
   5        $
	 row2��5E      $��5q�6%   $��2��60   $��1��6=   $��2��6M   $��Center=�6a   $��Center=�6~   .+�5F      �� -   5        $ NomUser��5F       $	��Top=�61   $��Center=�6I   $��5,0,5,0q�6f   $��30(�6w   
�������$
��Bold"�6�   ��5G   $   �� *propTextBlock.FontFamily+6V   5H      � 5J      $��5q�6   $��3��6"   $��0��6/   $��4��6?   $��2��6S   $��Center=�6d   $	��Top=�6�   .+�5L      #  MaterialDesignThemes.Wpf.Card  -   5          Name$ 	cardDatos��5L   6   $	��350��6*   $y�Visible=�6I     MaterialDesignBackground#���  5M      .��5N      �� .+�5O      9� -   5         9�Name$ detalleDatos��5O   '    9� 
IsExpanded . $��Stretch=�5Q   #   $
��Bold"�5R   #   $��Datos de Membrecia��5T   #   ��5S   #   �� *propTextBlock.FontFamily+.��5U   "   �� $��Center=�6-   $ Vertical=�5V   -     MaterialDesignBody#���  5W   -   $��	19,0,12,0q�5X   -   $	��307��6@   .+�5Y   &   �� -   5        $ dato_1��5Y   0   $��5,-1,5,0q�6@   $��16(�6R   $
��Bold"�6�   ��6`   �� *propTextBlock.FontFamily+6�   �� 5Z   &   -   5        $ dato_2��5Z   0   $��5,1,5,0q�6@   $��16(�6Q   $
��Bold"�6�   ��6_   �� *propTextBlock.FontFamily+6�   �� 5[   &   -   5        $ dato_3��5[   0   $��5,1,5,10q�6@   $��16(�6R   $
��Bold"�6�   ��6`   �� *propTextBlock.FontFamily+6�   5]   #   5^      �� 5_        MaterialDesignDivider#���  5`      $��1��5a      $��Stretch=�5b       J� SnapsToDevicePixels . 5c      5d      5e      5f      � 5i      -   5        $	 	PromoLeft��5i      $y�	Collapsed=�6*   $��5,150,100,5q�6A   $��0��6V   $��0��6c   $��3��6s   $��Center=�6�   $	��Top=�6�   .+�5j        $	��200��5k      .��5l      �  5m      �� 5n   "   $	��140 �5o   %   �� 5p   "   $��* �5q   %   �� 5r   "   $
��Auto �5s   %   .+�5u      �� $!��..\Resources\Assets\gym.jpg��5v   #   $	��140��5w   #   $	��196��5x   #   $��UniformToFill=�5y   #   �� 5z      $��0��5{   #    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 5|   #   $��Right=�5}   #   $��Bottom=�5~   #   $��
0 0 16 -20q�5   #   .��5�   "   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ Alien=�5�   %   5�      �� 5�      $��1��5�   #   $��8 24 8 0q�5�   #   .+�5�   "   �� $
��Bold"�5�   %   Semana de Descuento5�   #   �� 5�   "   $
��Wrap=�5�   %   $��Center=�5�   %   '%Aprovecha nuestra semana de descuento5�   #   5�      �� 5�      $��Right=�5�   #   $��2��5�   #   $ 
Horizontal=�5�   #   $��8q�5�   #   5�      5�      5�      5�      � 5�      -   5        $	 
PromoRigth��5�      $y�	Collapsed=�6+   $��100,150,5,5q�6B   $��0��6W   $��3��6d   $��3��6t   $��Center=�6�   $	��Top=�6�   .+�5�        $	��200��5�      .��5�      �  5�      �� 5�   "   $	��140 �5�   %   �� 5�   "   $��* �5�   %   �� 5�   "   $
��Auto �5�   %   .+�5�      �� $!��..\Resources\Assets\gym.jpg��5�   #   $	��140��5�   #   $	��196��5�   #   $��UniformToFill=�5�   #   �� 5�      $��0��5�   #   #��[ 5�   #   $��Right=�5�   #   $��Bottom=�5�   #   $��
0 0 16 -20q�5�   #   .��5�   "     $ Alien=�5�   %   5�      �� 5�      $��1��5�   #   $��8 24 8 0q�5�   #   .+�5�   "   �� $
��Bold"�5�   %   Semana de Descuento5�   #   �� 5�   "   $
��Wrap=�5�   %   $��Center=�5�   %   '%Aprovecha nuestra semana de descuento5�   #   5�      �� 5�      $��Right=�5�   #   $��2��5�   #   $ 
Horizontal=�5�   #   $��8q�5�   #   5�      5�      5�      5�      5�      5�      5�      5�      