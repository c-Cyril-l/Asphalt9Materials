using Asphalt_9_Materials.Core;
using Asphalt_9_Materials.ViewModel.Entities;
using Asphalt_9_Materials.ViewModel.Helpers;
using Asphalt_9_Materials.ViewModel.Services;
using Asphalt_9_Materials.ViewModel.Services.Interfaces;
using Asphalt_9_Materials.ViewModel.Validation;
using Helpers.Utilities;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Asphalt_9_Materials.ViewModel.ViewModels.Misc
{
    public class UpdateCarViewModel : CarValidation, IPageService
    {

        #region Constructor

        public UpdateCarViewModel()
        {
            // Initializing commands.
            InitializeCommands();

            // Initializing car instance.
            _car = new Car();

            // Initializing car list.
            CarCollection = new ObservableCollection<Car>();

            // Initializing car image.
            _carImage = new BitmapImage();

            // Initializing image name instance.
            _imageName = string.Empty;

            // Initializing windows dialog service.
            _windowsDialogService = new WindowsDialogService();

        }

        #endregion

        #region Initialize Validation Properties

        private void InitializeValidationProperties()
        {

            #region Information Initialization

            var refill = (double)Car.Refill;

            if (refill > 60)
            {
                Refill = $"{refill / 60}";
                RefillDetection = "Hr(s)";
            }
            else
            {
                Refill = refill.ToString();
                RefillDetection = "Min(s)";
            }

            CarImage = new BitmapImage(new Uri(Car.Image))
            {
                DecodePixelWidth = 570,
                DecodePixelHeight = 318
            };

            ImageName = Path.GetFileNameWithoutExtension(Car.Image);

            #endregion

            #region Blueprints Initialization

            FirstStar = Car.Blueprints.FirstStar.ToString();
            SecondStar = Car.Blueprints.SecondStar.ToString();
            ThirdStar = Car.Blueprints.ThirdStar.ToString();
            FourthStar = Car.Blueprints.FourthStar.ToString();
            FifthStar = Car.Blueprints.FifthStar.ToString();
            SixthStar = Car.Blueprints.SixthStar.ToString();

            #endregion

            #region Ranks Initialization

            StockRank = Car.Ranks.Stock.ToString();
            FirstStarRank = Car.Ranks.FirstStar.ToString();
            SecondStarRank = Car.Ranks.SecondStar.ToString();
            ThirdStarRank = Car.Ranks.ThirdStar.ToString();
            FourthStarRank = Car.Ranks.FourthStar.ToString();
            FifthStarRank = Car.Ranks.FifthStar.ToString();
            SixthStarRank = Car.Ranks.SixthStar.ToString();

            #endregion

            #region Upgrades Initialization

            Stage0 = Car.Upgrades.Stage0.ToString();
            Stage1 = Car.Upgrades.Stage1.ToString();
            Stage2 = Car.Upgrades.Stage2.ToString();
            Stage3 = Car.Upgrades.Stage3.ToString();
            Stage4 = Car.Upgrades.Stage4.ToString();
            Stage5 = Car.Upgrades.Stage5.ToString();
            Stage6 = Car.Upgrades.Stage6.ToString();
            Stage7 = Car.Upgrades.Stage7.ToString();
            Stage8 = Car.Upgrades.Stage8.ToString();
            Stage9 = Car.Upgrades.Stage9.ToString();
            Stage10 = Car.Upgrades.Stage10.ToString();
            Stage11 = Car.Upgrades.Stage11.ToString();
            Stage12 = Car.Upgrades.Stage12.ToString();

            #endregion

            #region Additional Parts Initialization

            EpicCost = Car.AdditionalParts.EpicCost.ToString();
            RareCost = Car.AdditionalParts.RareCost.ToString();
            UncommonCost = Car.AdditionalParts.UncommonCost.ToString();

            #endregion

            #region Performance Initialization

            StockTopSpeed = Car.Performance.StockTopSpeed.ToString();
            StockAcceleration = Car.Performance.StockAcceleration.ToString();
            StockHandling = Car.Performance.StockHandling.ToString();
            StockNitro = Car.Performance.StockNitro.ToString();

            MaxTopSpeed = Car.Performance.MaxTopSpeed.ToString();
            MaxAcceleration = Car.Performance.MaxAcceleration.ToString();
            MaxHandling = Car.Performance.MaxHandling.ToString();
            MaxNitro = Car.Performance.MaxNitro.ToString();

            #endregion

        }

        #endregion        

        #region IPage Implementation

        public string Name => string.Empty;

        #endregion

        #region Commands

        #region Declarations

        public RelayCommand AddImage { get; private set; }

        public RelayCommand UpdateCarCommand { get; private set; }

        #endregion

        #region Initialize Commands

        private void InitializeCommands()
        {
            AddImage = new RelayCommand(AddNewImage);
            UpdateCarCommand = new RelayCommand(UpdatingCar, CanSubmit);
        }

        #endregion

        #endregion

        #region Declarations

        private readonly WindowsDialogService _windowsDialogService;

        private string _imageName;

        private string _status;

        private BitmapImage _carImage;

        private Car _car;

        private Brush _foreground;

        private Brush _statusColor;

        #endregion

        #region Methods

        /// <summary>
        /// A method to open the image for the car.
        /// </summary>
        /// <param name="sender"></param>
        private void AddNewImage(object sender)
        {
            var ofd = _windowsDialogService.OpenFileDialog(@"Image Files (*.png;*.jpg)|*.png;*jpg", false, "Add An Image");

            if (!string.IsNullOrEmpty(ofd))
            {
                CarImage = new BitmapImage(new Uri(ofd))
                { DecodePixelWidth = 570, DecodePixelHeight = 318 };

                ImageName =
                    Path.GetFileNameWithoutExtension(ofd).ToLower().Replace("-", "_");
            }

        }

        /// <summary>
        /// Check whether the car can be updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private bool CanSubmit(object sender)
        {
            using (var a9 = new Asphalt9Entities())
            {
                var carToDelete =
                    a9.Grandes
                    .SingleOrDefault(item => string.Concat(item.Brand, " ", item.CarName)
                    .Equals(Car.FullName));

                return (carToDelete != null) ? true : false;
            }
        }

        /// <summary>
        /// Method to show whether the update operation is succeeded.
        /// </summary>
        private void NotifyCurrentStatus()
        {
            if (!string.IsNullOrEmpty(Status))
                _windowsDialogService.ShowMessageBox(Status,
                                               "Updating Car",
                                               MessageBoxButton.OK,
                                               Status.ToLower().Contains("error") ? MessageBoxImage.Warning :
                                               MessageBoxImage.Information);
        }

        /// <summary>
        /// A Method to execute updating car asynchronously.
        /// </summary>
        /// <param name="sender"></param>
        private void UpdatingCar(object sender)
        {
            Task.Run(ProcessingUpdateAsync).Wait();
        }

        /// <summary>
        /// Updating the car asynchronously.
        /// </summary>
        /// <returns></returns>
        private async Task ProcessingUpdateAsync()
        {
            using (var a9 = new Asphalt9Entities())
            {
                using (var transaction = a9.Database.BeginTransaction())
                {

                    try
                    {
                        // Updating the car.
                        await UpdateCarAsync(a9, Car.FullName);


                        // Saving the update.
                        a9.SaveChanges();

                        // committing the saved changes into the database.
                        transaction.Commit();

                        // Saving the input image to app image directory.
                        if (!FileHelpers.IsImageExist(ImageName))
                        {
                            var encoder = new PngBitmapEncoder();

                            encoder.Frames.Add(BitmapFrame.Create(CarImage));

                            var imagePath = FileHelpers.ImagePath(imageName: ImageName);

                            using (var fileStream = new FileStream(imagePath, FileMode.Create))
                            {
                                encoder.Save(fileStream);
                            }
                        }

                        Status = $"{Car.FullName} Has been updated successfully.";

                    }
                    catch
                    {
                        // Rolling back adding the car in case an error occurred.
                        transaction.Rollback();
                        Status = @"Error occurred while updating the car!";
                    }

                }
            }

        }

        /// <summary>
        /// Replacing the old properties with new ones.
        /// </summary>
        /// <param name="a9">Asphalt 9 Entity</param>
        /// <param name="CarName">Car name</param>
        /// <returns></returns>
        private async Task UpdateCarAsync(Asphalt9Entities a9, string CarName)
        {
            var carToUpdate =
                a9.Grandes
                .FirstOrDefault(item =>
                string.Concat(item.Brand, " ", item.CarName)
                .Equals(CarName));


            await Task.Run(() =>
            {
                // Updating Car Information 
                carToUpdate.Brand = Car.CarBrand;
                carToUpdate.CarName = Car.CarName;
                carToUpdate.CarClass = Car.CarClass;
                carToUpdate.CarType = Car.Type;
                carToUpdate.Fuel = Car.Fuel;
                carToUpdate.Refill = Car.Refill;
                carToUpdate.ReleaseDate = Car.ReleaseDate;

                // Updating Max Stats
                carToUpdate.MaxDetail.TopSpeed = Car.Performance.MaxTopSpeed;
                carToUpdate.MaxDetail.Acceleration = Car.Performance.MaxAcceleration;
                carToUpdate.MaxDetail.Handling = Car.Performance.MaxHandling;
                carToUpdate.MaxDetail.Nitro = Car.Performance.MaxNitro;

                // Updating Stock Stats
                carToUpdate.StockDetail.TopSpeed = Car.Performance.StockTopSpeed;
                carToUpdate.StockDetail.Acceleration = Car.Performance.StockAcceleration;
                carToUpdate.StockDetail.Handling = Car.Performance.StockHandling;
                carToUpdate.StockDetail.Nitro = Car.Performance.StockNitro;

                // Updating Ranks
                carToUpdate.StarRank.FirstStarRank = Car.Ranks.FirstStar;
                carToUpdate.StarRank.SecondStarRank = Car.Ranks.SecondStar;
                carToUpdate.StarRank.ThirdStarRank = Car.Ranks.ThirdStar;
                carToUpdate.StarRank.FourthStarRank = Car.Ranks.FourthStar;
                carToUpdate.StarRank.FifthStarRank = Car.Ranks.FifthStar;
                carToUpdate.StarRank.SixthStarRank = Car.Ranks.SixthStar;
                carToUpdate.StarRank.Max = Car.Ranks.Max;

                // Updating Blueprints
                carToUpdate.Blueprint.FirstStarBP = Car.Blueprints.FirstStar;
                carToUpdate.Blueprint.SecondStarBP = Car.Blueprints.SecondStar;
                carToUpdate.Blueprint.ThirdStarBP = Car.Blueprints.ThirdStar;
                carToUpdate.Blueprint.FourthStarBP = Car.Blueprints.FourthStar;
                carToUpdate.Blueprint.FifthStarBP = Car.Blueprints.FifthStar;
                carToUpdate.Blueprint.SixthStarBP = Car.Blueprints.SixthStar;

                // Updating Upgrades
                carToUpdate.Upgrade.Stage1 = Car.Upgrades.Stage0;
                carToUpdate.Upgrade.Stage2 = Car.Upgrades.Stage1;
                carToUpdate.Upgrade.Stage3 = Car.Upgrades.Stage2;
                carToUpdate.Upgrade.Stage4 = Car.Upgrades.Stage3;
                carToUpdate.Upgrade.Stage5 = Car.Upgrades.Stage4;
                carToUpdate.Upgrade.Stage6 = Car.Upgrades.Stage5;
                carToUpdate.Upgrade.Stage7 = Car.Upgrades.Stage6;
                carToUpdate.Upgrade.Stage8 = Car.Upgrades.Stage7;
                carToUpdate.Upgrade.Stage9 = Car.Upgrades.Stage8;
                carToUpdate.Upgrade.Stage10 = Car.Upgrades.Stage9;
                carToUpdate.Upgrade.Stage11 = Car.Upgrades.Stage10;
                carToUpdate.Upgrade.Stage12 = Car.Upgrades.Stage11;
                carToUpdate.Upgrade.Stage13 = Car.Upgrades.Stage12;
                carToUpdate.Upgrade.Total = Car.Upgrades.TotalStagesCost;

                // Updating Uncommon Parts
                carToUpdate.UncommonPart.Quantity = Car.AdditionalParts.UncommonQuantity;
                carToUpdate.UncommonPart.Cost = Car.AdditionalParts.UncommonCost;
                carToUpdate.UncommonPart.TotalCost = Car.AdditionalParts.UncommonTotalCost;

                // Updating Rare Parts
                carToUpdate.RarePart.Quantity = Car.AdditionalParts.RareQuantity;
                carToUpdate.RarePart.Cost = Car.AdditionalParts.RareCost;
                carToUpdate.RarePart.TotalCost = Car.AdditionalParts.RareTotalCost;

                // Updating Epic Parts
                carToUpdate.EpicPart.Quantity = Car.AdditionalParts.EpicQuantity;
                carToUpdate.EpicPart.Cost = Car.AdditionalParts.EpicCost;
                carToUpdate.EpicPart.TotalCost = Car.AdditionalParts.EpicTotalCost;

            });

        }

        #endregion

        #region Properties        

        /// <summary>
        /// Car to update
        /// </summary>
        public override Car Car
        {
            get => _car;
            set
            {
                _car = value;

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

                RaisePropertyChanged(nameof(Car));
                RaisePropertyChanged(nameof(Foreground));
                InitializeValidationProperties();


            }
        }

        /// <summary>
        /// Operation result message.
        /// </summary>
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                RaisePropertyChanged(nameof(Status));
                NotifyCurrentStatus();
            }
        }

        /// <summary>
        /// Status color whether red or green depending on status 
        /// </summary>
        public Brush StatusColor
        {
            get => _statusColor;
            set
            {
                _statusColor = value;
                RaisePropertyChanged(nameof(StatusColor));
            }
        }

        /// <summary>
        /// Car type foreground color.
        /// </summary>
        public Brush Foreground
        {
            get => _foreground;
            set
            {
                _foreground = value;
                RaisePropertyChanged(nameof(Foreground));
            }
        }

        /// <summary>
        /// Image name of the car.
        /// </summary>
        public string ImageName
        {
            get => _imageName;
            set
            {
                _imageName = value;
                RaisePropertyChanged(nameof(ImageName));
            }
        }

        /// <summary>
        /// The Image of the car.
        /// </summary>
        public BitmapImage CarImage
        {
            get => _carImage;
            set
            {
                _carImage = value;
                RaisePropertyChanged(nameof(CarImage));
            }
        }

        /// <summary>
        /// The Collection of available cars.
        /// </summary>
        public ObservableCollection<Car> CarCollection { get; set; }

        #endregion

    }
}
