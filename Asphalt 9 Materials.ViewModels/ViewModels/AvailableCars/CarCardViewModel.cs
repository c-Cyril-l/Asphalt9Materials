using Asphalt_9_Materials.Core;
using Asphalt_9_Materials.ViewModel.Services.Interfaces;
using Helpers.Utilities;
using System;
using System.Windows.Media;

namespace Asphalt_9_Materials.ViewModel.ViewModels.AvailableCars
{
    public class CarCardViewModel : ObservableObject, IPageService
    {

        #region Constructor

        public CarCardViewModel()
        {
            // Initializing car instance.
            _car = new Car();

            // Initializing card height.
            _itemHeight = 320;

            // Initializing card width.
            _itemWidth = 320;

            // Initializing image path.
            _imageUri = string.Empty;
        }

        #endregion

        #region IPage Implementation

        public string Name => string.Empty;

        #endregion

        #region Declarations

        private Car _car;
        private int _itemHeight;
        private int _itemWidth;
        private string _imageUri;

        #endregion        

        #region Properties

        /// <summary>
        /// Current Car.
        /// </summary>
        public Car Car
        {
            get => _car;
            set
            {
                _car = value;
                RaisePropertyChanged(nameof(Car));
            }
        }

        /// <summary>
        /// Car type foreground
        /// </summary>
        public Brush Foreground
        {
            get
            {
                switch ((CarType)Enum.Parse(typeof(CarType), Car.Type))
                {
                    case CarType.Rare:
                        return Brushes.Purple;
                    case CarType.Epic:
                        return Brushes.DarkOrange;
                    case CarType.Uncommon:
                    default:
                        return Brushes.Gray;
                }
            }

        }

        /// <summary>
        /// User control Height.
        /// </summary>
        public int ItemHeight
        {
            get => _itemHeight;
            set
            {
                _itemHeight = value;
                RaisePropertyChanged(nameof(ItemHeight));
            }
        }

        /// <summary>
        /// User control width
        /// </summary>
        public int ItemWidth
        {
            get => _itemWidth;
            set
            {
                _itemWidth = value;
                RaisePropertyChanged(nameof(ItemWidth));
            }
        }

        /// <summary>
        /// Car image url.
        /// </summary>
        public string ImageUri
        {
            get => _imageUri;
            set
            {
                _imageUri = value;
                RaisePropertyChanged(nameof(ImageUri));
            }
        }

        /// <summary>
        /// Showing car stats tooltip.
        /// </summary>
        public string ButtonToolTipText => $"Show {Car.FullName} Stats";


        #endregion

    }
}
