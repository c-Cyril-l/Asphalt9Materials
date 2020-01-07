using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Asphalt_9_Materials.ViewModel.Converters
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return DependencyProperty.UnsetValue;

            var date = value as string;

            return DateTime.Parse(date);


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            if (value == null) return DependencyProperty.UnsetValue;

            var date = (value is DateTime time) ? time : default;
            return date.ToString("MM/yyyy");
        }

    }
}
