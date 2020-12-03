using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using PiquiNet.GyM.Utilities;

namespace PiquiNet.GyM.Application.Controls.Users
{
    /// <summary>
    /// Lógica de interacción para UserControlUsers.xaml
    /// </summary>
    public partial class UserControlUsers : UserControl
    {
        Validations _validation = new Validations();
        Bussiness.Users _usersBussiness = new Bussiness.Users();
        Bussiness.Role _roleBussiness = new Bussiness.Role();
        MatMessageBox matMessageBox = new MatMessageBox();
        Util util = new Util();
        Security _security = new Security();
        Entities.Users _User = new Entities.Users();
        Entities.Role _Role = new Entities.Role();
        

        public UserControlUsers()
        {
            InitializeComponent();
            txtNombre.Focus();
            StartListUsers(0);
            StartRoles();
            btnGuardar.Visibility = Visibility.Visible;
            imgSocio.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "socios.png");
        }

        private void TxtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNombre.Text.Length > 0)
            {
                txtNombre.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                txtUserCod.Text = _validation.CreateCodeUser(txtNombre.Text + "|" + txtAP.Text + "|" + txtAM.Text, "U");
            }
            else
            {
                txtNombre.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                txtUserCod.Text = _validation.CreateCodeUser(txtNombre.Text + "|" + txtAP.Text + "|" + txtAM.Text, "U");
            }
        }

        private void TxtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Tab)
            {

                if (!_validation.ValidFields(1, txtNombre.Text))
                {
                    txtNombre.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtNombre.ToolTip = "El nombre, tiene que ser texto.";
                }
                else
                {
                    txtNombre.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
                    txtAP.ToolTip = "Campo correcto";
                    txtAP.Focus();
                }
            }
        }

        private void TxtAP_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNombre.Text != "")
            {
                if (txtAP.Text.Length > 0)
                {
                    txtAP.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                    txtUserCod.Text = _validation.CreateCodeUser(txtNombre.Text + "|" + txtAP.Text + "|" + txtAM.Text, "U");
                }
                else
                {
                    txtAP.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtUserCod.Text = _validation.CreateCodeUser(txtNombre.Text + "|" + txtAP.Text + "|" + txtAM.Text, "U");
                }
            }
            else
            {
                txtAP.Text = string.Empty;
                txtNombre.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                txtNombre.ToolTip = "El nombre es requerido.";
                txtNombre.Focus();
            }
        }

        private void TxtAP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Tab)
            {
                if (!_validation.ValidFields(1, txtAP.Text))
                {
                    txtAP.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtAP.ToolTip = "El campo Apellido, tiene que ser texto.";
                }
                else
                {
                    txtAP.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
                    txtAP.ToolTip = "Campo correcto";
                    txtAM.Focus();
                }
            }
        }

        private void TxtAM_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAP.Text != "")
            {
                if (txtAM.Text.Length > 0)
                {
                    txtAM.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                    txtUserCod.Text = _validation.CreateCodeUser(txtNombre.Text + "|" + txtAP.Text + "|" + txtAM.Text, "U");
                }
                else
                {
                    txtAM.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtUserCod.Text = _validation.CreateCodeUser(txtNombre.Text + "|" + txtAP.Text + "|" + txtAM.Text, "U");
                }
            }
            else
            {
                txtAM.Text = string.Empty;
                txtAP.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                txtAP.ToolTip = "El apellido paterno es requerido.";
                txtAP.Focus();
            }
        }

        private void TxtAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Tab)
            {
                if (!_validation.ValidFields(1, txtAM.Text))
                {
                    txtAM.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtAM.ToolTip = "El campo Apellido, tiene que ser texto.";
                }
                else
                {
                    txtAM.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
                    txtAM.ToolTip = "Campo Correcto";
                    txtMail.Focus();
                }
            }
        }

        private void TxtMail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAM.Text != "")
            {
                if (txtMail.Text.Length > 0)
                    txtMail.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            }
            else
            {
                txtMail.Text = string.Empty;
                txtAM.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                txtAM.ToolTip = "El apellido materno es requerido.";
                txtAM.Focus();
            }
        }

        private void TxtMail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Tab)
            {
                if (txtMail.Text !="")
                {
                    if (!_validation.ValidFields(2, txtMail.Text))
                    {
                        txtMail.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                        txtMail.ToolTip = "No es un formato de correo valido.";
                    }
                    else
                    {
                        txtMail.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
                        txtMail.ToolTip = "Campo Correcto";
                        txtNomUser.Focus();
                    }
                }
            }
        }

        private void TxtNomUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAM.Text != "")
            {
                if (txtNomUser.Text.Length > 0)
                {
                    txtNomUser.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                }
                else
                {
                    txtNomUser.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                }
            }
            else
            {
                txtNomUser.Text = string.Empty;
                txtAM.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                txtAM.ToolTip = "El apellido materno es requerido.";
                txtAM.Focus();
            }
        }

        private void TxtNomUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Tab)
            {
                if (!_validation.ValidFields(3, txtNomUser.Text))
                {
                    txtNomUser.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtNomUser.ToolTip = "El nombre de usuario, no admite carateres especiales.";
                }
                else
                {
                    txtNomUser.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
                    txtNomUser.ToolTip = "Campo correcto";
                    txtPassword.Focus();
                }
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Tab)
            {
                if (txtNomUser.Text != "")
                {
                    if (txtPassword.Password.Length > 0)
                    {
                        txtPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                    }
                    else
                    {
                        txtPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    }
                }
                else
                {
                    txtPassword.Password = string.Empty;
                    txtConfirmPassword.Password = string.Empty;
                    txtNomUser.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtNomUser.ToolTip = "El nombre de usuario es requerido.";
                    txtNomUser.Focus();
                }
            }
                   }

        private void TxtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Tab)
            {
                if (txtPassword.Password.Length > 0 && txtConfirmPassword.Password.Length > 0)
                {
                    if (!_validation.ValidPassword(txtPassword.Password, txtConfirmPassword.Password))
                    {
                        txtPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                        txtConfirmPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                        
                        txtConfirmPassword.Password  = string.Empty;

                        txtPassword.ToolTip = "La confirmación de contraseña es incorrecta.";
                        txtPassword.Focus();
                    }
                    else
                    {
                        txtPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
                        txtConfirmPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
                        txtPassword.ToolTip = "Campo correcto";
                        txtConfirmPassword.ToolTip = "Campo correcto";
                        txtNumberPhone.Focus();
                    }
                }
                else
                {
                    txtPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtConfirmPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtPassword.Password  = string.Empty;
                    txtConfirmPassword.Password  = string.Empty;

                    txtPassword.ToolTip = "La contraseña es requerida.";
                    txtPassword.Focus();
                }   
            }
        }
        private void TxtNumberPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPassword.Password != string.Empty || txtConfirmPassword.Password != string.Empty)
            {
                if (txtNumberPhone.Text.Length > 0)
                {
                    txtNumberPhone.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                }
                else
                {
                    txtNumberPhone.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                }
            }
            else
            {
                txtNumberPhone.Text = string.Empty;
                txtPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                txtPassword.ToolTip = "La contraseña es requerida.";
                txtPassword.Password = string.Empty;
                txtConfirmPassword.Password = string.Empty;
                txtPassword.Focus();
            }
        }

        private void TxtNumberPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Tab)
            {
                if (!_validation.ValidFields(4, txtNumberPhone.Text))
                {
                    txtNumberPhone.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtNumberPhone.ToolTip = "El campo telefono, tiene que ser numerico.";
                }
                else
                {
                    txtNumberPhone.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
                    txtNumberPhone.ToolTip = "Campo correcto";
                    cmbRol.Focus();
                }
            }
        }
        private void StartListUsers(int _userId, bool _parameter = false)
        {
            lvUsers.Items.Clear();
            List<Entities.Users> _lstUsers = new List<Entities.Users>();

            if (_parameter)
            {
                _lstUsers = _usersBussiness.SelectUser(_userId, true);
            }
            else
            {
                _lstUsers = _usersBussiness.AllUsers(true);
            }

            for (var i = 0; i < _lstUsers.Count; i++) 
            {
                lvUsers.Items.Add(new Entities.Users
                {
                    UserId = _lstUsers[i].UserId,
                    UserCode = _lstUsers[i].UserCode,
                    Name = _lstUsers[i].Name,
                    LastName = _lstUsers[i].LastName,
                    MotherLastName = _lstUsers[i].MotherLastName,
                    UserName = _lstUsers[i].UserName,
                    Mail = _lstUsers[i].Mail == "" || _lstUsers[i].Mail == null ? "Sin Correo" : _lstUsers[i].Mail.Substring(0,6) + "..."
                });
                
            }
        }
        protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as Entities.Users; 
            
            if (item != null)
            {
                _User.UserId = item.UserId;
                _User.ModByUserId = int.Parse(Uid.Text);
                StartDataFormUpdate(_usersBussiness.SelectUser(item.UserId,true));
            }
        }
        private void StartDataFormUpdate(List<Entities.Users> _lstUsuario)
        {
            if (_lstUsuario.Count > 0) 
            {
                for (var i = 0; i < _lstUsuario.Count; i++)
                {
                    txtUserCod.Text = _lstUsuario[i].UserCode;
                    txtNombre.Text = _lstUsuario[i].Name;
                    txtAP.Text = _lstUsuario[i].LastName;
                    txtAM.Text = _lstUsuario[i].MotherLastName;
                    txtMail.Text = _lstUsuario[i].Mail;
                    txtNomUser.Text = _lstUsuario[i].UserName;
                    txtPassword.Password = _lstUsuario[i].Password;
                    txtConfirmPassword.Password = string.Empty;
                    txtNumberPhone.Text = _lstUsuario[i].PhoneNumber;
                    cmbRol.Text = _lstUsuario[i].Rol.NameRole;
                    btnGuardar.Visibility = Visibility.Collapsed;
                    btnModifica.Visibility = Visibility.Visible;

                    lblEstatus.Visibility = Visibility.Visible;
                    rbEstatus.Visibility = Visibility.Visible;
                    rbEstatus.IsChecked = bool.Parse(_lstUsuario[i].IsActive.ToString());
                }
            }
            else
            {
                matMessageBox.TypeMessageBox("Usuarios","Ocurrio un error al consultar intente nuevamente.",2);
            }
            
        }
        private void StartRoles()
        {
            List<Entities.Role> _lstRole = new List<Entities.Role>();
            List<Entities.Role> _lstRoleCMB = new List<Entities.Role>();

            _lstRole = _roleBussiness.ProccessRole();


            for (var i = 0; i < _lstRole.Count; i++)
            {
                if (_lstRole[i].EstatusTransaccion)
                    _lstRoleCMB.Add(new Entities.Role { RoleId = _lstRole[i].RoleId, NameRole = _lstRole[i].NameRole });

                if (_lstRoleCMB.Count < 1)
                    _lstRoleCMB.Add(new Entities.Role { RoleId = -0, NameRole = "Sin Resultados" });

            }

            cmbRol.ItemsSource = _lstRoleCMB;
            cmbRol.SelectedValue = 1;
        }
        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            _User.UserCode = txtUserCod.Text;
            _User.Name = txtNombre.Text;
            _User.LastName = txtAP.Text;
            _User.MotherLastName = txtAM.Text;
            _User.Mail = txtMail.Text;
            _User.UserName = txtNomUser.Text;
            _User.Password = txtConfirmPassword.Password;
            _User.PhoneNumber = txtNumberPhone.Text;
            _User.Rol = new Entities.Role();
            _User.Rol.RoleId = int.Parse(cmbRol.SelectedValue.ToString());
            _User.Sex = null;
            _User.BirthDay = null;
            _User.TypeUser = true;
            _User.AddByUserId = int.Parse(Uid.Text);
            _User.ModByUserId = int.Parse(Uid.Text);


            if (_User.Imagen == null)
            {
                _User.Imagen = new Entities.ImageUser();
                Bitmap _bmImage = new Bitmap(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "imguser.png");
                _User.Imagen.Image = util.ImageToByte(_bmImage);
                _User.Imagen.width_Img = _bmImage.Width;
                _User.Imagen.height_Img = _bmImage.Height;
            }

            if (_validation.ValidFormUser(_User))
            {
                if (_validation.ValidPassword(txtPassword.Password, txtConfirmPassword.Password))
                {
                    var resp = _usersBussiness.CreateUser(_User);

                    if (resp.EstatusTransaccion)
                    {
                        matMessageBox.TypeMessageBox("Usuarios", resp.Mensaje, 1);
                        StartListUsers(0);
                        _User = new Entities.Users();
                        BtnLimpiar_Click(null, null);
                    }
                }
                else
                {
                    txtPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtConfirmPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtPassword.Password = string.Empty;
                    txtConfirmPassword.Password = string.Empty;

                    txtPassword.ToolTip = "La contraseña es requerida.";
                    txtConfirmPassword.ToolTip = "La contraseña es requerida.";
                    txtPassword.Focus();
                }
            }
            else
            {
                if(txtNombre.Text == string.Empty)
                    txtNombre.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");

                if (txtAP.Text == string.Empty)
                    txtAP.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");

                if (txtAM.Text == string.Empty)
                    txtAM.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");

                if (txtNomUser.Text == string.Empty)
                    txtNomUser.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");

                if (txtPassword.Password == string.Empty)
                    txtPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");

                if (txtConfirmPassword.Password == string.Empty)
                    txtConfirmPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");

                matMessageBox.TypeMessageBox("Usuarios", "Todos los campos en rojo son obligatorios.", 2);
            }
            
        }

        private void BtnModifica_Click(object sender, RoutedEventArgs e)
        {
            _User.UserCode = txtUserCod.Text;
            _User.Name = txtNombre.Text;
            _User.LastName = txtAP.Text;
            _User.MotherLastName = txtAM.Text;
            _User.Mail = txtMail.Text;
            _User.UserName = txtNomUser.Text;
            _User.Password = txtConfirmPassword.Password;
            _User.PhoneNumber = txtNumberPhone.Text;
            _User.IsActive = rbEstatus.IsChecked;

            if (_User.Imagen == null)
            {
                _User.Imagen = new Entities.ImageUser();
                Bitmap _bmImage = new Bitmap(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "imguser.png");
                _User.Imagen.Image = util.ImageToByte(_bmImage);
                _User.Imagen.width_Img = _bmImage.Width;
                _User.Imagen.height_Img = _bmImage.Height;
            }

            if (_validation.ValidFormUser(_User))
            {
                if (_validation.ValidPassword(txtPassword.Password, txtConfirmPassword.Password))
                {
                    var resp = _usersBussiness.UpdateUser(_User);

                    if (resp.EstatusTransaccion)
                    {
                        matMessageBox.TypeMessageBox("Usuarios", resp.Mensaje, 1);
                        StartListUsers(0);
                        _User = new Entities.Users();
                        BtnLimpiar_Click(null, null);
                    }
                    else
                    {
                        matMessageBox.TypeMessageBox("Usuarios", resp.Mensaje, 2);
                        _User = new Entities.Users();
                    }
                }
                else
                {
                    txtPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtConfirmPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtPassword.Password = string.Empty;
                    txtConfirmPassword.Password = string.Empty;

                    txtPassword.ToolTip = "La contraseña es requerida.";
                    txtConfirmPassword.ToolTip = "La contraseña es requerida.";
                    txtPassword.Focus();
                }
               
            }
            else
            {
                matMessageBox.TypeMessageBox("Usuarios", "Todos los campos en rojo son obligatorios.", 2);
            }
        }
        private void RbEstatus_Click(object sender, RoutedEventArgs e)
        {
            _User.IsActive = rbEstatus.IsChecked;
            var respuesta = _usersBussiness.UpdateEstatusUser(_User);

            if (!respuesta.EstatusTransaccion)
            {
                matMessageBox.TypeMessageBox("Usuarios", respuesta.Mensaje, 2);
                StartListUsers(0);
                _User = new Entities.Users();
                BtnLimpiar_Click(null, null);
            }
        }
        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtAP.Text = string.Empty;
            txtAM.Text = string.Empty;
            txtUserCod.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtNomUser.Text = string.Empty;
            txtPassword.Password = string.Empty;
            txtConfirmPassword.Password = string.Empty;
            txtNumberPhone.Text = string.Empty;
            cmbRol.Text = string.Empty;

            lblEstatus.Visibility = Visibility.Collapsed;
            rbEstatus.Visibility = Visibility.Collapsed;
            rbEstatus.IsChecked = false;

            _User.Imagen = new Entities.ImageUser();

            txtNombre.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            txtAP.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            txtAM.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            txtNomUser.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            txtPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            txtConfirmPassword.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            txtMail.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            txtNumberPhone.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

            btnGuardar.Visibility = Visibility.Visible;
            btnModifica.Visibility = Visibility.Collapsed;
            BtnTrash_Click(null, null);
            txtNombre.Focus();
        }

        private void TxtBuscaRegistros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                lvUsers.Items.Clear();
                List<Entities.Users> _lstUsers = new List<Entities.Users>();

                if (txtBuscaRegistros.Text != "")
                {
                    _lstUsers = _usersBussiness.SearchUser(txtBuscaRegistros.Text, true);
                }
                else
                {
                    _lstUsers = _usersBussiness.AllUsers(true);
                }


                for (var i = 0; i < _lstUsers.Count; i++)
                {
                    lvUsers.Items.Add(new Entities.Users
                    {
                        UserId = _lstUsers[i].UserId,
                        UserCode = _lstUsers[i].UserCode,
                        Name = _lstUsers[i].Name,
                        LastName = _lstUsers[i].LastName,
                        MotherLastName = _lstUsers[i].MotherLastName,
                        UserName = _lstUsers[i].UserName,
                        Mail = _lstUsers[i].Mail == "" || _lstUsers[i].Mail == null ? "Sin Correo" : _lstUsers[i].Mail.Substring(0, 6) + "...",
                        Rol = new Entities.Role
                        {
                            RoleId = _lstUsers[i].Rol.RoleId,
                            NameRole = _lstUsers[i].Rol.NameRole
                        }
                    });

                }
            }
           
        }

        private void btnLoadImag_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (*.png) | *.png";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
            {
                imgSocio.ImageSource = util.GetGlowingImage(openFileDialog.FileName);
                btnTrash.Visibility = Visibility.Visible;

                Bitmap _bmImage = new Bitmap(openFileDialog.FileName);

                _User.Imagen = new Entities.ImageUser();
                _User.Imagen.Image = util.ImageToByte(_bmImage);
                _User.Imagen.width_Img = _bmImage.Width;
                _User.Imagen.height_Img = _bmImage.Height;
            }

        }

        private void BtnTrash_Click(object sender, RoutedEventArgs e)
        {
            imgSocio.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "socios.png");
            btnTrash.Visibility = Visibility.Collapsed;
        }

        
    }
}
