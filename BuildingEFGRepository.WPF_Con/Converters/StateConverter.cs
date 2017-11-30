using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BuildingEFGRepository.DAL;
using BuildingEFGRepository.DataBase;

namespace BuildingEFGRepository.WPF_Con.Converters
{
    public class StateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var repository = value as IConGenericRepository<FootballClub>;

            var data = repository.Find(1);

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
