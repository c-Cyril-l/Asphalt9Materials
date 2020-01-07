using Asphalt_9_Materials.Core;
using Asphalt_9_Materials.ViewModel.Entities;
using Asphalt_9_Materials.ViewModel.Helpers;
using Asphalt_9_Materials.ViewModel.Services;
using Asphalt_9_Materials.ViewModel.Services.Interfaces;
using Asphalt_9_Materials.ViewModel.Validation;
using Helpers.Utilities;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Asphalt_9_Materials.ViewModel.ViewModels.Misc
{
    public class AddNewViewModel : CarValidation, IPageService
    {

        #region Constructor

        public AddNewViewModel()
        {
            // Initializing commands.
            InitializeCommands();

            // Initializing car instance.
            _car = new Car();

            // Initializing windows dialog service.
            _windowsDialogService = new WindowsDialogService();

            // Initializing car image.
            _carImage = new BitmapImage();

            // Initializing image name.
            _imageName = string.Empty;

            // load drafted car if there will be a drafted one.
            LoadDraftedFile();
        }

        #endregion

        #region IPage Implementation

        public string Name => string.Empty;

        #endregion

        #region Commands 

        #region Declarations

        public RelayCommand AddImage { get; private set; }
        public RelayCommand DraftCommand { get; private set; }

        public RelayCommand ClearDraft { get; private set; }
        public RelayCommand AddNewCarCommand { get; private set; }

        #endregion

        #region Initialize Commands

        private void InitializeCommands()
        {
            AddImage = new RelayCommand(AddNewImage);
            DraftCommand = new RelayCommand(DraftInfo);
            ClearDraft = new RelayCommand(ClearCurrentInformations, IsJsonFileExist);
            AddNewCarCommand = new RelayCommand(AddingCar, CanSubmit);
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Adding the new car asynchronously.
        /// </summary>
        /// <returns></returns>
        private async Task AddCarAsync()
        {
            using (var a9 = new Asphalt9Entities())
            {
                using (var transaction = a9.Database.BeginTransaction())
                {

                    try
                    {
                        // creating new entity with the given car information by the user.
                        var newCar = new Grande
                        {
                            Brand = Car.CarBrand,
                            CarName = Car.CarName,
                            CarClass = Car.CarClass,
                            CarType = Enum.Parse(typeof(CarType), Car.Type).ToString(),
                            Fuel = Car.Fuel,
                            CarImage = string.Concat(Car.CarClass.ToLower(), "_", ImageName),
                            Refill = Car.Refill,
                            ReleaseDate = Car.ReleaseDate,
                            Stars = Car.Stars,

                            // every single grande entity has the links with other entities via foreign key created in database.

                            Blueprint = new Entities.Blueprint()
                            {
                                FirstStarBP = Car.Blueprints.FirstStar,
                                SecondStarBP = Car.Blueprints.SecondStar,
                                ThirdStarBP = Car.Blueprints.ThirdStar,
                                FourthStarBP = Car.Blueprints.FourthStar,
                                FifthStarBP = Car.Blueprints.FifthStar,
                                SixthStarBP = Car.Blueprints.SixthStar,
                                TotalBP = Car.Blueprints.Total
                            },

                            StockDetail = new StockDetail()
                            {
                                TopSpeed = Car.Performance.StockTopSpeed,
                                Acceleration = Car.Performance.StockAcceleration,
                                Handling = Car.Performance.StockHandling,
                                Nitro = Car.Performance.StockNitro,
                            },

                            MaxDetail = new MaxDetail()
                            {
                                TopSpeed = Car.Performance.MaxTopSpeed,
                                Acceleration = Car.Performance.MaxAcceleration,
                                Handling = Car.Performance.MaxHandling,
                                Nitro = Car.Performance.MaxNitro,
                            },

                            StarRank = new StarRank()
                            {
                                StockStarRank = Car.Ranks.Stock,
                                FirstStarRank = Car.Ranks.FirstStar,
                                SecondStarRank = Car.Ranks.SecondStar,
                                ThirdStarRank = Car.Ranks.ThirdStar,
                                FourthStarRank = Car.Ranks.FourthStar,
                                FifthStarRank = Car.Ranks.FifthStar,
                                SixthStarRank = Car.Ranks.SixthStar,
                                Max = Car.Ranks.Max
                            },

                            Upgrade = new Upgrade()
                            {
                                Stage1 = Car.Upgrades.Stage0,
                                Stage2 = Car.Upgrades.Stage1,
                                Stage3 = Car.Upgrades.Stage2,
                                Stage4 = Car.Upgrades.Stage3,
                                Stage5 = Car.Upgrades.Stage4,
                                Stage6 = Car.Upgrades.Stage5,
                                Stage7 = Car.Upgrades.Stage6,
                                Stage8 = Car.Upgrades.Stage7,
                                Stage9 = Car.Upgrades.Stage8,
                                Stage10 = Car.Upgrades.Stage9,
                                Stage11 = Car.Upgrades.Stage10,
                                Stage12 = Car.Upgrades.Stage11,
                                Stage13 = Car.Upgrades.Stage12,
                                Total = Car.Upgrades.TotalStagesCost

                            },

                            UncommonPart = new UncommonPart()
                            {
                                Cost = Car.AdditionalParts.UncommonCost,
                                Quantity = Car.AdditionalParts.UncommonQuantity,
                                TotalCost = Car.AdditionalParts.UncommonTotalCost
                            },

                            RarePart = new RarePart()
                            {
                                Cost = Car.AdditionalParts.RareCost,
                                Quantity = Car.AdditionalParts.RareQuantity,
                                TotalCost = Car.AdditionalParts.RareTotalCost
                            },

                            EpicPart = new EpicPart()
                            {
                                Cost = Car.AdditionalParts.EpicCost,
                                Quantity = Car.AdditionalParts.EpicQuantity,
                                TotalCost = Car.AdditionalParts.EpicTotalCost
                            }

                        };

                        // here we check if the current car is new or already exist.
                        if (a9.Grandes
                            .Any(item => string.Concat(item.Brand, " ", item.CarName) ==
                            string.Concat(newCar.Brand, " ", newCar.CarName)))
                        {
                            Status = "Another car with same name is already exists!";
                            return;
                        }

                        // Adding new Car
                        a9.Grandes.Add(newCar);

                        // saving the addition.
                        a9.SaveChanges();

                        // Committing the addition of the new car into the database.
                        transaction.Commit();

                        // Saving the image into app image directory.
                        await Task.Run(() =>
                        {

                            var encoder = new PngBitmapEncoder();

                            encoder.Frames.Add(item: BitmapFrame.Create(source: CarImage));

                            var imagePath = FileHelpers.ImagePath(imageName: newCar.CarImage);

                            using (var fileStream = new FileStream(path: imagePath, mode: FileMode.Create))
                            {
                                encoder.Save(stream: fileStream);
                            }
                        });

                        // Notifying the state of operation.
                        Status = $"{newCar.Brand} {newCar.CarName} has been added successfully.";

                    }
                    catch
                    {
                        // Rolling back adding the car in case an error occurred.
                        transaction.Rollback();
                        Status = @"Error occurred while adding the car!";
                    }

                }
            }

        }

        /// <summary>
        /// A Method to execute the adding car asynchronously.
        /// </summary>
        /// <param name="sender"></param>
        private void AddingCar(object sender)
        {
            Task.Run(AddCarAsync).Wait();
        }

        /// <summary>
        /// Check whether a new car can be added.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private bool CanSubmit(object sender)
        {
            // returns true if car properties meet the required conditions.
            return Car.IsValid();
        }

        /// <summary>
        /// Indicates whether the draft file exist.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>Whether the json file is exist.</returns>
        private bool IsJsonFileExist(object sender = null)
        {
            return File.Exists(FileHelpers.JsonFile);
        }

        /// <summary>
        /// Loading the saved car properties (if ever saved ofc).
        /// </summary>
        private void LoadDraftedFile()
        {
            if (!IsJsonFileExist()) return;
            var json = File.ReadAllText(FileHelpers.JsonFile);

            if (string.IsNullOrEmpty(json)) return;
            var car = JsonConvert.DeserializeObject<Car>(json);

            if (FileHelpers.IsImageExist(car.Image, true))
            {
                ImagePath = Car.Image;

                CarImage = new BitmapImage(new Uri(ImagePath)) { DecodePixelWidth = 570, DecodePixelHeight = 318 };

                ImageName =
            Path.GetFileNameWithoutExtension(ImagePath).ToLower().Replace("-", "_");
            }
            Car = car;

        }

        /// <summary>
        /// Saving the current car properties for later use.
        /// </summary>
        /// <param name="sender"></param>
        private void DraftInfo(object sender)
        {
            var car = Car;
            car.Image = ImagePath;
            var json = JsonConvert.SerializeObject(car);
            File.WriteAllText(FileHelpers.JsonFile, json);
        }

        /// <summary>
        /// Add the image of the car
        /// </summary>
        /// <param name="sender"></param>
        private void AddNewImage(object sender)
        {
            var ofd = _windowsDialogService.OpenFileDialog(@"Image Files (*.png;*.jpg)|*.png;*jpg", false, "Add An Image");

            // indication whether the user selected an image or cancelled the dialog.
            if (!string.IsNullOrEmpty(ofd))
            {
                ImagePath = ofd;

                CarImage = new BitmapImage(new Uri(ofd))
                { DecodePixelWidth = 570, DecodePixelHeight = 318 };

                ImageName =
                    Path.GetFileNameWithoutExtension(ofd).ToLower().Replace("-", "_");
            }
        }

        /// <summary>
        /// Clearing the current informations that came from drafted;
        /// </summary>
        /// <param name="sender"></param>
        private void ClearCurrentInformations(object sender)
        {
            _car = new Car();
            RaisePropertyChanged(nameof(Car));
            ClearProperties();
        }


        /// <summary>
        /// Method to show whether the update operation is succeeded.
        /// </summary>
        private void NotifyCurrentStatus()
        {
            if (!string.IsNullOrEmpty(Status))
                _windowsDialogService.ShowMessageBox(Status,
                                               "Adding New Car",
                                               MessageBoxButton.OK,
                                               Status.ToLower().Contains("error") ? MessageBoxImage.Warning :
                                               MessageBoxImage.Information);
        }

        #endregion

        #region Declarations

        private readonly WindowsDialogService _windowsDialogService;

        private Car _car;

        private string _status;

        private string _imageName;

        private BitmapImage _carImage;

        private Brush _foreground;

        private Brush _statusColor;

        private string _imagePath;

        #endregion

        #region Properties

        /// <summary>
        /// The Car To add, every property the user provides will be connected to this.
        /// </summary>
        public override Car Car
        {
            get => _car;
            set
            {
                _car = value;

                // Changing Car type foreground.
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

                // Indication whether the added property meet the rules.
                InitializeValidationProperties();
            }
        }

        /// <summary>
        /// Car type foreground.
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
                Car.Image = value;
                RaisePropertyChanged(nameof(ImageName));
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
        /// Car Image.
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
        /// The Path of added image.
        /// </summary>
        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                RaisePropertyChanged(nameof(ImagePath));
            }
        }

        #region Initialize Validation Properties

        private void InitializeValidationProperties()
        {
            #region Information Initialization

            var refill = Car.Refill ?? 0;
            TimeSpan ts = TimeSpan.FromMinutes(refill);
            if (ts.TotalMinutes > 60)
            {
                Refill = $"{ts.TotalMinutes / 60}";
                RefillDetection = "Hr(s)";
            }
            else
            {
                Refill = ts.Minutes.ToString();
                RefillDetection = "Min(s)";
            }
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

        #endregion

    }
}
