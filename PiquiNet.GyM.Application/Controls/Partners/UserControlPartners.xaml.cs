using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using PiquiNet.GyM.FingerPrint;
using PiquiNet.GyM.Utilities;
using BespokeFusion;
using Microsoft.Win32;
using System.Drawing;
using System.Configuration;
using DPUruNet;
using System.Threading;
using System.Diagnostics;
using System.Globalization;

namespace PiquiNet.GyM.Application.Controls.Partners
{
    /// <summary>
    /// Lógica de interacción para UserControlPartners.xaml
    /// </summary>
    public partial class UserControlPartners : UserControl
    {
        ReaderFinger readerFinger = new ReaderFinger();
        Validations _validation = new Validations();
        Util util = new Util();
        Security _security = new Security();
        Bussiness.Users _usersBussiness = new Bussiness.Users();
        MatMessageBox matMessageBox = new MatMessageBox();


        private ReaderCollection _readers;
        private bool reset;
        //private Reader currentReader;
        private int numOfProcess;
        int _counteoHuella = 1;

        Entities.Users _User = new Entities.Users();

        public UserControlPartners()
        {
            InitializeComponent();
            txtNombre.Focus();
            StartListUsers(0);
            btnGuardar.Visibility = Visibility.Visible;
            imgSocio.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "socios.png");
            ImgBrushUserHuella.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "huella.jpg");
            _User.Imagen = new Entities.ImageUser();
        }
       
        // When set by child forms, shows s/n and enables buttons.
        public Reader CurrentReader
        {
            get { return currentReader; }
            set
            {
                currentReader = value;
                SendMessage(Action.SendBitmap, value);
            }
        }
        private Reader currentReader;


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentReader == null)
            {
                OpenReader();
                _counteoHuella = 1;
            }
        }
        private void TxtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNombre.Text.Length > 0)
            {
                txtNombre.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                txtUserCod.Text = _validation.CreateCodeUser(txtNombre.Text + "|" + txtAP.Text + "|" + txtAM.Text, "S");
            }
            else
            {
                txtNombre.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                txtUserCod.Text = _validation.CreateCodeUser(txtNombre.Text + "|" + txtAP.Text + "|" + txtAM.Text, "S");
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
                    txtUserCod.Text = _validation.CreateCodeUser(txtNombre.Text + "|" + txtAP.Text + "|" + txtAM.Text, "S");
                }
                else
                {
                    txtAP.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtUserCod.Text = _validation.CreateCodeUser(txtNombre.Text + "|" + txtAP.Text + "|" + txtAM.Text, "S");
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
                    txtUserCod.Text = _validation.CreateCodeUser(txtNombre.Text + "|" + txtAP.Text + "|" + txtAM.Text, "S");
                }
                else
                {
                    txtAM.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                    txtUserCod.Text = _validation.CreateCodeUser(txtNombre.Text + "|" + txtAP.Text + "|" + txtAM.Text, "S");
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
                if (txtMail.Text != "")
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
                        txtMail.Focus();
                    }
                }
            }
        }


        private void StartListUsers(int _userId, bool _parameter = false)
        {
            lvUsers.Items.Clear();
            List<Entities.Users> _lstUsers = new List<Entities.Users>();

            if (_parameter)
            {
                _lstUsers = _usersBussiness.SelectUser(_userId, false);
            }
            else
            {
                _lstUsers = _usersBussiness.AllUsers(false);
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
                    Mail = _lstUsers[i].Mail == "" || _lstUsers[i].Mail == null ? "Sin Correo" : _lstUsers[i].Mail,
                    PhoneNumber = _lstUsers[i].PhoneNumber == null ? "Sin Teléfono" : _lstUsers[i].PhoneNumber,
                    DateAdd = _lstUsers[i].DateAdd
                    //DateAdd = DateTime.ParseExact(_lstUsers[i].DateAdd.ToString().Substring(0, 10), "dd/MM/yyyy", CultureInfo.InvariantCulture)

                });
            }
        }

        protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as Entities.Users;
                        
            if (item != null)
            {
                if (currentReader == null)
                {
                    OpenReader();
                    _counteoHuella = 1;
                }

                _User.UserId = item.UserId;
                _User.ModByUserId = int.Parse(Uid.Text);
                StartDataFormUpdate(_usersBussiness.SelectUser(item.UserId, false));
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
                    txtNumberPhone.Text = _lstUsuario[i].PhoneNumber;
                    btnMembership.Visibility = Visibility.Visible;

                    if(_lstUsuario[i].BirthDay != null)
                        txtFechaNac.Text = _lstUsuario[i].BirthDay.ToString().Substring(0, 10);

                    btnGuardar.Visibility = Visibility.Collapsed;
                    btnModifica.Visibility = Visibility.Visible;

                    lblEstatus.Visibility = Visibility.Visible;
                    rbEstatus.Visibility = Visibility.Visible;
                    rbEstatus.IsChecked = bool.Parse(_lstUsuario[i].IsActive.ToString());

                    if (bool.Parse(_lstUsuario[i].Sex.ToString()))
                    {
                        Mujer.IsChecked = true;
                        Hombre.IsChecked = false;
                    }
                    else
                    {
                        Mujer.IsChecked = false;
                        Hombre.IsChecked = true;
                    }

                    _User.Imagen = _lstUsuario[i].Imagen;
                }
            }
            else
            {
                matMessageBox.TypeMessageBox("Usuarios", "Ocurrio un error al consultar intente nuevamente.", 2);
            }
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            _User.UserCode = txtUserCod.Text;
            _User.Name = txtNombre.Text;
            _User.LastName = txtAP.Text;
            _User.MotherLastName = txtAM.Text;
            _User.Mail = txtMail.Text;
            _User.UserName = txtUserCod.Text;
            _User.Password = txtUserCod.Text;
            _User.PhoneNumber = txtNumberPhone.Text;

            _User.Rol = new Entities.Role();
            _User.Rol.RoleId = 3;
            _User.BirthDay = null;

            if (txtFechaNac.Text != string.Empty)
                _User.BirthDay = DateTime.Parse(txtFechaNac.Text);

            _User.TypeUser = false;
            _User.AddByUserId = int.Parse(Uid.Text);
            _User.ModByUserId = int.Parse(Uid.Text);


            if (_User.Imagen == null || _User.Imagen.Image == null)
            {
                Bitmap _bmImage = new Bitmap(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "imguser.png");
                _User.Imagen.Image = util.ImageToByte(_bmImage);
                _User.Imagen.width_Img = _bmImage.Width;
                _User.Imagen.height_Img = _bmImage.Height;
            }

            if (_validation.ValidFormUser(_User,true))
            {
                var resp = _usersBussiness.CreateUser(_User);

                if (resp.EstatusTransaccion)
                {
                    matMessageBox.TypeMessageBox("Usuarios", resp.Mensaje, 1);
                    StartListUsers(0);
                    _User = new Entities.Users();
                    BtnLimpiar_Click(null, null);
                    CancelCaptureAndCloseReader(this.OnCaptured);
                }
            }
            else
            {
                if (txtNombre.Text == string.Empty)
                    txtNombre.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");

                if (txtAP.Text == string.Empty)
                    txtAP.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");

                if (txtAM.Text == string.Empty)
                    txtAM.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
               

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
            _User.UserName = txtUserCod.Text;
            _User.Password = txtUserCod.Text;
            _User.PhoneNumber = txtNumberPhone.Text;

            _User.Rol = new Entities.Role();
            _User.Rol.RoleId = 3;
            _User.BirthDay = null;

            if (txtFechaNac.Text != string.Empty)
                _User.BirthDay = DateTime.Parse(txtFechaNac.Text);

            _User.TypeUser = false;
            _User.AddByUserId = int.Parse(Uid.Text);
            _User.ModByUserId = int.Parse(Uid.Text);


            if (_User.Imagen == null || _User.Imagen.Image == null)
            {
                Bitmap _bmImage = new Bitmap(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "imguser.png");
                _User.Imagen.Image = util.ExtractByteArray(_bmImage);
                _User.Imagen.width_Img = _bmImage.Width;
                _User.Imagen.height_Img = _bmImage.Height;
            }


            if (_validation.ValidFormUser(_User,true))
            {
                var resp = _usersBussiness.UpdateUser(_User);

                if (resp.EstatusTransaccion)
                {
                    matMessageBox.TypeMessageBox("Usuarios", resp.Mensaje, 1);
                    StartListUsers(0);
                    _User = new Entities.Users();
                    BtnLimpiar_Click(null, null);
                    CancelCaptureAndCloseReader(this.OnCaptured);
                }
                else
                {
                    matMessageBox.TypeMessageBox("Usuarios", resp.Mensaje, 2);
                    _User = new Entities.Users();
                    CancelCaptureAndCloseReader(this.OnCaptured);
                }
            }
            else
            {
                matMessageBox.TypeMessageBox("Usuarios", "Todos los campos en rojo son obligatorios.", 2);
            }
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtAP.Text = string.Empty;
            txtAM.Text = string.Empty;
            txtUserCod.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtNumberPhone.Text = string.Empty;
            txtFechaNac.Text = string.Empty;
            Mujer.IsChecked = false;
            Hombre.IsChecked = false;

            lblEstatus.Visibility = Visibility.Collapsed;
            rbEstatus.Visibility = Visibility.Collapsed;
            rbEstatus.IsChecked = false;

            txtNombre.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            txtAP.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            txtAM.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            txtMail.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            txtNumberPhone.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

            btnGuardar.Visibility = Visibility.Visible;
            btnModifica.Visibility = Visibility.Collapsed;
            BtnTrash_Click(null, null);
            txtNombre.Focus();

            //Colors.DarkBlue

            _User.Imagen = new Entities.ImageUser();
            ImgBrushUserHuella.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "huella.jpg");

            iH1.Kind = MaterialDesignThemes.Wpf.PackIconKind.Numeric1BoxOutline;
            H1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("DodgerBlue");

            iH2.Kind = MaterialDesignThemes.Wpf.PackIconKind.Numeric2BoxOutline;
            H2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("DodgerBlue");

            iH3.Kind = MaterialDesignThemes.Wpf.PackIconKind.Numeric3BoxOutline;
            H3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("DodgerBlue");

            txtHuellas.Text = "Capture 3 huellas del socio.";

            CancelCaptureAndCloseReader(this.OnCaptured);

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

                _User.Imagen.Image = util.ExtractByteArray(_bmImage);
                _User.Imagen.width_Img = _bmImage.Width;
                _User.Imagen.height_Img = _bmImage.Height;
            }

        }

        private void BtnTrash_Click(object sender, RoutedEventArgs e)
        {
            imgSocio.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "socios.png");
            btnTrash.Visibility = Visibility.Collapsed;
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

        private void Mujer_Click(object sender, RoutedEventArgs e)
        {
            _User.Sex = true;
        }

        private void Hombre_Click(object sender, RoutedEventArgs e)
        {
            _User.Sex = false;
        }
        private void TxtBuscaRegistros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                lvUsers.Items.Clear();
                List<Entities.Users> _lstUsers = new List<Entities.Users>();

                if (txtBuscaRegistros.Text != "")
                {
                    _lstUsers = _usersBussiness.SearchUser(txtBuscaRegistros.Text, false);
                }
                else
                {
                    _lstUsers = _usersBussiness.AllUsers(false);
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
                        Mail = _lstUsers[i].Mail == "" || _lstUsers[i].Mail == null ? "Sin Correo" : _lstUsers[i].Mail,
                        PhoneNumber = _lstUsers[i].PhoneNumber == null ? "Sin Teléfono": _lstUsers[i].PhoneNumber,
                        DateAdd = _lstUsers[i].DateAdd

                    });

                }
            }

        }

        private void SalirMod_Click(object sender, RoutedEventArgs e)
        {
            DialogHost.IsOpen = false;
        }

        /// <summary>
        /// Open a device and check result for errors.
        /// </summary>
        /// <returns>Returns true if successful; false if unsuccessful</returns>
        public void OpenReader()
        {
            reset = false;
            currentReader = null;

            Constants.ResultCode result = Constants.ResultCode.DP_DEVICE_FAILURE;

            _readers = ReaderCollection.GetReaders();
            foreach (Reader Reader in _readers)
            {
                currentReader = Reader;
            }

            if (currentReader != null)
            {
                // Open reader
                result = currentReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);

                if (result != Constants.ResultCode.DP_SUCCESS)
                {
                    reset = true;
                }
                else
                {
                  StartCaptureAsync(OnCaptured);
                }
            }

        }

        /// <summary>
        /// Handler for when a fingerprint is captured.
        /// </summary>
        /// <param name="captureResult">contains info and data on the fingerprint capture</param>
        public void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                // Check capture quality and throw an error if bad.
                if (!readerFinger.CheckCaptureResult(captureResult)) return;
                // Create bitmap
                foreach (Fid.Fiv fiv in captureResult.Data.Views)
                {
                    SendMessage(Action.SendBitmap, readerFinger.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                }
            }
            catch (Exception ex)
            {
                // Send error message, then close form
                //SendMessage(Action.SendMessage, "Error:  " + ex.Message);
               // matMessageBox.TypeMessageBox("Socios", "Ocurrio un error con el lector, desconecte y vuelva a conectar.", 3);
            }
        }

        /// <summary>
        /// Hookup capture handler and start capture.
        /// </summary>
        /// <param name="OnCaptured">Delegate to hookup as handler of the On_Captured event</param>
        /// <returns>Returns true if successful; false if unsuccessful</returns>
        public bool StartCaptureAsync(Reader.CaptureCallback OnCaptured)
        {
            // Activate capture handler
            currentReader.On_Captured += new Reader.CaptureCallback(OnCaptured);

            //Call capture
            if (!CaptureFingerAsync())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Function to capture a finger. Always get status first and calibrate or wait if necessary.  Always check status and capture errors.
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public bool CaptureFingerAsync()
        {
            try
            {
                GetStatus();

                Constants.ResultCode captureResult = currentReader.CaptureAsync(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, currentReader.Capabilities.Resolutions[0]);
                if (captureResult != Constants.ResultCode.DP_SUCCESS)
                {
                    reset = true;
                   // matMessageBox.TypeMessageBox("Socios", "Ocurrio un error con el lector, desconecte y vuelva a conectar.", 3);
                }

                return true;
            }
            catch (Exception ex)
            {
               // matMessageBox.TypeMessageBox("Socios", "Ocurrio un error con el lector, desconecte y vuelva a conectar.", 3);
                return false;
            }
        }

        /// <summary>
        /// Check the device status before starting capture.
        /// </summary>
        /// <returns></returns>
        public void GetStatus()
        {
            Constants.ResultCode result = currentReader.GetStatus();

            if ((result != Constants.ResultCode.DP_SUCCESS))
            {
                reset = true;
                //matMessageBox.TypeMessageBox("Socios", "Ocurrio un error con el lector, desconecte y vuelva a conectar.", 3);
            }

            if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY))
            {
                Thread.Sleep(50);
            }
            else if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
            {
                currentReader.Calibrate();
            }
            else if ((currentReader.Status.Status != Constants.ReaderStatuses.DP_STATUS_READY))
            {
                //matMessageBox.TypeMessageBox("Socios", "Ocurrio un error con el lector, desconecte y vuelva a conectar.", 3);
            }
        }

        private enum Action
        {
            SendBitmap,
            SendMessage
        }
        private delegate void SendMessageCallback(Action action, object payload);
        private void SendMessage(Action action, object payload)
        {
            
            try
            {
                switch (action)
                {
                    case Action.SendMessage:
                        _counteoHuella = 0;
                        //ImgBrushUserHuella.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "huella.jpg");
                        break;

                    case Action.SendBitmap:

                        Task checkProcess = new Task(() =>
                        {
                            if (Process.GetProcesses().Count() > numOfProcess)
                                this.Dispatcher.Invoke(() =>
                                {
                                    if (_counteoHuella <= 3)
                                    {
                                        ImgBrushUserHuella.ImageSource = util.ImageSourceFromBitmap((Bitmap)payload);
                                        switch (_counteoHuella)
                                        {
                                            case 1:
                                                _User.Imagen.Huella_1 = util.ExtractByteArray((Bitmap)payload);
                                                _User.Imagen.width_H = 357;
                                                _User.Imagen.height_H = 392;
                                                //H1.Visibility = Visibility.Visible;
                                                iH1.Kind = MaterialDesignThemes.Wpf.PackIconKind.Check;
                                                H1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
                                                txtHuellas.Text = "Faltan 2 huellas.";
                                                _counteoHuella = 2;
                                                break;

                                            case 2:
                                                _User.Imagen.Huella_2 = util.ExtractByteArray((Bitmap)payload);
                                                _User.Imagen.width_H = 357;
                                                _User.Imagen.height_H = 392;
                                                //H2.Visibility = Visibility.Visible;
                                                H2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
                                                iH2.Kind = MaterialDesignThemes.Wpf.PackIconKind.Check;
                                                txtHuellas.Text = "Falta 1 huella.";
                                                _counteoHuella = 3;
                                                break;

                                            case 3:
                                                _User.Imagen.Huella_3 = util.ExtractByteArray((Bitmap)payload);
                                                _User.Imagen.width_H = 357;
                                                _User.Imagen.height_H = 392;
                                                //H3.Visibility = Visibility.Visible;
                                                H3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
                                                iH3.Kind = MaterialDesignThemes.Wpf.PackIconKind.Check;
                                                txtHuellas.Text = "Huellas capturadas.";
                                                _counteoHuella = 4;
                                                
                                                CancelCaptureAndCloseReader(this.OnCaptured);
                                                break;

                                            default:
                                                
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        CancelCaptureAndCloseReader(this.OnCaptured);
                                        txtHuellas.Text = "Ya capturo las 3 huellas.";
                                    }
                                });
                        });
                        checkProcess.Start();

                        break;
                }
            }
            catch (Exception ex)
            {
               // matMessageBox.TypeMessageBox("Socios", "Ocurrio un error con el lector, desconecte y vuelva a conectar.", 3);
            }
        }

        /// <summary>
        /// Cancel the capture and then close the reader.
        /// </summary>
        /// <param name="OnCaptured">Delegate to unhook as handler of the On_Captured event </param>
        public void CancelCaptureAndCloseReader(Reader.CaptureCallback OnCaptured)
        {
            if (currentReader != null)
            {
                currentReader.CancelCapture();

                // Dispose of reader handle and unhook reader events.
                currentReader.Dispose();

                if (reset)
                {
                    CurrentReader = null;
                }
            }
        }

        private void H1_Click(object sender, RoutedEventArgs e)
        {  
        }

        private void H2_Click(object sender, RoutedEventArgs e)
        {
        }

        private void H3_Click(object sender, RoutedEventArgs e)
        {
        }

        private async void BtnMembership_Click(object sender, RoutedEventArgs e)
        {
            var Modal = new Entities.Partners()
            {
                propTextBlock = new Entities.PropertyTextBlock
                {
                    FontFamily = "Century Gothic",
                    Margin = new Thickness(2, 2, 2, 2)
                },

                Codigo = "ELU270719S",
                NombreCompleto = "Edilberto López Ubaldo",
                Telefono = "7131370380",
                imgSocioModal = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "socios.png")
            };
            

            //DialogHost.IsOpen = true;
            await MaterialDesignThemes.Wpf.DialogHost.Show(Modal);
        }

    }
}
