using Asphalt_9_Materials.Core;
using Asphalt_9_Materials.ViewModel.Entities;
using Asphalt_9_Materials.ViewModel.Helpers;
using Asphalt_9_Materials.ViewModel.Services.Interfaces;
using Helpers.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Asphalt_9_Materials.ViewModel.ViewModels.Misc
{
    public class CompareViewModel : ObservableObject, IPageService
    {

        #region Declarations

        private Car _carToAdd;

        #endregion

        #region Constructor

        public CompareViewModel()
        {
            // Initializing car to add instance.
            _carToAdd = new Car();

            // Initializing car to remove instance.
            _carToRemove = new Car();

            // Initializing car list.
            CarCollection = new ObservableCollection<Car>();

            // Initializing comparison list.
            CompareCollection = new ObservableCollection<Car>();

            // Initializing commands.
            InitializeCommands();
        }

        #endregion

        #region IPage Implementation

        public string Name => string.Empty;

        #endregion

        #region Methods

        /// <summary>
        /// Adding the selected car to comparison list.
        /// </summary>
        private void AddCarToCompare(object sender = null)
        {
            using (var a9 = new Asphalt9Entities())
            {
                foreach (var carItem in CarCollection)
                {
                    if ((carItem.FullName != CarToAdd.FullName) ||
                        CompareCollection.Contains(carItem))
                        continue;

                    CompareCollection.Add(carItem);
                }

            }

        }

        /// <summary>
        /// Remove the selected car from comparison list.
        /// </summary>
        /// <param name="sender"></param>
        private void RemoveCurrentFromCompare(object sender)
        {
            if (CarToRemove != null)
                CompareCollection.Remove(CarToRemove);
        }

        /// <summary>
        /// Getting selected car informations.
        /// </summary>
        /// <param name="car">Selected Car</param>
        /// <param name="isPath">is path has been provided?</param>
        /// <returns>The Informations of selected car</returns>
        public Car GetCar(AddCar_Result car, bool isPath = true)
        {
            return new Car()
            {
                CarName = car.CarName,
                CarBrand = car.CarBrand,
                FullName = car.FullName,
                Stars = car.Stars ?? 0,
                Image = isPath ? FileHelpers.ImagePath(car.Image) : car.Image,
                Refill = car.Refill,
                Fuel = car.Fuel,
                ReleaseDate = car.ReleaseDate,
                CarClass = car.CarClass,

                Type = Enum.Parse(typeof(CarType), car.Type).ToString(),

                Performance = new Core.Performance()
                {
                    MaxTopSpeed = car.MaxSpeed ?? 0,
                    MaxAcceleration = car.MaxAcceleration ?? 0,
                    MaxHandling = car.MaxHandling ?? 0,
                    MaxNitro = car.MaxNitro ?? 0,
                    StockTopSpeed = car.StockSpeed ?? 0,
                    StockAcceleration = car.StockAcceleration ?? 0,
                    StockHandling = car.StockHandling ?? 0,
                    StockNitro = car.StockNitro ?? 0,
                },

                Blueprints = new Core.Blueprint()
                {
                    FirstStar = car.FirstStarBP,
                    SecondStar = car.SecondStarBP,
                    ThirdStar = car.ThirdStarBP,
                    FourthStar = car.FourthStarBP,
                    FifthStar = car.FifthStarBP,
                    SixthStar = car.SixthStarBP,
                },
                Ranks = new Core.Ranks()
                {
                    Stock = car.StockStarRank,
                    FirstStar = car.FirstStarRank,
                    SecondStar = car.SecondStarRank,
                    ThirdStar = car.ThirdStarRank,
                    FourthStar = car.FourthStarRank,
                    FifthStar = car.FifthStarRank,
                    SixthStar = car.SixthStarRank,
                },
                Upgrades = new Upgrades()
                {
                    Stage0 = car.Stage1,
                    Stage1 = car.Stage2,
                    Stage2 = car.Stage3,
                    Stage3 = car.Stage4,
                    Stage4 = car.Stage5,
                    Stage5 = car.Stage6,
                    Stage6 = car.Stage7,
                    Stage7 = car.Stage8,
                    Stage8 = car.Stage9,
                    Stage9 = car.Stage10,
                    Stage10 = car.Stage11,
                    Stage11 = car.Stage12,
                    Stage12 = car.Stage13,
                },

                AdditionalParts = new AdditionalParts()
                {
                    EpicQuantity = car.EpicQuantity,
                    EpicCost = car.EpicCost,

                    RareQuantity = car.RareQuantity,
                    RareCost = car.RareCost,

                    UncommonQuantity = car.UncommonQuantity,
                    UncommonCost = car.UncommonCost,
                }
            };


        }

        #endregion

        #region Commands

        #region Declarations
        public RelayCommand AddingCarToCompare { get; private set; }
        public RelayCommand RemoveFromCompare { get; private set; }

        #endregion

        #region Initialize Commands

        private void InitializeCommands()
        {
            AddingCarToCompare = new RelayCommand(AddCarToCompare);
            RemoveFromCompare = new RelayCommand(RemoveCurrentFromCompare);
        }

        #endregion

        #endregion

        #region Properties


        public Car CarToAdd
        {
            get => _carToAdd;
            set
            {
                _carToAdd = value;
                RaisePropertyChanged(nameof(CarToAdd));
            }
        }

        private Car _carToRemove;

        public Car CarToRemove
        {
            get => _carToRemove;
            set
            {
                _carToRemove = value;
                switch ((CarType)Enum.Parse(typeof(CarType), value.Type))
                {
                    case CarType.Rare:
                        Foreground = Brushes.Purple;
                        break;
                    case CarType.Epic:
                        Foreground = Brushes.DarkOrange;
                        break;
                    case CarType.Uncommon:
                    default:
                        Foreground = Brushes.Gray;
                        break;
                }
                RaisePropertyChanged(nameof(CarToRemove));
                RaisePropertyChanged(nameof(CurrentItemRemoveString));
                RaisePropertyChanged(nameof(Foreground));
            }
        }


        private string _status;

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        private Brush _foreground;

        public Brush Foreground
        {
            get => _foreground;
            set
            {
                _foreground = value;
                RaisePropertyChanged(nameof(Foreground));
            }
        }

        public ObservableCollection<Car> CarCollection { get; set; }

        public ObservableCollection<Car> CompareCollection { get; private set; }

        public string CurrentItemRemoveString => $"Remove {CarToRemove.FullName} From List";

        #endregion


    }
}
