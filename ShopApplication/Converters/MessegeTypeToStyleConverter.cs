using ShopApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ShopApplication.Converters
{
    public class MessegeTypeToStyleConverter : IValueConverter
    {
        public Style ErrorStyle => (Style) Application.Current.Resources["ErrorStyle"];
        public Style StatusStyle => (Style) Application.Current.Resources["StatusStyle"];
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Messege MessegeType = (Messege) value;
            if (MessegeType == Messege.Error)
                return ErrorStyle;
            if (MessegeType == Messege.Status)
                return StatusStyle;
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
