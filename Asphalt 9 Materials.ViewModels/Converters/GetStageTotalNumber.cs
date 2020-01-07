using System;
using System.Globalization;
using System.Windows.Data;

namespace Asphalt_9_Materials.ViewModel.Converters
{
    public class GetStageTotalNumber : IValueConverter
    {
        /// <summary>
        /// Calculating the total stages.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>The Total Number</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as int?;
            return (value != null) ? ($"{val * 4:#,##0}") : null;
        }

        /// <summary>
        /// Calculating the total stages into individuals.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>The Total number divided by 4</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as int?;
            return (value != null) ? (val / 4) : null;
        }
    }
}
