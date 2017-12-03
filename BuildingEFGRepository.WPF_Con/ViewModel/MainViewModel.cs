using GalaSoft.MvvmLight;
using System;
using BuildingEFGRepository.DAL;
using BuildingEFGRepository.DataBase;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using BuildingEFGRepository.WPF_Con.Helper;
using System.Dynamic;
using System.Windows.Data;

namespace BuildingEFGRepository.WPF_Con.ViewModel
{
    public class MainViewModel : ViewModelBase, IDisposable
    {
        public dynamic ViewBag { get; set; }

        private readonly IConGenericRepository<FootballClub> _repository;


        public ObservableCollection<FootballClub> Data { get; set; }


        private FootballClub _selectedItem;
        public FootballClub SelectedItem
        {
            get { return _selectedItem; }
            set { Set(nameof(SelectedItem), ref _selectedItem, value); }
        }




        public MainViewModel(IConGenericRepository<FootballClub> repository)
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            _repository = repository;

            Data = _repository.All();

            ViewBag = new ExpandoObject();
            ViewBag.Repository = _repository;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }


        public RelayCommand SaveCommand => new RelayCommand(SaveExecute, SaveCanExecute);

        private bool SaveCanExecute()
        {
            var result = _repository.HasChanges();

            return result;
        }

        private void SaveExecute()
        {
            Action callback = () =>
            {
                var changes = _repository.SaveChanges();

                Messenger.Default.Send(new PopupMessage($"It has been realized {changes} change(s) in Database." ));

                CollectionViewSource.GetDefaultView(Data).Refresh();
            };

            Messenger.Default.Send(new PopupMessage("Has you make the changes in DataBase ?", callback));
        }





    }
}