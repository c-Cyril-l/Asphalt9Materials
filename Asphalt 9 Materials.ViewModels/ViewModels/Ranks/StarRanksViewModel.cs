﻿using Asphalt_9_Materials.Core;
using Asphalt_9_Materials.ViewModel.Services.Interfaces;
using Helpers.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Asphalt_9_Materials.ViewModel.ViewModels.Ranks
{
    public class StarRanksViewModel : ObservableObject, IPageService
    {

        #region Constructor

        public StarRanksViewModel()
        {
            // Initializing car instance.
            _car = new Car();

            // Initializing car list.
            CarCollection = new ObservableCollection<Car>();
        }

        #endregion

        #region IPage Implementation

        public string Name => string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Selected car from dataGrid.
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
        /// Collection of available cars.
        /// </summary>
        public ObservableCollection<Car> CarCollection { get; set; }

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

        #endregion

        #region Declarations

        private Car _car;

        private Brush _foreground;


        #endregion

    }
}
