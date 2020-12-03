using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using BespokeFusion;

namespace PiquiNet.GyM.Utilities
{
    public class MatMessageBox
    {
        public void TypeMessageBox(string _title, string _message, int _type)
        {
            //CustomMaterialMessageBox _MessageBox = new CustomMaterialMessageBox();

            switch (_type)
            {
                case 1: // Message Success
                    var _MessageSuccess = new CustomMaterialMessageBox
                    {

                        Width = 500,
                        Height = 220,
                        TxtMessage = { Text = _message, Foreground = Brushes.Black,
                                       HorizontalAlignment = HorizontalAlignment.Center,
                                       VerticalAlignment = VerticalAlignment.Center,
                                       Margin = new Thickness(0, 0, 0, 0)
                        },
                        TxtTitle = { Text = _title, Foreground = Brushes.White },
                        BtnOk = { Content = "Entiendo",
                                  Width =110,
                                  Background = Brushes.DarkGreen
                        },
                        BtnCancel = { Visibility = System.Windows.Visibility.Collapsed },
                        MainContentControl = { Background = Brushes.White },
                        TitleBackgroundPanel = { Background = Brushes.DarkGreen },
                        BorderBrush = Brushes.DarkGreen,
                        BtnCopyMessage = { Visibility = Visibility.Collapsed }
                    };

                    _MessageSuccess.Show();
                    break;

                case 2: // Message Warning
                    var _MessageWarning = new CustomMaterialMessageBox
                    {
                        Width = 500,
                        Height = 220,
                        TxtMessage = { Text = _message, Foreground = Brushes.Black,
                                       HorizontalAlignment = HorizontalAlignment.Center,
                                       VerticalAlignment = VerticalAlignment.Center,
                                       Margin = new Thickness(0, 0, 0, 0)
                        },
                        TxtTitle = { Text = _title, Foreground = Brushes.White },
                        BtnOk = { Content = "Entiendo",
                                  Width =110,
                                  Background = Brushes.DarkOrange
                        },
                        BtnCancel = { Visibility = Visibility.Collapsed},
                        MainContentControl = { Background = Brushes.White },
                        TitleBackgroundPanel = { Background = Brushes.DarkOrange },
                        BorderBrush = Brushes.DarkOrange,
                        BtnCopyMessage = {Visibility = Visibility.Collapsed}
                        
                    };

                    _MessageWarning.Show();
                    break;

                case 3: // Message Error
                    var _MessageError = new CustomMaterialMessageBox
                    {
                        Width = 500,
                        Height = 220,
                        TxtMessage = { Text = _message, Foreground = Brushes.Black,
                                       HorizontalAlignment = HorizontalAlignment.Center,
                                       VerticalAlignment = VerticalAlignment.Center,
                                       Margin = new Thickness(0, 0, 0, 0)
                        },
                        TxtTitle = { Text = _title, Foreground = Brushes.White },
                        BtnOk = { Content = "Entiendo",
                                  Width =110,
                                  Background = Brushes.DarkRed
                        },
                        BtnCancel = { Visibility = Visibility.Collapsed },
                        MainContentControl = { Background = Brushes.White },
                        TitleBackgroundPanel = { Background = Brushes.DarkRed },
                        BorderBrush = Brushes.DarkRed,
                        BtnCopyMessage = { Visibility = Visibility.Visible }

                    };

                    _MessageError.Show();
                    break;

                case 4: // Message Detition
                    var _MessageCondition = new CustomMaterialMessageBox
                    {

                        Width = 500,
                        Height = 220,
                        TxtMessage = { Text = _message, Foreground = Brushes.Black,
                                       HorizontalAlignment = HorizontalAlignment.Center,
                                       VerticalAlignment = VerticalAlignment.Center,
                                       Margin = new Thickness(0, 0, 0, 0)
                        },
                        TxtTitle = { Text = _title, Foreground = Brushes.White },
                        BtnOk = { Content = "Si", Width = 110 },
                        BtnCancel = { Content = "No", Width = 110 },
                        MainContentControl = { Background = Brushes.White },
                        TitleBackgroundPanel = { Background = Brushes.Black },
                        BorderBrush = Brushes.Black,
                        BtnCopyMessage = { Visibility = Visibility.Collapsed }
                    };

                    _MessageCondition.Show();
                    break;

                case 5:
                    var _MessageShutdown = new CustomMaterialMessageBox
                    {

                        Width = 500,
                        Height = 220,
                        TxtMessage = { Text = _message, Foreground = Brushes.Black,
                                       HorizontalAlignment = HorizontalAlignment.Center,
                                       VerticalAlignment = VerticalAlignment.Center,
                                       Margin = new Thickness(0, 0, 0, 0)
                        },
                        TxtTitle = { Text = _title, Foreground = Brushes.White },
                        BtnOk = { Content = "Si", Width = 110 },
                        BtnCancel = { Content = "No", Width = 110 },
                        MainContentControl = { Background = Brushes.White },
                        TitleBackgroundPanel = { Background = Brushes.Black },
                        BorderBrush = Brushes.Black,
                        BtnCopyMessage = { Visibility = Visibility.Collapsed }
                    };

                    _MessageShutdown.Show();

                    var results = _MessageShutdown.Result;

                    if (results.ToString() == "OK")
                    {
                        System.Windows.Application.Current.Shutdown();
                    }

                    break;

            }


            
        }
    }
}
