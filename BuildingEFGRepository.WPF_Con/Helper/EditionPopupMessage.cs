using BuildingEFGRepository.DAL;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEFGRepository.WPF_Con.Helper
{
    public class EditionPopupMessage<T> : NotificationMessage where T : class
    {
        public T Model { get; set; }

        public Action AceptMessageCallBack { get; set; }
        public Action CancelMessageCallBack { get; set; }

        public IDisconGenericRepository<T> Repository { get; private set; }


        public EditionPopupMessage(string notification, T model, IDisconGenericRepository<T> repository, Action aceptMessageCallback = null, Action cancelMessageCallBack = null) : base(notification)
        {
            Model = model;
            AceptMessageCallBack  = aceptMessageCallback;
            CancelMessageCallBack = cancelMessageCallBack;
            Repository = repository;
        }
    }
}
