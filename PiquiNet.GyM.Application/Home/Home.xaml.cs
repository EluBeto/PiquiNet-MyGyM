using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using PiquiNet.GyM.Application.Controls.Home;
using PiquiNet.GyM.Application.Controls.Users;
using PiquiNet.GyM.Application.Controls.Role;
using PiquiNet.GyM.Application.Controls.Membership;
using PiquiNet.GyM.Application.Controls.Partners;
using PiquiNet.GyM.Application.Controls.Registry;
using PiquiNet.GyM.Application.Controls.Settings;
using PiquiNet.GyM.Utilities;
using System.Configuration;
using System.Windows.Media;

namespace PiquiNet.GyM.Application.Home
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        #region Variables Globales
        MainWindow _Login = new MainWindow();
        UserControlHome _UserControlHome = new UserControlHome();
        UserControlUsers _UserControlUsers = new UserControlUsers();
        UserControlRole _UserControlRole = new UserControlRole();
        UserControlMembership _UserControlMembership = new UserControlMembership();
        UserControlRegistry _UserControlRegistry = new UserControlRegistry();
        UserControlPartners _UserControlPartners = new UserControlPartners();
        UserControlSettings _UserControlSettings = new UserControlSettings();
        DispatcherTimer timer = new DispatcherTimer();
        ListView lstView = new ListView();
        Util _util = new Util();
        Security _security = new Security();
        MatMessageBox matMessageBox = new MatMessageBox();
        #endregion

        #region Metodos Publicos
        public Home()
        {
            InitializeComponent();

            CreateMenu();
            
            imgFondo.ImageSource = _util.GetGlowingImage(_security.HextoStr(ConfigurationManager.AppSettings["Uri"].ToString()) + "barbells.jpg");
            
            Btn_Max.ToolTip = "Maximizar";
            max_min.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;

            StartClock();
        }
        #endregion

        #region Metodos Privados
        private void StartClock()
        {

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();
        }

        private void tickevent(object sender, EventArgs e)
        {
            var diaText = DateTime.Now.ToString(@"ddd");
            var dia = DateTime.Now.ToString(@"dd");
            var mes = DateTime.Now.ToString(@"MMM");
            var hora = DateTime.Now.ToString(@"hh:mm:ss tt");

            Reloj.Text = diaText + " " + dia + " de " + mes + " " + hora;
        }

        private void Btn_Max_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                Btn_Max.ToolTip = "Maximizar";
                max_min.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;
                this.WindowState = WindowState.Normal;
                RenderizeScreen();
            }
            else
            {
                Btn_Max.ToolTip = "Minimizar";
                max_min.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMinimize;
                this.WindowState = WindowState.Maximized;
                RenderizeScreen();
            }

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton.ToString() == "Left")
                DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            if(index != 0)
                RenderizeScreen();

            switch (index)
            {
                case -1:
                    //imgFondo.ImageSource = _util.GetGlowingImage("users.jpg");
                    GridPrincipal.Children.Clear();
                    _UserControlSettings.StartLector();
                    GridPrincipal.Children.Add(_UserControlSettings);

                    break;

                case 0:
                    //imgFondo.ImageSource = _util.GetGlowingImage("barbells.jpg");

                    NumAlert.Badge = null;
                    NumAlert.BadgeBackground = (SolidColorBrush)new BrushConverter().ConvertFromString("GreenYellow");
                    IconAlert.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("GreenYellow");
                    //Colors.GreenYellow

                    GridPrincipal.Children.Clear();                    
                    GridPrincipal.Children.Add(_UserControlHome);

                    _UserControlHome.gridReg.Margin = new Thickness(20, 20, 20, 20);
                    //_UserControlHome.gridReg.Width = GridPM.ActualWidth;
                    //_UserControlHome.gridReg.Height = GridPM.ActualHeight;

                    if (GridPM.ActualWidth == 0 && GridPM.ActualHeight == 0)
                    {
                        _UserControlHome.gridReg.Width = 774;
                        _UserControlHome.gridReg.Height = 550;
                    }
                    else
                    {
                        RenderizeScreen();
                    }                    
                    break;

                case 1:
                    //imgFondo.ImageSource = _util.GetGlowingImage("users.jpg");
                    NumAlert.Badge = 3;
                    NumAlert.BadgeBackground = (SolidColorBrush)new BrushConverter().ConvertFromString("Crimson");
                    IconAlert.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Crimson");

                    _UserControlUsers.txtNombre.Focus();
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(_UserControlUsers);
                    
                    break;

                case 2:
                    //imgFondo.ImageSource = _util.GetGlowingImage("rol.jpg");

                    NumAlert.Badge = 4;
                    NumAlert.BadgeBackground = (SolidColorBrush)new BrushConverter().ConvertFromString("Crimson");
                    IconAlert.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Crimson");

                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(_UserControlRole);
                    break;

                case 3:
                    //imgFondo.ImageSource = _util.GetGlowingImage("socios.jpg");

                    NumAlert.Badge = 5;
                    NumAlert.BadgeBackground = (SolidColorBrush)new BrushConverter().ConvertFromString("Crimson");
                    IconAlert.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("Crimson");

                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(_UserControlPartners);
                    break;

                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(_UserControlMembership);
                    break;

                case 5:
                    GridPrincipal.Children.Clear();
                    //GridPrincipal.Children.Add(_UserControlPartners);
                    break;

                case 6:
                    GridPrincipal.Children.Clear();
                    //GridPrincipal.Children.Add(_UserControlPartners);
                    break;

                case 7:
                    GridPrincipal.Children.Clear();
                    //GridPrincipal.Children.Add(_UserControlPartners);
                    break;

                case 8:
                    GridPrincipal.Children.Clear();
                    //GridPrincipal.Children.Add(_UserControlPartners);
                    break;

                case 9:
                    //imgFondo.ImageSource = _util.GetGlowingImage("registro.jpg");
                    
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(_UserControlRegistry);

                    break;

                case 10:
                    GridPrincipal.Children.Clear();
                    //GridPrincipal.Children.Add();
                    break;

                case 11:
                    GridPrincipal.Children.Clear();
                    //GridPrincipal.Children.Add(_UserControlPartners);
                    break;

                case 12:
                    GridPrincipal.Children.Clear();
                    //GridPrincipal.Children.Add(_UserControlPartners);
                    break;

                default:
                    GridPrincipal.Children.Clear();
                    break;
            }
            
        }

        private void MoveCursorMenu(int index)
        {
            TransitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (170 + (45 * index)), 0, 0);
        }

        private void RenderizeScreen()
        {
            double _TotalColum = GridPM.ActualWidth / 7;
            int _TotalColumInt = Convert.ToInt32(Math.Truncate(_TotalColum));

            _UserControlHome.gridReg.Margin = new Thickness(20, 20, 20, 20);
            _UserControlHome.gridReg.Width = GridPM.ActualWidth;
            _UserControlHome.gridReg.Height = GridPM.ActualHeight;


            _UserControlUsers.spListView.Height = 195; //GridPM.ActualHeight - 320;
            _UserControlUsers.spListView.Width = GridPM.ActualWidth - 40;

            _UserControlUsers.lvUsers.Height = 185; //GridPM.ActualHeight - 520;
            _UserControlUsers.lvUsers.Width = GridPM.ActualWidth - 40;

            _UserControlUsers.col1.Width = _TotalColumInt + 10;
            _UserControlUsers.col2.Width = _TotalColumInt;
            _UserControlUsers.col3.Width = _TotalColumInt;
            _UserControlUsers.col4.Width = _TotalColumInt;
            _UserControlUsers.col5.Width = _TotalColumInt - 10;
            _UserControlUsers.col6.Width = _TotalColumInt - 10;

            _UserControlUsers.Uid = idUser;
            _UserControlUsers.gridReg.Margin = new Thickness(20, 20, 20, 20);
            _UserControlUsers.gridReg.Width = GridPM.ActualWidth;
            _UserControlUsers.gridReg.Height = GridPM.ActualHeight;

            _UserControlRole.gridReg.Margin = new Thickness(20, 20, 20, 20);
            _UserControlRole.gridReg.Width = GridPM.ActualWidth;
            _UserControlRole.gridReg.Height = GridPM.ActualHeight;


            _UserControlMembership.spListView.Height = 195; //GridPM.ActualHeight - 320;
            _UserControlMembership.spListView.Width = GridPM.ActualWidth - 40;

            _UserControlMembership.lvUsers.Height = 185; //GridPM.ActualHeight - 520;
            _UserControlMembership.lvUsers.Width = GridPM.ActualWidth - 40;

            _UserControlMembership.col1.Width = _TotalColumInt + 50;
            _UserControlMembership.col2.Width = _TotalColumInt + 50;
            _UserControlMembership.col3.Width = _TotalColumInt + 50;

            _UserControlMembership.Uid = idUser;
            _UserControlMembership.gridReg.Margin = new Thickness(20, 20, 20, 20);
            _UserControlMembership.gridReg.Width = GridPM.ActualWidth;
            _UserControlMembership.gridReg.Height = GridPM.ActualHeight;

            _UserControlRegistry.gridReg.Margin = new Thickness(20, 20, 20, 20);
            _UserControlRegistry.gridReg.Width = GridPM.ActualWidth;
            _UserControlRegistry.gridReg.Height = GridPM.ActualHeight;

            //_UserControlPartners.DialogHost.Width = 550;
            //_UserControlPartners.DialogHost.Height = GridPM.ActualHeight - 150;

            _UserControlPartners.spListView.Height = 195; //GridPM.ActualHeight - 320;
            _UserControlPartners.spListView.Width = GridPM.ActualWidth - 40;

            _UserControlPartners.lvUsers.Height = 185; //GridPM.ActualHeight - 520;
            _UserControlPartners.lvUsers.Width = GridPM.ActualWidth - 40;

            _UserControlPartners.col1.Width = _TotalColumInt + 10;
            _UserControlPartners.col2.Width = _TotalColumInt;
            _UserControlPartners.col3.Width = _TotalColumInt;
            _UserControlPartners.col4.Width = _TotalColumInt;
            _UserControlPartners.col5.Width = _TotalColumInt - 8;
            _UserControlPartners.col6.Width = _TotalColumInt - 10;

            _UserControlPartners.Uid = idUser;
            _UserControlPartners.gridReg.Margin = new Thickness(20, 20, 20, 20);
            _UserControlPartners.gridReg.Width = GridPM.ActualWidth;
            _UserControlPartners.gridReg.Height = GridPM.ActualHeight;

            _UserControlSettings.gridReg.Margin = new Thickness(20, 20, 20, 20);
            _UserControlSettings.gridReg.Width = GridPM.ActualWidth;
            _UserControlSettings.gridReg.Height = GridPM.ActualHeight;
        }

        private void CreateMenu()
        {
            ItemInicio.Visibility = Visibility.Visible;
            ItemUsuarios.Visibility = Visibility.Visible;
            ItemRoles.Visibility = Visibility.Visible;
            ItemSocios.Visibility = Visibility.Visible;
            ItemMembrecia.Visibility = Visibility.Visible;
            ItemClases.Visibility = Visibility.Collapsed;
            ItemProductos.Visibility = Visibility.Collapsed;
            ItemCompras.Visibility = Visibility.Collapsed;
            ItemVentas.Visibility = Visibility.Collapsed;
            ItemRegistro.Visibility = Visibility.Visible;
            ItemReportes.Visibility = Visibility.Collapsed;
            ItemConfig.Visibility = Visibility.Collapsed;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListViewMenu.SelectedIndex = -1;
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _Login.Show();
        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {

            matMessageBox.TypeMessageBox("GyM", "¿Esta seguro que desea salir?",5);

        }
        #endregion
    }
}
