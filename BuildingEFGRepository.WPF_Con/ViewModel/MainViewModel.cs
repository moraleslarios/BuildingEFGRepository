using GalaSoft.MvvmLight;
using System;
using BuildingEFGRepository.DAL;
using BuildingEFGRepository.DataBase;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using BuildingEFGRepository.WPF_Con.Helper;
using System.Dynamic;

namespace BuildingEFGRepository.WPF_Con.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
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


        //public RelayCommand CreateNewCommand => new RelayCommand(CreateNewExecute);

        //private void CreateNewExecute()
        //{
        //    Action cancelAction = () => Data.Remove(SelectedItem);

        //    var model = new FootballClub();
        //    SelectedItem = model;
        //    Data.Add(model);

        //    Messenger.Default.Send(new EditionPopupMessage<FootballClub>("Insert", model, _repository, cancelMessageCallBack: cancelAction));
        //}



    }
}