using Helpers.Utilities;

namespace Asphalt_9_Materials.Core
{
    public class Performance : ObservableObject
    {

        #region Maxed

        #region Declarations

        private double? _maxTopSpeed;

        private double? _maxAcceleration;

        private double? _maxHandling;

        private double? _maxNitro;

        #endregion

        #region Properties

        /// <summary>
        /// Car Top Speed At Max
        /// </summary>
        public double? MaxTopSpeed
        {
            get => _maxTopSpeed;
            set
            {
                _maxTopSpeed = value;
                RaisePropertyChanged(nameof(MaxTopSpeed));
            }
        }


        /// <summary>
        /// Car Acceleration At Max
        /// </summary>
        public double? MaxAcceleration
        {
            get => _maxAcceleration;
            set
            {
                _maxAcceleration = value;
                RaisePropertyChanged(nameof(MaxAcceleration));
            }
        }

        /// <summary>
        /// Car Handling At Max
        /// </summary>
        public double? MaxHandling
        {
            get => _maxHandling;
            set
            {
                _maxHandling = value;
                RaisePropertyChanged(nameof(MaxHandling));
            }
        }

        /// <summary>
        /// Car Nitro At Max
        /// </summary>
        public double? MaxNitro
        {
            get => _maxNitro;
            set
            {
                _maxNitro = value;
                RaisePropertyChanged(nameof(MaxNitro));
            }
        }

        #endregion

        #endregion

        #region Stock

        #region Declarations

        private double? _stockTopSpeed;

        private double? _stockAcceleration;

        private double? _stockHandling;

        private double? _stockNitro;


        #endregion

        #region Properties

        /// <summary>
        /// Car Top Speed At Stock
        /// </summary>
        public double? StockTopSpeed
        {
            get => _stockTopSpeed;
            set
            {
                _stockTopSpeed = value;
                RaisePropertyChanged(nameof(StockTopSpeed));
            }
        }

        /// <summary>
        /// Car Acceleration At Stock
        /// </summary>
        public double? StockAcceleration
        {
            get => _stockAcceleration;
            set
            {
                _stockAcceleration = value;
                RaisePropertyChanged(nameof(StockAcceleration));
            }
        }

        /// <summary>
        /// Car Handling At Stock
        /// </summary>
        public double? StockHandling
        {
            get => _stockHandling;
            set
            {
                _stockHandling = value;
                RaisePropertyChanged(nameof(StockHandling));
            }
        }

        /// <summary>
        /// Car Nitro At Stock
        /// </summary>
        public double? StockNitro
        {
            get => _stockNitro;
            set
            {
                _stockNitro = value;
                RaisePropertyChanged(nameof(StockNitro));
            }
        }


        #endregion

        #endregion

    }
}
