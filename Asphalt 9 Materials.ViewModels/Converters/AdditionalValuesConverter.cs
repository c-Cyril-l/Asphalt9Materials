using System;
using System.Globalization;
using System.Windows.Data;

namespace Asphalt_9_Materials.ViewModel.Converters
{
    public class AdditionalValuesConverter : IValueConverter
    {
        /// <summary>
        /// Additional parts value converter, here we convert the total value came from database to individuals.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Value has been divided by 4</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as int?;
            if (value != null)
                return val / 4;
            return null;
        }

        /// <summary>
        /// Additional parts value converter, here we convert the individual values to total.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Value has been multiplied by 4</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as int?;
            if (value != null)
                return val * 4;
            return null;
        }
    }
}
