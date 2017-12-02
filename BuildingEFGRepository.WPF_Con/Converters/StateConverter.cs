using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BuildingEFGRepository.DAL;
using BuildingEFGRepository.DataBase;
using BuildingEFGRepository.DataBase.Repositories;
using System.Data.Entity;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace BuildingEFGRepository.WPF_Con.Converters
{
    public class StateConverter : IMultiValueConverter
    {

        public ImageBrush _imgInsert;
        public ImageBrush _imgUpdate;



        public StateConverter()
        {
            _imgInsert = Application.Current.FindResource("Inserted") as ImageBrush;
            _imgUpdate = Application.Current.FindResource("Edited") as ImageBrush;
        }


        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //return _imgUpdate;

            if (values[0] == null || values[0] == DependencyProperty.UnsetValue) return null;
            if (values[1] == null || values[1] == DependencyProperty.UnsetValue) return null;

            var repository = values[0] as ConGenericRepository<FootballClub>;
            var id = int.Parse(values[1].ToString());

            string path = null;

            if (id == 0) return _imgInsert;

            //bool isUpdated = repository.IsUpdateState(id);

            bool isUpdated = repository._dbContext.ChangeTracker.Entries<FootballClub>().Any(a => a.Entity.Id == id && a.State == EntityState.Modified);

            if (isUpdated) return _imgUpdate;

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
