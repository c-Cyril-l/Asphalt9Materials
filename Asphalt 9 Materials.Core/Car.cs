using Asphalt_9_Materials.Annotations;
using Helpers.Utilities;
using System.ComponentModel;
using System.Linq;

namespace Asphalt_9_Materials.Core
{

    public class Car : ObservableObject, IDataErrorInfo
    {

        #region Constructor

        public Car()
        {
            _blueprints = new Blueprint();

            _performance = new Performance();

            _upgrades = new Upgrades();

            _ranks = new Ranks();

            _additionalParts = new AdditionalParts();

        }

        #endregion

        #region Declarations

        private AdditionalParts _additionalParts;

        private Blueprint _blueprints;

        private Performance _performance;

        private Upgrades _upgrades;

        private Ranks _ranks;

        private string _carBrand;

        private string _carClass;

        private string _carName;

        [CanBeNull]
        private int? _fuels;

        private string _fullName;

        private string _image;

        private double? _refill;

        private string _releaseDate;

        private int? _stars;

        private string _type;

        #endregion

        #region Properties

        /// <summary>
        /// Car Additional Parts like epics, rare, uncommon
        /// </summary>
        public AdditionalParts AdditionalParts
        {
            get => _additionalParts;
            set
            {
                _additionalParts = value;
                RaisePropertyChanged(nameof(AdditionalParts));
            }
        }

        /// <summary>
        /// Car Blueprints
        /// </summary>
        public Blueprint Blueprints
        {
            get => _blueprints;
            set
            {
                _blueprints = value;
                RaisePropertyChanged(nameof(Blueprints));
            }
        }

        /// <summary>
        /// Car Brand
        /// </summary>
        public string CarBrand
        {
            get => _carBrand;
            set
            {
                _carBrand = value;
                RaisePropertyChanged(nameof(CarBrand));
            }
        }

        /// <summary>
        /// Car Class
        /// </summary>
        public string CarClass
        {
            get => _carClass;
            set
            {
                _carClass = value;
                RaisePropertyChanged(nameof(CarClass));
            }
        }

        /// <summary>
        /// Car Name
        /// </summary>
        public string CarName
        {
            get => _carName;
            set
            {
                _carName = value;
                RaisePropertyChanged(nameof(CarName));

            }
        }

        /// <summary>
        /// Car Fuels
        /// </summary>
        [CanBeNull]
        public int? Fuel
        {
            get => _fuels;
            set
            {
                _fuels = value;
                RaisePropertyChanged(nameof(Fuel));
            }
        }

        /// <summary>
        /// Car Full Name Which Is Car Brand Name + Car Name
        /// </summary>
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                RaisePropertyChanged(nameof(FullName));
            }
        }

        /// <summary>
        /// Car Image
        /// </summary>
        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                RaisePropertyChanged(nameof(Image));
            }
        }

        /// <summary>
        /// Car Performance 
        /// </summary>
        public Performance Performance
        {
            get => _performance;
            set
            {
                _performance = value;
                RaisePropertyChanged(nameof(Performance));
            }
        }

        /// <summary>
        /// Car Ranks
        /// </summary>
        public Ranks Ranks
        {
            get => _ranks;
            set
            {
                _ranks = value;
                RaisePropertyChanged(nameof(Ranks));
            }
        }

        /// <summary>
        /// Car Refill Time
        /// </summary>
        public double? Refill
        {
            get => _refill;
            set
            {
                _refill = value;
                RaisePropertyChanged(nameof(Refill));
            }
        }

        /// <summary>
        /// Release Date Of The Car
        /// </summary>
        public string ReleaseDate
        {
            get => _releaseDate;
            set
            {
                _releaseDate = value;
                RaisePropertyChanged(nameof(ReleaseDate));
            }
        }

        /// <summary>
        /// Car Stars
        /// </summary>
        public int? Stars
        {
            get => _stars;
            set
            {
                _stars = value;
                RaisePropertyChanged(nameof(Stars));
            }
        }

        /// <summary>
        /// Car Type
        /// </summary>
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                RaisePropertyChanged(nameof(Type));
            }
        }

        /// <summary>
        /// Car Upgrades
        /// </summary>
        public Upgrades Upgrades
        {
            get => _upgrades;
            set
            {
                _upgrades = value;
                RaisePropertyChanged(nameof(Upgrades));
            }
        }

        /// <summary>
        /// The Total credit required for upgrading the car.
        /// </summary>
        public int? TotalCreditCost =>
            (AdditionalParts.UncommonTotalCost ?? 0) +
            (AdditionalParts.RareTotalCost ?? 0) +
            (AdditionalParts.EpicTotalCost ?? 0) +
            (Upgrades.TotalStagesCost ?? 0);

        #region IDataErrorInfo Members

        public string Error => this[null];

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(CarBrand))
                {
                    if (string.IsNullOrWhiteSpace(CarBrand))
                        return " Car brand is required.";
                    if (CarBrand.Substring(0, 1) != CarBrand.Substring(0, 1).ToUpper())
                        return " First Letter of car brand must be capital.";
                    if (CarBrand.Length < 3)
                        return " Car brand must be at least 3 characters.";
                }
                else if (columnName == nameof(CarName))
                {
                    if (string.IsNullOrWhiteSpace(CarName))
                        return " Car name required.";
                    if (CarName.Substring(0, 1) != CarName.Substring(0, 1).ToUpper())
                        return " First Letter of car name must be capital.";
                }
                else if (columnName == nameof(Image))
                {
                    if (string.IsNullOrWhiteSpace(Image))
                        return " Car image is required.";
                    if (Image.Length < 3)
                        return " Car image must be at least 3 characters.";
                }
                else if (columnName == nameof(CarClass))
                {
                    if (string.IsNullOrWhiteSpace(CarClass) || string.IsNullOrWhiteSpace(CarClass))
                        return " Car Class is required.";
                }
                else if (columnName == nameof(ReleaseDate))
                {
                    if (string.IsNullOrWhiteSpace(ReleaseDate))
                        return " Car Release Date is required.";
                    if (!ReleaseDate.Any(char.IsNumber))
                        return "Date is invalid!";
                }
                else if (columnName == nameof(Type))
                {
                    if (string.IsNullOrWhiteSpace(Type))
                        return " Car Type Required.";
                }
                else if (columnName == nameof(Stars))
                {
                    if (!Stars.HasValue || (Stars < 3))
                        return " Car stars are Required.";
                }

                return null;
            }
        }

        public bool IsValid()
        {
            return string.IsNullOrEmpty(this[nameof(CarBrand)]) &&
                   string.IsNullOrEmpty(this[nameof(CarName)]) &&
                   string.IsNullOrEmpty(this[nameof(Image)]) &&
                   string.IsNullOrEmpty(this[nameof(CarClass)]) &&
                   string.IsNullOrEmpty(this[nameof(Type)]) &&
                   string.IsNullOrEmpty(this[nameof(Stars)]) &&
                   string.IsNullOrEmpty(this[nameof(ReleaseDate)]);
        }

        #endregion

        #endregion

    }
}
