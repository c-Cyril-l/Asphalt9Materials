using Asphalt_9_Materials.Annotations;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Asphalt_9_Materials.ViewModel.Converters
{
    public class ToLowerCaseConverter : IValueConverter
    {
        /// <summary>
        /// Convert string to lower case.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Lower case string</returns>
        public object Convert([CanBeNull] object value, Type targetType, object parameter, CultureInfo culture)
        { return (!string.IsNullOrEmpty(value as string)) ? ((string)value).ToLower() : string.Empty; }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { throw new NotImplementedException(); }
    }
}
