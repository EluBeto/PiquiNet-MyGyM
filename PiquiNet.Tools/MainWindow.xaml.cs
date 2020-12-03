using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using PiquiNet.GyM.Utilities;

namespace PiquiNet.Tools
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Security security = new Security();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLimpia_Click(object sender, RoutedEventArgs e)
        {
            txtPath.Text  = string.Empty;
            txtRespuesta.Text  = string.Empty;
            cmbProceso.Text  = string.Empty;
            cmbProceso.SelectedIndex = -1;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPath.Text != "" && cmbProceso.Text != "")
                {
                    switch (cmbProceso.SelectedIndex)
                    {
                        case 0:
                            txtRespuesta.Text = security.EncryptConnectionString(txtPath.Text);
                            break;

                        case 1:
                            txtRespuesta.Text = security.DecryptConnectionString(txtPath.Text);
                            break;

                        case 2:
                            txtRespuesta.Text = security.StrToHex(txtPath.Text);
                            break;

                        case 3:
                            txtRespuesta.Text = security.HextoStr(txtPath.Text);
                            break;

                        case 4:
                            txtRespuesta.Text = security.EncryptString(txtPath.Text);
                            break;

                        case 5:
                            txtRespuesta.Text = security.DecryptString(txtPath.Text);
                            break;
                    }
                }
                else
                {
                    txtRespuesta.Text = "Ingrese todos los datos";
                }
            }
            catch (Exception ex)
            {
                txtRespuesta.Text = ex.Message;
            }
        }

        private void BtnCopia_Click(object sender, RoutedEventArgs e)
        {
            txtRespuesta.SelectAll();
            txtRespuesta.Copy();
        }
    }
}
