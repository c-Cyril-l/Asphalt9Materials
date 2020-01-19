using Asphalt_9_Materials.Core;
using Asphalt_9_Materials.ViewModel.Entities;
using Asphalt_9_Materials.ViewModel.Helpers;
using Asphalt_9_Materials.ViewModel.Services;
using Asphalt_9_Materials.ViewModel.Services.Interfaces;
using Helpers.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Asphalt_9_Materials.ViewModel.ViewModels.Misc
{
    public class DeleteCarViewModel : ObservableObject, IPageService
    {

        #region Constructor

        public DeleteCarViewModel()
        {
            // Initializing commands.
            InitializeCommands();

            // Initializing car instance.
            _car = new Car();

            // Initializing car list.
            CarCollection = new ObservableCollection<Car>();

            // Initializing windows dialog service.
            _windowsDialogService = new WindowsDialogService();
        }


        #endregion

        #region IPage Implementation

        public string Name => string.Empty;

        #endregion

        #region Commands

        #region Declarations

        public RelayCommand DeleteCarCommand { get; private set; }

        #endregion

        #region Initialize Commands

        /// <summary>
        /// Initialize relay commands.
        /// </summary>
        private void InitializeCommands()
        {
            DeleteCarCommand = new RelayCommand(DeletingCar, CanSubmit);
        }

        #endregion

        #endregion

        #region Declaration

        private readonly WindowsDialogService _windowsDialogService;

        private Car _car;

        private string _status;

        private Brush _foreground;

        private Brush _statusColor;

        #endregion

        #region Methods

        /// <summary>
        /// Check whether the requested car can be deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private bool CanSubmit(object sender)
        {
            using (var a9 = new Asphalt9Entities())
            {
                var carToDelete =
                    a9.Grandes
                    .FirstOrDefault(item => string.Concat(item.Brand, " ", item.CarName)
                    .Equals(Car.FullName));

                return carToDelete != null;
            }
        }

        /// <summary>
        /// A Method to delete the car asynchronously.
        /// </summary>
        /// <returns></returns>
        private async Task DeleteCarAsync()
        {
            using (var a9 = new Asphalt9Entities())
            {
                using (var transaction = a9.Database.BeginTransaction())
                {

                    try
                    {
                        // Finding the requested car from entities.
                        var carToDelete = a9.Grandes
                            .FirstOrDefault(item => string.Concat(item.Brand, " ", item.CarName).Equals(Car.FullName));

                        var imgName = carToDelete?.CarImage;

                        if (carToDelete != null)
                        {
                            // Deleting the car asynchronously.
                            await DeleteCarAsync(a9, carToDelete, transaction);

                            // Removing the car from car collection as well as empty the car property.
                            var currentDispatcher = Application.Current.Dispatcher;
                            currentDispatcher?.Invoke(() =>
                            {
                                if (Car == null) return;
                                CarCollection.Remove(Car);

                                _car = new Car();
                                RaisePropertyChanged(nameof(Car));
                            });

                            // Notifying that the operation succeeded.
                            Status = $"{carToDelete.Brand} {carToDelete.CarName} Has Been Deleted Successfully.";

                            // Avoiding "The Image used by another process" warning issue.
                            // Not good practice but anyway.
                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            // Deleting the car image from app images directory.
                            if (FileHelpers.IsImageExist(imgName))
                                File.Delete(FileHelpers.ImagePath(imgName));
                        }
                    }
                    catch
                    {
                        // Rolling back adding the car in case an error occurred.
                        transaction.Rollback();
                        Status = @"Error occurred while deleting the car!";
                    }

                }
            }

        }

        /// <summary>
        /// Removing the car from database.
        /// </summary>
        /// <param name="a9">Asphalt9Entities</param>
        /// <param name="carToDelete">Car to delete.</param>
        /// <param name="transaction">Transaction.</param>
        /// <returns></returns>
        private async Task DeleteCarAsync(Asphalt9Entities a9, Grande carToDelete, DbContextTransaction transaction)
        {
            await Task.Run(() =>
            {
                // Removing the entity related to the requested car to delete.
                a9.Grandes.Remove(carToDelete);

                // saving changes.
                a9.SaveChanges();

                // committing the saved changes into the database.
                transaction.Commit();

            });

        }

        /// <summary>
        /// A Method to execute delete the car asynchronously. 
        /// </summary>
        /// <param name="sender"></param>
        private void DeletingCar(object sender)
        {
            Task.Factory.StartNew(DeleteCarAsync).Wait();
        }

        /// <summary>
        /// Method to show whether the delete operation is succeeded.
        /// </summary>
        private void NotifyCurrentStatus()
        {
            if (!string.IsNullOrEmpty(Status))
                _windowsDialogService.ShowMessageBox(Status,
                                               "Deleting Car",
                                               MessageBoxButton.OK,
                                               Status.ToLower().Contains("error") ? MessageBoxImage.Warning :
                                               MessageBoxImage.Information);
        }


        #endregion

        #region Properties

        /// <summary>
        /// Car to delete
        /// </summary>
        public Car Car
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
                    default:
                        Foreground = Brushes.Gray;
                        break;
                }

                RaisePropertyChanged(nameof(Car));

                RaisePropertyChanged(nameof(Foreground));

            }
        }


        /// <summary>
        /// Status for delete operation.
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
        /// Car type foreground
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
        /// Collection of available cars.
        /// </summary>
        public ObservableCollection<Car> CarCollection { get; set; }

        #endregion

    }
}
