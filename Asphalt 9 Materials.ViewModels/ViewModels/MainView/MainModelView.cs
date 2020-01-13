using Asphalt_9_Materials.Core;
using Asphalt_9_Materials.ViewModel.Entities;
using Asphalt_9_Materials.ViewModel.Helpers;
using Asphalt_9_Materials.ViewModel.Services;
using Asphalt_9_Materials.ViewModel.Services.Interfaces;
using Asphalt_9_Materials.ViewModel.ViewModels.About;
using Asphalt_9_Materials.ViewModel.ViewModels.AvailableCars;
using Asphalt_9_Materials.ViewModel.ViewModels.Blueprints;
using Asphalt_9_Materials.ViewModel.ViewModels.Career;
using Asphalt_9_Materials.ViewModel.ViewModels.Introduction;
using Asphalt_9_Materials.ViewModel.ViewModels.Misc;
using Asphalt_9_Materials.ViewModel.ViewModels.Misc.Comparison;
using Asphalt_9_Materials.ViewModel.ViewModels.Performance.Performance;
using Asphalt_9_Materials.ViewModel.ViewModels.Ranks;
using Asphalt_9_Materials.ViewModel.ViewModels.Routes;
using Helpers.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Asphalt_9_Materials.ViewModel.ViewModels.MainView
{
    public class MainModelView : ObservableObject
    {

        #region Declarations

        private WindowState _windowState;

        #endregion

        #region Constructor

        public MainModelView()
        {
            // Initializing ViewModelList Instance.
            ViewModelList = new List<IPageService>();

            // Initializing ViewModels.
            InitializeViewModels();

            // Adding ViewModels to ViewModelList.
            AddingViewModels();

            // Initializing Collections.
            InitializeObservableCollections();

            // Initializing default value for WindowState.
            _windowState = WindowState.Normal;

            // Initializing Commands.
            InitializeCommands();

            // Set the main view as Introduction ViewModel.
            IntroductionNavigation(IntroductionViewModel);

        }

        #endregion

        #region Properties

        /// <summary>
        /// Windows states.
        /// </summary>
        public WindowState WindowState
        {
            get { return _windowState; }
            set
            {
                _windowState = value;
                RaisePropertyChanged(nameof(WindowState));
            }
        }


        #endregion

        #region Task Lists

        /// <summary>
        /// Getting car list from the database by executing stored procedure.
        /// </summary>
        /// <param name="carClass">Car class</param>
        /// <param name="isClass">Is class has been provided?</param>
        /// <returns>A List of cars based on given information.</returns>
        internal async Task<ObservableCollection<Car>> CarListAsync(string carClass, bool isClass)
        {
            var a9 = new Asphalt9Entities();
            try
            {
                var getInfo = new GettingInfo();

                var getCarInfo = new GetModeledInformations();

                var stats = await getInfo.GettingCarsAsync(carClass, a9, isClass);

                var performsList = new ObservableCollection<Car>();

                stats.ForEach(item =>
                {
                    var car = getCarInfo.GetCar(item);
                    performsList.Add(car);
                });

                return performsList;
            }
            finally
            {
                a9.Dispose();
            }
        }

        /// <summary>
        /// Getting career list from the database by executing stored procedure.
        /// </summary>
        /// <param name="chapter">Career chapter</param>
        /// <param name="isChapter">Is chapter has been provided?</param>
        /// <returns>A List of chapters based on given information.</returns>
        internal async Task<ObservableCollection<Core.Career>> CareerListAsync(int chapter, bool isChapter)
        {
            var a9 = new Asphalt9Entities();
            try
            {
                var getInfo = new GettingInfo();

                var getCareerInfo = new GetModeledInformations();

                var stats = await getInfo.GettingCareerAsync(chapter, a9, isChapter);

                var careerList = new ObservableCollection<Core.Career>();

                stats.ForEach(item =>
                {
                    var career = getCareerInfo.GetCareer(item);
                    careerList.Add(career);
                });

                return careerList;
            }
            finally
            {
                a9.Dispose();
            }
        }

        #endregion

        #region Methods

        #region Exporting Database

        /// <summary>
        /// Generate database script asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task GenerateScriptAsync()
        {

            var windowsDialogService = new WindowsDialogService();

            var dialogResult = windowsDialogService.SaveFileDialog(@"Script File(*.sql)|*.sql",
                                                  @"Exporting Database",
                                                  "Asphalt 9 Materials",
                                                  true,
                                                  Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            if (dialogResult.Item1 != true)
                return;

            var dS = new DatabaseScript();

            var connectionString =
                $@"data source=.\SQLEXPRESS;attachdbfilename=|DataDirectory|\Asphalt9DB.mdf;integrated security=True;multipleactiveresultsets=True;connect timeout=50;user instance=True;Initial Catalog=Asphalt9";

            await dS.GenerateDatabaseScript(connectionString,
                dialogResult.Item3);

            MessageBox.Show($"Script Generated Successfully! \n {dialogResult.Item2}");

        }

        #endregion

        #region About Methods

        /// <summary>
        /// Show about view models asynchronously.
        /// </summary>
        /// <param name="viewModel">ViewModel name in about section.</param>
        /// <returns></returns>
        private async Task ShowAboutViewModels(string viewModel)
        {
            await Task.Run(() =>
            {
                switch (viewModel)
                {
                    case "about":
                        AboutNavigation(AboutViewModel);
                        break;

                    case "credits":
                        AboutNavigation(CreditsViewModel);
                        break;
                }
            });
        }

        #endregion

        #region Introduction Methods

        /// <summary>
        /// Show introduction view models asynchronously.
        /// </summary>
        /// <param name="viewModel">ViewModel name in introduction sections.</param>
        /// <returns></returns>
        private async Task ShowIntroductionViewModels(string viewModel)
        {
            await Task.Run(() =>
            {
                switch (viewModel)
                {
                    case "intro":
                        IntroductionNavigation(IntroductionViewModel);
                        break;

                    case "game_play":
                        IntroductionNavigation(GamePlayViewModel);
                        break;

                    case "currencies":
                        IntroductionNavigation(CurrenciesViewModel);
                        break;

                    case "how_to":
                        IntroductionNavigation(HowToViewModel);
                        break;

                    case "tips":
                        IntroductionNavigation(TipsViewModel);
                        break;
                }
            });
        }


        #endregion

        #region Available Cars Methods

        /// <summary>
        /// Adding car for specified class.
        /// </summary>
        /// <param name="carClass">The Class to get cars.</param>
        /// <param name="isClass">Is Class has been provided?</param>
        /// <returns></returns>
        public async Task AddClassCarsAsync(string carClass, bool isClass = true)
        {
            CarList.Clear();
            CardList.Clear();

            CarList = await CarListAsync(carClass: carClass, isClass: isClass);

            await CreateCardAsync(CarList);
        }


        /// <summary>
        /// Demonstrating cars as cards.
        /// </summary>
        /// <param name="carList">List of cars.</param>
        /// <returns></returns>
        private async Task CreateCardAsync(ObservableCollection<Car> carList)
        {
            CardList.Clear();
            foreach (var car in carList)
            {
                var card = new CarCardViewModel { Car = car, ImageUri = car.Image };
                await Task.Run(() =>
                {
                    CardList.Add(card);
                });

                AddCarCardsToCarViewModel();
            }
        }

        /// <summary>
        /// Adding car cards to view model and navigating main view to it.
        /// </summary>
        private void AddCarCardsToCarViewModel()
        {
            CarsPageViewModel.CardCollection.Clear();

            foreach (var item in CardList)
            {
                CarsPageViewModel.CardCollection.Add(item);
            }

            CarNavigation();
        }

        #endregion

        #region Ranks Methods

        /// <summary>
        /// Adding ranks asynchronously.
        /// </summary>
        /// <param name="carClass">Car class</param>
        /// <param name="isClass">Is class has been provided?</param>
        /// <returns></returns>
        private async Task AddingRanksAsync(string carClass, bool isClass = true)
        {
            var carRanksList = await CarListAsync(carClass: carClass, isClass: isClass);
            AddRanksToRanksViewModel(carRanksList);
        }

        /// <summary>
        /// Add ranks to its view model.
        /// </summary>
        /// <param name="carList">The List of cars</param>
        private void AddRanksToRanksViewModel(IReadOnlyCollection<Car> carList)
        {
            if (carList == null) return;
            var currentDispatcher = Application.Current.Dispatcher;
            currentDispatcher?.Invoke(delegate
            {
                CarRanksViewModel.CarCollection.Clear();

                foreach (var item in carList)
                {
                    CarRanksViewModel.CarCollection.Add(item);
                }
            });
            RankNavigation();
        }

        #endregion

        #region Blueprints Methods

        /// <summary>
        /// Adding blueprints asynchronously.
        /// </summary>
        /// <param name="carClass">Car class</param>
        /// <param name="isClass">Is class has been provided?</param>
        /// <returns></returns>
        public async Task AddBlueprintsAsync(string carClass, bool isClass = true)
        {
            var blueprintsList = await CarListAsync(carClass: carClass, isClass: isClass);

            AddBlueprintsToViewModel(blueprintsList);
        }

        /// <summary>
        /// Add blueprints to its view model.
        /// </summary>
        /// <param name="carList">the list of cars</param>
        private void AddBlueprintsToViewModel(IReadOnlyCollection<Car> carList)
        {
            if (carList == null) return;
            var currentDispatcher = Application.Current.Dispatcher;
            currentDispatcher?.Invoke(delegate
            {
                BlueprintsPageViewModel.CarCollection.Clear();
                foreach (var item in carList)
                {
                    BlueprintsPageViewModel.CarCollection.Add(item);
                }
            });

            BlueprintNavigation();
        }

        #endregion

        #region Performance Stats Methods

        /// <summary>
        /// Adding Performance stats for specified class and type (Max or Stock).
        /// </summary>
        /// <param name="carClass">Car class</param>
        /// <param name="performanceType">Performance type whether max or speed.</param>
        /// <param name="isClass">Is class has been provided?</param>
        /// <returns></returns>
        private async Task AddingPerformanceStatsAsync(string carClass, string performanceType, bool isClass = true)
        {
            var performsList = await CarListAsync(carClass, isClass);
            var isMaxed = performanceType.ToLower() == "max";
            AddPerformancesToViewModel(performsList, isMaxed);
        }

        /// <summary>
        /// Adding performance stats to main view and navigating main view to it.
        /// </summary>
        /// <param name="carList">list of cars</param>
        /// <param name="isMaxed">whether the max stats or stock stats</param>
        private void AddPerformancesToViewModel(IEnumerable<Car> carList, bool isMaxed = false)
        {
            var currentDispatcher = Application.Current.Dispatcher;

            if (isMaxed)
            {
                currentDispatcher?.Invoke(delegate
                {
                    MaxPerformanceViewModel.CarCollection.Clear();
                    foreach (var item in carList)
                    {
                        MaxPerformanceViewModel.CarCollection.Add(item);
                    }
                });
                PerformanceNavigation(MaxPerformanceViewModel);
            }
            else
            {
                currentDispatcher?.Invoke(delegate
                {
                    StockPerformanceViewModel.CarCollection.Clear();
                    foreach (var item in carList)
                    {
                        StockPerformanceViewModel.CarCollection.Add(item);
                    }
                });
                PerformanceNavigation(StockPerformanceViewModel);
            }
        }

        #endregion

        #region Carrer Methods

        /// <summary>
        /// Adding chapters asynchronously.
        /// </summary>
        /// <param name="chapter">Chapter to add</param>
        /// <param name="isChapter">Is chapter has been provided?</param>
        /// <returns></returns>
        public async Task AddChaptersAsync(string chapter, bool isChapter = true)
        {
            int.TryParse(chapter, out var chapterNumber);

            var chapterList = await CareerListAsync(chapter: chapterNumber, isChapter: isChapter);

            AddToChaptersToViewModel(chapterList);
        }

        /// <summary>
        /// Adding given chapters to chapters page.
        /// </summary>
        /// <param name="chapterList">List of chapters.</param>
        private void AddToChaptersToViewModel(ObservableCollection<Core.Career> chapterList)
        {
            var currentDispatcher = Application.Current.Dispatcher;
            currentDispatcher?.Invoke(delegate
            {
                CareerViewModel.CareerCollection.Clear();
                foreach (var item in chapterList)
                {
                    CareerViewModel.CareerCollection.Add(item);
                }
            });

            // Navigating to career page.
            CareerNavigation();
        }


        #endregion

        #region Misc Methods

        #region Section Navaigation

        /// <summary>
        /// A Method to determine type of misc navigations requested by the user.
        /// </summary>
        /// <param name="miscNavigationType"></param>
        /// <param name="compareType">Comparison type in case the navigation type is comparison.</param>
        private void MiscellaneousNavigationRequest(string miscNavigationType, string compareType = null)
        {
            switch (miscNavigationType)
            {
                case "ImportantNote":
                    Task.Factory.StartNew(() => MiscNavigation(ImportantNoteViewModel)).Wait();
                    break;
                case "AddNewCar":
                    Task.Factory.StartNew(() => MiscNavigation(AddNewCarViewModel)).Wait();
                    break;
                case "DeleteCar":
                    Task.Factory.StartNew(() => AddDeleteCarAsync(string.Empty, false)).Wait();
                    break;
                case "UpdateCar":
                    Task.Factory.StartNew(() => AddCarUpdateAsync(string.Empty, false)).Wait();
                    break;
                case "CarComparison":
                    Task.Factory.StartNew(() => AddCarComparisonAsync(string.Empty, false, compareType)).Wait();
                    break;
            }
        }

        #endregion

        #region Delete Car Methods

        /// <summary>
        /// Adding cars to delete asynchronously.
        /// </summary>
        /// <param name="carClass">Car class</param>
        /// <param name="isClass">Is class has been provided?</param>
        /// <returns></returns>
        public async Task AddDeleteCarAsync(string carClass, bool isClass = true)
        {
            var carList = await CarListAsync(carClass: carClass, isClass: isClass);
            DeleteCarPage(carList);
        }

        /// <summary>
        /// Add cars to delete view model.
        /// </summary>
        /// <param name="carList">List of cars</param>
        private void DeleteCarPage(ObservableCollection<Car> carList)
        {
            var currentDispatcher = Application.Current.Dispatcher;
            currentDispatcher?.Invoke(delegate
            {
                DeleteCarViewModel.CarCollection.Clear();
                foreach (var item in carList)
                {
                    DeleteCarViewModel.CarCollection.Add(item);
                }
            });

            MiscNavigation(DeleteCarViewModel);
        }

        #endregion

        #region Update Car Methods

        /// <summary>
        /// Adding cars to update asynchronously.
        /// </summary>
        /// <param name="carClass">Car class</param>
        /// <param name="isClass">Is class has been provided?</param>
        /// <returns></returns>
        public async Task AddCarUpdateAsync(string carClass, bool isClass = true)
        {
            var carList = await CarListAsync(carClass: carClass, isClass: isClass);
            AddCarToUpdateViewModel(carList);
        }

        /// <summary>
        /// Add cars to update view model.
        /// </summary>
        /// <param name="carList">List of cars</param>
        private void AddCarToUpdateViewModel(ObservableCollection<Car> carList)
        {
            var currentDispatcher = Application.Current.Dispatcher;
            currentDispatcher?.Invoke(delegate
            {
                UpdateCarViewModel.CarCollection.Clear();
                foreach (var item in carList)
                {
                    UpdateCarViewModel.CarCollection.Add(item);
                }
            });

            MiscNavigation(UpdateCarViewModel);
        }

        #endregion

        #region Compare Cars Methods

        /// <summary>
        /// Adding cars to comparison view models.
        /// </summary>
        /// <param name="carClass">Car class</param>
        /// <param name="isClass">Is class has been provided?</param>
        /// <param name="compareType">comparison type whether stock or max</param>
        /// <returns></returns>
        public async Task AddCarComparisonAsync(string carClass, bool isClass = true, string compareType = "Stock")
        {
            var carList = await CarListAsync(carClass: carClass, isClass: isClass);
            AddCarsToComparisonViewModel(carList, compareType);
        }

        /// <summary>
        /// Add cars to their comparison view model.
        /// </summary>
        /// <param name="carList">List of cars</param>
        /// <param name="compareType">comparison type whether stock or max</param>
        private void AddCarsToComparisonViewModel(ObservableCollection<Car> carList, string compareType)
        {
            var currentDispatcher = Application.Current.Dispatcher;

            switch (compareType.ToLower())
            {
                case "max":
                    currentDispatcher?.Invoke(delegate
                    {
                        MaxComparisonViewModel.CarCollection.Clear();
                        foreach (var item in carList)
                        {
                            MaxComparisonViewModel.CarCollection.Add(item);
                        }
                    });
                    MiscNavigation(MaxComparisonViewModel);
                    break;
                case "rank":
                    currentDispatcher?.Invoke(delegate
                    {
                        RankComparisonViewModel.CarCollection.Clear();
                        foreach (var item in carList)
                        {
                            RankComparisonViewModel.CarCollection.Add(item);
                        }
                    });
                    MiscNavigation(RankComparisonViewModel);
                    break;
                case "blueprints":
                    currentDispatcher?.Invoke(delegate
                    {
                        BlueprintsComparisonViewModel.CarCollection.Clear();
                        foreach (var item in carList)
                        {
                            BlueprintsComparisonViewModel.CarCollection.Add(item);
                        }
                    });
                    MiscNavigation(BlueprintsComparisonViewModel);
                    break;

                case "stock":
                    currentDispatcher?.Invoke(delegate
                    {
                        StockComparisonViewModel.CarCollection.Clear();
                        foreach (var item in carList)
                        {
                            StockComparisonViewModel.CarCollection.Add(item);
                        }
                    });
                    MiscNavigation(StockComparisonViewModel);
                    break;
            }
        }

        #endregion

        #endregion

        #region Routes Methods

        /// <summary>
        /// Adding Routes Asynchronously.
        /// </summary>
        /// <param name="location">City</param>
        /// <returns></returns>
        public async Task AddRoutesAsync(string location)
        {
            using (var a9 = new Asphalt9Entities())
            {
                var query = (await a9.RouteTracks
                    .AsNoTracking()
                    .Where(m => m.Location.ToLower() == location)
                    .ToListAsync()).Select(m => new
                    {
                        _Location = m.Location,
                        _Track = m.Track,
                        Duration = m.duration ?? 0,
                        Video = m.video
                    })
                    .ToList();

                var trackList = new ObservableCollection<Tuple<string, string, int, string>>();

                query.ForEach(m => trackList.Add(new Tuple<string, string, int, string>(m._Location,
                                                                                        m._Track,
                                                                                        m.Duration,
                                                                                        m.Video)));
                AddTracksToTrackPage(trackList);
            }
        }

        /// <summary>
        /// Adding Tracks to its view model.
        /// </summary>
        /// <param name="trackList">The List of tracks.</param>
        private void AddTracksToTrackPage(ObservableCollection<Tuple<string, string, int, string>> trackList)
        {
            var currentDispatcher = Application.Current.Dispatcher;
            currentDispatcher?.Invoke(delegate
            {
                RouteTracksViewModel.RouteCollection.Clear();

                foreach (var item in trackList)
                {
                    RouteTracksViewModel.RouteCollection.Add(item);
                    RouteTracksViewModel.RouteName = item.Item1;
                }
            });
            RouteNavigation();
        }

        #endregion

        #endregion

        #region WindowStates & Closing Application

        /// <summary>
        /// Closing Entire Application.
        /// </summary>
        /// <param name="sender"></param>
        private static void CloseApplication(object sender) { Application.Current.Shutdown(); }

        /// <summary>
        /// Minimizing Application
        /// </summary>
        /// <param name="obj"></param>
        private void MinimizeApplication(object obj) { WindowState = WindowState.Minimized; }

        #endregion

        #region View Models

        #region Creating instance for view models

        private ImportantNoteViewModel _importantViewModel;
        private AddNewViewModel _addNewCarViewModel;
        private DeleteCarViewModel _deleteCarViewModel;
        private UpdateCarViewModel _updateCarViewModel;
        private MaxComparisonViewModel _maxComparisonViewModel;
        private StockComparisonViewModel _stockComparisonViewModel;
        private RankComparisonViewModel _rankComparisonViewModel;
        private BlueprintsComparisonViewModel _blueprintsComparisonViewModel;

        private AboutViewModel _aboutViewModel;
        private CreditsViewModel _creditsViewModel;

        private IntroductionViewModel _introductionViewModel;
        private TipsViewModel _tipsViewModel;
        private HowToViewModel _howToViewModel;
        private GamePlayViewModel _gamePlayViewModel;
        private CurrenciesViewModel _currenciesViewModel;

        private CareerViewModel _careerViewModel;

        private BlueprintsViewModel _blueprintsPageViewModel;

        private StarRanksViewModel _carRanksViewModel;

        private CarsPageViewModel _carsPageViewModel;

        private StockPerformanceViewModel _stockPerformanceViewModel;
        private MaxPerformanceViewModel _maxPerformanceViewModel;

        private TracksViewModel _routeTracksViewModel;



        #endregion

        #region Initialize ViewModels

        /// <summary>
        /// Initializing View Models Instances.
        /// </summary>
        private void InitializeViewModels()
        {
            _aboutViewModel = new AboutViewModel();
            _creditsViewModel = new CreditsViewModel();
            _tipsViewModel = new TipsViewModel();
            _howToViewModel = new HowToViewModel();
            _currenciesViewModel = new CurrenciesViewModel();
            _gamePlayViewModel = new GamePlayViewModel();
            _importantViewModel = new ImportantNoteViewModel();
            _introductionViewModel = new IntroductionViewModel();
            _careerViewModel = new CareerViewModel();
            _blueprintsPageViewModel = new BlueprintsViewModel();
            _carRanksViewModel = new StarRanksViewModel();
            _carsPageViewModel = new CarsPageViewModel();
            _maxPerformanceViewModel = new MaxPerformanceViewModel();
            _stockPerformanceViewModel = new StockPerformanceViewModel();
            _routeTracksViewModel = new TracksViewModel();
            _addNewCarViewModel = new AddNewViewModel();
            _deleteCarViewModel = new DeleteCarViewModel();
            _updateCarViewModel = new UpdateCarViewModel();
            _maxComparisonViewModel = new MaxComparisonViewModel();
            _stockComparisonViewModel = new StockComparisonViewModel();
            _rankComparisonViewModel = new RankComparisonViewModel();
            _blueprintsComparisonViewModel = new BlueprintsComparisonViewModel();
        }

        #endregion

        #region Adding View Models

        /// <summary>
        /// Adding view models to the list (list of view models).
        /// </summary>
        private void AddingViewModels()
        {
            ViewModelList.AddRange(collection: new IPageService[]
                {
                    CarsPageViewModel,
                    BlueprintsPageViewModel,
                    MaxPerformanceViewModel,
                    StockPerformanceViewModel,
                    CarRanksViewModel,
                    RouteTracksViewModel,
                    AddNewCarViewModel,
                    DeleteCarViewModel,
                    UpdateCarViewModel,
                    MaxComparisonViewModel,
                    StockComparisonViewModel,
                    RankComparisonViewModel,
                    BlueprintsComparisonViewModel,
                    CareerViewModel,
                    IntroductionViewModel,
                    GamePlayViewModel,
                    CurrenciesViewModel,
                    HowToViewModel,
                    AboutViewModel,
                    CreditsViewModel,
                    TipsViewModel,
                    ImportantNoteViewModel
                });
        }


        #endregion

        #region Navigating ViewModels

        /// <summary>
        /// Navigating to Rank View Model.
        /// </summary>
        private void RankNavigation() { Navigate(CarRanksViewModel); }

        /// <summary>
        /// Navigating to Performance View Models.
        /// </summary>
        private void PerformanceNavigation(IPageService viewModel) { Navigate(viewModel); }

        /// <summary>
        /// Navigating to Available Cars View Model.
        /// </summary>
        private void CarNavigation() { Navigate(CarsPageViewModel); }

        /// <summary>
        /// Navigating to Blueprints View Model.
        /// </summary>
        private void BlueprintNavigation() { Navigate(BlueprintsPageViewModel); }

        /// <summary>
        /// Navigating to Career Chapters View Model.
        /// </summary>
        private void CareerNavigation() { Navigate(CareerViewModel); }

        /// <summary>
        /// Navigating to Route View Model.
        /// </summary>
        private void RouteNavigation() { Navigate(RouteTracksViewModel); }

        /// <summary>
        /// Navigating to Misc View Models.
        /// </summary>
        private void MiscNavigation(IPageService viewModel) { Navigate(viewModel); }

        /// <summary>
        /// Navigating to Introduction View Models.
        /// </summary>
        private void IntroductionNavigation(IPageService viewModel) { Navigate(viewModel); }

        /// <summary>
        /// Navigating to About View Models.
        /// </summary>
        private void AboutNavigation(IPageService viewModel) { Navigate(viewModel); }

        #endregion

        #region ViewModel Properties

        #region About View Models

        /// <summary>
        /// About ViewModel Property.
        /// </summary>
        public AboutViewModel AboutViewModel
        {
            get => _aboutViewModel;
            set
            {
                _aboutViewModel = value;
                RaisePropertyChanged(nameof(AboutViewModel));
            }
        }

        /// <summary>
        /// Credits ViewModel Property.
        /// </summary>
        public CreditsViewModel CreditsViewModel
        {
            get => _creditsViewModel;
            set
            {
                _creditsViewModel = value;
                RaisePropertyChanged(nameof(CreditsViewModel));
            }
        }

        #endregion

        #region Introduction View Models

        /// <summary>
        /// Tips ViewModel Property.
        /// </summary>
        public TipsViewModel TipsViewModel
        {
            get => _tipsViewModel;
            set
            {
                _tipsViewModel = value;
                RaisePropertyChanged(nameof(TipsViewModel));
            }
        }

        /// <summary>
        /// How To ViewModel Property.
        /// </summary>
        public HowToViewModel HowToViewModel
        {
            get => _howToViewModel;
            set
            {
                _howToViewModel = value;
                RaisePropertyChanged(nameof(HowToViewModel));
            }
        }

        /// <summary>
        /// Currencies ViewModel Property.
        /// </summary>
        public CurrenciesViewModel CurrenciesViewModel
        {
            get => _currenciesViewModel;
            set
            {
                _currenciesViewModel = value;
                RaisePropertyChanged(nameof(CurrenciesViewModel));
            }
        }

        /// <summary>
        /// GamePlay ViewModel Property.
        /// </summary>
        public GamePlayViewModel GamePlayViewModel
        {
            get => _gamePlayViewModel;
            set
            {
                _gamePlayViewModel = value;
                RaisePropertyChanged(nameof(GamePlayViewModel));
            }
        }

        /// <summary>
        /// Introduction ViewModel Property.
        /// </summary>
        public IntroductionViewModel IntroductionViewModel
        {
            get => _introductionViewModel;
            set
            {
                _introductionViewModel = value;
                RaisePropertyChanged(nameof(IntroductionViewModel));
            }
        }

        #endregion

        #region Career Chapters View Models

        /// <summary>
        /// Career Chapters ViewModel Property.
        /// </summary> 
        public CareerViewModel CareerViewModel
        {
            get => _careerViewModel;
            set
            {
                _careerViewModel = value;
                RaisePropertyChanged(nameof(CareerViewModel));
            }
        }

        #endregion

        #region Misc View Models

        /// <summary>
        /// Important Note ViewModel Property.
        /// </summary>
        public ImportantNoteViewModel ImportantNoteViewModel
        {
            get => _importantViewModel;
            set
            {
                _importantViewModel = value;
                RaisePropertyChanged(nameof(ImportantNoteViewModel));
            }
        }

        /// <summary>
        /// Add New Car ViewModel Property.
        /// </summary>
        public AddNewViewModel AddNewCarViewModel
        {
            get => _addNewCarViewModel;
            set
            {
                _addNewCarViewModel = value;
                RaisePropertyChanged(nameof(AddNewCarViewModel));
            }
        }

        /// <summary>
        /// Delete Car ViewModel Property.
        /// </summary>
        public DeleteCarViewModel DeleteCarViewModel
        {
            get => _deleteCarViewModel;
            set
            {
                _deleteCarViewModel = value;
                RaisePropertyChanged(nameof(DeleteCarViewModel));
            }
        }

        /// <summary>
        /// Update Car ViewModel Property.
        /// </summary>
        public UpdateCarViewModel UpdateCarViewModel
        {
            get => _updateCarViewModel;
            set
            {
                _updateCarViewModel = value;
                RaisePropertyChanged(nameof(UpdateCarViewModel));
            }
        }

        /// <summary>
        /// Max Comparison ViewModel Property.
        /// </summary>
        public MaxComparisonViewModel MaxComparisonViewModel
        {
            get => _maxComparisonViewModel;
            set
            {
                _maxComparisonViewModel = value;
                RaisePropertyChanged(nameof(MaxComparisonViewModel));
            }
        }

        /// <summary>
        /// Stock Comparison ViewModel Property.
        /// </summary>
        public StockComparisonViewModel StockComparisonViewModel
        {
            get => _stockComparisonViewModel;
            set
            {
                _stockComparisonViewModel = value;
                RaisePropertyChanged(nameof(StockComparisonViewModel));
            }
        }

        /// <summary>
        /// Rank Comparison ViewModel Property.
        /// </summary>
        public RankComparisonViewModel RankComparisonViewModel
        {
            get => _rankComparisonViewModel;
            set
            {
                _rankComparisonViewModel = value;
                RaisePropertyChanged(nameof(RankComparisonViewModel));
            }
        }

        /// <summary>
        /// Blueprints Comparison ViewModel Property.
        /// </summary>
        public BlueprintsComparisonViewModel BlueprintsComparisonViewModel
        {
            get => _blueprintsComparisonViewModel;
            set
            {
                _blueprintsComparisonViewModel = value;
                RaisePropertyChanged(nameof(BlueprintsComparisonViewModel));
            }
        }

        #endregion

        #region Blueprints View Models

        /// <summary>
        /// Blueprints ViewModel Property.
        /// </summary>
        public BlueprintsViewModel BlueprintsPageViewModel
        {
            get => _blueprintsPageViewModel;
            set
            {
                _blueprintsPageViewModel = value;
                RaisePropertyChanged(nameof(BlueprintsPageViewModel));
            }
        }

        #endregion

        #region Routes View Models

        /// <summary>
        /// Routes ViewModel Property.
        /// </summary>
        public TracksViewModel RouteTracksViewModel
        {
            get => _routeTracksViewModel;
            set
            {
                _routeTracksViewModel = value;
                RaisePropertyChanged(nameof(RouteTracksViewModel));
            }
        }

        #endregion

        #region Available Cars View Models

        /// <summary>
        /// Cars ViewModel Property.
        /// </summary>
        public CarsPageViewModel CarsPageViewModel
        {
            get => _carsPageViewModel;
            set
            {
                _carsPageViewModel = value;
                RaisePropertyChanged(nameof(CarsPageViewModel));
            }
        }

        #endregion

        #region Performance

        /// <summary>
        /// Stock Performance ViewModel Property.
        /// </summary>
        public StockPerformanceViewModel StockPerformanceViewModel
        {
            get => _stockPerformanceViewModel;
            set
            {
                _stockPerformanceViewModel = value;
                RaisePropertyChanged(nameof(StockPerformanceViewModel));
            }
        }

        /// <summary>
        /// Max Performance ViewModel Property.
        /// </summary>
        public MaxPerformanceViewModel MaxPerformanceViewModel
        {
            get => _maxPerformanceViewModel;
            set
            {
                _maxPerformanceViewModel = value;
                RaisePropertyChanged(nameof(MaxPerformanceViewModel));
            }
        }

        #endregion

        #region Ranks View Models

        /// <summary>
        /// Ranks ViewModel Property.
        /// </summary>
        public StarRanksViewModel CarRanksViewModel
        {
            get => _carRanksViewModel;
            set
            {
                _carRanksViewModel = value;
                RaisePropertyChanged(nameof(CarRanksViewModel));
            }
        }

        #endregion

        #endregion

        #endregion

        #region Collections

        #region Declarations

        public ObservableCollection<CarCardViewModel> CardList { get; set; }

        public ObservableCollection<Car> CarList { get; set; }

        #endregion

        #region Initialize Collections

        /// <summary>
        /// Initializing Observable Collections.
        /// </summary>
        private void InitializeObservableCollections()
        {
            CardList = new ObservableCollection<CarCardViewModel>();
            CarList = new ObservableCollection<Car>();
        }

        #endregion

        #endregion

        #region Commands

        #region Declarations

        public RelayCommand ShowAboutCommand { get; private set; }

        public RelayCommand ShowIntroductionCommand { get; private set; }

        public RelayCommand ShowChaptersCommand { get; private set; }

        public RelayCommand CloseApplicationCommand { get; private set; }

        public RelayCommand MinimizeApplicationCommand { get; private set; }

        public RelayCommand CollectCarsCommand { get; private set; }

        public RelayCommand CollectBlueprintsCommand { get; private set; }

        public RelayCommand CollectPerformanceStatsCommand { get; private set; }

        public RelayCommand ProvideRanksCommand { get; private set; }

        public RelayCommand ProvideRoutesCommand { get; private set; }

        public RelayCommand ExportDatabaseCommand { get; private set; }

        public RelayCommand ShowMiscCommand { get; private set; }

        #endregion

        #region InitializeCommands

        /// <summary>
        /// Initializing Commands
        /// </summary>
        private void InitializeCommands()
        {
            ShowMiscCommand = new RelayCommand(MiscNavigationRequest, CanProvideMisc);

            ShowAboutCommand = new RelayCommand(AboutNavigationRequest);

            ShowChaptersCommand = new RelayCommand(CareerNavigationRequest, CanProvideChapters);

            ShowIntroductionCommand = new RelayCommand(IntroductionNavigationRequest);

            CloseApplicationCommand = new RelayCommand(CloseApplication);

            MinimizeApplicationCommand = new RelayCommand(MinimizeApplication);

            CollectCarsCommand = new RelayCommand(AvailableCarsNavigationRequest, CanProvideAvailableCars);

            CollectBlueprintsCommand = new RelayCommand(BlueprintsNavigationRequest, CanProvideBlueprints);

            CollectPerformanceStatsCommand = new RelayCommand(PerformanceNavigationRequest, CanProvidePerformanceStats);

            ProvideRanksCommand = new RelayCommand(RanksNavigationRequest, CanProvideRanks);

            ProvideRoutesCommand = new RelayCommand(RoutesNavigationRequest, CanProvideRoutes);

            ExportDatabaseCommand = new RelayCommand(ExportDatabaseScriptRequest);
        }


        #endregion

        #endregion

        #region Execution

        #region Can Navigate

        /// <summary>
        /// Indicates whether the misc section is navigable.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>True if misc section can be navigated, False if not.</returns>
        private static bool CanProvideMisc(object sender)
        { return (sender != null) && sender.ToString().ToLower().Contains("misc"); }

        /// <summary>
        /// Indicates whether the career chapters section is navigable.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>True if career chapters section can be navigated, False if not.</returns>
        private static bool CanProvideChapters(object sender)
        { return (sender != null) && sender.ToString().ToLower().Contains("chapters"); }

        /// <summary>
        /// Indicates whether the rank section is navigable.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>True if rank section can be navigated, False if not.</returns>
        private static bool CanProvideRanks(object sender)
        { return (sender != null) && sender.ToString().ToLower().Contains("ranks"); }

        /// <summary>
        /// Indicates whether the available cars section is navigable.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>True if available cars section can be navigated, False if not.</returns>
        private static bool CanProvideAvailableCars(object sender)
        { return (sender != null) && sender.ToString().ToLower().Contains("cars"); }

        /// <summary>
        /// Indicates whether the blueprints section is navigable.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>True if blueprints section can be navigated, False if not.</returns>
        private static bool CanProvideBlueprints(object sender)
        { return (sender != null) && sender.ToString().ToLower().Contains("blueprints"); }

        /// <summary>
        /// Indicates whether the routes section is navigable.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>True if routes section can be navigated, False if not.</returns>
        private static bool CanProvideRoutes(object sender)
        { return (sender != null) && sender.ToString().ToLower().Contains("route"); }

        /// <summary>
        /// Indicates whether the performance section is navigable.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>True if performance section can be navigated, False if not.</returns>
        private static bool CanProvidePerformanceStats(object sender)
        { return (sender != null) && sender.ToString().ToLower().Contains("performance"); }

        #endregion

        #region Navigation Requests From UI

        /// <summary>
        /// The Request for navigating of misc pages from the user.
        /// </summary>
        /// <param name="sender">This is the 'TAG' property we received from the UI.</param>
        private void MiscNavigationRequest(object sender)
        {
            var receivedParameter = sender.ToString();

            var miscType = receivedParameter.Split('|')[0];

            var compareType = (receivedParameter.Split('|')[2] != "None") ? receivedParameter.Split('|')[2] : null;

            Task.Factory.StartNew(() => MiscellaneousNavigationRequest(miscType, compareType)).Wait();
        }

        /// <summary>
        /// The Request for exporting the database script from the user.
        /// </summary>
        /// <param name="sender"></param>
        public void ExportDatabaseScriptRequest(object sender)
        {
            Task.Factory.StartNew(GenerateScriptAsync).Wait();
        }

        /// <summary>
        /// The Request for navigating of blueprints from the user.
        /// </summary>
        /// <param name="sender">This is the 'TAG' property we received from the UI.</param>
        public void BlueprintsNavigationRequest(object sender)
        {
            var receivedParameter = sender.ToString();

            var blueprintClass = receivedParameter.Split('|')[0];

            var isClass = blueprintClass.ToLower() != "all";

            Task.Factory.StartNew(() => AddBlueprintsAsync(blueprintClass, isClass)).Wait();
        }

        /// <summary>
        /// The Request for navigating of introduction pages from the user.
        /// </summary>
        /// <param name="sender">This is the 'TAG' property we received from the UI.</param>
        public void IntroductionNavigationRequest(object sender)
        {
            var receivedParameter = sender.ToString();
            var part = receivedParameter.Split('|')[0];
            Task.Factory.StartNew(() => ShowIntroductionViewModels(part.ToLower())).Wait();
        }

        /// <summary>
        /// The Request for navigating of about pages from the user.
        /// </summary>
        /// <param name="sender">This is the 'TAG' property we received from the UI.</param>
        public void AboutNavigationRequest(object sender)
        {
            var receivedParameter = sender.ToString();
            var part = receivedParameter.Split('|')[0];
            Task.Factory.StartNew(() => ShowAboutViewModels(part.ToLower())).Wait();
        }

        /// <summary>
        /// The Request for navigating of career chapters pages from the user.
        /// </summary>
        /// <param name="sender">This is the 'TAG' property we received from the UI.</param>
        public void CareerNavigationRequest(object sender)
        {
            var receivedParameter = sender.ToString();

            var chapter = receivedParameter.Split('|')[0];

            var isChapter = chapter.ToLower() != "all";

            Task.Factory.StartNew(() => AddChaptersAsync(chapter, isChapter)).Wait();
        }

        /// <summary>
        /// The Request for navigating of routes from the user.
        /// </summary>
        /// <param name="sender"></param>
        public void RoutesNavigationRequest(object sender)
        {
            var receivedParameter = sender.ToString();
            var str = receivedParameter.Split('|')[0];

            Task.Factory.StartNew(() => AddRoutesAsync(str)).Wait();
        }

        /// <summary>
        /// The Request for navigating of performance from the user.
        /// </summary>
        /// <param name="sender">This is the 'TAG' property we received from the UI.</param>
        public void PerformanceNavigationRequest(object sender)
        {
            var receivedParameter = sender.ToString();

            var str = receivedParameter.Split('|');

            var @class = str[0];

            var @type = str[1];

            var isClass = @class.ToLower() != "all";

            Task.Factory.StartNew(() => AddingPerformanceStatsAsync(@class, type, isClass)).Wait();
        }

        /// <summary>
        /// The Request for navigating of ranks from the user.
        /// </summary>
        /// <param name="sender"></param>
        public void RanksNavigationRequest(object sender)
        {
            var receivedParameter = sender.ToString();
            var str = receivedParameter.Split('|')[0];
            var isClass = str.ToLower() != "all";
            Task.Factory.StartNew(() => AddingRanksAsync(str, isClass)).Wait();
        }

        /// <summary>
        /// The Request for navigating of available cars from the user.
        /// </summary>
        /// <param name="sender"></param>
        public void AvailableCarsNavigationRequest(object sender)
        {
            var receivedParameter = sender.ToString();

            var carClass = receivedParameter.Split('|')[0];

            var isClass = carClass.ToLower() != "all";

            var dispatcher = Dispatcher.CurrentDispatcher;

            if (Application.Current != null)
            {
                // use the application dispatcher if running from the software
                dispatcher = Application.Current.Dispatcher;
            }

            // delegate the operation to UI thread.
            dispatcher?.BeginInvoke(DispatcherPriority.Send,
                                    new Action(async () => await AddClassCarsAsync(carClass, isClass)));
        }

        #endregion

        #endregion

        #region IPage Implementations

        private IPageService _currentViewModel;

        /// <summary>
        /// List of recorded view models.
        /// </summary>
        public List<IPageService> ViewModelList { get; set; }

        /// <summary>
        /// Current view model.
        /// </summary>
        public IPageService CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                RaisePropertyChanged(nameof(CurrentViewModel));
            }
        }

        /// <summary>
        /// Navigating to specific view model.
        /// </summary>
        /// <param name="viewModel">View model to navigate.</param>
        private void Navigate(IPageService viewModel)
        { CurrentViewModel = ViewModelList.FirstOrDefault(vm => vm == viewModel); }
        #endregion
    }
}