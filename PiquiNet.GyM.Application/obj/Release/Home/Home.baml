   M S B A M L   `   `   `  ���� S  OPiquiNet.GyM.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:PiquiNet.GyM.Application.HomePiquiNet.GyM.Application.Home  (    "PiquiNet.GyM.Application.Home.Home   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     =local+clr-namespace:PiquiNet.GyM.Application.Home     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$
  Home��$	��600��$
��1024�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=�.��� -   ���	#FFEEEEEE.+��� $	��Top=�
���   �.+�� ���	#FF0069C0$��10��� $��5q�.+��� $��Center=� �� Orientation$ 
Horizontal=�$��335,0,177,0q�$	��502��.+��� -    ��Name$ Reloj��$��Center=�$��20(�$��Century Gothic)�$��150 0q�
�������$
��Bold"��� $ 
Horizontal=�$��Right=�$
��10 0q�.+�%  MaterialDesignThemes.Wpf.Badged  -     Name$ NumAlert��$��0,0,10,0q�.���� $��30��$��0,0,0,0q� � ToolTip$ Notificaciónes��$��30��$��0q�
���������Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  -     Name$ 	IconAlert���  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]	   Kind$	 BellOutline=��� -   $��30��$ Configuración��$��30��$��0q�
�������$��0 0 20 0q���Z� ��Z� .��  $	 Settings=��� -   
 ��Name$
 Btn_Max��$��30��$��30��$��0q�
���������Z� ��Z� .��  -   $ max_min��o�  o� 
IsMainMenu . $��0,5,0,5q�
���   ����	#FF858484.@�m� $��_Salir��$��20��.@�m� -   $��Cerrar aplicación�� m� Icon   $	 	ExitToApp=�$��20��$��20��m� -	    m�Name$ btnCerrarSesion��$��_Cerrar sesión��   $	 ExitRun=�$��20��$��20��� -
    �Name$ GridPM��$��
250 50 0 0q����� -   imgFondo�� j� Stretch$ UniformToFill=�.+�� -   $ GridPrincipal��$��Center=�$��Center=�$
��Auto=�� $	��250��$
��Left=����	#FF222222.+��� $	��Top=�$��Center=����	#FF302F2F$	��250��$	��160��.+�A� $��85��$��85��$	��Top=�$��Center=�$
��0 10q�
����������� -   ImgBrushUser�� �� ImageSource$B </PiquiNet.GyM.Application;component/Resources/Assets/elu.jpg��$ UniformToFill=��� $��¡Hola!��$	��Top=�$��Center=�$	��0 0q�$��18(�
��������� -   $ NomUser��$	��Top=�$��Center=�$	��0 5q�$��18(�
��������� -   $ idUser��$y�	Collapsed=�?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -     Name$ TransitioningContentSlide��C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.2X�.��� -   $ 
GridCursor��$y�	Collapsed=�$��	0 170 0 0q����	#FF0069C0$��10��$
��Left=�$��45��$	��Top=��� -    ��Name$ ListViewMenu��$��
0,170,0,44q�
�������$��Century Gothic)�$��17(� �� SelectedIndex$ 0��.@��� -    ��Name$ 
ItemInicio��$��45��.���� $ 
Horizontal=�.+�  $
	 Home=�$��25��$��25��$��Center=�$��5q��� $��Início��$��17(�$��Center=�$
��20 0q��� -   $ ItemUsuarios��$��45��.���� $ 
Horizontal=�.+�  $
	 User=�$��25��$��25��$��Center=�$��5q��� $��Usuarios��$��17(�$��Center=�$
��20 0q��� -   $ 	ItemRoles��$��45��.���� $ 
Horizontal=�.+�  $	 AccountEdit=�$��25��$��25��$��Center=�$��5q��� $��Roles��$��17(�$��Center=�$
��20 0q��� -   $ 
ItemSocios��$��45��.���� $ 
Horizontal=�.+�  $	 People=�$��25��$��25��$��Center=�$��5q��� $��Socios��$��17(�$��Center=�$
��20 0q��� -   $ ItemMembrecia��$��45��.���� $ 
Horizontal=�.+�  $	 	Checkbook=�$��25��$��25��$��Center=�$��5q��� $��
Membrecias��$��17(�$��Center=�$
��20 0q��� -   $ 
ItemClases��$��45��.���� $ 
Horizontal=�.+�  $	 Adjust=�$��25��$��25��$��Center=�$��5q��� $��Clases��$��17(�$��Center=�$
��20 0q��� -   $ ItemProductos��$��45��.���� $ 
Horizontal=�.+�  $	 SeatFlat=�$��25��$��25��$��Center=�$��5q��� $��	Productos��$��17(�$��Center=�$
��20 0q��� -   $ ItemCompras��$��45��.���� $ 
Horizontal=�.+�  $	 PaymentSettings=�$��25��$��25��$��Center=�$��5q��� $��Compras��$��17(�$��Center=�$
��20 0q��� -   $ 
ItemVentas��$��45��.���� $ 
Horizontal=�.+�  $
	 Sale=�$��25��$��25��$��Center=�$��5q��� $��Ventas��$��17(�$��Center=�$
��20 0q��� -   $ ItemRegistro��$��45��.���� $ 
Horizontal=�.+�  $	 Register=�$��25��$��25��$��Center=�$��5q��� $��Registro��$��17(�$��Center=�$
��20 0q��� -   $ ItemReportes��$��45��.���� $ 
Horizontal=�.+�  $	 Report=�$��25��$��25��$��Center=�$��5q��� $��Reportes��$��17(�$��Center=�$
��20 0q��� -   $ 
ItemConfig��$��45��.���� $ 
Horizontal=�.+�  $	 SettingsApplications=�$��25��$��25��$��Center=�$��5q��� $��Configuración��$��17(�$��Center=�$
��20 0q��� $��57,0,0,4q�$ ��Copyright © 2019 PiquiNet��
�������$��16��$��Bottom=�$
��Left=�$	��150��