using System;
using System.Globalization;
using System.Windows.Data;

namespace Asphalt_9_Materials.ViewModel.Converters
{
    public class NumberSeparator : IValueConverter
    {
        /// <summary>
        /// Separating every 3 digits.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>The Number with separation of every 3 digits.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value != null) ? ($"{value:#,##0}") : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
