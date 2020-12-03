using PiquiNet.GyM.Application.RegisterView;
using System;
using System.Collections.Generic;
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

namespace PiquiNet.GyM.Application.Controls.Registry
{
    /// <summary>
    /// Lógica de interacción para UserControlRegistry.xaml
    /// </summary>
    public partial class UserControlRegistry : UserControl
    {
        RegisterActivity registerActivity = new RegisterActivity();
        private bool _IsActiveButton = false;
        private bool _State = false;
        public UserControlRegistry()
        {
            InitializeComponent();

            btnOpenRegister.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
            btnStatus.Content = "Maximizar";
        }

        private void BtnOpenRegister_Click(object sender, RoutedEventArgs e)
        {
            if (registerActivity.IsLoaded == false && _IsActiveButton == false)
            {
                _IsActiveButton = true;
                btnOpenRegister.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");
                btnOpenRegister.Content = "Cerrar";
                registerActivity.OpenRegister();
            }
            else
            {
                _IsActiveButton = false;
                _State = false;
                btnOpenRegister.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("Green");
                btnOpenRegister.Content = "Abrir";
                registerActivity.CloseRegister();
                registerActivity = new RegisterActivity();
            }
        }

        private void BtnStatus_Click(object sender, RoutedEventArgs e)
        {
            if (!_State)
            {
                btnStatus.Content = "Minimizar";
                registerActivity.WindowState = WindowState.Maximized;
                _State = true;
            }
            else
            {
                btnStatus.Content = "Maximizar";
                registerActivity.WindowState = WindowState.Normal;
                _State = false;
            }
            
        }
    }
}
