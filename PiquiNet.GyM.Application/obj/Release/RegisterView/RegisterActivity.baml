   M S B A M L   `   `   `  ���� S  OPiquiNet.GyM.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:PiquiNet.GyM.Application.RegisterView%PiquiNet.GyM.Application.RegisterView  <    6PiquiNet.GyM.Application.RegisterView.RegisterActivity   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Elocal3clr-namespace:PiquiNet.GyM.Application.RegisterView     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  RegisterActivity��$	��650��$
��1100�� � WindowStyle$
 None=� J� Opacity$	 100Q� � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=� � WindowState$ Normal=�.��?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -     Name$ TransitioningContentSlide��C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.8X�.��� -   	 �Name$	 gridReg������ -   ImgBrushBackground��
 �� Opacity$

 0.50Q�.+��� -    ��Name$ 	stakBarra��$��0,0,0,0q����	#FF4F4D4D$��40��$	��Top=�.+��� $��Registro��$��22(�$��Center=�$��0 5 0 0q�
�������$
��Bold"����� *propTextBlock.FontFamily+�� $��	0,45,0,20q�
������ $��45��$	��Top=�$��Center=� �� Orientation$ Vertical=�.+��� -    ��Name$ fechaRegistro��$��30(�$��Center=�$��0,0,0,0q�
���   �$
��Bold"����� *propTextBlock.FontFamily+�� $��	0,90,0,20q�
������ $��45��$	��Top=�$��Center=�$ Vertical=�.+��� -   $ horaRegistro��$��40(�$��Center=�$��0,0,0,0q�
���   �$
��Bold"����� *propTextBlock.FontFamily+� $��	0,120,0,0q�$��Center=�$��Center=�$
��auto��$
��auto�� � RowDefinitions �� $	��230 ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+�� $��0,0,0,0q�$��0��$��1��$��2��$��2��$	��240��$	��Top=�$��Center=�.+��� $	��Top=�$��Center=�.+��� -    ��Name$ 	btnHuella��$	��200��$	��210��$��	10,0,10,0q� &  "MaterialDesignFloatingActionButton#��[  3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IsIndicatorVisible .    Value$ -1Q�   IsIndeterminate . .��A� $	��170��$	��180��$	��Top=�$��Center=�$��0,0,0,0q����� -   ImgBrushUserHuella�� j� Stretch$ UniformToFill=�� $��0,0,0,0q�$��1��$��1��$��2��$��Center=�$��Center=�.+��� -	   $ titleH��$	��Top=�$��Center=�$��5,0,5,0q�$��36(�
�������$
��Bold"����� *propTextBlock.FontFamily+� -
   $
	 row2��$��5q�$��2��$��1��$��2��$��Center=�$��Center=�.+��� -   $ NomUser��$	��Top=�$��Center=�$��5,0,5,0q�$��30(�
�������$
��Bold"����� *propTextBlock.FontFamily+� $��5q�$��3��$��0��$��4��$��2��$��Center=�$	��Top=�.+�#  MaterialDesignThemes.Wpf.Card  -     Name$ 	cardDatos��$	��350��$y�Visible=�  MaterialDesignBackground#���  .���� .+�9� -    9�Name$ detalleDatos�� 9� 
IsExpanded . $��Stretch=�$
��Bold"�$��Datos de Membrecia������ *propTextBlock.FontFamily+.���� $��Center=�$ Vertical=�  MaterialDesignBody#���  $��	19,0,12,0q�$	��307��.+��� -   $ dato_1��$��5,-1,5,0q�$��16(�$
��Bold"����� *propTextBlock.FontFamily+�� -   $ dato_2��$��5,1,5,0q�$��16(�$
��Bold"����� *propTextBlock.FontFamily+�� -   $ dato_3��$��5,1,5,10q�$��16(�$
��Bold"����� *propTextBlock.FontFamily+��   MaterialDesignDivider#���  $��1��$��Stretch=� J� SnapsToDevicePixels . � -   $	 	PromoLeft��$y�	Collapsed=�$��5,150,100,5q�$��0��$��0��$��3��$��Center=�$	��Top=�.+�  $	��200��.���  �� $	��140 ��� $��* ��� $
��Auto �.+��� $!��..\Resources\Assets\gym.jpg��$	��140��$	��196��$��UniformToFill=��� $��0�� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ $��Right=�$��Bottom=�$��
0 0 16 -20q�.��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ Alien=��� $��1��$��8 24 8 0q�.+��� $
��Bold"�Semana de Descuento�� $
��Wrap=�$��Center=�'%Aprovecha nuestra semana de descuento�� $��Right=�$��2��$ 
Horizontal=�$��8q�� -   $	 
PromoRigth��$y�	Collapsed=�$��100,150,5,5q�$��0��$��3��$��3��$��Center=�$	��Top=�.+�  $	��200��.���  �� $	��140 ��� $��* ��� $
��Auto �.+��� $!��..\Resources\Assets\gym.jpg��$	��140��$	��196��$��UniformToFill=��� $��0��#��[ $��Right=�$��Bottom=�$��
0 0 16 -20q�.��  $ Alien=��� $��1��$��8 24 8 0q�.+��� $
��Bold"�Semana de Descuento�� $
��Wrap=�$��Center=�'%Aprovecha nuestra semana de descuento�� $��Right=�$��2��$ 
Horizontal=�$��8q�