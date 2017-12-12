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
            if (values[0] == null) return null;

            var valueStr = values[0].ToString();

            switch (valueStr)
            {
                case "Added"   : return _imgInsert;
                case "Modified": return _imgUpdate;
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
