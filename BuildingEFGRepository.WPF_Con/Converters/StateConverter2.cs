using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BuildingEFGRepository.WPF_Con.Converters
{
    public class StateConverter2 : IValueConverter
    {

        public string pathUpdate = "Images/edit-row.png";
        public string pathInsert = "Images/insert_row_above1600.png";


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var id = int.Parse(value.ToString());

            if(id == 0) return pathInsert;

            return pathUpdate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
