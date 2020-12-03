using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PiquiNet.GyM.Bussiness;
using PiquiNet.GyM.Utilities;


namespace PiquiNet.GyM.Application
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Validations _Validation = new Validations();
        Util util = new Util();
        Login _Login = new Login();
        Security _security = new Security();
        MatMessageBox matMessageBox = new MatMessageBox();
        public MainWindow()
        {
            InitializeComponent();
            ReaderCredentials();
            InitialFocus();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-es");
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            Home.Home _WindowPrincipal = new Home.Home();

            if (_Validation.ValidationLoginNotNull(TxtUser.Text, TxtPassword.Password))
            {
                Entities.Users _UserLog = new Entities.Users();

                _UserLog = _Login.ProccessLogin(TxtUser.Text, TxtPassword.Password);

                if (_UserLog.EstatusTransaccion)
                {
                    if (_UserLog.IsActive == true)
                    {
                        if (_Validation.ValidationLogin(TxtUser.Text, TxtPassword.Password, _UserLog.UserCode, _UserLog.UserName, _UserLog.Password))
                        {
                            _WindowPrincipal.NomUser.Text = _UserLog.Name;
                            _WindowPrincipal.idUser.Text = _UserLog.UserId.ToString();
                            _WindowPrincipal.ImgBrushUser.ImageSource = util.ImageSourceFromBitmap(util.ByteToImage(_UserLog.Imagen.Image, _UserLog.Imagen.width_Img, _UserLog.Imagen.height_Img));

                            _WindowPrincipal.Show();
                            this.Close();
                        }
                        else
                        {
                            TxtUser.Text = string.Empty;
                            TxtPassword.Password = string.Empty;
                            LblResultado.Text = "El usuario/contraseña son incorrectos.";
                        }
                    }
                    else
                    {
                        matMessageBox.TypeMessageBox("Login", "El usuario fue desactivado por el administrador de sistema.", 2);
                    }
                    
                }
                else
                {
                    if (_UserLog.Codigo == -600)
                    {
                        matMessageBox.TypeMessageBox("Login",_UserLog.Mensaje,3);
                    }
                    else
                    {
                        TxtUser.Text  = string.Empty;
                        TxtPassword.Password  = string.Empty;
                        LblResultado.Text = _UserLog.Mensaje;
                    }
                    
                }
                
            }
            else
            {
                if(TxtUser.Text == "")
                    TxtUser.Foreground = Brushes.Red;
                
                if(TxtPassword.Password == "")
                    TxtPassword.Foreground = Brushes.Red;

                LblResultado.Text = "Usuario y contraseña son requeridos.";
            }

        }

        private void TxtUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            LblResultado.Text  = string.Empty;
            TxtUser.Foreground = Brushes.Black;
            TxtPassword.Password  = string.Empty;
        }
        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            LblResultado.Text  = string.Empty;
            TxtPassword.Foreground = Brushes.Black;
        }

        private void LogOut_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton.ToString() == "Left")
                DragMove();
        }

        private void TxtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                TxtPassword.Focus();
                TxtPassword.Password  = string.Empty;
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Login_Button_Click(null,null);
            }
        }
        
        private void ChkRecuerdaCred_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string _path = @_security.DecryptString(_security.HextoStr(ConfigurationManager.AppSettings["Sec"].ToString()));
                string _credenciales = TxtUser.Text + "|" + TxtPassword.Password;
                string _name = _path + "Cred.dll";

                util.CreateArchivo(_path, _name, _credenciales);

            }catch(Exception ex)
            {
                
            }
        }

        private void ReaderCredentials()
        {
            try
            {
                string _path = @_security.DecryptString(_security.HextoStr(ConfigurationManager.AppSettings["Sec"].ToString()));
                string _FileName = _path + "Cred.dll";

                string[] _arrCredentials = util.ReadFile(_path, _FileName).Split('|');
                TxtUser.Text = _arrCredentials[0];
                TxtPassword.Password = _arrCredentials[1];

                if (_arrCredentials[0] != "" && _arrCredentials[1] != "")
                {
                    chkRecuerdaCred.IsChecked = true;
                }
                else
                {
                    chkRecuerdaCred.IsChecked = false;
                }
            }catch(Exception ex)
            {
                
            }

        }

        private void InitialFocus()
        {
            if (TxtUser.Text != "" && TxtPassword.Password != "")
            {
                BtnLogin.Focus();
            }

            if (TxtUser.Text == "" && TxtPassword.Password != "")
            {
                TxtUser.Focus();
            }

            if (TxtUser.Text != "" && TxtPassword.Password == "")
            {
                TxtPassword.Focus();
            }
        }
    }
}
