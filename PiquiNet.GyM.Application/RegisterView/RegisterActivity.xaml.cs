using DPUruNet;
using PiquiNet.GyM.FingerPrint;
using PiquiNet.GyM.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace PiquiNet.GyM.Application.RegisterView
{
    /// <summary>
    /// Lógica de interacción para RegisterActivity.xaml
    /// </summary>
    public partial class RegisterActivity
    {
        DispatcherTimer timer = new DispatcherTimer();
        ReaderFinger readerFinger = new ReaderFinger();
        Validations _validation = new Validations();
        Util util = new Util();
        Security _security = new Security();
        Bussiness.HuellasUser _HuellasUserBussiness = new Bussiness.HuellasUser();

        private ReaderCollection _readers;
        private bool reset;
        private int numOfProcess;
        private int _counteoHuella = 0;
        private bool _IsValidH= false;
        string result = string.Empty;
        List<Entities.Users> _lstHuellas = new List<Entities.Users>();
        Fmd FingerRecultConvert = null;
        Bitmap _scannedFingerPrint = null;

        public RegisterActivity()
        {
            InitializeComponent();
            cardDatos.Visibility = Visibility.Collapsed;
        }

        // When set by child forms, shows s/n and enables buttons.
        public Reader CurrentReader
        {
            get { return currentReader; }
            set
            {
                currentReader = value;
            }
        }
        
        private Reader currentReader;

        private void ObtenerHUellas()
        {
            _lstHuellas = null;
            _lstHuellas = _HuellasUserBussiness.AllUsersHuellas();
        }
        public void OpenRegister()
        {
            ObtenerHUellas();
            OpenReader();

            InitializeBackground(DateTime.Now.ToString(@"dddd"));
            StartClock();
            titleH.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
            titleH.Text = "Identificate";
            ImgBrushUserHuella.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "huella.jpg");
            btnHuella.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("DodgerBlue");

            this.Show();
            this.Focus();
        }

        public void CloseRegister()
        {
            CancelCaptureAndCloseReader(this.OnCaptured);
            this.Close();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton.ToString() == "Left")
                DragMove();
        }

        private void StartClock()
        {

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();
        }

        private void tickevent(object sender, EventArgs e)
        {
            var diaText = DateTime.Now.ToString(@"dddd");
            var dia = DateTime.Now.ToString(@"dd");
            var mes = DateTime.Now.ToString(@"MMMM");
            var hora = DateTime.Now.ToString(@"hh:mm:ss tt", new CultureInfo("en-US"));

            fechaRegistro.Text = diaText.ToUpper() + " " + dia + " DE " + mes.ToUpper();
            horaRegistro.Text = hora;
        }

        private void InitializeBackground(string _dia)
        {
            switch (_dia)
            {
                case "lunes":
                    ImgBrushBackground.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "lunes.jpg");
                    break;

                case "martes":
                    ImgBrushBackground.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "martes.jpg");
                    break;

                case "miércoles":
                    ImgBrushBackground.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "miercoles.jpg");
                    break;

                case "jueves":
                    ImgBrushBackground.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "jueves.jpg");
                    break;

                case "viernes":
                    ImgBrushBackground.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "viernes.jpg");
                    break;

                case "sábado":
                    ImgBrushBackground.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "sabado.jpg");
                    break;

                case "domingo":
                    ImgBrushBackground.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "domingo.jpg");
                    break;

            }
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
        /// <param name="fingerprint">contains info and data on the fingerprint capture</param>
        public void OnCaptured(CaptureResult fingerprint)
        {
            try
            {
                Entities.Users _user = new Entities.Users();
                // Check capture quality and throw an error if bad.
                if (!readerFinger.CheckCaptureResult(fingerprint)) return;
               
                else
                {
                    //SendMessage(Action.ClearWindow, "");
                    _IsValidH = false;
                    CompareResult _statusCompare = null;
                    Fmd _ResultFingerScan = null;

                    _ResultFingerScan = ConvertFingerScan(fingerprint);
                    RenderFingerScan();

                    _counteoHuella = _counteoHuella + 1;

                    if (_counteoHuella == 3)
                    {
                        _counteoHuella = 0;
                        _user.Name = "Si esto es un error, consultelo con el administrador.";
                        SendMessage(Action.UserDonotExist, _user);
                        Thread.Sleep(5000);
                    }
                    else
                    {
                        for (var i = 0; i < _lstHuellas.Count; i++)
                        {
                            if (_lstHuellas[i].Imagen.lstFingerFmd != null)
                            {
                                for (var h = 0; h < _lstHuellas[i].Imagen.lstFingerFmd.Count; h++)
                                {
                                    Fmd _ResultFingerBD = null;
                                    _ResultFingerBD = _lstHuellas[i].Imagen.lstFingerFmd[h];

                                    _statusCompare = Comparison.Compare(_ResultFingerBD, 0, _ResultFingerScan, 0);

                                    if (_statusCompare != null)
                                    {
                                        if (_statusCompare.ResultCode == Constants.ResultCode.DP_SUCCESS && _statusCompare.Score == 0)
                                        {
                                            SendMessage(Action.AuthenticatedUser, _lstHuellas[i]);
                                            _counteoHuella = 0;

                                            _IsValidH = true;
                                            break;
                                        }
                                    }
                                }

                                if (_statusCompare.ResultCode == Constants.ResultCode.DP_SUCCESS && _statusCompare.Score == 0)
                                {
                                    _counteoHuella = 0;
                                    break;
                                }
                            }                            
                        }

                        if (_IsValidH == false && _counteoHuella <= 3)
                        {
                            _user.Name = "Intenta nuevamente.";
                            SendMessage(Action.Retry, _user);

                            _IsValidH = false;

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void RenderFingerScan()
        {
            Task ProssesClearMeesage = new Task(() =>
            {
                if (Process.GetProcesses().Count() > numOfProcess)
                    this.Dispatcher.Invoke(() =>
                    {

                        ImgBrushUserHuella.ImageSource = util.ImageSourceFromBitmap(_scannedFingerPrint);

                    });
            });
            ProssesClearMeesage.Start();
        }

        private Fmd ConvertFingerScan(CaptureResult scannedFingerPrintCR)
        {
            try
            {
                FingerRecultConvert = null;
                _scannedFingerPrint = null;

                foreach (Fid.Fiv fiv in scannedFingerPrintCR.Data.Views)
                {
                    _scannedFingerPrint = readerFinger.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height);
                }

                DataResult<Fmd> resultConversion = util.ExtractFmdfromBmp(_scannedFingerPrint);
                FingerRecultConvert = resultConversion.Data;
            }
            catch (Exception ex)
            {
                FingerRecultConvert = null;
            }
            return FingerRecultConvert;
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
            AuthenticatedUser,
            Retry,
            ExpiredMembership,
            UserDonotExist,
            ClearWindow
        }
        private delegate void SendMessageCallback(Action action, object message);
        private void SendMessage(Action action, object user)
        {
            try
            {
                Task ProssesMeesage = new Task(() =>
                {
                    if (Process.GetProcesses().Count() > numOfProcess)
                        this.Dispatcher.Invoke(() =>
                        {
                            Entities.Users _userProccess = new Entities.Users();
                            _userProccess = (Entities.Users)user;

                            var propTextBlock = new Entities.PropertyTextBlock
                            {
                                FontFamily = "Century Gothic"
                                // Margin = new Thickness(2, 2, 2, 2)
                            };

                            switch (action)
                            {
                                case Action.AuthenticatedUser:
                                    
                                    titleH.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");

                                    if (_userProccess.Sex == true)
                                    {
                                        titleH.Text = "¡ Bienvenida !";
                                    }
                                    else
                                    {
                                        titleH.Text = "¡ Bienvenido !";
                                    }
                                    
                                    //ImgBrushUserHuella.ImageSource = util.ImageSourceFromBitmap(imageByte);

                                    NomUser.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                                    NomUser.Text = _userProccess.Name;

                                    cardDatos.Visibility = Visibility.Visible;

                                    if (_userProccess.Membrecia.IsActive)
                                    {
                                        btnHuella.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
                                        stakBarra.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");

                                        detalleDatos.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("LimeGreen");
                                        dato_1.Text = "Tipo de Membrecia: " + _userProccess.Membrecia.Membrecia;
                                        dato_2.Text = "Fecha de Alta: " + _userProccess.Membrecia.FechaFin;
                                        dato_3.Text = "Resta: " + _userProccess.Membrecia.DiasRestantes + (_userProccess.Membrecia.DiasRestantes == 1 ? " Día" : " Dias");
                                    }
                                    else
                                    {
                                        btnHuella.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                                        stakBarra.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");

                                        detalleDatos.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                                        dato_1.Text = "Tipo de Membrecia: " + _userProccess.Membrecia.Membrecia;
                                        dato_2.Text = "Fecha de Alta: " + _userProccess.Membrecia.FechaFin;
                                        dato_3.Text = "Tu membrecia esta vencida, agradeceremos tu pago.";
                                    }
                                    
                                    break;

                                case Action.Retry:

                                    btnHuella.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Orange");
                                    stakBarra.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Orange");

                                    titleH.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                                    titleH.Text = "¡Hooops! algo salio mal";
                                    //ImgBrushUserHuella.ImageSource = util.ImageSourceFromBitmap(imageByte);

                                    NomUser.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                                    NomUser.Text = _userProccess.Name;

                                    cardDatos.Visibility = Visibility.Collapsed;

                                    break;

                                case Action.ExpiredMembership:

                                    btnHuella.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Orange");
                                    stakBarra.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Orange");

                                    titleH.Text = "¡Hooops! Parece que no has pagado";
                                    //ImgBrushUserHuella.ImageSource = util.ImageSourceFromBitmap(imageByte);
                                    NomUser.Text = _userProccess.Name;
                                    //error.Text = "Es necesario que acudas con el administrador.";

                                    break;

                                case Action.UserDonotExist:

                                    btnHuella.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                                    stakBarra.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");

                                    titleH.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                                    titleH.Text = "Lo siento pero no existes.";
                                    //ImgBrushUserHuella.ImageSource = util.ImageSourceFromBitmap(imageByte);

                                    NomUser.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                                    NomUser.Text = _userProccess.Name;
                                    //error.Text = "";

                                    break;

                                case Action.ClearWindow:
                                    
                                    btnHuella.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Yellow");
                                    //stakBarra.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Yellow");

                                    ImgBrushUserHuella.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "huella.jpg");
                                    titleH.Text = "Espere un momento";
                                    NomUser.Text = "Validadndo Huella";
                                    //error.Text = "";

                                    break;
                            }

                        });
                });
                ProssesMeesage.Start();

                Thread _thread = new Thread(() => ClearVista());
                _thread.Start();

            }
            catch (Exception ex)
            {
                // matMessageBox.TypeMessageBox("Socios", "Ocurrio un error con el lector, desconecte y vuelva a conectar.", 3);
            }
        }

        public void ClearVista()
        {
            Thread.Sleep(6000);

            Task ProssesClearMeesage = new Task(() =>
            {
                if (Process.GetProcesses().Count() > numOfProcess)
                    this.Dispatcher.Invoke(() =>
                    {

                        btnHuella.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("DodgerBlue");
                        stakBarra.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF4F4D4D");

                        ImgBrushUserHuella.ImageSource = util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "huella.jpg");

                        titleH.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Black");
                        NomUser.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("White");

                        titleH.Text = "Identificate";
                        NomUser.Text = "";
                        //error.Text = "";

                        detalleDatos.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("LightBlue");
                        cardDatos.Visibility = Visibility.Collapsed;

                    });
            });
            ProssesClearMeesage.Start();

            
        }
        public void CerrarLector()
        {
            CancelCaptureAndCloseReader(OnCaptured);
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

    }
}
