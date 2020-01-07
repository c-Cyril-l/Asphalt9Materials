using System;
using System.Globalization;
using System.Windows.Data;


namespace Asphalt_9_Materials.ViewModel.Converters
{
    public class DecimalConverter : IValueConverter
    {

        /// <summary>
        /// decimal value converter, here we change periods to commas.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Decimal value with comma instead of period.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            var decimalParse = decimal.Parse(value?.ToString()).ToString("0.##").Replace(".", ",");
            return decimalParse;

        }

        /// <summary>
        /// decimal value converter, here we convert back commas to periods.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Decimal value with periods instead of commas.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            var dotToComma = value?.ToString().Replace(",", ".");
            var decimalParse = decimal.Parse(dotToComma);
            return decimalParse;

        }
    }
}
