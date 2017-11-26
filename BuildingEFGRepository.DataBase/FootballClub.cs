namespace BuildingEFGRepository.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using BuildingEFGRepository.DataBase.Helper;

    [Serializable]
    public partial class FootballClub : ObservableDataObject
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }

        private int _cityId;
        public int CityId
        {
            get { return _cityId; }
            set { _cityId = value; OnPropertyChanged(); }
        }


        private string _name;
        [Required]
        [StringLength(50)]
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        private decimal _members;
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "numeric")]
        public decimal Members
        {
            get { return _members; }
            set { _members = value; OnPropertyChanged(); }
        }

        private string _stadium;
        [Required]
        [StringLength(50)]
        public string Stadium
        {
            get { return _stadium; }
            set { _stadium = value; OnPropertyChanged(); }
        }

        private DateTime? _fundationDate;
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime? FundationDate
        {
            get { return _fundationDate; }
            set { _fundationDate = value; OnPropertyChanged(); }
        }

        private string _logo;

        public string Logo
        {
            get { return _logo; }
            set { _logo = value; OnPropertyChanged(); }
        }



        //public ICollection<FootballClub> FootballClubs { get; set; }
    }
}
