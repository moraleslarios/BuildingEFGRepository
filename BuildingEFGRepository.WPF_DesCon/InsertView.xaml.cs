using GalaSoft.MvvmLight.Messaging;
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
using System.Windows.Shapes;

namespace BuildingEFGRepository.WPF_Con
{
    /// <summary>
    /// Interaction logic for InsertView.xaml
    /// </summary>
    public partial class InsertView : Window
    {
        public InsertView()
        {
            InitializeComponent();

            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage obj)
        {
            // close window in all cases

            this.Close();
        }
    }
}
