﻿#pragma checksum "..\..\..\Login\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F9A2D98E8B9625FC484F890F7EBFA019E10733EA324D9441BC3922DFD0037A99"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using PiquiNet.GyM.Application;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PiquiNet.GyM.Application {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\Login\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush ImgBrushUser;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Login\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLogOut;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Login\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtUser;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Login\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TxtPassword;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Login\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLogin;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Login\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LblResultado;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Login\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkRecuerdaCred;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PiquiNet.GyM.Application;component/login/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Login\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\..\Login\MainWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ImgBrushUser = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 3:
            this.BtnLogOut = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Login\MainWindow.xaml"
            this.BtnLogOut.Click += new System.Windows.RoutedEventHandler(this.LogOut_Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TxtUser = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\Login\MainWindow.xaml"
            this.TxtUser.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TxtUser_TextChanged);
            
            #line default
            #line hidden
            
            #line 44 "..\..\..\Login\MainWindow.xaml"
            this.TxtUser.KeyDown += new System.Windows.Input.KeyEventHandler(this.TxtUser_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TxtPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 45 "..\..\..\Login\MainWindow.xaml"
            this.TxtPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.TxtPassword_PasswordChanged);
            
            #line default
            #line hidden
            
            #line 45 "..\..\..\Login\MainWindow.xaml"
            this.TxtPassword.KeyDown += new System.Windows.Input.KeyEventHandler(this.TxtPassword_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Login\MainWindow.xaml"
            this.BtnLogin.Click += new System.Windows.RoutedEventHandler(this.Login_Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.LblResultado = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.chkRecuerdaCred = ((System.Windows.Controls.CheckBox)(target));
            
            #line 53 "..\..\..\Login\MainWindow.xaml"
            this.chkRecuerdaCred.Click += new System.Windows.RoutedEventHandler(this.ChkRecuerdaCred_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
