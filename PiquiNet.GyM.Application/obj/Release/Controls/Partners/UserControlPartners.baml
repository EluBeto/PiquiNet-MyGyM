   M S B A M L   `   `   `  ���� S  OPiquiNet.GyM.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:PiquiNet.GyM.Application.Controls.Partners*PiquiNet.GyM.Application.Controls.Partners  D    >PiquiNet.GyM.Application.Controls.Partners.UserControlPartners   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Jlocal8clr-namespace:PiquiNet.GyM.Application.Controls.Partners     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  $
��auto��$
��auto��.��?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -      Name$  TransitioningContentSlide��C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.8X�.��� -    �Name$ gridReg�����	#FFF5F1F1 J� Opacity$
 0.90Q�.+��� $��0,0,0.333,0q����	#FF4F4D4D$��35��$	��Top=�.+��� $��Socios��$��24(�$��Center=�$��0 5 0 0q�
�������$��Century Gothic)��� -    ��Name$	 Uid��$y�	Collapsed=��� $��	0,350,0,0q����	#FF4F4D4D$��35��$	��Top=�.+��� $��Registro de Socios��$��18(�$��Center=�$��0 5 0 0q�
�������$��Century Gothic)�� $��0, 60, 0, 10q�$	��Top=� � RowDefinitions �� $��50 ��� $��50 ��� $��* ��� $��* ��� $��* ��� $��* � � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* �.+�� $��20 0 0 5q�$��0��$��0��$
��Left=�$��40��$	��178��.+��� -    ��Name$ 
txtUserCod��{�.  )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Codigo�� %  !MaterialDesignFloatingHintTextBox#��[  $
��Bold"�$��14(�� $��5 0 0 5q�$��0��$��1��$
��Left=�$��40��$	��178��.+��� -   $ 	txtNombre��$	 Nombre��
 �� 	MaxLength$
 19�� �� CharacterCasing$ Upper=�#��[  � $��5 0 0 5q�$��0��$��2��$
��Left=�$��40��$	��178��.+��� -   $ txtAP��$	 Apellido Paterno��$
 19��$ Upper=�#��[  � $��	10 0 20 5q�$��0��$��3��$
��Left=�$��40��$	��178��.+��� -   $ txtAM��$	 Apellido Materno��$
 19��$ Upper=�#��[  � $��20 0 0 5q�$��1��$��0��$
��Left=�$��40��$	��178��.+��� -   $ txtMail��$	 Correo electrónico��$
 35��$ Upper=�#��[  � $��5 0 0 5q�$��1��$��1��$
��Left=�$��40��$	��178��.+�(  "System.Windows.Controls.DatePicker  -	     Name$ txtFechaNac��$	��178��$	 Fecha de nacimiento�� ( $MaterialDesignFloatingHintDatePicker#��[  � Language$ es-es�� $��5 0 0 5q�$��1��$��2��$
��Left=�$��40��$	��178��.+��� -
   $ txtNumberPhone��$
 10��$	 Telefono��#��[  � $��	10 0 20 5q�$��1��$��3��$
��Left=�$��40��$	��178��.+��� $
��Sexo��	� -    	�Name$ Mujer��$��0 20 0 0q�  MaterialDesignRadioButton#��[ .��Mujer	� -   $ Hombre��$��	80 20 0 0q�#��[ .��Hombre� $��20 0 0 5q�$��2��$��0��$
��Left=�$��40��$	��178��.+��� -   $ 
lblEstatus��$��Estatus��$y�	Collapsed=�$��10,15,10,10q�d� -    d�Name$ 	rbEstatus�� * &MaterialDesignSwitchAccentToggleButton#��[  � ToolTip$, &MaterialDesignSwitchAccentToggleButton��$��5,15,5,5q�$y�	Collapsed=�� $��5 0 0 5q�$��2��$��1��$
��Left=�$��40��$	��178��� $��5 0 0 5q�$��2��$��2��$
��Left=�$��40��$	��178��� $��	10 0 20 5q�$��2��$��Right=�$��40��$	��178��� $��20 0 0 5q�$��3��$��0��$
��Left=�$��40��$	��178��� $��5 0 0 5q�$��3��$��1��$
��Left=�$��40��$	��178��� $��5 0 0 5q�$��3��$��2��$
��Left=�$��40��$	��178��� $��	10 0 20 5q�$��3��$��3��$
��Left=�$��40��$	��178��� $��20 0 0 5q�$��4��$��0��$
��Left=�$��40��$	��178��� $��5 0 0 5q�$��4��$��1��$
��Left=�$��40��$	��178��.+��� -    ��Name$ 
btnGuardar��$y�	Collapsed=�.��	Guardar�� -   $ btnModifica��$y�	Collapsed=�.��	Modificar� $��5 0 0 5q�$��4��$��2��$
��Left=�$��40��$	��178��.+��� -   $ 
btnLimpiar�����	#FFD29941���	#FFA1A3A5$	 0.8Q�.��	Limpiar� $��	10 0 20 5q�$��4��$��3��$
��Left=�$��40��$	��130��.+��� -   $ btnMembership�����#3CB371���#2E8B57$	 0.8Q�$y�	Collapsed=�.��	Membrecia� $��0, 390, 0, 10q�$	��Top=� �� $��50 ��� $	��300 � �� $
��auto �.+�(  "MaterialDesignThemes.Wpf.ColorZone  $��0��$��0,0,60,0q�$	��Top=�$��Right=�   Mode$ Light=�$��2q�.��]� .+���  �� Orientation$ 
Horizontal=�+  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . .+�  $ Standard=�$��0 0 0 0q�   CornerRadius$ 2�� K� ZIndex$ 1��$��0 0 0 0q�+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�.���  �� $
��Auto ��� $��* ��� $��* �.+���   MaterialDesignToolButton#���  .��'	  !MaterialDesignThemes.Wpf.PackIcon	  �
  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]] 
  Kind$ Magnify=�$	 .56Q��� -   $ txtBuscaRegistros��$��1��$��8 0 0 0q�$	 Busca Socio��.  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�$��0q�$	��200��$��Center=��� #���  $��2���� -    ��Name$ 
spListView��$��1��$	��Top=�$
��Left=�$
��auto��$
��auto�� � 	Resources   	itemstyle �� 
TargetType��%   &	       �� " ��.�-   .+��� -    ��Name$ lvUsers��$��10 0 0 0q�#��[ $	��Top=�$��Ebrima)�$
��Bold"�$
��auto��$
��auto��$��Visible=�$��Visible=�?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid$   SelectiveScrollingOrientation$ Vertical=� �� View �� .P��� $��Id��  �� Width$  0��! �� DisplayMemberBinding! �� *UserId+�� -   col1��$��Codigo��! �� *
UserCode+�� -   col2��$��Nombre��! �� *Name+�� -   col3��$��Apellido P.��! �� *
LastName+�� -   col4��$��Apellido M.��! �� *MotherLastName+�� -   col5��$��Fecha de Alta��! �� *	DateAdd+�� -   col6��$��	Teléfono��! �� *PhoneNumber+&   MaterialDesignThemes.Wpf.Flipper  $��520 180 50 0q�  MaterialDesignCardFlipper#��[ $��Right=�"   FrontContent" �� -     MaterialDesignFlatButton#��[ #   FlipCommand#��Z# $��0 0 0 0q�$	��250��$��Center=�$��Captura Huella��$   BackContent$ � $	��250��$	��200�� �� $
��Auto ��� $��* �.+�  $ Accent=�$��6q�.���� $ 
Horizontal=����	#FFB29D9D.+���  & "MaterialDesignToolForegroundButton#��[ #��Z# $
��Left=�.��	  $ 	ArrowLeft=�$��Right=��� $��8 0 0 0q�$��Center=��� $�Huella��� $��1��$��0 0 0 0q�$��Center=�$	��Top=�$	��250��$	��250�� �� $	��100 ��� $��50 ��� $��50 �.+��� $��0��$	��Top=�$��Center=�$	��250��$	��250��.+�A� $��90��$��90��$	��Top=�$��Center=�$��0 0 0 0q�
���   ����� -   ImgBrushUserHuella��% j� Stretch$% UniformToFill=��� $��1��$ 
Horizontal=�$��0 12 0 0q�$��Center=�.+��� -   $ 
txtHuellas��Capture 3 huellas del socio.�� $��2��$ 
Horizontal=�$��Center=�$��Center=�$��	10,0,10,0q�.+��� -    $ H1�� *	 &MaterialDesignFloatingActionMiniButton#��� 	 $ Depth2=�$y�Visible=�$��5,5,5,5q�.��	  -!   & 	 Name$	& iH1��$ Numeric1BoxOutline=��� -"   $ H2��#��� 	 $ Depth2=�$y�Visible=�$��5,5,5,5q�.��	  -#   $	& iH2��$ Numeric2BoxOutline=��� -$   $ H3��#��� 	 $ Depth2=�$y�Visible=�$��5,5,5,5q�.��	  -%   $	& iH3��$ Numeric3BoxOutline=�  $��0 180 330 0q�#��[ $��Right=�" �� #��[ #��Z# $��0 0 0 0q�$	��250��$��Center=�$��Carga Imagen��$ � $	��250��$	��250�� �� $
��Auto ��� $��* �.+�  $ Accent=�$��6q�.���� $ 
Horizontal=����	#FFB29D9D.+��� #��[ #��Z# $
��Left=�.��	  $ 	ArrowLeft=�$��Right=��� $��8 0 0 0q�$��Center=��� $�Imagen Socio��� $��1��$��0 0 0 0q�$��Center=�$	��Top=�$	��250��$	��250�� �� $	��120 ��� $��50 ��� $��60 �.+��� $��0��$	��Top=�$��Center=�$	��250��$	��300��.+�A� $	��120��$	��120��$	��Top=�$��Center=�$��0,10,0,0q�
���   ����� -&   imgSocio���� $��1��$	��Top=�$��Center=�$	��150��$��40��.+�� $��Center=�$	��Top=�$��0,0,0,0q�.+��� -'   $��btnLoadImag�����	#FF54B75A.��Busca Imagen�� -(   $ btnTrash��#��[ #��Z# $��Right=����	#FFA60F0F$ Elimina Imagen��$��5 0 0 0q�$y�	Collapsed=�.��	  $ Trash=�$��Right=��� $��2��$��0,0,0,0q�$��Center=�$	��Top=�.+��� $��Formato de imagen .PNG���� $!��Tamaño 550 x 550 píxeles.��)  #MaterialDesignThemes.Wpf.DialogHost  -)   '  Name$' 
DialogHost��(   CloseOnClickAway( . $
��auto��$
��auto��$��Center=�$��Center=�)   DialogContentTemplate) �� * �� DataType$* local:Person��.R�� $ gridMod��$
��auto��$
��auto��.+��� $��	Membrecia�� 
 MaterialDesignGroupBox#��� 
 $��0,0,0,0q�$ Depth3=�$��Center=�$��Center=�$��0q�.��� g1�� �� $	��150 ��� $	��100 ��� $��* ��� $��* ��� $��* ��� $��* � �� $	��100 ��� $	��200 ��� $	��200 �.+��� $��0��$��0��$��0,10,0,0q�.+��� $��Datos de Socio��$
��Bold"����� *propTextBlock.FontFamily+���� *propTextBlock.Margin+�� $�� ���� $��Codigo: ������ *propTextBlock.FontFamily+���� *propTextBlock.Margin+�� $��Nombre: ������ *propTextBlock.FontFamily+���� *propTextBlock.Margin+�� $��
Telefono: ������ *propTextBlock.FontFamily+���� *propTextBlock.Margin+�� $��0��$��1��$��0,10,0,0q�.+��� $�� ������ *propTextBlock.Margin+�� $�� ���� ���� *Codigo+���� *propTextBlock.FontFamily+���� *propTextBlock.Margin+�� ���� *NombreCompleto+���� *propTextBlock.FontFamily+���� *propTextBlock.Margin+�� ���� *
Telefono+���� *propTextBlock.FontFamily+���� *propTextBlock.Margin+�� $��0��$��2��$��0,10,0,0q�.+�A� $	��120��$	��120��$	��Top=�$��Center=�
���   ����� + �� ImageSource+ �� *imgSocioModal+�� $��5��$��1���� $ 
Horizontal=�$��Center=�$��Bottom=�.+��� $ GuardaMembrecia��.��	Guardar�� $ SalirMod��-*   $��10q����#FF8C00���#FF8C00$	 0.8Q�.��
Cancelar