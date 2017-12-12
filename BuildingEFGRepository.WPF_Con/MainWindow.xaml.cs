using System;
using BuildingEFGRepository.DataBase;
using BuildingEFGRepository.WPF_Con.Helper;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;

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

        private async void messengerCallback(PopupMessage obj)
        {
            if(obj.AceptMessageCallBack != null)
            {
                var result = await this.ShowMessageAsync("Save Data", obj.Notification, MessageDialogStyle.AffirmativeAndNegative);

                if(result == MessageDialogResult.Affirmative )
                {
                    obj.AceptMessageCallBack();
                }
            }
            else
            {
                await this.ShowMessageAsync("Save Data", obj.Notification, MessageDialogStyle.Affirmative);


            }




        }

       


    }
}
