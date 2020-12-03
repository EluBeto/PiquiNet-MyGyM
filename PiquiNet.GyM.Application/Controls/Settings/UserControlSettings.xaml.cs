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
using PiquiNet.GyM.FingerPrint;

namespace PiquiNet.GyM.Application.Controls.Settings
{
    /// <summary>
    /// Lógica de interacción para UserControlSettings.xaml
    /// </summary>
    public partial class UserControlSettings : UserControl
    {
        ReaderFinger _readerFinger = new ReaderFinger();
        public UserControlSettings()
        {
            InitializeComponent();
        }

        public void StartLector()
        {
            cmbLector.Text  = string.Empty;
            cmbLector.Items.Clear();
            cmbLector.SelectedIndex = -1;

            try
            {
                string[] _arrReaders = _readerFinger.GetSerial().Split('|');

                foreach (string SerialNomber in _arrReaders)
                {
                    if(SerialNomber !="")
                        cmbLector.Items.Add(SerialNomber);
                }

                //if (cmbLector.Items.Count > 0)
                //{
                //    cmbLector.SelectedIndex = 0;
                //}
            }
            catch (Exception e)
            {

            }
        }
    }
}
