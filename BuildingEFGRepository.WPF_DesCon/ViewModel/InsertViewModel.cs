using BuildingEFGRepository.DAL;
using BuildingEFGRepository.DataBase;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingEFGRepository.WPF_Con.ViewModel
{
    public class InsertViewModel : ViewModelBase
    {

        private FootballClub _model;
        public FootballClub Model
        {
            get { return _model; }
            set { Set(nameof(Model), ref _model, value); }
        }


        public Action AceptCallBack { get; set; }
        public Action CancelCallBack { get; set; }


        private readonly IDisconGenericRepository<FootballClub> _repository;



        public InsertViewModel(FootballClub model, IDisconGenericRepository<FootballClub> repository)
        {
            Model = model;
            _repository = repository;
        }


        public RelayCommand InsertCommand => new RelayCommand(InsertExecute);
        private void InsertExecute()
        {
            _repository.Add(Model);

            AceptCallBack?.Invoke();

            Messenger.Default.Send(new NotificationMessage("Inserted"));
        }

        public RelayCommand CancelCommand => new RelayCommand(CancelExecute);
        private void CancelExecute()
        {
            CancelCallBack?.Invoke(); // ... Another code

            Messenger.Default.Send(new NotificationMessage("Cancel"));
        }
    }
}
