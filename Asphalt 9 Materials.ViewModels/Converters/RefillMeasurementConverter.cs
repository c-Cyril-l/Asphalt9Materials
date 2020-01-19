using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Asphalt_9_Materials.ViewModel.Converters
{
    public class RefillMeasurementConverter : IValueConverter
    {
        /// <summary>
        /// Measuring the refill time of cars.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>The Refill time in hours and minutes or just in minutes</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            var refill = (double)value;

            return (refill > 60) ? ($"{refill / 60} Hr(s)") : ($"{refill} Min(s)");

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
