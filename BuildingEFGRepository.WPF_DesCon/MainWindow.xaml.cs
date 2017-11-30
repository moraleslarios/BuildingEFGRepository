using BuildingEFGRepository.DataBase;
using BuildingEFGRepository.WPF_Con.Helper;
using BuildingEFGRepository.WPF_Con.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
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

            Messenger.Default.Register<EditionPopupMessage<FootballClub>>(this, messengerCallback);
        }

        private void messengerCallback(EditionPopupMessage<FootballClub> obj)
        {
            switch (obj.Notification)
            {
                case "Insert": InstanceInsert(obj); break;
                case "Update" : InstanceUpdate(obj); break;
            }


            

        }

        private void InstanceUpdate(EditionPopupMessage<FootballClub> obj)
        {
            var viewModel = new EditViewModel(obj.Model, obj.Repository)
            {
                AceptCallBack  = obj.AceptMessageCallBack,
                CancelCallBack = obj.CancelMessageCallBack

            };

            var view = new EditView { DataContext = viewModel };
            view.ShowDialog();
        }

        private static void InstanceInsert(EditionPopupMessage<FootballClub> obj)
        {
            var viewModel = new InsertViewModel(obj.Model, obj.Repository)
            {
                AceptCallBack  = obj.AceptMessageCallBack,
                CancelCallBack = obj.CancelMessageCallBack

            };

            var view = new InsertView { DataContext = viewModel };
            view.ShowDialog();
        }


    }
}
