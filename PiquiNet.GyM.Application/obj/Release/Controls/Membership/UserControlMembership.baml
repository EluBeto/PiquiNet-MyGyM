   M S B A M L   `   `   `  ���� S  OPiquiNet.GyM.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:PiquiNet.GyM.Application.Controls.Membership,PiquiNet.GyM.Application.Controls.Membership  H    BPiquiNet.GyM.Application.Controls.Membership.UserControlMembership   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Llocal:clr-namespace:PiquiNet.GyM.Application.Controls.Membership     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  $
��auto��$
��auto��.��?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -      Name$  TransitioningContentSlide��C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.8X�.��� -    �Name$ gridReg�����	#FFF5F1F1 J� Opacity$
 0.90Q�.+��� $��0,0,0.333,0q����	#FF4F4D4D$��35��$	��Top=�.+��� $��Membrecías��$��24(�$��Center=�$��0 5 0 0q�
�������$��Century Gothic)��� -    ��Name$	 Uid��$y�	Collapsed=��� $��	0,230,0,0q����	#FF4F4D4D$��35��$	��Top=�.+��� $��Registro de Membrecías��$��18(�$��Center=�$��0 5 0 0q�
�������$��Century Gothic)�� $��0,60,0,0q�$	��Top=� � RowDefinitions �� $��50 ��� $��50 ��� $��* ��� $��* ��� $��* ��� $��* � � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* �.+�� $��20 0 0 5q�$��0��$��0��$
��Left=�$��40��$	��178��.+��� -    ��Name$ 	txtNombre��)  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Nombre��
 �� 	MaxLength$
 19�� �� CharacterCasing$ Upper=� %  !MaterialDesignFloatingHintTextBox#��[  � $��5 0 0 5q�$��0��$��1��$
��Left=�$��40��$	��178��.+��� -   $ txtAP��$	 Precio��$
 19��$ Upper=�#��[  � $��5 0 0 5q�$��0��$��2��$
��Left=�$��40��$	��178��.+��� -   $ 
lblEstatus��$��Estatus��$y�	Collapsed=�$��10,15,10,10q�d� -    d�Name$ 	rbEstatus�� * &MaterialDesignSwitchAccentToggleButton#��[  � ToolTip$, &MaterialDesignSwitchAccentToggleButton��$��5,15,5,5q�$y�	Collapsed=�� $��20 0 0 5q�$��4��$��0��$
��Left=�$��40��$	��178��� $��5 0 0 5q�$��4��$��1��$
��Left=�$��40��$	��178��.+��� -    ��Name$ 
btnGuardar��$y�	Collapsed=�.��	Guardar�� -	   $ btnModifica��$y�	Collapsed=�.��	Modificar� $��5 0 10 5q�$��4��$��2��$
��Left=�$��40��$	��178��.+��� -
   $ 
btnLimpiar�����	#FFD29941���	#FFA1A3A5$	 0.8Q�.��	Limpiar� $��0, 280, 0, 10q�$	��Top=� �� $��50 ��� $	��300 � �� $
��auto �.+�(  "MaterialDesignThemes.Wpf.ColorZone  $��0��$��0,0,60,0q�$	��Top=�$��Right=�   Mode$ Light=�$��2q�.��]� .+���  �� Orientation$ 
Horizontal=�+  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . .+�  $ Standard=�$��0 0 0 0q�   CornerRadius$ 2�� K� ZIndex$ 1��$��0 0 0 0q�+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�.���  �� $
��Auto ��� $��* ��� $��* �.+���   MaterialDesignToolButton#���  .��'  !MaterialDesignThemes.Wpf.PackIcon  �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]] 	  Kind$ Magnify=�$	 .56Q��� -   $ txtBuscaRegistros��$��1��$��8 0 0 0q�$	 Busca Membrecia��.
  (MaterialDesignThemes.Wpf.TextFieldAssist 
  DecorationVisibility$ Hidden=�$��0q�$	��200��$��Center=��� #���  $��2���� -    ��Name$ 
spListView��$��1��$	��Top=�$
��Left=�$
��auto��$
��auto�� � 	Resources   	itemstyle �� 
TargetType��%   &	       �� " ��.�-   .+��� -    ��Name$ lvUsers��$��10 0 0 0q�#��[ $	��Top=�$��Ebrima)�$
��Bold"�$
��auto��$
��auto��$��Visible=�$��Visible=�?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid$   SelectiveScrollingOrientation$ Vertical=� �� View �� .P��� $��Id�� �� Width$ 0�� �� DisplayMemberBinding �� *MemId+�� -   col1��$��Concepto�� �� *Name+�� -   col2��$��Precio�� �� *Price+�� -   col3��$��Fecha de Alta�� �� *	DateAdd+