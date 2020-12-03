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
using System.Drawing;

namespace PiquiNet.GyM.Application.Controls.Membership
{
    /// <summary>
    /// Lógica de interacción para UserControlMembership.xaml
    /// </summary>
    public partial class UserControlMembership : UserControl
    {
        
        public UserControlMembership()
        {
            InitializeComponent();
            btnGuardar.Visibility = Visibility.Visible;
        }

        private void RbEstatus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnModifica_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TxtBuscaRegistros_KeyDown(object sender, KeyEventArgs e)
        {

        }

        protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //var item = ((FrameworkElement)e.OriginalSource).DataContext as Entities.Users;

            //if (item != null)
            //{
            //    if (currentReader == null)
            //    {
            //        OpenReader();
            //        _counteoHuella = 1;
            //    }

            //    _User.UserId = item.UserId;
            //    _User.ModByUserId = int.Parse(Uid.Text);
            //    StartDataFormUpdate(_usersBussiness.SelectUser(item.UserId, false));
            //}
        }
    }
}
