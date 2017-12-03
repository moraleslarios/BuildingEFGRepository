using System;
using BuildingEFGRepository.DataBase;
using BuildingEFGRepository.WPF_Con.Helper;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using System.Windows;

namespace BuildingEFGRepository.WPF_Con
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Messenger.Default.Register<PopupMessage>(this, messengerCallback);
        }

        private void messengerCallback(PopupMessage obj)
        {
            if(obj.AceptMessageCallBack != null)
            {
                var result = MessageBox.Show(obj.Notification, "Save Data", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if(result == MessageBoxResult.Yes)
                {
                    obj.AceptMessageCallBack();
                }
            }
            else
            {
                MessageBox.Show(obj.Notification, "Save Data", MessageBoxButton.OK, MessageBoxImage.Information);


            }




        }

       


    }
}
