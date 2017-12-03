using BuildingEFGRepository.DAL;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEFGRepository.WPF_Con.Helper
{
    public class PopupMessage : NotificationMessage
    {
        public Action AceptMessageCallBack { get; set; }



        public PopupMessage(string notification,  Action aceptMessageCallback = null) : base(notification)
        {
            AceptMessageCallBack  = aceptMessageCallback;
        }
    }
}
