using Helpers.Utilities;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Asphalt_9_Materials.ViewModel.Converters
{
    public class ImageConverter : ObservableObject, IValueConverter
    {
        #region Constructor

        public ImageConverter()
        {
            _decodePixelHeight = -1;
            _decodePixelWidth = -1;
        }

        #endregion


        #region Declarations

        private int _decodePixelWidth;

        private int _decodePixelHeight;

        #endregion

        #region Properties

        /// <summary>
        /// Image Width (The Width that the image will be converted to).
        /// </summary>
        public int DecodePixelWidth
        {
            get => _decodePixelWidth;
            set
            {
                _decodePixelWidth = value;
                RaisePropertyChanged(nameof(DecodePixelWidth));
            }
        }

        /// <summary>
        /// Image Height (The Height that the image will be converted to).
        /// </summary>
        public int DecodePixelHeight
        {
            get => _decodePixelHeight;
            set
            {
                _decodePixelHeight = value;
                RaisePropertyChanged(nameof(DecodePixelHeight));
            }
        }

        #endregion

        #region #region Converters

        /// <summary>
        /// Getting the image with desired resolution from image file path.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>The Image with desired resolution from given image path.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string uri)) return DependencyProperty.UnsetValue;

            if (!(DecodePixelWidth >= 0) && !(DecodePixelHeight >= 0)) return DependencyProperty.UnsetValue;

            return new BitmapImage(new Uri(uri))
            { DecodePixelHeight = DecodePixelHeight, DecodePixelWidth = DecodePixelWidth };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }



        #endregion

    }
}
